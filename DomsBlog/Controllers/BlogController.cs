using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DomsBlog.Models.NHibernate.Domain;
using DomsBlog.Models.Service;
using DomsBlog.Models.Repositories;
using MvcLibrary.UrlTools;
using MvcLibrary.ActionResults;
using DomsBlog.Models.DataModels;
using DomsBlog.Models.ViewModels;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;
using DomsBlog.Utils;

namespace DomsBlog.Controllers
{
    [ValidateInput(false)]
    public class BlogController : MasterController
    {
        private IBlogService BlogService = null;

        public BlogController()
        {
            
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            BlogService = new BlogService(HttpContext);
        }

        //
        // GET: /Blog/
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index(int? page)
        {
            if (page != null && page.Value == 1)
            {
                return new PermamentRedirectResult("/");
            }

            return View(BlogService.ListBlogsForFrontPage(page != null ? page.Value : 1, 10));
        }

        public ActionResult TaggedWith(string tag, int id, int? page)
        {
            if (page != null && page.Value == 1)
            {
                return new PermamentRedirectResult("/");
            }

            TagData tagData = null;
            BlogListingView blogListing = BlogService.GetTaggedBlogsForFrontPage(id, page != null ? page.Value : 1, 10, out tagData);

            string urlFriendlyTagName = tagData.TagName.ToFriendlyUrl();

            if(tag == null)
            {
                RedirectToAction("Index");
            }
            else if(urlFriendlyTagName != tag)
            {
                return new PermamentRedirectResult(Url.Action("TaggedWith", new { tag = urlFriendlyTagName, id = tagData.Id }));
            }

            ViewData["TagName"] = tagData.TagName;

            return View("TaggedBlogs", blogListing);
        }

        //
        // GET: /Blog/Details/5
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult View(int? id, string blogTitle, int? page)
        {
            int replyId = Int32.TryParse(Request.QueryString["replyId"], out replyId) ? replyId : -1;
            bool replyWithQuote = Boolean.TryParse(Request.QueryString["replyWithQuote"], out replyWithQuote) ? replyWithQuote : false;

            bool commentApproval = Boolean.TryParse(Request.QueryString["awaitingApproval"], out commentApproval) ? commentApproval : false;

            BlogPageView blogPageView = BlogService.GetBlogPage(id.Value, page != null ? page.Value : 1,
                replyId, replyWithQuote, commentApproval);

            string realTitle = UrlEncoder.ToFriendlyUrl(blogPageView.Title);
            string urlTitle = (blogTitle ?? "").Trim().ToLower();
            if (realTitle != urlTitle)
            {
                return new PermamentRedirectResult("/Blog/" + blogPageView.BlogId + "/" + realTitle);
            }

            return View(blogPageView);
        }

        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult View(int id, string blogTitle, CommentForm comment)
        {
            ICaptchaService captchaService = new ReCaptchaService();
            comment.PassesCaptchaValidation = captchaService.PassesCaptcha(Request, BlogValues.CaptchaPrivateKey());

            int replyId = Int32.TryParse(Request.QueryString["replyId"], out replyId) ? replyId : -1;
            bool replyWithQuote = Boolean.TryParse(Request.QueryString["replyWithQuote"], out replyWithQuote) ? replyWithQuote : false;
            int pageNumber = Int32.TryParse(Request.QueryString["page"], out pageNumber) ? pageNumber : 1;

            if (comment.IsValid(new ModelStateWrapper(this.ModelState)))
            {
                BlogService.CreateBlogComment(id, replyId != -1 ? (int?)replyId : null, comment);
                Response.Redirect("/Blog/" + id + "/" + blogTitle + "?awaitingApproval=true#postcomment");
            }

            BlogPageView blogPageView = BlogService.GetBlogPage(id, pageNumber, replyId, replyWithQuote, false);
            blogPageView.CommentForm = comment;

            return View("View", blogPageView);
        }

        public ActionResult ViewImages(int id, string blogTitle)
        {
            return View(BlogService.GetBlogImagesPage(id));
        }
    }
}