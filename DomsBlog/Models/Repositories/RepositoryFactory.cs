using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Models.Repositories
{
    public static class RepositoryFactory
    {
        public static IBlogRepository GetBlogRepository()
        {
            return new NHibernateBlogRepository();
        }

        public static IPollRepository GetPollRepository()
        {
            return new NHibernatePollRepository();
        }
    }
}