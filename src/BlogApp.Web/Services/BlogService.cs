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
using Microsoft.JSInterop;

namespace BlogApp.Web.Services
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClient _http;
        public BlogService(HttpClient http, IBlogConfiguration blogConfiguration)
        {
            _http = http;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(blogConfiguration.ApiUrl)
            };
        }

        public async Task<List<PostModel>> GetPostsAsync()
        {
            try
            {
                Console.WriteLine($"Starting {nameof(GetPostsAsync)}");
                var request = new GetPostsRequest();

                var response = await _httpClient.GetAsync("/api/posts".WithQueryParams(request));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAs<GetPostsResponse>();
                    if (content.IsSuccess)
                    {
                        Console.WriteLine($"Ending {nameof(GetPostsAsync)}");
                        return content.Posts ?? new List<PostModel>();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ex Ending {nameof(GetPostsAsync)}");
                Console.WriteLine(e);
            }
            return new List<PostModel>();
        }

        public async Task<BlogAppModel> GetBlogConfigurationAsync()
        {
            try
            {
                Console.WriteLine($"Starting {nameof(GetBlogConfigurationAsync)}");
                var response = await _http.GetAsync("/data/app.json");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Ending {nameof(GetBlogConfigurationAsync)}");
                    return await response.Content.ReadAs<BlogAppModel>();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ex Ending {nameof(GetBlogConfigurationAsync)}");
                Console.WriteLine(e);
            }

            return default(BlogAppModel);
        }

        public Task<PostModel> GetPostAsync(string slug)
        {
            Console.WriteLine($"Starting {nameof(GetPostAsync)}");
            return Task.FromResult(default(PostModel));
        }

        public async Task<List<CategoryModel>> GetSpotlightCategoriesAsync()
        {
            try
            {
                Console.WriteLine($"Starting {nameof(GetSpotlightCategoriesAsync)}");
                var request = new GetCategoriesRequest()
                {
                    IsSpotlight = true
                };
                var response = await _httpClient.GetAsync("/api/categories".WithQueryParams(request));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAs<GetCategoriesResponse>();
                    if (content.IsSuccess)
                    {
                        Console.WriteLine($"Ending {nameof(GetSpotlightCategoriesAsync)}");
                        return content.Categories ?? new List<CategoryModel>();
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ex Ending {nameof(GetSpotlightCategoriesAsync)}");
                Console.WriteLine(e);
                throw;
            }
            return new List<CategoryModel>();
        }

        public async Task<CategoryModel> GetCategoryAsync(string slug)
        {
            try
            {
                Console.WriteLine($"Starting {nameof(GetCategoryAsync)}");
                var request = new GetCategoryRequest()
                {
                    IncludePosts = true
                };
                var response = await _httpClient.GetAsync($"/api/categories/{slug}".WithQueryParams(request));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAs<GetCategoryResponse>();
                    if (content.IsSuccess)
                    {
                        Console.WriteLine($"Ending {nameof(GetCategoryAsync)}");
                        return content.Category;
                    }
                }

                return default(CategoryModel);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ex Ending {nameof(GetCategoryAsync)}");
                Console.WriteLine(e);
                throw;
            }
        }
    }
}