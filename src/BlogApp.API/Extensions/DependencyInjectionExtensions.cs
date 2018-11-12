using BlogApp.API.Mappers;
using BlogApp.API.Mappers.Impl;
using BlogApp.API.Repositories;
using BlogApp.API.Repositories.Impl;
using BlogApp.API.Services;
using BlogApp.API.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddMappersLayer(this IServiceCollection services)
        {
            services.AddTransient<IPostMapper, PostMapper>();
            services.AddTransient<ICategoryMapper, CategoryMapper>();
            return services;
        }

        public static IServiceCollection AddRepositoriesLayer(this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, IPostRepository>();
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