using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Models.Service
{
    public class PollOptionView
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int Votes { get; set; }
        public bool SuggestComment { get; set; }

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

        public PollView Poll { get; set; }
    }
}