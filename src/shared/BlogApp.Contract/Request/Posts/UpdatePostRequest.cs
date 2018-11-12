using System;
using BlogApp.Contract.Models;

namespace BlogApp.Contract.Request.Posts
{
    public class UpdatePostRequest : RequestBase
    {
        public Guid PostId { get; set; }
        public PostModel Post { get; set; }
    }
}