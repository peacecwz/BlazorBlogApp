namespace BlogApp.API.Extensions
{
    public static class StringsExtensions
    {
        public static string ToSlug(this string title)
        {
            //TODO (peacecwz): Create slug
            return title.ToLower().Replace(" ", "-");
        }
    }
}