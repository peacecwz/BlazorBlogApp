using BlogApp.Contract.Models;

namespace BlogApp.Contract.Request.Categories
{
    public class CreateCategoryRequest : RequestBase
    {
        public CategoryModel Category { get; set; }
    }
}