using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Models.Service
{
    public class PollOptionDetailView
    {
        public string Answer { get; set; }
        public int Votes { get; set; }

        private decimal? _percentageOfTotal = null;
        public decimal PercentageOfTotal
        {
            get
            {
                if (_percentageOfTotal == null)
                {
                    int totalVotes = Poll.Options.Sum(o => o.Votes);

                    decimal percentage = totalVotes > 0 ? (100m / (decimal)totalVotes) * (decimal)this.Votes : 0m;

                    _percentageOfTotal = Math.Round(percentage, 1, MidpointRounding.AwayFromZero);
                }

                return _percentageOfTotal.Value;
            }
        }

        public PollDetailView Poll { get; set; }
    }

    public class PollDetailView
    {
        public string Question { get; set; }
        public DateTime DatePosted { get; set; }

        public IList<PollOptionDetailView> Options { get; set; }
        public IList<CommentView> Comments { get; set; }

        public int NumComments { get; set; }

        public CommentForm CommentForm { get; set; }

        public int TotalVotes
        {
            get
            {
                return Options.Sum(o => o.Votes);
            }
        }

        public CommentView ReplyComment { get; set; }
    }
}