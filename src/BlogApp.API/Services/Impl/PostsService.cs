using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BlogApp.API.Data.Entities;
using BlogApp.API.Extensions;
using BlogApp.API.Mappers;
using BlogApp.API.Repositories;
using BlogApp.Contract.Request.Posts;
using BlogApp.Contract.Response.Posts;
using Microsoft.Extensions.Logging;

namespace BlogApp.API.Services.Impl
{
    public class PostsService : IPostsService
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostMapper _postMapper;
        private readonly ILogger<PostsService> _logger;
        public PostsService(IPostRepository postRepository, IPostMapper postMapper, ILogger<PostsService> logger)
        {
            _postRepository = postRepository;
            _postMapper = postMapper;
            _logger = logger;
        }

        public void Dispose()
        {
            _postRepository?.Dispose();
        }

        public async Task<GetPostsResponse> GetPostsAsync(GetPostsRequest request)
        {
            var response = new GetPostsResponse();

            var postEntities = await _postRepository.GetPostsAsync(request.PageIndex, request.ItemCountPerPage);
            response.Posts = postEntities.Select(x => _postMapper.ToModel(x)).ToList();

            return response;
        }

        public async Task<GetPostResponse> GetPostAsync(GetPostRequest request)
        {
            var response = new GetPostResponse();

            PostEntity postEntity = null;
            if (Guid.TryParse(request.Slug, out var postId))
            {
                postEntity = await _postRepository.GetPostByIdAsync(postId);
            }
            else
            {
                postEntity = await _postRepository.GetPostBySlugAsync(request.Slug);
            }

            if (postEntity == null)
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
                return response;
            }

            response.Post = _postMapper.ToModel(postEntity);
            return response;
        }

        public async Task<CreatePostResponse> CreatePostAsync(CreatePostRequest request)
        {
            var response = new CreatePostResponse();

            bool isExists = await _postRepository.IsExistsPostByTitleAsync(request.Post.Title.ToLower());
            if (isExists)
            {
                response.StatusCode = (int)HttpStatusCode.Conflict;
                return response;
            }

            var entity = _postMapper.ToEntity(request.Post);
            entity.Slug = request.Post.Title.ToSlug();

            bool isSuccess = await _postRepository.CreatePostAsync(entity);
            if (!isSuccess)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return response;
            }

            response.StatusCode = (int)HttpStatusCode.Created;

            return response;
        }

        public async Task<UpdatePostResponse> UpdatePostAsync(UpdatePostRequest request)
        {
            var response = new UpdatePostResponse();

            var entity = await _postRepository.GetPostByIdAsync(request.PostId);
            if (entity == null)
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
                return response;
            }

            string slug = entity.Slug;
            if (request.Post.Title != entity.Title)
            {
                slug = request.Post.Title.ToSlug();
            }

            entity = _postMapper.ToEntity(request.Post);
            entity.Id = request.PostId;
            entity.Slug = slug;

            bool isSuccess = await _postRepository.UpdatePostAsync(entity);
            if (!isSuccess)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return response;
        }

        public async Task<DeletePostResponse> DeletePostAsync(DeletePostRequest request)
        {
            var response = new DeletePostResponse();

            var entity = await _postRepository.GetPostByIdAsync(request.PostId);
            if (entity == null)
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
                return response;
            }

            bool isSuccess = await _postRepository.DeletePostAsync(entity);
            if (!isSuccess)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return response;
        }
    }
}