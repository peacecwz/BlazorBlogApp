namespace BlogApp.Web.Services
{
    public interface IBlogConfiguration
    {
        string ApiUrl { get; set; }
    }

    public class BlogConfiguration : IBlogConfiguration
    {
        public string ApiUrl { get; set; } = "http://localhost:5010/";
    }
}