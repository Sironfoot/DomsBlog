using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MvcLibrary.BBCode
{
    public class QuoteParser : IParser
    {
        private string _authorReplacementText = null;

        public QuoteParser() { }

        public QuoteParser(string authorReplacementText)
        {
            _authorReplacementText = authorReplacementText;
        }

        public string ParseBeforeLineBreaksEncoding(string bbCode)
        {
            if (_authorReplacementText != null)
            {
                string authorText = String.Format(_authorReplacementText, "$1");

                bbCode = Regex.Replace(bbCode, @"\[quote author=&quot;(.*?)&quot;\](.*?)\[\/quote\]", "</p><blockquote>" + authorText + " $2</blockquote><p>",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline);

                bbCode = Regex.Replace(bbCode, @"\[quote\](.*?)\[\/quote\]", "</p><blockquote>$1</blockquote><p>",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline);
            }
            else
            {
                bbCode = Regex.Replace(bbCode, @"\[quote\](.*?)\[\/quote\]", "</p><blockquote>$1</blockquote><p>",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline);
            }

            return bbCode;
        }

        public string ParseAfterLineBreaksEncoding(string bbCode)
        {
            return bbCode;
        }
    }
}