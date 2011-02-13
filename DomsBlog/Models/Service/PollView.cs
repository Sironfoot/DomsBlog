using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Models.Service
{
    public class PollView
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int NumComments { get; set; }
        public DateTime PostedDate { get; set; }
        public IList<PollOptionView> Options{ get; set; }

        public int TotalVotes
        {
            get
            {
                return Options.Sum(o => o.Votes);
            }
        }

        public bool ResultsMode { get; set; }
    }
}