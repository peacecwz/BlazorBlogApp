namespace BlogApp.Contract.Request.Categories
{
    public class DeleteCategoryRequest : RequestBase
    {
        public int CategoryId { get; set; }
    }
}