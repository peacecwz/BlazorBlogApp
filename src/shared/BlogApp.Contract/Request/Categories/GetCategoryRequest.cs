﻿namespace BlogApp.Contract.Request.Categories
{
    public class GetCategoryRequest : RequestBase
    {
        public int CategoryId { get; set; }
    }
}