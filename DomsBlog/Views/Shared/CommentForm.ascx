<%@ Import Namespace="DomsBlog.Utils" %>
<%@ Import Namespace="MvcLibrary.Extensions" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DomsBlog.Models.Service.CommentForm>" %>

<h2 id="postcomment">Leave a Comment</h2>
        
<% if (Model.ReplyComment != null) { %>

    <div class="CommentReplyView qjYellowFade">
        <h3>
            In Reply to comment by
            <strong>"<%= Model.ReplyComment.Author.IsNullEmptyOrWhitespace() ? "Anonymous" : Html.Encode(Model.ReplyComment.Author) %>"</strong>
        </h3>
        <p><%= BBDecoding.DecodeBlogCommentText(Model.ReplyComment.CommentText)%></p>
    </div>

<% } %>

<form action="#postcomment" method="post">
    <fieldset class="StandardForm">
        <legend>Comment Details</legend>
        
        <div class="FormRow">
            <label for="YourName">Your Name:</label>
            <%= Html.TextBox("YourName", Model.YourName)%>
            <%= Html.ValidationMessage("YourName")%>
        </div>
        
        <div class="FormRow">
            <label for="Website">Website:</label>
            <%= Html.TextBox("Website")%>
            <%= Html.ValidationMessage("Website")%>
        </div>
        
        <div class="FormRowCheckBox">
            <%= Html.CheckBox("EmailOnReply", Model.EmailOnReply)%>
            <label for="EmailOnReply">Email me when someone replies</label>
        </div>
        
        <div class="FormRow">
            <label for="EmailAddress">Email Address:</label>
            <%= Html.TextBox("EmailAddress", Model.EmailAddress)%>
            <%= Html.ValidationMessage("EmailAddress")%>
        </div>

        
        
        <div class="FormRow CommentTitleFormRow">
            <label for="Title">Title:</label>
            <%= Html.TextBox("Title", Model.Title)%> *
            <%= Html.ValidationMessage("Title")%>
        </div>
        
        <div class="FormRow">
            <label for="CommentText">Comment:</label>
            <%= Html.TextArea("CommentText", Model.CommentText, new { cols = "50", rows = "10" })%> *
            <%= Html.ValidationMessage("CommentText", Model.CommentText)%>
            <span class="BBCodeInstruction">
                <strong>BBCode:</strong> [b]bold[/b], [i]italics[/i], [code]code[/code], [li]bullet&nbsp;point[/li],
                [h]Heading[/h], [url="http://www.example.com"]link[/url], [quote&nbsp;author="John&nbsp;Smith"]quote[/quote]
            </span>
        </div>
        
        <div class="FormRowCaptcha">
            <label>Anti-spam Test</label>
        
            <% Html.RenderPartial("ReCaptcha"); %>
            
            <%= Html.ValidationMessage("Captcha")%>
        </div>

        <div class="FormButtons">
            <input type="submit" value="Submit Comment" />
            <input type="reset" value="Reset" />
        </div>
        
        <%= Html.AntiForgeryToken() %>
    </fieldset>
</form>