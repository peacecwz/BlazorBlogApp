using System;

namespace BlogApp.Web.Infrastructure.Implementations
{
    public class Configurations : IBlogAppConfiguration
    {
        public string BlogAppApiUrl => "https://blogappapi.azurewebsites.net/";
    }
}