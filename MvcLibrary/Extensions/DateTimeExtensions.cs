using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MvcLibrary.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToStringWithOrdinal(this DateTime value, string format)
        {
            format = format ?? "";

            string ordinal = value.Day.GetOrdinal();
            format = Regex.Replace(format, @"(\bdd\b|\bd\b)", "$1{0}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            return value.ToString(format).Replace("{0}", ordinal);
        }

        /// <summary>
        /// Converts a regular DateTime to a RFC822 date string.
        /// </summary>
        /// <returns>The specified date formatted as a RFC822 date string.</returns>
        /// <remarks>http://www.extensionmethod.net/Details.aspx?ID=90</remarks>
        public static string ToRFC822DateString(this DateTime date)
        {
            int offset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Hours;
            string timeZone = "+" + offset.ToString().PadLeft(2, '0');
            if (offset < 0)
            {
                int i = offset * -1;
                timeZone = "-" + i.ToString().PadLeft(2, '0');
            }
            return date.ToString("ddd, dd MMM yyyy HH:mm:ss " + timeZone.PadRight(5, '0'), System.Globalization.CultureInfo.GetCultureInfo("en-US"));
        }
    }
}