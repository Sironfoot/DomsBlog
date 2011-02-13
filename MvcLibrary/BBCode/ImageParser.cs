using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MvcLibrary.BBCode
{
    public class ImageParser : IParser
    {
        #region IParser Members

        public string ParseBeforeLineBreaksEncoding(string bbCode)
        {
            return Regex.Replace(bbCode, @"\[img=&quot;(.*?)&quot; alt=&quot;(.*?)&quot; class=&quot;(.*?)&quot;\]",
                "<img src=\"$1\" alt=\"$2\" class=\"$3\" />",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);
        }

        public string ParseAfterLineBreaksEncoding(string bbCode)
        {
            return bbCode;
        }

        #endregion
    }
}