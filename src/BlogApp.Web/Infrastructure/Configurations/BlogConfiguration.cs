namespace BlogApp.Web.Infrastructure.Configurations
{
    public class BlogConfiguration : IBlogConfiguration
    {

        public BlogConfiguration(IClientEnviromment clientEnviromment)
        {
            ApiUrl = clientEnviromment.IsDevelopment
                ? "https://localhost:5010/"
                : "https://api.barisceviz.com/";
        }

        public string ApiUrl { get; private set; }
    }
}