using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Models.NHibernate.Domain
{
    public class Poll
    {
        public virtual int Id { get; set; }
        public virtual string Question { get; set; }
        public virtual DateTime PostedDate { get; set; }

        public virtual IList<PollOption> PollOptions { get; set; }
        public virtual IList<PollComment> PollComments { get; set; }
    }
}