﻿namespace BlogApp.Contract.Request.Posts
{
    public class GetPostsRequest : RequestBase
    {
        public bool IsFeaturePosts { get; set; }
        public int PageIndex { get; set; } = 0;
        public int ItemCountPerPage { get; set; } = 20;
    }
}