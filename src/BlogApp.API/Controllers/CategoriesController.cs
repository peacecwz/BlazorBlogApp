using System.Threading.Tasks;
using BlogApp.API.Common;
using BlogApp.API.Services;
using BlogApp.Contract.Request.Categories;
using BlogApp.Contract.Response.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync(GetCategoriesRequest request)
        {
            GetCategoriesResponse response = await _categoriesService.GetCategoriesAsync(request);

            return GenerateResponse(response);
        }

        // GET api/categories/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryAsync(int id)
        {
            var request = new GetCategoryRequest()
            {
                CategoryId = id
            };

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
