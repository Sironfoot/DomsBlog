using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.ActionResults;
using DomsBlog.Models.ViewModels;
using DomsBlog.Models.DataModels;

namespace DomsBlog.Models.Service
{
    public interface IBlogService
    {
        string GetBlogTitle(int blogId);
        BlogListingView GetTaggedBlogsForFrontPage(int tagId, int pageNumber, int recordsPerPage, out TagData tag);
        BlogListingView ListBlogsForFrontPage(int pageNumber, int recordsPerPage);
        BlogPageView GetBlogPage(int blogId, int pageNumber, int replyId, bool replyIsQuote, int commentFadeId);
        int CreateBlogComment(int blogId, int? parentCommentId, CommentForm comment);
        RssFeed GetRssBlogFeed(int maxRecords, string webAddress, string blogUrl);
        BlogImagesView GetBlogImagesPage(int blogId);
    }
}