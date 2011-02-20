using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomsBlog.Models.NHibernate.Domain;
using DomsBlog.Models.Service;
using DomsBlog.Models.DataModels;

namespace DomsBlog.Models.Repositories
{
    public interface IBlogRepository
    {
        string GetBlogTitle(int blogId);
        IList<CommentSubscriber> GetCommentSubscribers(int blogId);
        IList<BlogPageSimpleData> GetBlogPageListForBlog(int blogId);
        Image GetRandomImage();
        Image GetImageFromId(int imageId);
        TagData GetTagFromId(int tagId);
        IList<BlogItemListingData> GetTaggedBlogs(int tagId, int pageNumber, int recordsPerPage, out int totalRecords);
        IList<BlogItemListingData> ListBlogs(int pageNumber, int recordsPerPage, out int totalRecords);
        Blog GetBlogFromId(int id);
        IList<Image> GetImagesForBlog(int blogId);
        BlogPageView GetBlogPage(int blogId, int pageNumber);
        BlogComment CreateBlogComment(int blogId, int? childCommentId, CommentForm commentForm);
        BlogComment ApproveComment(int commentId, string approvalKey);
        void DeleteComment(int commentId, string approvalKey);
    }
}