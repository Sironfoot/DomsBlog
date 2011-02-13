using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Models.NHibernate.Domain
{
    public class TaggedBlog
    {
        public virtual int Id { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual Blog Blog { get; set; }
    }
}