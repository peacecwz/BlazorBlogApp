using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Blazor;

namespace BlogApp.Web.Extensions
{
    public static class StringExtensions
    {
        public static List<string> SplitWithCommaSeprator(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new List<string>();
            }

            return text?.Split(',')?.ToList()?.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }

        public static MarkupString ToHtml(this string html)
        {
            return (MarkupString) html;
        }
    }
}