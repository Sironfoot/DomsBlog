using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MvcLibrary.BBCode
{
    public class CodeParser : IParser
    {
        public string ParseBeforeLineBreaksEncoding(string bbCode)
        {
            bbCode = Regex.Replace(bbCode, @"(\s)*\[code\](\s)*", "[code]");
            bbCode = Regex.Replace(bbCode, @"(\s)*\[\/code\](\s)*", "[/code]");

            return bbCode;
        }

        public string ParseAfterLineBreaksEncoding(string bbCode)
        {
            string element = "</p><pre>$1</pre><p>";

            string startTag = "";
            string endTag = "";

            int contentPos = element.IndexOf("$1");

            if (contentPos != -1)
            {
                startTag = element.Substring(0, contentPos);
                endTag = element.Substring(contentPos + 2);
            }

            StringBuilder newText = new StringBuilder();

            int lastEnd = 0;

            Regex reCodeTags = new Regex(@"\[code\].*?\[\/code\]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            for (Match match = reCodeTags.Match(bbCode); match.Success; match = match.NextMatch())
            {
                newText.Append(bbCode.Substring(lastEnd, match.Index - lastEnd));
                string value = match.Value;
                value = value.Substring("[code]".Length, value.Length - "[code][/code]".Length);
                value = Regex.Replace(value, @"<br \/>", "\n",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
                newText.Append(startTag);
                newText.Append(value);
                newText.Append(endTag);
                lastEnd = match.Index + match.Length;
            }

            newText.Append(bbCode.Substring(lastEnd));

            return newText.ToString();
        }
    }
}