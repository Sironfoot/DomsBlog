using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomsBlog.Models.Service;

namespace DomsBlog.Models.Repositories
{
    public interface IPollRepository
    {
        int CreatePollComment(int pollId, int? parentCommentId, CommentForm commentForm);
        IList<PollView> GetPolls(int pageNumber, int recordsPerPage, out int totalRecords);
        PollDetailView GetPoll(int id);
        PollView GetLatestPoll();
        void RegisterVote(int pollOptionId);
    }
}