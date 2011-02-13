using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MvcLibrary.UrlTools
{
    /// <summary>
    ///     Various utils for dealing with URLs
    /// </summary>
    public static class UrlEncoder
    {
        public static string ToFriendlyUrl(this UrlHelper helper, string urlToEncode)
        {
            return urlToEncode.ToFriendlyUrl();
        }

        /// <summary>
        ///     Encodes a string into a safe, SEO friendly format that can be safely used as URLs for links
        /// </summary>
        /// <param name="urlToEncode">The string to convert into a safe/friendly URL</param>
        public static string ToFriendlyUrl(this string urlToEncode)
        {
            urlToEncode = (urlToEncode ?? "").Trim().ToLower();

            StringBuilder url = new StringBuilder();

            foreach (char ch in urlToEncode)
            {
                switch (ch)
                {
                    case ' ':
                        url.Append('-');
                        break;
                    case '&':
                        url.Append("and");
                        break;
                    case '\'':
                        break;
                    default:
                        if ((ch >= '0' && ch <= '9') || (ch >= 'a' && ch <= 'z'))
                        {
                            url.Append(ch);
                        }
                        else
                        {
                            url.Append('-');
                        }
                        break;
                }
            }

            return url.ToString();
        }
    }
}