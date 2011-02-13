using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomsBlog.Models.Repositories;
using MvcLibrary.ActionResults;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MvcLibrary.UrlTools;
using MvcLibrary.Extensions;
using DomsBlog.Models.ViewModels;
using DomsBlog.Models.DataModels;
using DomsBlog.Models.NHibernate.Domain;
using System.Net.Mail;
using DomsBlog.Utils;
using System.Text.RegularExpressions;

namespace DomsBlog.Models.Service
{
    public class BlogService : IBlogService
    {
        private IBlogRepository BlogRepository = null;
        private HttpContextBase HttpContext = null;

        public BlogService(HttpContextBase httpContext)
        {
            BlogRepository = RepositoryFactory.GetBlogRepository();
            this.HttpContext = httpContext;
        }

        public string GetBlogTitle(int blogId)
        {
            return BlogRepository.GetBlogTitle(blogId);
        }

        public BlogListingView GetTaggedBlogsForFrontPage(int tagId, int pageNumber, int recordsPerPage, out TagData tag)
        {
            tag = BlogRepository.GetTagFromId(tagId);

            int totalRecords = 0;
            IList<BlogItemListingData> blogItems = BlogRepository.GetTaggedBlogs(tagId, pageNumber, recordsPerPage, out totalRecords);

            BlogListingView blogListing = new BlogListingView(pageNumber, recordsPerPage, totalRecords);

            foreach (BlogItemListingData blog in blogItems)
            {
                BlogListingView.BlogItemView blogItem = new BlogListingView.BlogItemView(blog.Id, blog.Title,
                    blog.PostedDate, blog.NumComments, blog.NumImages, blog.BlogType, blog.AbstractText);

                foreach (TagData tagData in blog.Tags)
                {
                    blogItem.Tags.Add(new BlogListingView.TagView(tagData.Id, tagData.TagName));
                }

                blogListing.Blogs.Add(blogItem);
            }

            return blogListing;
        }

        public BlogListingView ListBlogsForFrontPage(int pageNumber, int recordsPerPage)
        {
            int totalRecords = 0;
            IList<BlogItemListingData> blogItems = BlogRepository.ListBlogs(pageNumber, recordsPerPage, out totalRecords);

            BlogListingView blogListing = new BlogListingView(pageNumber, recordsPerPage, totalRecords);

            foreach (BlogItemListingData blog in blogItems)
            {
                BlogListingView.BlogItemView blogItem = new BlogListingView.BlogItemView(blog.Id, blog.Title,
                    blog.PostedDate, blog.NumComments, blog.NumImages, blog.BlogType, blog.AbstractText);

                foreach (TagData tagData in blog.Tags)
                {
                    blogItem.Tags.Add(new BlogListingView.TagView(tagData.Id, tagData.TagName));
                }

                if (blog.PreviewImage != null)
                {
                    Image image = blog.PreviewImage;
                    blogItem.PreviewImage = new BlogListingView.PreviewImageView(image.Id, image.FileName, image.Caption, image.AltText);
                }

                blogListing.Blogs.Add(blogItem);
            }

            return blogListing;
        }

        public BlogPageView GetBlogPage(int blogId, int pageNumber, int replyId, bool replyIsQuote, int commentFadeId)
        {
            BlogPageView blogPage = BlogRepository.GetBlogPage(blogId, pageNumber);

            blogPage.BlogPages = BlogRepository.GetBlogPageListForBlog(blogId);

            blogPage.BlogText = BBDecoding.DecodeBlogText(blogPage.BlogText);

            foreach (Match match in Regex.Matches(blogPage.BlogText, @"\[image id=&quot;([0-9]+)&quot; position=&quot;(left|right|center)&quot;\]"))
            {
                int imageId = Int32.TryParse(match.Groups[1].Value, out imageId) ? imageId : -1;

                string cssClass = "";
                switch (match.Groups[2].Value)
                {
                    case "center":
                        cssClass = "ImageClear";
                        break;
                    case "right":
                        cssClass = "ImageFloatRight";
                        break;
                    default:
                        cssClass = "ImageFloatLeft";
                        break;
                }

                Image image = BlogRepository.GetImageFromId(imageId);

                if (image != null)
                {
                    string html = "<a href=\"/Images/" + image.Id + "/" + image.FileName + "\">" +
                        "<img class=\"" + cssClass + "\" alt=\"" + HttpUtility.HtmlAttributeEncode(image.AltText) + "\" title=\"" +
                            HttpUtility.HtmlAttributeEncode(image.Caption) + "\" src=\"/Images/" +
                            image.Id + "/thumb_" + image.FileName + "\" />" +
                        "</a>";

                    blogPage.BlogText = blogPage.BlogText.Replace(match.Value, html);
                }
                else
                {
                    blogPage.BlogText = blogPage.BlogText.Replace(match.Value, "");
                }
            }

            CommentView commentToFade = FindCommentInTree(blogPage.Comments, commentFadeId);
            if (commentToFade != null)
            {
                commentToFade.HighlightMe = true;
            }

            if (replyId == -1)
            {
                blogPage.CommentForm.Title = "RE: " + blogPage.ShortTitle;
            }
            else
            {
                CommentView replyComment = FindCommentInTree(blogPage.Comments, replyId);
                blogPage.ReplyComment = replyComment;

                if (replyComment != null)
                {
                    blogPage.CommentForm.Title = "RE: " + replyComment.Title;
                    blogPage.CommentForm.ReplyComment = replyComment;

                    if (replyIsQuote)
                    {
                        blogPage.CommentForm.CommentText =
                            "[quote author=\"" + replyComment.Author + "\"]\n" + replyComment.CommentText + "\n[/quote]";
                    }
                }
            }

            return blogPage;
        }

