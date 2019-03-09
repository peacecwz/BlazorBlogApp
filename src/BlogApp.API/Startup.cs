using BlogApp.API.Extensions;
using BlogApp.API.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMappersLayer()
                .AddRepositoriesLayer()
                .AddServicesLayer()
                .AddSwaggerIntegration()
                .AddConfiguredAuthentication()
                .AddCors(options =>
                    options.AddPolicy("AllowAny", cors => cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()))
                .AddMvc(options => options.Filters.Add<ExceptionFilter>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseCors("AllowAny")
                .UseConfiguredExceptionHandler(env)
                .UseSwaggerIntegration()
                .UseMvc();
        }
    }
}