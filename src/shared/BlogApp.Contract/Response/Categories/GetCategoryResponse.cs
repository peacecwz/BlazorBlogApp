using BlogApp.Contract.Models;

namespace BlogApp.Contract.Response.Categories
{
    public class GetCategoryResponse : ResponseBase
    {
        public CategoryModel Category { get; set; }
    }
}