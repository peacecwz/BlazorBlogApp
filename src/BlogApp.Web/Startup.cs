using BlogApp.Web.Infrastructure;
using BlogApp.Web.Infrastructure.Implementations;
using BlogApp.Web.Services;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IBlogAppConfiguration, Configurations>();
            services.AddScoped<IBlogService, BlogService>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
