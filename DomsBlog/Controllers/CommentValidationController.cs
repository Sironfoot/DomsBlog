using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomsBlog.Models.Service;
using DomsBlog.Models.NHibernate.Domain;
using MvcLibrary.UrlTools;

namespace DomsBlog.Controllers
{
    public class CommentValidationController : MasterController
    {
        private IBlogService BlogService = null;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            BlogService = new BlogService(HttpContext);
        }

        public ActionResult Approve(int commentId, string guid)
        {
            BlogComment comment = BlogService.ApproveBlogComment(commentId, guid);

            if (comment != null)
            {
                return RedirectToAction("View", "Blog", new { id = comment.Blog.Id, blogTitle = comment.Blog.Title.ToFriendlyUrl() });
            }
            else
            {
                return Redirect("~/");
            }
        }

        public string Delete(int commentId, string guid)
        {
            BlogService.DeleteBlogComment(commentId, guid);

            return "Comment has been deleted";
        }
    }
}