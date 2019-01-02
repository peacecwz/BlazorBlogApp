using System;
using System.Threading.Tasks;
using BlogApp.API.Common;
using BlogApp.API.Services;
using BlogApp.Contract.Request.Posts;
using BlogApp.Contract.Response.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Authorize]
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ApiControllerBase
    {
        private readonly IPostsService _postsService;
        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        //GET api/posts
        [AllowAnonymous]
        [HttpGet("")]
        public async Task<IActionResult> GetPosts([FromQuery]GetPostsRequest request)
        {
            GetPostsResponse response = await _postsService.GetPostsAsync(request);

            return GenerateResponse(response);
        }

        //GET api/post/slug
        [AllowAnonymous]
        [HttpGet("{slug}")]
        public async Task<IActionResult> GetPosts([FromRoute]string slug, GetPostRequest request)
        {
            GetPostResponse response = await _postsService.GetPostAsync(request);

            return GenerateResponse(response);
        }

        //POST api/posts
        [HttpPost("")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
        {
            CreatePostResponse response = await _postsService.CreatePostAsync(request);

            return GenerateResponse(response);
        }

        // PUT api/posts/{00000-000000000-000000000-000000}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryAsyncTask(Guid id, [FromBody] UpdatePostRequest request)
        {
            request.PostId = id;
            UpdatePostResponse response = await _postsService.UpdatePostAsync(request);

            return GenerateResponse(response);
        }

        // DELETE api/post/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(Guid id)
        {
            var request = new DeletePostRequest()
            {
                PostId = id
            };

            DeletePostResponse response = await _postsService.DeletePostAsync(request);

            return GenerateResponse(response);
        }
    }
}