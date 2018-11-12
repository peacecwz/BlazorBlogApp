using System;

namespace BlogApp.Contract.Request.Posts
{
    public class DeletePostRequest : RequestBase
    {
        public Guid PostId { get; set; }
    }
}