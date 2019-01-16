using System.Threading.Tasks;
using BlogApp.API.Common;
using BlogApp.API.Services;
using BlogApp.Contract.Request.Categories;
using BlogApp.Contract.Response.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ApiControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        // GET api/categories
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync([FromQuery]GetCategoriesRequest request)
        {
            GetCategoriesResponse response = await _categoriesService.GetCategoriesAsync(request);

            return GenerateResponse(response);
        }

        // GET api/categories/5
        [HttpGet("{slug}")]
        public async Task<IActionResult> GetCategoryAsync([FromRoute]string slug)
        {
            var request = new GetCategoryRequest();

            if (int.TryParse(slug, out int categoryId))
            {
                request.CategoryId = categoryId;
            }
            else
            {
                request.Slug = slug;
            }

            GetCategoryResponse response = await _categoriesService.GetCategoryAsync(request);

            return GenerateResponse(response);
        }

        // POST api/categories
        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryRequest request)
        {
            CreateCategoryResponse response = await _categoriesService.CreateCategoryAsync(request);

            return GenerateResponse(response);
        }

        // PUT api/categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryAsyncTask(int id, [FromBody] UpdateCategoryRequest request)
        {
            request.CategoryId = id;
            UpdateCategoryResponse response = await _categoriesService.UpdateCategoryAsync(request);

            return GenerateResponse(response);
        }

        // DELETE api/categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var request = new DeleteCategoryRequest()
            {
                CategoryId = id
            };

            DeleteCategoryResponse response = await _categoriesService.DeleteCategoryAsync(request);

            return GenerateResponse(response);
        }
    }
}
