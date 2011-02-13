using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Models.NHibernate.Domain
{
    public class BlogType
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<Blog> Blogs { get; set; }
    }
}