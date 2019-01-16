using System.Collections.Generic;

namespace BlogApp.Contract.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSpotlight { get; set; }
        public List<PostModel> Posts { get; set; }
        public string Slug { get; set; }
    }
}