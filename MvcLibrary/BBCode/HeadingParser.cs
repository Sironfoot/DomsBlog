using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MvcLibrary.BBCode
{
    public class HeadingParser : IParser
    {
        private HeadingType _headingType = HeadingType.H1;

        public HeadingParser(HeadingType headingType)
        {
            _headingType = headingType;
        }

        public string ParseBeforeLineBreaksEncoding(string bbCode)
        {
            string level = "1";

            switch (_headingType)
            {
                case HeadingType.H1:
                    level = "1";
                    break;
                case HeadingType.H2:
                    level = "2";
                    break;
                case HeadingType.H3:
                    level = "3";
                    break;
                case HeadingType.H4:
                    level = "4";
                    break;
                case HeadingType.H5:
                    level = "5";
                    break;
                case HeadingType.H6:
                    level = "6";
                    break;
            }

            return Regex.Replace(bbCode, "\\[h\\](.*?)\\[\\/h\\]", "</p><h" + level + ">$1</h" + level + "><p>",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);
        }

        public string ParseAfterLineBreaksEncoding(string bbCode)
        {
            return bbCode;
        }
    }
}