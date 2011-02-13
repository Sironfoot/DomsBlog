using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace MvcLibrary.BBCode
{
    public class BBDecoder
    {
        public string Decode(string bbCode)
        {
            bbCode = "<p>" + HttpUtility.HtmlEncode(bbCode) + "</p>";

            foreach (IParser parser in Parsers)
            {
                bbCode = parser.ParseBeforeLineBreaksEncoding(bbCode);
            }

            bbCode = bbCode.Replace("\n", "<br />");

            foreach (IParser parser in Parsers)
            {
                bbCode = parser.ParseAfterLineBreaksEncoding(bbCode);
            }

            bbCode = Regex.Replace(bbCode, @"\<br \/\>(\s)*\<br \/\>", "</p><p>",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

            bbCode = Regex.Replace(bbCode, @"\<p\>(\s)*\<\/p\>", "",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

            bbCode = Regex.Replace(bbCode, @"\<br \/\>(\s)*\<\/p\>", "</p>",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

            bbCode = Regex.Replace(bbCode, @"(\s)*\<\/p\>", "</p>",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

            bbCode = Regex.Replace(bbCode, @"\<p\>(\s)*", "<p>",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

            bbCode = Regex.Replace(bbCode, @"(\s)*\<br \/\>(\s)*", "<br />",
               RegexOptions.IgnoreCase | RegexOptions.Singleline);

            return bbCode;
        }

        private List<IParser> _parsers = new List<IParser>();
        public IList<IParser> Parsers { get { return _parsers; } }
    }
}