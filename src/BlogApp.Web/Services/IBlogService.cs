using System.Collections.Generic;
using System.Threading.Tasks;
using BlogApp.Contract.Models;
using BlogApp.Web.ViewModels;
using Newtonsoft.Json;

namespace BlogApp.Web.Services
{
    public interface IBlogService
    {
        Task<List<CategoryModel>> GetSpotlightCategoriesAsync();
        Task<HomePageViewModel> GetHomePageAsync();
    }
}