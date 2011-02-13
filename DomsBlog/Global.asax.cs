using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DomsBlog.Models.NHibernate;
using MvcLibrary;

namespace DomsBlog
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            this.BeginRequest += new EventHandler(MvcApplication_BeginRequest);
            this.EndRequest += new EventHandler(MvcApplication_EndRequest);
            this.Disposed += new EventHandler(MvcApplication_Disposed);
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Links",
                "Links/{action}/{name}",
                new { controller = "Links", action = "Index", name = "" }
            );

            routes.MapRoute(
                "Portfolio",
                "Portfolio",
                new { controller = "Portfolio", action = "Index" }
            );

            routes.MapRoute(
                "PortfolioDetail",
                "Portfolio/{name}",
                new { controller = "Portfolio", action = "Detail", name = "" }
            );


            routes.MapRoute(
                "Ego",
                "About/{action}/{name}",
                new { controller = "Ego", action = "Index", name = "" }
            );

            routes.MapRoute(
                "PollVote",
                "Poll/Vote",
                new { controller = "Poll", action = "Vote" }
            );

            routes.MapRoute(
                "Polls",
                "Poll/{id}/{question}",
                new { controller = "Poll", action = "View", id = "", question = "" }
            );

            routes.MapRoute(
                "PollList",
                "Polls",
                new { controller = "Poll", action = "Index" }
            );

            routes.MapRoute(
                "RSS",
                "Feeds/{action}/{id}/{name}",
                new { controller = "Rss", action = "LatestBlogs", id = "", name = "" }
            );

            routes.MapRoute(
                "TaggedBlogs",
                "Blogs/TaggedWith/{tag}/{id}",
                new { controller = "Blog", action = "TaggedWith", tag = "", id = "" }
            );

            routes.MapRoute(
                "ViewBlog",
                "Blog/{id}/{blogTitle}",
                new { controller = "Blog", action = "View", id = "", blogTitle = "" }
            );

            routes.MapRoute(
                "ViewBlogImages",
                "Blog/{id}/{blogTitle}/Images",
                new { controller = "Blog", action = "ViewImages", id = "", blogTitle = "" }
            );

            routes.MapRoute("LegacyBlog", "displayBlog.aspx",
                new { controller = "LegacyBlog", action = "ViewBlog" });
            routes.MapRoute("LegacyBlogComments", "displayComments.aspx",
                new { controller = "LegacyBlog", action = "ViewComments" });
            routes.MapRoute("LegacyLeaveComment", "leaveComment.aspx",
                new { controller = "LegacyBlog", action = "LeaveComment" });
            routes.MapRoute("LegacyUrls", "{page}.aspx",
                new { controller = "LegacyBlog", action = "ProcessLegacyUrl", page = "" });

            routes.MapRoute(
                "Root",
                "",
                new { controller = "Blog", action = "Index" }
                );

            routes.MapRoute(
               "Error",
               "{*url}",
               new { controller = "Error", action = "Process", code = "404" }
           );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }

        private void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            ExecutionTimer.StartTimer();
        }

        private void MvcApplication_EndRequest(object sender, EventArgs e)
        {
            NHibernateHelper.CloseSession();
        }

        private void MvcApplication_Disposed(object sender, EventArgs e)
        {
            NHibernateHelper.CloseSessionFactory();
        }
    }
}