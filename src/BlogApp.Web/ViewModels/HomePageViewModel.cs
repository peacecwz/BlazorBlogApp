using System.Collections.Generic;
using BlogApp.Contract.Models;

namespace BlogApp.Web.ViewModels
{
    public class HomePageViewModel
    {
        public List<PostModel> Posts { get; set; } = new List<PostModel>();
        public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
    }
}