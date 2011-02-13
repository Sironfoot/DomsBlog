using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MvcLibrary.BBCode
{
    public class BoldParser : IParser
    {
        public string ParseBeforeLineBreaksEncoding(string bbCode)
        {
            return Regex.Replace(bbCode, "\\[b\\](.*?)\\[\\/b\\]", "<strong>$1</strong>",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);
        }

        public string ParseAfterLineBreaksEncoding(string bbCode)
        {
            return bbCode;
        }
    }
}