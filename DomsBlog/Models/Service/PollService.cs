using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomsBlog.Models.Repositories;
using MvcLibrary.Extensions;

namespace DomsBlog.Models.Service
{
    public class PollService : IPollService
    {
        IPollRepository PollRepository = null;

        public PollService()
        {
            PollRepository = RepositoryFactory.GetPollRepository();
        }

        public IList<PollView> GetPreviousPolls(int pageNumber, int recordsPerPage, out int totalRecords)
        {
            return PollRepository.GetPolls(pageNumber, recordsPerPage, out totalRecords);
        }

        public PollDetailView GetPoll(int id, int replyId, bool replyIsQuote, int commentFadeId)
        {
            PollDetailView detailView = PollRepository.GetPoll(id);

            CommentView commentToFade = FindCommentInTree(detailView.Comments, commentFadeId);
            if (commentToFade != null)
            {
                commentToFade.HighlightMe = true;
            }

            detailView.CommentForm = new CommentForm();

            if (replyId == -1)
            {
                detailView.CommentForm.Title = "RE: " + detailView.Question;
            }
            else
            {
                CommentView replyComment = FindCommentInTree(detailView.Comments, replyId);
                detailView.ReplyComment = replyComment;

                if (replyComment != null)
                {
                    detailView.CommentForm.Title = "RE: " + replyComment.Title;
                    detailView.CommentForm.ReplyComment = replyComment;

                    if (replyIsQuote)
                    {
                        detailView.CommentForm.CommentText =
                            "[quote author=\"" + replyComment.Author + "\"]\n" + replyComment.CommentText + "\n[/quote]";
                    }
                }
            }

            return detailView;
        }

        private CommentView FindCommentInTree(IList<CommentView> comments, int commentId)
        {
            CommentView comment = comments.SingleOrDefault(c => c.Id == commentId);

            if (comment == null)
            {
                foreach (CommentView childComment in comments)
                {
                    comment = FindCommentInTree(childComment.ChildComments, commentId);

                    if (comment != null)
                    {
                        break;
                    }
                }
            }

            return comment;
        }

        public PollView GetLatestPoll(HttpRequestBase request)
        {
            PollView latestPoll = PollRepository.GetLatestPoll();

            int totalVotes = latestPoll.Options.Sum(o => o.Votes);

            HttpCookie cookie = request.Cookies["PollVote"];
            if (cookie != null)
            {
                int lastVotedPollId = Int32.TryParse(cookie.Value, out lastVotedPollId) ? lastVotedPollId : -1;
                if (lastVotedPollId == latestPoll.Id)
                {
                    latestPoll.ResultsMode = true;
                }
                else
                {
                    latestPoll.ResultsMode = false;
                }
            }

            bool showResults = Boolean.TryParse(request.QueryString["showResults"], out showResults) ? showResults : false;
            if (showResults)
            {
                latestPoll.ResultsMode = true;
            }

            return latestPoll;
        }

        public void RegisterVote(int pollOptionId, HttpRequestBase request, HttpResponseBase response)
        {
            // Make sure pollOptionId corresponds to a PollOption inside the current latest Poll
            PollView latestPoll = PollRepository.GetLatestPoll();
            if (latestPoll != null && latestPoll.Options.Any(o => o.Id == pollOptionId))
            {
                // Check if user is allowed to vote by way of a cookie
                HttpCookie cookie = request.Cookies["PollVote"];
                if (cookie != null)
                {
                    int lastVotedPollId = Int32.TryParse(cookie.Value, out lastVotedPollId) ? lastVotedPollId : -1;
                    if (lastVotedPollId != latestPoll.Id)
                    {
                        cookie.Value = latestPoll.Id.ToString();
                        response.Cookies.Add(cookie);
                        PollRepository.RegisterVote(pollOptionId);
                    }
                }
                else
                {
                    cookie = new HttpCookie("PollVote", latestPoll.Id.ToString());
                    cookie.Expires = DateTime.Now.AddYears(10);
                    response.Cookies.Add(cookie);
                    PollRepository.RegisterVote(pollOptionId);
                }
            }
        }

        public int CreatePollComment(CommentForm commentForm)
        {
            commentForm.YourName = commentForm.YourName.IsNullEmptyOrWhitespace() ? "Anonymous" : commentForm.YourName;
            commentForm.IsAdminComment = false;

            return PollRepository.CreatePollComment(commentForm.ContainerId, commentForm.ParentCommentId, commentForm);
        }
    }
}