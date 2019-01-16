using BlogApp.Web.Helpers;
using BlogApp.Web.Services;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDateHelper, DateHelper>();
            services.AddSingleton<IContentHelper, ContentHelper>();
            services.AddSingleton<IBlogService, MockBlogService>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
