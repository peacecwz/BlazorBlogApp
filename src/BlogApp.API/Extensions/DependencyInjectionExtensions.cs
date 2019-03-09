using BlogApp.API.Data;
using BlogApp.API.Mappers;
using BlogApp.API.Mappers.Impl;
using BlogApp.API.Repositories;
using BlogApp.API.Repositories.Impl;
using BlogApp.API.Services;
using BlogApp.API.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BlogApp.API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddConfiguredAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication();
            services.AddAuthorization();
            return services;
        }

        public static IServiceCollection AddSwaggerIntegration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("v1", new Info()
                {
                    Title = "Blazor Blog API",
                    Version = "v1"
                });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerIntegration(this IApplicationBuilder services)
        {
            services.UseSwagger();
            services.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor Blog API");
                //options.DocumentTitle = "Trendyol.InstallmentApi";
                //options.RoutePrefix = string.Empty;
                //options.DisplayRequestDuration();
            });
            return services;
        }

        public static IServiceCollection AddMappersLayer(this IServiceCollection services)
        {
            services.AddTransient<IPostMapper, PostMapper>();
            services.AddTransient<ICategoryMapper, CategoryMapper>();
            return services;
        }

        public static IServiceCollection AddRepositoriesLayer(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            services.AddDbContext<BlogAppDbContext>(options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString("DbConnection"));
                });
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }

        public static IServiceCollection AddServicesLayer(this IServiceCollection services)
        {
            services.AddScoped<IPostsService, PostsService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            return services;
        }
    }
}