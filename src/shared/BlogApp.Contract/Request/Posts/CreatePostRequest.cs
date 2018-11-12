using BlogApp.Contract.Models;

namespace BlogApp.Contract.Request.Posts
{
    public class CreatePostRequest : RequestBase
    {
        public PostModel Post { get; set; }
    }
}