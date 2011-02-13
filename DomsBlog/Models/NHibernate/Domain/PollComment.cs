using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Models.NHibernate.Domain
{
    public class PollComment
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string TextContent { get; set; }
        public virtual string Author { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual bool EmailOnReply { get; set; }
        public virtual string Website { get; set; }
        public virtual string IPAddress { get; set; }
        public virtual bool IsAdminComment { get; set; }
        public virtual DateTime PostedDate { get; set; }

        public virtual Poll Poll { get; set; }

        public virtual PollComment ParentComment { get; set; }
        public virtual IList<PollComment> ChildComments { get; set; }
    }
}