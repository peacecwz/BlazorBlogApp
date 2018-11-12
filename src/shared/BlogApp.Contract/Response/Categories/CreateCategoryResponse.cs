using BlogApp.Contract.Models;

namespace BlogApp.Contract.Response.Categories
{
    public class CreateCategoryResponse : ResponseBase
    {
        public CategoryModel Category { get; set; }
    }
}