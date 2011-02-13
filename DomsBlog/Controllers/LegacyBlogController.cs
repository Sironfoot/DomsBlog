using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DomsBlog.Models.NHibernate.Domain;
using DomsBlog.Models.Service;
using MvcLibrary.ActionResults;
using MvcLibrary.UrlTools;

namespace DomsBlog.Controllers
{
    public class LegacyBlogController : MasterController
    {
        private IBlogService BlogService = null;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            BlogService = new BlogService(HttpContext);
        }

        public ActionResult ViewBlog(int id, int? page)
        {
            string title = BlogService.GetBlogTitle(id);

            string url = Url.Action("View", "Blog", new { id = id, blogTitle = title.ToFriendlyUrl(), page = page });

            return new PermamentRedirectResult(url);
        }

        public ActionResult ViewComments(int id)
        {
            string title = BlogService.GetBlogTitle(id);

            string url = Url.Action("View", "Blog", new { id = id, blogTitle = title.ToFriendlyUrl() });

            return new PermamentRedirectResult(url + "#comments");
        }

        public ActionResult LeaveComment(int id)
        {
            string title = BlogService.GetBlogTitle(id);

            string url = Url.Action("View", "Blog", new { id = id, blogTitle = title.ToFriendlyUrl() });

            return new PermamentRedirectResult(url + "#postcomment");
        }

        public ActionResult ProcessLegacyUrl(string page)
        {
            switch ((page ?? "").Trim().ToLower())
            {
                case "about":
                    return new PermamentRedirectResult(Url.Action("Index", "Ego"));
                case "cv":
                    return new PermamentRedirectResult(Url.Action("CV", "Ego"));
                case "links":
                    return new PermamentRedirectResult(Url.Action("Index", "Links"));
                case "portfolio":
                    return new PermamentRedirectResult(Url.Action("Index", "Portfolio"));
                case "menorcanmagic":
                    return new PermamentRedirectResult(Url.Action("Detail", "Portfolio", new { name = "Private-Menorca" }));
                case "asissas":
                    return new PermamentRedirectResult(Url.Action("Detail", "Portfolio", new { name = "SCRI-Seed-Archive-System" }));
                case "domsblog":
                    return new PermamentRedirectResult(Url.Action("Detail", "Portfolio", new { name = "Dominics-Blog" }));
                case "blueislandsun":
                    return new PermamentRedirectResult(Url.Action("Detail", "Portfolio", new { name = "Blue-Island-Sun" }));
                default:
                    return View("404");
            }
        }
    }
}