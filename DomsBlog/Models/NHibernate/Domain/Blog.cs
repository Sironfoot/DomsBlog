using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomsBlog.Models.Repositories;
using NHibernate.Mapping;

namespace DomsBlog.Models.NHibernate.Domain
{
    public class Blog
    {
        public virtual int Id { get; set; }
        public virtual string ShortTitle { get; set; }
        public virtual string Title { get; set; }
        public virtual string Abstract { get; set; }
        public virtual DateTime PostedDate { get; set; }
        public virtual bool IsVisible { get; set; }

        public virtual BlogType BlogType { get; set; }

        public virtual IList<BlogPage> BlogPages { get; set; }
        public virtual IList<BlogComment> BlogComments { get; set; }
        public virtual IList<Image> Images { get; set; }
        public virtual IList<TaggedBlog> TaggedBlogs { get; set; }

        public virtual int NumComments { get; set; }
        public virtual int NumImages { get; set; }
    }
}