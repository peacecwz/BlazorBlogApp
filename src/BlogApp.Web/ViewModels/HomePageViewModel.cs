using System.Collections.Generic;
using BlogApp.Contract.Models;

namespace BlogApp.Web.ViewModels
{
    public class HomePageViewModel
    {
        public List<PostModel> Posts { get; set; }
        public List<CategoryModel> Categories { get; set; }
    }
}