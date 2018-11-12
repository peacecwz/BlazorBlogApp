using System.Collections.Generic;
using BlogApp.Contract.Models;

namespace BlogApp.Contract.Response.Categories
{
    public class GetCategoriesResponse : ResponseBase
    {
        public List<CategoryModel> Categories { get; set; }
    }
}