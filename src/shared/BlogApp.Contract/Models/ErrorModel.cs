using System.Collections.Generic;

namespace BlogApp.Contract.Models
{
    public class ErrorModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ErrorModel> SubErrors { get; set; } = new List<ErrorModel>();
    }
}