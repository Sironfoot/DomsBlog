using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DomsBlog.Models.Service;
using System.Net;
using System.IO;
using System.Text;
using MvcLibrary.UrlTools;
using MvcLibrary.ActionResults;
using DomsBlog.Utils;

namespace DomsBlog.Controllers
{
    public class PollController : MasterController
    {
        //
        // POST: /Poll/Vote
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Vote(int? pollOptionId)
        {
            if (pollOptionId != null)
            {
                PollService.RegisterVote(pollOptionId.Value, Request, Response);
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Index()
        {
            int page = Int32.TryParse(Request.QueryString["page"], out page) ? page : 1;
            int totalRecords = 0;

            IList<PollView> polls = PollService.GetPreviousPolls(page, 10, out totalRecords);
            ViewData["totalRecords"] = totalRecords;

            return View(polls);
        }

        public ActionResult View(int id, string question)
        {
            int replyId = Int32.TryParse(Request.QueryString["replyId"], out replyId) ? replyId : -1;
            bool replyWithQuote = Boolean.TryParse(Request.QueryString["replyWithQuote"], out replyWithQuote) ? replyWithQuote : false;
            int commentFadeId = Int32.TryParse(Request.QueryString["fadeComment"], out commentFadeId) ? commentFadeId : -1;

            PollDetailView pollDetail = PollService.GetPoll(id, replyId, replyWithQuote, commentFadeId);

            string realTitle = UrlEncoder.ToFriendlyUrl(pollDetail.Question);
            string urlTitle = (question ?? "").Trim().ToLower();
            if (realTitle != urlTitle)
            {
                return new PermamentRedirectResult("/Poll/" + id + "/" + realTitle);
            }

            return View(pollDetail);
        }

        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult View(int id, string question, CommentForm comment)
        {
            ICaptchaService captchaService = new ReCaptchaService();
            comment.PassesCaptchaValidation = captchaService.PassesCaptcha(Request, BlogValues.CaptchaPrivateKey());

            int replyId = Int32.TryParse(Request.QueryString["replyId"], out replyId) ? replyId : -1;
            bool replyWithQuote = Boolean.TryParse(Request.QueryString["replyWithQuote"], out replyWithQuote) ? replyWithQuote : false;

            comment.ContainerId = id;
            comment.IpAddress = Request.UserHostAddress;
            comment.ParentCommentId = replyId != -1 ? (int?)replyId : null;

            int commentId = -1;

            if (comment.IsValid(new ModelStateWrapper(ModelState)))
            {
                commentId = PollService.CreatePollComment(comment);
                Response.Redirect("/Poll/" + id + "/" + question + "?fadeComment=" + commentId + "#comments");
            }

            PollDetailView pollDetail = PollService.GetPoll(id, -1, false, -1);
            pollDetail.CommentForm = comment;

            return View("View", pollDetail);
        }
    }
}