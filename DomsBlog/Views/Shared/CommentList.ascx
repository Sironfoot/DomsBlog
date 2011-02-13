<%@ Import Namespace="MvcLibrary.Extensions" %>
<%@ Import Namespace="MvcLibrary.MvcHelpers" %>
<%@ Import Namespace="DomsBlog.Utils" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<DomsBlog.Models.Service.CommentView>>" %>

<% if(Model.Count() > 0) { %>
<ul>
    <%
        int index = 0;
        foreach (var item in Model)
        {
            index++;
            %>
    
    <li class="<%= index < Model.Count() ? "SiblingsAfter" : "" %> <%= item.AdminComment ? "AdminComment" : "" %>">
        <div class="<%= item.HighlightMe ? "qjBlueFade" : "" %>">
            <h3><%= Html.Encode(item.Title) %></h3>
            
            <%= BBDecoding.DecodeBlogCommentText(item.CommentText) %>
            
            <p class="CommentInfo">
                Posted on <%= item.PostedDate.ToString("d MMMM yyyy - h:mm tt") %> /
                by
                <% if (!item.Website.IsNullEmptyOrWhitespace()) { %>
                    <a href="<%= Html.Encode(item.Website) %>">
                        <%= item.Author.IsNullEmptyOrWhitespace() ? "Anonymous" : Html.Encode(item.Author) %>
                    </a>
                <% } else { %>
                    <strong><%= item.Author.IsNullEmptyOrWhitespace() ? "Anonymous" : Html.Encode(item.Author) %></strong>
                <% } %>
                <% if(item.AdminComment) { %> (Administrator) <% } %>
            </p>
                        
            <div class="CommentReplyButtons">
                <a href="<%= Url.Action("View", new { replyId = item.Id }).ParseAmpersands() %>#postcomment">Reply<span class="Hidden"> to <em><%= Html.Encode(item.Title) %></em>.</span></a>
                <a href="<%= Url.Action("View", new { replyId = item.Id, replyWithQuote = true }).ParseAmpersands() %>#postcomment"><span class="Hidden">Reply to <em><%= Html.Encode(item.Title) %></em> with </span>Quote</a>
            </div>
        </div>
        
        <% if(item.ChildComments.Count > 0) { %>

            <% Html.RenderPartial("CommentList", item.ChildComments); %>

        <% } %>
    </li>
    
    <% } %>
</ul>
<% } %>