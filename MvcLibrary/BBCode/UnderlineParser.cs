using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MvcLibrary.BBCode
{
    public class UnderlineParser : IParser
    {
        public string ParseBeforeLineBreaksEncoding(string bbCode)
        {
            return Regex.Replace(bbCode, "\\[u\\](.*?)\\[\\/u\\]", "<span class=\"Underline\">$1</span>",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);
        }

        public string ParseAfterLineBreaksEncoding(string bbCode)
        {
            return bbCode;
        }
    }
}