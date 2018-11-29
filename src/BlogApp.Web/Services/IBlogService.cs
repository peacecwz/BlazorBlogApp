using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogApp.Contract.Models;
using BlogApp.Contract.Request.Categories;
using BlogApp.Contract.Request.Posts;
using BlogApp.Contract.Response.Categories;
using BlogApp.Contract.Response.Posts;
using BlogApp.Web.Infrastructure;
using BlogApp.Web.ViewModels;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace BlogApp.Web.Services
{
    public interface IBlogService
    {
        Task<List<CategoryModel>> GetCategoriesAsync();
        Task<HomePageViewModel> GetHomePageAsync();
    }

    public class BlogService : IBlogService
    {
        private readonly IBlogAppConfiguration _blogAppConfiguration;
        public BlogService(IBlogAppConfiguration blogAppConfiguration)
        {
            _blogAppConfiguration = blogAppConfiguration;
        }

        public async Task<List<CategoryModel>> GetCategoriesAsync()
        {
            try
            {
                var request = new GetCategoriesRequest();
                var response = await _blogAppConfiguration.BlogAppApiUrl
                    .AppendPathSegment("/posts")
                    .SetQueryParams(request)
                    .GetJsonAsync<GetCategoriesResponse>();

                if (response.IsSuccess)
                {
                    return response.Categories;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred. {ex.Message} StackTrace: {ex.StackTrace}");
            }

            return new List<CategoryModel>();
        }

        public async Task<HomePageViewModel> GetHomePageAsync()
        {
            var viewModel = new HomePageViewModel();
            try
            {
                var request = new GetPostsRequest()
                {
                    IsFeaturePosts = true
                };
                var postsResponse = await _blogAppConfiguration.BlogAppApiUrl
                    .AppendPathSegment("/posts")
                    .SetQueryParams(request)
                    .GetJsonAsync<GetPostsResponse>();

                if (postsResponse.IsSuccess)
                {
                    viewModel.Posts = postsResponse.Posts;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}, StackTrace: {ex.StackTrace}");
            }

            try
            {
                var request = new GetCategoriesRequest();
                var categoriesResponse = await _blogAppConfiguration.BlogAppApiUrl
                    .AppendPathSegment("/categories")
                    .SetQueryParams(request)
                    .GetJsonAsync<GetCategoriesResponse>();
                if (categoriesResponse.IsSuccess)
                {
                    viewModel.Categories = categoriesResponse.Categories;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}, StackTrace: {e.StackTrace}");
            }

            return viewModel;
        }
    }

    public class BlogAppConfiguration
    {
    }
}