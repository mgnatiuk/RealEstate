using System;
namespace RealEstate.Application.Extensions
{
    public static class DateFormatExtension
    {
        public static string GetDateOnly(this DateTime date)
        {
            string dateOnly = null;

            if(date != null && date != new DateTime())
            {
                dateOnly = date.ToString("yyyy-MM-dd");
            }

            return dateOnly;
        }

        public static string GetDateWithTime(this DateTime date)
        {
            string dateWithTime = null;

            if (date != null && date != new DateTime())
            {
                dateWithTime = date.ToString("yyyy-MM-dd HH:mm:ss");
            }

            return dateWithTime;
        }
    }
}
