using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlogApp.Contract.Models;
using Newtonsoft.Json;

namespace BlogApp.Web.Services
{
    public interface IBlogService
    {
        Task<List<PostModel>> GetPostsAsync();
        Task<BlogAppModel> GetBlogConfigurationAsync();
        Task<PostModel> GetPostAsync(string slug);
        Task<List<CategoryModel>> GetSpotlightCategoriesAsync();
        Task<CategoryModel> GetCategoryAsync(string slug);
    }

    public class MockBlogService : IBlogService
    {
        public Task<List<PostModel>> GetPostsAsync()
        {
            var posts = new List<PostModel>()
            {
                CreatePostModel(1),
                CreatePostModel(2),
                CreatePostModel(3),
                CreatePostModel(4),
                CreatePostModel(5),
                CreatePostModel(6),
                CreatePostModel(7),
                CreatePostModel(8),
                CreatePostModel(9),
                CreatePostModel(10)
            };

            return Task.FromResult(posts);
        }

        public Task<BlogAppModel> GetBlogConfigurationAsync()
        {
            var blogAppConfiguration = new BlogAppModel()
            {
                Title = "Baris Ceviz Blog",
                Icon = "favico.icon",
                Logo = "img/logo.png",
                Author = new AuthorModel()
                {
                    About = "Software Development Engineer @Trendyol, Microsoft Student Partner, Yildiz Technical University, @Scodeapp",
                    FullName = "Baris Ceviz",
                    ImageUrl = "https://pbs.twimg.com/profile_images/1065343290449555457/CGo0-nxE_400x400.jpg",
                    SocialMedias = new Dictionary<string, string>()
                    {
                        {"facebook","https://facebook.com/peacecwz" },
                        {"twitter","https://twitter.com/peacecwz" },
                        {"github","https://github.com/peacecwz" }
                    }
                }
            };

            return Task.FromResult(blogAppConfiguration);
        }

        public Task<PostModel> GetPostAsync(string slug)
        {
            return Task.FromResult(CreatePostModel(1));
        }

        public Task<List<CategoryModel>> GetSpotlightCategoriesAsync()
        {
            var categories = new List<CategoryModel>()
            {
                CreateCategoryModel(1,"General"),
                CreateCategoryModel(2,"Projects"),
                CreateCategoryModel(3,"Web"),
                CreateCategoryModel(4,"Mobile"),
                CreateCategoryModel(5,"About")
            };

            return Task.FromResult(categories);
        }

        public Task<CategoryModel> GetCategoryAsync(string slug)
        {
            var category = new CategoryModel()
            {
                Name = "Events",
                Description = "I joined as a speaker to events and I published all events on this category",
                Posts = new List<PostModel>()
                {
                    CreatePostModel(1),
                    CreatePostModel(2),
                    CreatePostModel(3),
                    CreatePostModel(4),
                    CreatePostModel(5)
                }
            };

            return Task.FromResult(category);
        }

        private CategoryModel CreateCategoryModel(int id, string name)
        {
            return new CategoryModel()
            {
                Id = id,
                Name = name,
                IsSpotlight = true
            };
        }

        private PostModel CreatePostModel(int slugId)
        {
            var blogConfig = GetBlogConfigurationAsync().Result;
            var author = blogConfig.Author;
            return new PostModel()
            {
                Slug = $"{slugId}-time",
                Content = "<p>Holy grail funding non-disclosure agreement advisor ramen bootstrapping ecosystem. Beta crowdfunding iteration assets business plan paradigm shift stealth mass market seed money rockstar niche market marketing buzz market. </p><p>Burn rate release facebook termsheet equity technology. Interaction design rockstar network effects handshake creative startup direct mailing. Technology influencer direct mailing deployment return on investment seed round. </p><p>Termsheet business model canvas user experience churn rate low hanging fruit backing iteration buyer seed money. Virality release launch party channels validation learning curve paradigm shift hypotheses conversion. Stealth leverage freemium venture startup business-to-business accelerator market. </p><blockquote>Gen-z strategy long tail churn rate seed money channels user experience incubator startup partner network low hanging fruit direct mailing. Client backing success startup assets responsive web design burn rate A/B testing metrics first mover advantage conversion. </blockquote><p>Freemium non-disclosure agreement lean startup bootstrapping holy grail ramen MVP iteration accelerator. Strategy market ramen leverage paradigm shift seed round entrepreneur crowdfunding social proof angel investor partner network virality.</p>",
                Title = "Life is worth living forever and ever",
                CoverIamgeUrl = "/img/demopic/8.jpg",
                Description =
                    "This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.",
                AuthorImageUrl = author.ImageUrl,
                AuthorFullName = author.FullName,
                PublishedDate = new DateTime(2017, 07, 22),
                Tags = ""
            };
        }
    }

    public class BlogService : IBlogService
    {
        public Task<List<PostModel>> GetPostsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BlogAppModel> GetBlogConfigurationAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("/data/app.json");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<BlogAppModel>(json);
                }
            }

            return default(BlogAppModel);
        }

        public Task<PostModel> GetPostAsync(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryModel>> GetSpotlightCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryModel> GetCategoryAsync(string slug)
        {
            throw new NotImplementedException();
        }
    }
}