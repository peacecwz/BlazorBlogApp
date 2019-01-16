using System.Collections.Generic;
using System.Threading.Tasks;
using BlogApp.Contract.Models;

namespace BlogApp.Web.Services
{
    public interface IBlogService
    {
        Task<List<PostModel>> GetPostsAsync();
        Task<BlogAppModel> GetBlogConfigurationAsync();
        Task<PostModel> GetPostAsync(string slug);
        Task<List<CategoryModel>> GetSpotlightCategoriesAsync();
        Task<CategoryModel> GetCategoryAsync(string slug);
    }
}