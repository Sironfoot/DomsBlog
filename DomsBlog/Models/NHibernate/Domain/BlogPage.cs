using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Models.NHibernate.Domain
{
    public class BlogPage
    {
        public virtual int Id { get; set; }
        public virtual string PageName { get; set; }
        public virtual int PageNumber { get; set; }
        public virtual string TextContent { get; set; }

        public virtual Blog Blog { get; set; }
    }
}