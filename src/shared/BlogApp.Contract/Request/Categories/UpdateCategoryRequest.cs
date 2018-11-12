using BlogApp.Contract.Models;

namespace BlogApp.Contract.Request.Categories
{
    public class UpdateCategoryRequest : RequestBase
    {
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}