using System.Collections.Generic;
using BlogApp.Contract.Models;

namespace BlogApp.Contract.Response.Posts
{
    public class GetPostsResponse : ResponseBase
    {
        public List<PostModel> Posts { get; set; }
    }
}