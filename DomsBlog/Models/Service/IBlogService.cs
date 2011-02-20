using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.ActionResults;
using DomsBlog.Models.ViewModels;
using DomsBlog.Models.DataModels;
using DomsBlog.Models.NHibernate.Domain;

namespace DomsBlog.Models.Service
{
    public interface IBlogService
    {
        string GetBlogTitle(int blogId);
        BlogListingView GetTaggedBlogsForFrontPage(int tagId, int pageNumber, int recordsPerPage, out TagData tag);
        BlogListingView ListBlogsForFrontPage(int pageNumber, int recordsPerPage);
        BlogPageView GetBlogPage(int blogId, int pageNumber, int replyId, bool replyIsQuote, bool commentAwaitingApproval);
        void CreateBlogComment(int blogId, int? parentCommentId, CommentForm comment);
        BlogComment ApproveBlogComment(int blogCommentId, string approvalKey);
        void DeleteBlogComment(int blogCommentId, string approvalKey);
        RssFeed GetRssBlogFeed(int maxRecords, string webAddress, string blogUrl);
        BlogImagesView GetBlogImagesPage(int blogId);
    }
}