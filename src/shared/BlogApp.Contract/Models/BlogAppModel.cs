using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Contract.Models
{
    public class BlogAppModel
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Logo { get; set; }
        public AuthorModel Author { get; set; }
    }
}