        private CommentView FindCommentInTree(IList<CommentView> comments, int commentId)
        {
            CommentView comment = comments.SingleOrDefault(c => c.Id == commentId);

            if (comment == null)
            {
                foreach (CommentView childComment in comments)
                {
                    comment = FindCommentInTree(childComment.ChildComments, commentId);

                    if (comment != null)
                    {
                        break;
                    }
                }
            }

            return comment;
        }

        public int CreateBlogComment(int blogId, int? parentCommentId, CommentForm comment)
        {
            comment.IpAddress = HttpContext.Request.UserHostAddress;
            comment.ContainerId = blogId;
            comment.IsAdminComment = false;
            comment.ParentCommentId = parentCommentId;

            comment.YourName = comment.YourName.IsNullEmptyOrWhitespace() ? "Anonymous" : comment.YourName;

            IList<CommentSubscriber> subscribers = BlogRepository.GetCommentSubscribers(blogId);

            int commentId = BlogRepository.CreateBlogComment(blogId, parentCommentId, comment);

            if (subscribers.Count > 0)
            {
                MailAddress from = new MailAddress("NO.REPLY@dominicpettifer.co.uk", "DominicPettifer.co.uk");

                Blog blog = BlogRepository.GetBlogFromId(blogId);
                if (blog != null)
                {
                    string subject = "New Comment for blog '" + blog.ShortTitle + "'";
                    string emailMessage = "Hello '##AUTHOR##'\n" +
                                          "\n" +
                                          "A new comment has been posted at DominicPettifer.co.uk for the blog '" +
                                            blog.Title + "', and you have chosen to receive these notifications.\n" +
                                          "\n" +
                                          "You can see the comments at http://www.dominicpettifer.co.uk/Blog/" +
                                            blog.Id + "/" + blog.Title.ToFriendlyUrl() + "#comments\n" +
                                          "\n" +
                                          "Yours\n" +
                                          "\n" +
                                          "Dominic Pettifer";

                    foreach (CommentSubscriber subscriber in subscribers)
                    {
                        string author = subscriber.Author.IsNullEmptyOrWhitespace() ? "Anonymous" : subscriber.Author;

                        // TODO: Put this behind an interface
                        MailAddress to = new MailAddress(subscriber.EmailAddress);

                        MailMessage message = new MailMessage();
                        message.From = from;
                        message.To.Add(to);
                        message.Subject = subject;
                        message.Body = emailMessage.Replace("##AUTHOR##", author);
                        message.IsBodyHtml = false;

                        SmtpClient client = new SmtpClient();
                        client.SendAsync(message, null);
                    }
                }
            }

            return commentId;
        }

        public RssFeed GetRssBlogFeed(int maxRecords, string webAddress, string blogUrl)
        {
            int totalRecords = 0;
            IList<BlogItemListingData> blogs = BlogRepository.ListBlogs(1, maxRecords, out totalRecords);

            List<RssItem> rssItems = (from b in blogs
                                      select new RssItem(b.Title,
                                          String.Format(blogUrl, b.Id, UrlEncoder.ToFriendlyUrl(b.Title)),
                                          b.AbstractText)
                                      {
                                          Author = "Dominic Pettifer",
                                          PudDate = b.PostedDate
                                      }).ToList();

            return new RssFeed("Dominic's Latest Blogs",
                "C#, ASP.NET, Silverlight, XHTML+CSS, MVC, SEO, Ajax and more...",
                webAddress, rssItems);
        }

        public BlogImagesView GetBlogImagesPage(int blogId)
        {
            BlogImagesView blogImages = null;

            BlogPageView blogPage = BlogRepository.GetBlogPage(blogId, 1);

            if (blogPage != null)
            {
                blogImages = new BlogImagesView(blogPage.BlogId, blogPage.ShortTitle, blogPage.Title, blogPage.PostedDate, blogPage.BlogType,
                    blogPage.Abstract, blogPage.NumImages, blogPage.NumComments);

                IList<Image> images = BlogRepository.GetImagesForBlog(blogId);

                foreach (Image image in images)
                {
                    ImageView imageView = new ImageView(image.Id, image.AltText, image.Caption, image.FileName);
                    blogImages.BlogImages.Add(imageView);
                }
            }

            return blogImages;
        }
    }
}