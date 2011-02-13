using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MvcLibrary.BBCode
{
    public class ItalicParser : IParser
    {
        public string ParseBeforeLineBreaksEncoding(string bbCode)
        {
            return Regex.Replace(bbCode, "\\[i\\](.*?)\\[\\/i\\]", "<em>$1</em>",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);
        }

        public string ParseAfterLineBreaksEncoding(string bbCode)
        {
            return bbCode;
        }
    }
}