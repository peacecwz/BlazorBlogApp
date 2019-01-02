namespace BlogApp.Contract.Request.Categories
{
    public class GetCategoriesRequest : RequestBase
    {
        public bool IsSpotlight { get; set; }
    }
}