using System.Net;
using BlogApp.Contract.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlogApp.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var logger = context.HttpContext.RequestServices.GetService<ILogger<ExceptionFilter>>();
            logger.LogError(context.Exception, "Has an error occurred on Exception Filter");

            var error = new ErrorModel()
            {
                Title = context.Exception.Message,
                Description = context.Exception.StackTrace
            };
            context.Exception = context.Exception.InnerException;

            while (context.Exception != null)
            {
                error.SubErrors.Add(new ErrorModel()
                {
                    Title = context.Exception.Message,
                    Description = context.Exception.StackTrace
                });
                context.Exception = context.Exception.InnerException;
            }

            context.ExceptionHandled = true;
            context.Result = new ObjectResult(error)
            {
                StatusCode = (int) HttpStatusCode.InternalServerError
            };
        }
    }
}