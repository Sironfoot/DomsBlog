using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Models.NHibernate.Domain
{
    public class Image
    {
        public virtual int Id { get; set; }
        public virtual string FileName { get; set; }
        public virtual string Caption { get; set; }
        public virtual string AltText { get; set; }
        public virtual bool ShowRandom { get; set; }

        public virtual Blog Blog { get; set; }
    }
}