using System.Net;
using BlogApp.Contract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BlogApp.API.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseConfiguredExceptionHandler(this IApplicationBuilder app, IHostingEnvironment hostingEnvironment)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var result = new ResponseBase()
                        {
                            StatusCode = 500
                        };

                        if (hostingEnvironment.IsDevelopment())
                        {
                            var ex = contextFeature.Error;
                            while (ex != null)
                            {
                                result.Messages.Add(new ResponseMessage()
                                {
                                    Title = contextFeature.Error.Message,
                                    Detail = contextFeature.Error.StackTrace
                                });
                                ex = contextFeature.Error.InnerException;
                            }
                        }

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
                    }
                });
            });
            return app;
        }
    }
}