using System;
using BlogApp.Contract.Enums;

namespace BlogApp.Contract.Models
{
    public class PostModel
    {
        public string Title { get; set; }
        public Guid PostId { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public PostContentType ContentType { get; set; }
        public int CategoryId { get; set; }
        public string Tags { get; set; }
        public string CoverIamgeUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? PublishedDate { get; set; }
        public Guid AuthorId { get; set; }
    }
}