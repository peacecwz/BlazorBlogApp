using System.Collections.Generic;

namespace BlogApp.Contract.Models
{
    public class AuthorModel
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string About { get; set; }
        public Dictionary<string, string> SocialMedias { get; set; }
    }
}