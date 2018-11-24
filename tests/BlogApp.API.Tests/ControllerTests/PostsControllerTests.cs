using BlogApp.API.Controllers;
using BlogApp.API.Services;
using Moq;

namespace BlogApp.API.Tests.ControllerTests
{
    public class PostsControllerTests : TestBase
    {
        private readonly PostsController _postsController;
        private readonly Mock<IPostsService> _postsService;
        public PostsControllerTests()
        {
            _postsService = new Mock<IPostsService>();
            _postsController = new PostsController(_postsService.Object);
        }
    }
}