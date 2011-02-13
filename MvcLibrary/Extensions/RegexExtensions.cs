using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MvcLibrary.Extensions
{
    /// <summary>
    ///     Helper class for performing Regular Expression tests on string inputs
    /// </summary>
    public static class RegexExtensions
    {
        private static readonly Regex EMAIL_REGEX;
        private static readonly Regex PHONE_REGEX;
        private static readonly Regex IPv4_REGEX;
        private static readonly Regex HTTP_URL_REGEX;
        private static readonly Regex WHOLE_NUMBER_REGEX;
        private static readonly Regex WHOLE_NUMBER_REGEX_UNSIGNED;
        private static readonly Regex REAL_NUMBER_REGEX;
        private static readonly Regex REAL_NUMBER_REGEX_UNSIGNED;

        /// <summary>
        ///     Regex pattern for testing Email addresses
        /// </summary>
        public const string EmailRegexPattern = @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";
        /// <summary>
        ///     Regex pattern for testing Telephone numbers (including country codes)
        /// </summary>
        public const string TelephoneRegexPattern = @"^(\+[0-9]{1,3})?[ ]{0,2}(\([0-9]+\))?[ ]{0,2}[0-9]{2,}[1-9]+[0-9\ \-]*$";
        /// <summary>
        ///     Regex pattern for testing IP (version 4) addresses
        /// </summary>
        public const string IPv4RegexPattern = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
        /// <summary>
        ///     Regex pattern for testing HTTP URLs (including the HTTP/HTTPS part)
        /// </summary>
        public const string HttpUrlRegexPattern = @"((https?):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)";
        /// <summary>
        ///     Regex pattern for testing signed or unsigned whole numbers (integers)
        /// </summary>
        public const string WholeNumberRegexPattern = @"^[-+]?[0-9]+$";
        /// <summary>
        ///     Regex pattern for testing unsigned whole numbers (integers)
        /// </summary>
        public const string WholeNumberUnsignedRegexPattern = @"^[0-9]+$";
        /// <summary>
        ///     Regex pattern for testing signed or unsigned real numbers
        ///     (includeing whole numbers and numbers with floating point digits)
        /// </summary>
        public const string RealNumberRegexPattern = @"^[-+]?[0-9]+\.?[0-9]*$";
        /// <summary>
        ///     Regex pattern for testing unsigned real numbers
        ///     (includeing whole numbers and numbers with floating point digits)
        /// </summary>
        public const string RealNumberUnsignedRegexPattern = @"^[0-9]+\.?[0-9]*$";

        public static string RealNumberRegexPatternRanged(int maxNumbersToLeft, int maxNumbersToRight)
        {
            return @"^[-+]?[0-9]{0-" + maxNumbersToLeft + @"}\.?[0-9]{0-" + maxNumbersToRight + @"}$";
        }

        public static string RealNumberUnsignedRegexPatternRanged(int maxNumbersToLeft, int maxNumbersToRight)
        {
            return @"^[0-9]{0-" + maxNumbersToLeft + @"}\.?[0-9]{0-" + maxNumbersToRight + @"}$";
        }

        static RegexExtensions()
        {
            EMAIL_REGEX = new Regex(EmailRegexPattern, RegexOptions.IgnoreCase);
            PHONE_REGEX = new Regex(TelephoneRegexPattern);
            IPv4_REGEX = new Regex(IPv4RegexPattern);
            HTTP_URL_REGEX = new Regex(HttpUrlRegexPattern, RegexOptions.IgnoreCase);
            WHOLE_NUMBER_REGEX = new Regex(WholeNumberRegexPattern);
            WHOLE_NUMBER_REGEX_UNSIGNED = new Regex(WholeNumberUnsignedRegexPattern);
            REAL_NUMBER_REGEX = new Regex(RealNumberRegexPattern);
            REAL_NUMBER_REGEX_UNSIGNED = new Regex(RealNumberUnsignedRegexPattern);
        }

        /// <summary>
        ///     Tests whether input is in the form of a valid email address
        /// </summary>
        /// <param name="input">Input string to test</param>
        public static bool IsEmailAddress(this string input)
        {
            return EMAIL_REGEX.IsMatch(input.Sanitise());
        }

        /// <summary>
        ///     Tests whether input is in the form of a valid telephone number,
        ///     including country and area code (optional)
        /// </summary>
        /// <param name="input">Input string to test</param>
        public static bool IsTelephoneNumber(this string input)
        {
            return PHONE_REGEX.IsMatch(input.Sanitise());
        }

        /// <summary>
        ///     Tests to see if the input is a valid IP (Internet Protocol) address.
        ///     Tests for version 4 IP addresses (eg. 192.168.0.1)
        /// </summary>
        /// <param name="input">Input string to test</param>
        public static bool IsIPv4Address(this string input)
        {
            return IPv4_REGEX.IsMatch(input.Sanitise());
        }

        /// <summary>
        ///     Tests if the input is a valid URL web address (including http://
        ///     or https:// part)
        /// </summary>
        /// <param name="input">Input string to test</param>
        public static bool IsHttpUrl(this string input)
        {
            return HTTP_URL_REGEX.IsMatch(input.Sanitise());
        }

        /// <summary>
        ///     Tests to see if the input is a whole number (integer), either signed or unsigned
        /// </summary>
        /// <param name="input">Input string to test</param>
        public static bool IsWholeNumber(this string input)
        {
            return WHOLE_NUMBER_REGEX.IsMatch(input.Sanitise());
        }

        /// <summary>
        ///     Tests to see if the input is a whole number (integer), either signed or unsigned
        /// </summary>
        /// <param name="input">Input string to test</param>
        /// <param name="isSigned">Numbers with signs at the front (-/+) will validate to true</param>
        public static bool IsWholeNumber(this string input, bool isSigned)
        {
            if (isSigned)
            {
                return WHOLE_NUMBER_REGEX.IsMatch(input.Sanitise());
            }
            else
            {
                return WHOLE_NUMBER_REGEX_UNSIGNED.IsMatch(input.Sanitise());
            }
        }

        /// <summary>
        ///     Tests to see if the input is a real number (including integers and floating point numbers),
        ///     either signed or unsigned
        /// </summary>
        /// <param name="input">Input string to test</param>
        public static bool IsRealNumber(this string input)
        {
            return REAL_NUMBER_REGEX.IsMatch(input.Sanitise());
        }

        /// <summary>
        ///     Tests to see if the input is a real number (including integers and floating point numbers),
        ///     either signed or unsigned
        /// </summary>
        /// <param name="input">Input string to test</param>
        /// <param name="isSigned">Numbers with signs at the front (-/+) will validate to true</param>
        public static bool IsRealNumber(this string input, bool isSigned)
        {
            if (isSigned)
            {
                return REAL_NUMBER_REGEX.IsMatch(input.Sanitise());
            }
            else
            {
                return REAL_NUMBER_REGEX_UNSIGNED.IsMatch(input.Sanitise());
            }
        }
    }
}
