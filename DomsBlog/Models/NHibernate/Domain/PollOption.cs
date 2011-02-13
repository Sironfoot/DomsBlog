using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Models.NHibernate.Domain
{
    public class PollOption
    {
        public virtual int Id { get; set; }
        public virtual string Answer { get; set; }
        public virtual int Votes { get; set; }
        public virtual int OrderIndex { get; set; }
        public virtual bool SuggestComment { get; set; }

        public virtual Poll Poll { get; set; }
    }
}