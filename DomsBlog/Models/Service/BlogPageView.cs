using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.Extensions;
using MvcLibrary.UrlTools;
using System.Web.Mvc;
using DomsBlog.Models.DataModels;
using DomsBlog.Utils;

namespace DomsBlog.Models.Service
{
    public class BlogPageView
    {
        public int BlogId { get; set; }
        public int PageNumber { get; set; }
        public string PageName { get; set; }
        public string ShortTitle { get; set; }
        public string Title { get; set; }
        public string UrlFriendlyTitle
        {
            get { return Title.ToFriendlyUrl(); }
        }
        public DateTime PostedDate { get; set; }
        public string BlogType { get; set; }
        public string Abstract { get; set; }

        public int NumImages { get; set; }
        public int NumComments { get; set; }

        public string BlogText { get; set; }

        private CommentForm _commentForm = new CommentForm();
        public CommentForm CommentForm
        {
            get { return _commentForm; }
            set { _commentForm = value; }
        }

        public IList<CommentView> Comments { get; set; }

        public CommentView ReplyComment { get; set; }
        public bool ReplyCommentRequiresQuote { get; set; }

        public IList<BlogPageSimpleData> BlogPages { get; set; }

        public bool HasNextPage()
        {
            return PageNumber < BlogPages.Count;
        }

        public bool HasPreviousPage()
        {
            return PageNumber > 1;
        }
    }
}