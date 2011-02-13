using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Models.Service
{
    public interface IPollService
    {
        IList<PollView> GetPreviousPolls(int pageNumber, int recordsPerPage, out int totalRecords);
        PollDetailView GetPoll(int id, int replyId, bool replyIsQuote, int commentFadeId);
        PollView GetLatestPoll(HttpRequestBase request);
        void RegisterVote(int pollOptionId, HttpRequestBase request, HttpResponseBase response);
        int CreatePollComment(CommentForm commentForm);
    }
}