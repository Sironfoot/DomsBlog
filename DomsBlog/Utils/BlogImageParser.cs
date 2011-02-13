using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using MvcLibrary.BBCode;

namespace DomsBlog.Utils
{
    public class BlogImageParser : IParser
    {
        public string ParseBeforeLineBreaksEncoding(string bbCode)
        {
            return Regex.Replace(bbCode, @"\[image id=&quot;(.*?)&quot;]",
                "<img src=\"$1\" alt=\"$2\" class=\"$3\" />",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);
        }

        public string ParseAfterLineBreaksEncoding(string bbCode)
        {
            return bbCode;
        }
    }
}