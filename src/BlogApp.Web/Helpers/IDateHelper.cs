using System;

namespace BlogApp.Web.Helpers
{
    public interface IDateHelper
    {
        string ToLocaleDate(DateTime? publishedDate);
    }
}