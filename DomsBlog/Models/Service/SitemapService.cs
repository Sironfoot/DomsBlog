using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomsBlog.Models.ViewModels;
using DomsBlog.Models.Repositories;
using DomsBlog.Models.DataModels;

namespace DomsBlog.Models.Service
{
    public class SitemapService : ISitemapService
    {
        private IBlogRepository BlogRepository = null;
        private IPollRepository PollRepository = null;

        public SitemapService()
        {
            BlogRepository = RepositoryFactory.GetBlogRepository();
            PollRepository = RepositoryFactory.GetPollRepository();
        }

        public SitemapView GetSitemapForPage()
        {
            SitemapView sitemap = new SitemapView();

            int totalRecords = 0;
            IList<BlogItemListingData> blogItems = BlogRepository.ListBlogs(1, 20, out totalRecords);

            foreach (BlogItemListingData blogItem in blogItems)
            {
                sitemap.Blogs.Add(new SitemapView.Blog(blogItem.Id, blogItem.Title, blogItem.NumImages > 0));
            }

            IList<PollView> polls = PollRepository.GetPolls(1, 20, out totalRecords);

            foreach (PollView poll in polls)
            {
                sitemap.Polls.Add(new SitemapView.Poll(poll.Id, poll.Question));
            }

            return sitemap;
        }
    }
}