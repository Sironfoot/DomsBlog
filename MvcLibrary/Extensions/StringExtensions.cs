using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcLibrary.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        ///     Converts null references to a blank string, trims off any whitespace
        ///     characters at the end of the string.
        /// </summary>
        /// <param name="input">String input to sanitise</param>
        public static string Sanitise(this string input)
        {
            return input == null ? "" : input.Trim();
        }

        /// <summary>
        ///     Tests whether the string is a NULL reference, is blank or contain nothing but
        ///     black empty whitespace characters.
        /// </summary>
        /// <param name="input">String input to test</param>
        public static bool IsNullEmptyOrWhitespace(this string input)
        {
            if (input != null && input.Trim().Length > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}