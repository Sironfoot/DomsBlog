using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MvcLibrary.BBCode
{
    public class ListItemParser : IParser
    {
        private ListItemType _listItemType = ListItemType.Unordered;

        public ListItemParser(ListItemType listItemType)
        {
            _listItemType = listItemType;
        }

        public string ParseBeforeLineBreaksEncoding(string bbCode)
        {
            switch (_listItemType)
            {
                case ListItemType.Unordered:

                    bbCode = Regex.Replace(bbCode, "\\[li\\](.*?)\\[\\/li\\]", "</p><ul><li>$1</li></ul><p>",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline);

                    bbCode = Regex.Replace(bbCode, @"\<\/ul\>\<p\>(\s)*\<\/p\>\<ul\>", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                    break;
                case ListItemType.Ordered:

                    bbCode = Regex.Replace(bbCode, "\\[oli\\](.*?)\\[\\/oli\\]", "</p><ol><li>$1</li></ol><p>",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline);

                    bbCode = Regex.Replace(bbCode, @"\<\/ol\>\<p\>(\s)*\<\/p\>\<ol\>", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                    break;
            }

            return bbCode;
        }

        public string ParseAfterLineBreaksEncoding(string bbCode)
        {
            return bbCode;
        }
    }
}
