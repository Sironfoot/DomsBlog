using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.BBCode;
using System.Text.RegularExpressions;
using DomsBlog.Models.ViewModels;
using DomsBlog.Models.Service;

namespace DomsBlog.Utils
{
    public static class BBDecoding
    {
        private static readonly BBDecoder BlogTextDecoder = null;
        private static readonly BBDecoder BlogCommentTextDecoder = null;

        static BBDecoding()
        {
            BlogTextDecoder = new BBDecoder();
            BlogTextDecoder.Parsers.Add(new BoldParser());
            BlogTextDecoder.Parsers.Add(new ItalicParser());
            BlogTextDecoder.Parsers.Add(new UnderlineParser());
            BlogTextDecoder.Parsers.Add(new HyperLinkParser());
            BlogTextDecoder.Parsers.Add(new ImageParser());
            BlogTextDecoder.Parsers.Add(new HeadingParser(HeadingType.H2));
            BlogTextDecoder.Parsers.Add(new ListItemParser(ListItemType.Unordered));
            BlogTextDecoder.Parsers.Add(new QuoteParser("<span class=\"author\">{0} says...</span>"));
            BlogTextDecoder.Parsers.Add(new CodeParser());
            BlogTextDecoder.Parsers.Add(new ImageParser());

            BlogCommentTextDecoder = new BBDecoder();
            BlogCommentTextDecoder.Parsers.Add(new BoldParser());
            BlogCommentTextDecoder.Parsers.Add(new ItalicParser());
            BlogCommentTextDecoder.Parsers.Add(new UnderlineParser());
            BlogCommentTextDecoder.Parsers.Add(new HyperLinkParser());
            BlogCommentTextDecoder.Parsers.Add(new ListItemParser(ListItemType.Unordered));
            BlogCommentTextDecoder.Parsers.Add(new QuoteParser("<span class=\"author\">{0} says...</span>"));
            BlogCommentTextDecoder.Parsers.Add(new CodeParser());
        }

        public static string DecodeBlogText(string input)
        {
            return BlogTextDecoder.Decode(input);
        }

        public static string DecodeBlogCommentText(string input)
        {
            return BlogCommentTextDecoder.Decode(input);
        }
    }
}