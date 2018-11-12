using BlogApp.Contract.Models;

namespace BlogApp.Contract.Response.Categories
{
    public class UpdateCategoryResponse : ResponseBase
    {
        public CategoryModel Category { get; set; }
    }
}