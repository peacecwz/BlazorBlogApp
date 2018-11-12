namespace BlogApp.Contract.Request.Posts
{
    public class GetPostRequest : RequestBase
    {
        public string Slug { get; set; }
    }
}