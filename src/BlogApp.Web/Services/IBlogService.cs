using System.Threading.Tasks;
using BlogApp.Contract.Response.Posts;
using BlogApp.Web.ViewModels;

namespace BlogApp.Web.Services
{
    public interface IBlogService
    {
        Task<HomePageViewModel> GetHomePageAsync();
    }

    public class BlogService : IBlogService
    {
        
        public Task<HomePageViewModel> GetHomePageAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}