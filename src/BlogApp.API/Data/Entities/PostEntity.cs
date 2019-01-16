using System;
using BlogApp.Contract.Enums;

namespace BlogApp.API.Data.Entities
{
    public class PostEntity : EntityBase<Guid>
    {
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public PostContentType ContentType { get; set; }
        public int CategoryId { get; set; }
        public string Tags { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime? PublishedDate { get; set; }
        public Guid AuthorId { get; set; }
        public bool IsPublished { get; set; }
    }
}