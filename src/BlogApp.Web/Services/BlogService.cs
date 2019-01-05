using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlogApp.Contract.Models;
using BlogApp.Contract.Request.Categories;
using BlogApp.Contract.Request.Posts;
using BlogApp.Contract.Response.Categories;
using BlogApp.Contract.Response.Posts;
using BlogApp.Web.Extensions;
using BlogApp.Web.Infrastructure;
using BlogApp.Web.ViewModels;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Http;
using Newtonsoft.Json;

namespace BlogApp.Web.Services
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient _client;
        private readonly IBlogAppConfiguration _blogAppConfiguration;

        public BlogService(IBlogAppConfiguration blogAppConfiguration)
        {
            _blogAppConfiguration = blogAppConfiguration;
            _client = new HttpClient()
            {
                BaseAddress = new Uri(_blogAppConfiguration.BlogAppApiUrl)
            };
        }

        public async Task<List<CategoryModel>> GetSpotlightCategoriesAsync()
        {
            try
            {
                var request = new GetCategoriesRequest()
                {
                    IsSpotlight = true
                };

                var response = await _client.GetAsync("/api/categories".WithQueryParams(request));
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAs<GetCategoriesResponse>();
                    return result.Categories;
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
                var postsResponse = await _client.GetAsync("/api/posts".WithQueryParams(request));
                if (postsResponse.IsSuccessStatusCode)
                {
                    var result = await postsResponse.Content.ReadAs<GetPostsResponse>();
                    viewModel.Posts = result.Posts;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}, StackTrace: {ex.StackTrace}");
            }

            try
            {
                var request = new GetCategoriesRequest();
                var categoriesResponse = await _client.GetAsync("/api/categories".WithQueryParams(request));

                if (categoriesResponse.IsSuccessStatusCode)
                {
                    var result = await categoriesResponse.Content.ReadAs<GetCategoriesResponse>();
                    viewModel.Categories = result.Categories;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}, StackTrace: {e.StackTrace}");
            }

            return viewModel;
        }
    }
}