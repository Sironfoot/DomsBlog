using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomsBlog.Models.NHibernate;
using NHibernate;
using DomsBlog.Models.NHibernate.Domain;
using NHibernate.Criterion;
using System.Collections;
using DomsBlog.Models.Service;
using DomsBlog.Utils;
using MvcLibrary.Extensions;
using DomsBlog.Models.DataModels;

namespace DomsBlog.Models.Repositories
{
    public class NHibernateBlogRepository : IBlogRepository
    {
        public string GetBlogTitle(int blogId)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            string hql = "SELECT b.Title " +
                         "FROM Blog b " +
                         "WHERE b.Id = " + blogId;

            IQuery query = session.CreateQuery(hql);

            return query.UniqueResult<string>();
        }

        public IList<CommentSubscriber> GetCommentSubscribers(int blogId)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            string hql = "SELECT c.Author, c.EmailAddress " +
                         "FROM BlogComment c " +
                         "WHERE c.Blog.Id = " + blogId + " " +
                            "AND c.EmailOnReply = 1 " +
                            "AND c.Approved = 1";

            IQuery query = session.CreateQuery(hql);

            IList result = query.List();

            List<CommentSubscriber> subscribers = new List<CommentSubscriber>();

            foreach (object[] commentObj in result)
            {
                string author = (string)commentObj[0];
                string email = (string)commentObj[1];

                if (!subscribers.Any(s => s.EmailAddress.Trim().Equals(email.Trim(), StringComparison.InvariantCultureIgnoreCase)))
                {
                    CommentSubscriber subscriber = new CommentSubscriber();
                    subscriber.Author = author;
                    subscriber.EmailAddress = email;
                    subscribers.Add(subscriber);
                }
            }

