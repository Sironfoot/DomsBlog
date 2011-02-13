using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomsBlog.Models.Service;
using NHibernate;
using DomsBlog.Models.NHibernate;
using DomsBlog.Models.NHibernate.Domain;
using NHibernate.Criterion;
using MvcLibrary.Extensions;

namespace DomsBlog.Models.Repositories
{
    public class NHibernatePollRepository : IPollRepository
    {
        public int CreatePollComment(int pollId, int? parentCommentId, CommentForm commentForm)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            PollComment comment = new PollComment();
            comment.Author = commentForm.YourName;
            comment.EmailAddress = commentForm.EmailAddress;
            comment.Website = commentForm.Website.IsNullEmptyOrWhitespace() ? null : commentForm.Website;
            comment.Title = commentForm.Title;
            comment.TextContent = commentForm.CommentText;
            comment.PostedDate = DateTime.Now;
            comment.IsAdminComment = commentForm.IsAdminComment;
            comment.IPAddress = commentForm.IpAddress;

            Poll poll = session.Get<Poll>(pollId);

            if (poll != null)
            {
                comment.Poll = poll;

                if (parentCommentId != null)
                {
                    PollComment parentComment = session.CreateCriteria(typeof(PollComment))
                        .Add(Restrictions.Eq("Id", parentCommentId.Value))
                        .Add(Restrictions.Eq("Poll.Id", pollId))
                        .UniqueResult<PollComment>();

                    if (parentComment != null)
                    {
                        comment.ParentComment = parentComment;
                    }
                }

                session.Save(comment);
                session.Flush();
                return comment.Id;
            }

            return -1;
        }

        public IList<PollView> GetPolls(int pageNumber, int recordsPerPage, out int totalRecords)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            int firstRecord = ((pageNumber - 1) * recordsPerPage);

            IList<Poll> polls = session.CreateCriteria(typeof(Poll))
                                    .AddOrder(Order.Desc("PostedDate"))
                                    .SetFirstResult(firstRecord)
                                    .SetMaxResults(recordsPerPage)
                                    .List<Poll>();

            totalRecords = session.CreateCriteria(typeof(Poll))
                                .SetProjection(Projections.Count("Id"))
                                .UniqueResult<int>();

            List<PollView> pollViews = new List<PollView>(recordsPerPage);

            foreach (Poll poll in polls)
            {
                PollView pollView = new PollView();
                pollView.Id = poll.Id;
                pollView.Question = poll.Question;
                pollView.PostedDate = poll.PostedDate;
                pollView.NumComments = session.CreateCriteria(typeof(PollComment))
                    .Add(Restrictions.Eq("Poll.Id", poll.Id))
                    .SetProjection(Projections.Count("Id"))
                    .UniqueResult<int>();
                pollView.ResultsMode = true;
                pollView.Options = (from o in poll.PollOptions
                                    orderby o.Votes descending
                                    select new PollOptionView()
                                    {
                                        Id = o.Id,
                                        Answer = o.Answer,
                                        Poll = pollView,
                                        Votes = o.Votes,
                                        SuggestComment = o.SuggestComment
                                    }).ToList();

                pollViews.Add(pollView);
            }

            return pollViews;
        }

        public PollDetailView GetPoll(int id)
        {
            PollDetailView pollDetail = null;

            ISession session = NHibernateHelper.GetCurrentSession();

            Poll poll = session.Get<Poll>(id);

            if (poll != null)
            {
                pollDetail = new PollDetailView();
                pollDetail.Question = poll.Question;
                pollDetail.DatePosted = poll.PostedDate;
                pollDetail.Options = new List<PollOptionDetailView>();

                foreach (PollOption option in poll.PollOptions.OrderByDescending(po => po.Votes))
                {
                    PollOptionDetailView optionDetail = new PollOptionDetailView();
                    optionDetail.Answer = option.Answer;
                    optionDetail.Poll = pollDetail;
                    optionDetail.Votes = option.Votes;

                    pollDetail.Options.Add(optionDetail);
                }

                IList<PollComment> comments = poll.PollComments;

                pollDetail.NumComments = comments.Count;

                pollDetail.Comments = LoadComments(comments
                    .Where(c => c.ParentComment == null)
                    .OrderByDescending(c => c.PostedDate)
                    .ToList());
            }

            return pollDetail;
        }

        private IList<CommentView> LoadComments(IList<PollComment> comments)
        {
            List<CommentView> commentViews = new List<CommentView>();

            if (comments != null)
            {
                foreach (PollComment comment in comments)
                {
                    CommentView commentView = new CommentView();
                    commentView.Id = comment.Id;
                    commentView.Title = comment.Title;
                    commentView.CommentText = comment.TextContent;
                    commentView.PostedDate = comment.PostedDate;
                    commentView.Author = comment.Author;
                    commentView.Website = comment.Website;
                    commentView.AdminComment = comment.IsAdminComment;

                    commentView.ChildComments = LoadComments(comment.ChildComments);

                    commentViews.Add(commentView);
                }
            }

            return commentViews;
        }

        public PollView GetLatestPoll()
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            string hql = "FROM Poll p " +
                         "ORDER BY p.PostedDate DESC";

            IQuery query = session.CreateQuery(hql);
            query.SetMaxResults(1);

            Poll poll = query.UniqueResult<Poll>();

            PollView latestPoll = new PollView();
            latestPoll.Id = poll.Id;
            latestPoll.Question = poll.Question;
            latestPoll.Options = new List<PollOptionView>();
            latestPoll.PostedDate = poll.PostedDate;
            latestPoll.NumComments = session.CreateCriteria(typeof(PollComment))
                .Add(Restrictions.Eq("Poll.Id", poll.Id))
                .SetProjection(Projections.Count("Id"))
                .UniqueResult<int>();

            foreach (PollOption option in poll.PollOptions.OrderBy(po => po.OrderIndex))
            {
                PollOptionView optionView = new PollOptionView();
                optionView.Answer = option.Answer;
                optionView.Id = option.Id;
                optionView.Votes = option.Votes;
                optionView.SuggestComment = option.SuggestComment;
                optionView.Poll = latestPoll;

                latestPoll.Options.Add(optionView);
            }

            return latestPoll;
        }

        public void RegisterVote(int pollOptionId)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            PollOption option = session.Get<PollOption>(pollOptionId);

            if (option != null)
            {
                option.Votes++;
                session.SaveOrUpdate(option);
                session.Flush();
            }
        }
    }
}