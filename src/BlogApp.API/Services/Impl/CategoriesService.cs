using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BlogApp.API.Data.Entities;
using BlogApp.API.Mappers;
using BlogApp.API.Repositories;
using BlogApp.Contract.Request.Categories;
using BlogApp.Contract.Response.Categories;
using Microsoft.Extensions.Logging;

namespace BlogApp.API.Services.Impl
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPostRepository _postRepository;
        private readonly ICategoryMapper _categoryMapper;
        private readonly IPostMapper _postMapper;
        private readonly ILogger<CategoriesService> _logger;

        public CategoriesService(ICategoryRepository categoryRepository, ICategoryMapper categoryMapper,
            ILogger<CategoriesService> logger, IPostRepository postRepository, IPostMapper postMapper)
        {
            _categoryRepository = categoryRepository;
            _categoryMapper = categoryMapper;
            _logger = logger;
            _postRepository = postRepository;
            _postMapper = postMapper;
        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }

        public async Task<GetCategoriesResponse> GetCategoriesAsync(GetCategoriesRequest request)
        {
            var response = new GetCategoriesResponse();

            IEnumerable<CategoryEntity> entities = null;
            if (request.IsSpotlight)
            {
                entities = await _categoryRepository.GetSpotlightCategoriesAsync();
            }
            else
            {
                entities = await _categoryRepository.GetCategoriesAsync();
            }

            response.Categories = entities.Select(x => _categoryMapper.ToModel(x)).ToList();

            return response;
        }

        public async Task<GetCategoryResponse> GetCategoryAsync(GetCategoryRequest request)
        {
            var response = new GetCategoryResponse();

            CategoryEntity entity = null;

            if (request.CategoryId.HasValue)
            {
                entity = await _categoryRepository.GetCategoryByIdAsync(request.CategoryId.Value);
            }
            else
            {
                entity = await _categoryRepository.GetCategoryBySlugAsync(request.Slug);
            }
            
            if (entity == null)
            {
                response.StatusCode = (int) HttpStatusCode.NotFound;
                return response;
            }

            response.Category = _categoryMapper.ToModel(entity);

            if (request.IncludePosts)
            {

                var postEntities = await _postRepository.GetPostsByCategoryIdAsync(entity.Id);
                if (postEntities == null)
                {
                    _logger.LogWarning($"Not found posts of {entity.Id}-{entity.Name}");
                    return response;
                }

                response.Category.Posts = postEntities.Select(post => _postMapper.ToModel(post)).ToList();
            }

            return response;
        }

        public async Task<CreateCategoryResponse> CreateCategoryAsync(CreateCategoryRequest request)
        {
            var response = new CreateCategoryResponse();

            bool isExists = await _categoryRepository.IsExistCategoryByNameAsync(request.Category.Name);
            if (isExists)
            {
                response.StatusCode = (int) HttpStatusCode.Conflict;
                return response;
            }

            var entity = _categoryMapper.ToEntity(request.Category);
            bool isSuccess = await _categoryRepository.CreateCategoryAsync(entity);

            if (isSuccess)
            {
                response.StatusCode = (int) HttpStatusCode.Created;
                response.Category = _categoryMapper.ToModel(entity);
            }
            else
            {
                response.StatusCode = (int) HttpStatusCode.InternalServerError;
            }

            return response;
        }

        public async Task<UpdateCategoryResponse> UpdateCategoryAsync(UpdateCategoryRequest request)
        {
            var response = new UpdateCategoryResponse();

            var existCategory = await _categoryRepository.GetCategoryByIdAsync(request.CategoryId);
            if (existCategory == null)
            {
                response.StatusCode = (int) HttpStatusCode.InternalServerError;
                return response;
            }

            var entity = _categoryMapper.ToEntity(request.Category);
            entity.Id = existCategory.Id;

            bool isSuccess = await _categoryRepository.UpdateCategoryAsync(entity);
            if (isSuccess)
            {
                response.StatusCode = (int) HttpStatusCode.OK;
                response.Category = _categoryMapper.ToModel(entity);
            }
            else
            {
                response.StatusCode = (int) HttpStatusCode.InternalServerError;
            }

            return response;
        }

        public async Task<DeleteCategoryResponse> DeleteCategoryAsync(DeleteCategoryRequest request)
        {
            var response = new DeleteCategoryResponse();

            var existCategory = await _categoryRepository.GetCategoryByIdAsync(request.CategoryId);
            if (existCategory == null)
            {
                response.StatusCode = (int) HttpStatusCode.NotFound;
                return response;
            }

            bool isSuccess = await _categoryRepository.DeleteCategoryAsync(existCategory);

            response.StatusCode = isSuccess
                ? (int) HttpStatusCode.OK
                : (int) HttpStatusCode.InternalServerError;

            return response;
        }
    }
}