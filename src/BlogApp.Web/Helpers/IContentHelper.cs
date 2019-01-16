namespace BlogApp.Web.Helpers
{
    public interface IContentHelper
    {
        string CalculateReadingTime(string content);
    }

    public class ContentHelper : IContentHelper
    {
        public string CalculateReadingTime(string content)
        {
            //TODO (peacecwz): Implement calculation of reading time

            return "6 min read";
        }
    }
}