            return subscribers;
        }

        public Image GetRandomImage()
        {
            Image image = null;

            ISession session = NHibernateHelper.GetCurrentSession();

            string hql = "SELECT i.Id " +
                         "FROM Image i " +
                         "WHERE i.ShowRandom = 1";

            IQuery query = session.CreateQuery(hql);

            IList<int> imageIds = query.List<int>();

            if (imageIds.Count > 0)
            {
                int randomIndex = new Random().Next(0, imageIds.Count);
                image = session.Get<Image>(imageIds[randomIndex]);
            }

            return image;
        }

        public IList<BlogPageSimpleData> GetBlogPageListForBlog(int blogId)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            string hql = "SELECT p.PageNumber, p.PageName " +
                         "FROM BlogPage p " +
                         "WHERE p.Blog.Id = " + blogId + " " +
                         "ORDER BY p.PageNumber ASC";

            IQuery query = session.CreateQuery(hql);

            IList result = query.List();

            List<BlogPageSimpleData> pages = new List<BlogPageSimpleData>();

            foreach (object[] pageObj in result)
            {
                int pageNumber = (int)pageObj[0];
                string pageName = (string)pageObj[1];

                BlogPageSimpleData page = new BlogPageSimpleData(pageNumber, pageName);
                pages.Add(page);
            }

            return pages;
        }

        public Image GetImageFromId(int imageId)
        {
            return NHibernateHelper.GetCurrentSession().Get<Image>(imageId);
        }

        public TagData GetTagFromId(int tagId)
        {
            Tag tag = NHibernateHelper.GetCurrentSession().Get<Tag>(tagId);

            TagData tagData = null;

            if (tag != null)
            {
                tagData = new TagData(tag.Id, tag.TagName);
            }

            return tagData;
        }

        public IList<BlogItemListingData> GetTaggedBlogs(int tagId, int pageNumber, int recordsPerPage, out int totalRecords)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            int firstRecord = (pageNumber - 1) * recordsPerPage;
            int lastRecord = pageNumber * recordsPerPage;

            totalRecords = session.CreateCriteria(typeof(Blog))
                .Add(Restrictions.Eq("IsVisible", true))
                .SetProjection(Projections.Count("Id")).UniqueResult<int>();

            string hql = "SELECT b.Id, b.Title, b.Abstract, b.PostedDate, bt.Name, COUNT(images), COUNT(comments) " +
                         "FROM Blog AS b " +
                            "INNER JOIN b.BlogType AS bt " +
                            "INNER JOIN b.TaggedBlogs tb " +
                            "INNER JOIN tb.Tag t " +
                            "LEFT OUTER JOIN b.BlogComments AS comments " +
                            "LEFT OUTER JOIN b.Images AS images " +
                         "WHERE b.IsVisible = 1 " +
                            "AND t.Id = " + tagId + " " +
                            "AND comments.Approved = 1 " +
                         "GROUP BY b.Id, b.Title, b.Abstract, b.PostedDate, bt.Name " +
                         "ORDER BY b.PostedDate DESC";

            IQuery query = session.CreateQuery(hql);
            query.SetFirstResult(firstRecord);
            query.SetMaxResults(recordsPerPage);

            IList result = query.List();

            List<BlogItemListingData> blogs = new List<BlogItemListingData>();

            foreach (object[] blogObj in result)
            {
                int blogId = (int)blogObj[0];
                string title = (string)blogObj[1];
                string abstractText = (string)blogObj[2];
                DateTime postedDate = (DateTime)blogObj[3];
                string blogType = (string)blogObj[4];
                long numImages = (long)blogObj[5];
                long numComments = (long)blogObj[6];

                string tagHql = "SELECT t " +
                                "FROM Tag AS t " +
                                    "INNER JOIN t.TaggedBlogs AS tb " +
                                "WHERE tb.Blog.Id = " + blogId + " " +
                                "ORDER BY t.TagName ASC";

                IQuery tagQuery = session.CreateQuery(tagHql);
                IList<Tag> tags = tagQuery.List<Tag>();

                BlogItemListingData blog = new BlogItemListingData(blogId, title, blogType,
                    abstractText, postedDate, (int)numComments, (int)numImages);

                foreach (Tag tag in tags)
                {
                    blog.Tags.Add(new TagData(tag.Id, tag.TagName));
                }

                if (numImages > 0)
                {
                    blog.PreviewImage = session.CreateCriteria(typeof(Image))
                        .Add(Restrictions.Eq("Blog.Id", blog.Id))
                        .SetMaxResults(1)
                        .UniqueResult<Image>();
                }

                blogs.Add(blog);
            }

            return blogs;
        }

        public IList<BlogItemListingData> ListBlogs(int pageNumber, int recordsPerPage, out int totalRecords)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            int firstRecord = (pageNumber - 1) * recordsPerPage;
            int lastRecord = pageNumber * recordsPerPage;

            totalRecords = session.CreateCriteria(typeof(Blog))
                .Add(Restrictions.Eq("IsVisible", true))
                .SetProjection(Projections.Count("Id")).UniqueResult<int>();

            string hql = "SELECT b.Id, b.Title, b.Abstract, b.PostedDate, bt.Name, COUNT(DISTINCT images), COUNT(DISTINCT comments) " +
                         "FROM Blog AS b " +
                            "INNER JOIN b.BlogType AS bt " +
                            "LEFT OUTER JOIN b.BlogComments AS comments " +
                            "LEFT OUTER JOIN b.Images AS images " +
                         "WHERE b.IsVisible = 1 " +
                            "AND comments.Approved = 1 " +
                         "GROUP BY b.Id, b.Title, b.Abstract, b.PostedDate, bt.Name " +
                         "ORDER BY b.PostedDate DESC";

            IQuery query = session.CreateQuery(hql);
            query.SetFirstResult(firstRecord);
            query.SetMaxResults(recordsPerPage);

            IList result = query.List();

            List<BlogItemListingData> blogs = new List<BlogItemListingData>();

            foreach (object[] blogObj in result)
            {
                int blogId = (int)blogObj[0];
                string title = (string)blogObj[1];
                string abstractText = (string)blogObj[2];
                DateTime postedDate = (DateTime)blogObj[3];
                string blogType = (string)blogObj[4];
                long numImages = (long)blogObj[5];
                long numComments = (long)blogObj[6];

                string tagHql = "SELECT t " +
                                "FROM Tag AS t " +
                                    "INNER JOIN t.TaggedBlogs AS tb " +
                                "WHERE tb.Blog.Id = " + blogId + " " +
                                "ORDER BY t.TagName ASC";

                IQuery tagQuery = session.CreateQuery(tagHql);
                IList<Tag> tags = tagQuery.List<Tag>();

                BlogItemListingData blog = new BlogItemListingData(blogId, title, blogType,
                    abstractText, postedDate, (int)numComments, (int)numImages);

                foreach (Tag tag in tags)
                {
                    blog.Tags.Add(new TagData(tag.Id, tag.TagName));
                }

                if (numImages > 0)
                {
                    blog.PreviewImage = session.CreateCriteria(typeof(Image))
                        .Add(Restrictions.Eq("Blog.Id", blog.Id))
                        .SetMaxResults(1)
                        .UniqueResult<Image>();
                }

                blogs.Add(blog);
            }

            return blogs;
        }

        public Blog GetBlogFromId(int id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            return session.Get<Blog>(id);
        }

        public IList<Image> GetImagesForBlog(int blogId)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            return session.CreateCriteria(typeof(Image))
                .Add(Restrictions.Eq("Blog.Id", blogId))
                .List<Image>();
        }

        public BlogPageView GetBlogPage(int blogId, int pageNumber)
        {
            pageNumber = pageNumber < 0 ? 1 : pageNumber;

            ISession session = NHibernateHelper.GetCurrentSession();

            Blog blog = session.Get<Blog>(blogId);

            BlogPageView blogPageView = null;

            if (blog != null)
            {
                BlogPage page = session.CreateCriteria(typeof(BlogPage))
                    .Add(Restrictions.Eq("Blog.Id", blog.Id))
                    .Add(Restrictions.Eq("PageNumber", pageNumber))
                    .UniqueResult<BlogPage>();

                blogPageView = new BlogPageView();
                blogPageView.BlogId = blog.Id;
                blogPageView.BlogType = blog.BlogType.Name;
                blogPageView.Abstract = blog.Abstract;
                blogPageView.Title = blog.Title;
                blogPageView.PostedDate = blog.PostedDate;
                blogPageView.NumImages = blog.Images.Count;
                blogPageView.ShortTitle = blog.ShortTitle;

                IList<BlogComment> comments = blog.BlogComments.Where(c => c.Approved).ToList();

                blogPageView.NumComments = comments.Count;

                if (page != null)
                {
                    blogPageView.PageNumber = page.PageNumber;
                    blogPageView.PageName = page.PageName;
                    blogPageView.BlogText = page.TextContent;
                }

                blogPageView.Comments = LoadComments(comments
                    .Where(c => c.ParentComment == null)
                    .OrderByDescending(c => c.PostedDate)
                    .ToList());
            }

            return blogPageView;
        }

        private IList<CommentView> LoadComments(IList<BlogComment> comments)
        {
            List<CommentView> commentViews = new List<CommentView>();

            if (comments != null)
            {
                foreach (BlogComment comment in comments)
                {
                    CommentView commentView = new CommentView();
                    commentView.Id = comment.Id;
                    commentView.Title = comment.Title;
                    commentView.CommentText = comment.TextContent;
                    commentView.PostedDate = comment.PostedDate;
                    commentView.Author = comment.Author;
                    commentView.Website = comment.Website;
                    commentView.AdminComment = comment.IsAdminComment;

                    commentView.ChildComments = LoadComments(comment.ChildComments);

                    commentViews.Add(commentView);
                }
            }

            return commentViews;
        }

        public BlogComment ApproveComment(int commentId, string approvalKey)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            BlogComment comment = session.Get<BlogComment>(commentId);

            if (comment != null && (comment.ApprovalKey ?? "").Equals(approvalKey, StringComparison.InvariantCultureIgnoreCase))
            {
                comment.Approved = true;
                comment.ApprovalKey = null;

                session.SaveOrUpdate(comment);
                session.Flush();
            }

            return comment;
        }

        public void DeleteComment(int commentId, string approvalKey)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            BlogComment comment = session.Get<BlogComment>(commentId);

            if (comment != null && (comment.ApprovalKey ?? "").Equals(approvalKey, StringComparison.InvariantCultureIgnoreCase))
            {
                session.Delete(comment);
                session.Flush();
            }
        }

        public BlogComment CreateBlogComment(int blogId, int? parentCommentId, CommentForm commentForm)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            BlogComment comment = new BlogComment();
            comment.Author = commentForm.YourName;
            comment.EmailAddress = commentForm.EmailAddress;
            comment.EmailOnReply = commentForm.EmailOnReply;
            comment.Website = commentForm.Website.IsNullEmptyOrWhitespace() ? null : commentForm.Website;
            comment.Title = commentForm.Title;
            comment.TextContent = commentForm.CommentText;
            comment.PostedDate = DateTime.Now;
            comment.IsAdminComment = commentForm.IsAdminComment;
            comment.IPAddress = commentForm.IpAddress;
            comment.Approved = false;
            comment.ApprovalKey = Guid.NewGuid().ToString();

            Blog blog = session.Get<Blog>(blogId);

            if (blog != null)
            {
                comment.Blog = blog;

                if (parentCommentId != null)
                {
                    BlogComment parentComment = session.CreateCriteria(typeof(BlogComment))
                        .Add(Restrictions.Eq("Id", parentCommentId.Value))
                        .Add(Restrictions.Eq("Blog.Id", blogId))
                        .UniqueResult<BlogComment>();

                    if (parentComment != null)
                    {
                        comment.ParentComment = parentComment;
                    }
                }

                session.Save(comment);
                session.Flush();
                return comment;
            }

            return null;
        }
    }
}