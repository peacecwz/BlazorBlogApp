using System;

namespace BlogApp.Web.Helpers
{
    public class DateHelper : IDateHelper
    {
        public string ToLocaleDate(DateTime? publishedDate)
        {
            return publishedDate?.ToLocalTime().ToString("dddd, d MMMM yyyy");
        }
    }
}