using BlogApp.Contract.Models;

namespace BlogApp.Contract.Response.Posts
{
    public class GetPostResponse : ResponseBase
    {
        public PostModel Post { get; set; }
    }
}