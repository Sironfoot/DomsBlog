<%@ Import Namespace="DomsBlog.Utils" %>
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage<DomsBlog.Models.Service.BlogPageView>" %>
    
<asp:Content ID="headerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.Encode(Model.Title) %>
</asp:Content>

<asp:Content ID="metaContent" ContentPlaceHolderID="MetaContent" runat="server">
    <meta name="description" content="<%= Html.AttributeEncode(Model.Abstract) %>" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="Breadcrumbs">
        <li><a href="/">Blogs</a></li>
        <li class="last"><%= Html.Encode(Model.ShortTitle) %></li>
    </ul>

    <h1 class="BlogTitle" id="FirstHeader"><%= Html.Encode(Model.Title) %></h1>
    
    <p class="BlogInfo">
        <span><%= Model.PostedDate.ToString("dd MMMM yyyy - h:mm tt")%> / by Dominic Pettifer.</span>
        
        <% if (Model.NumImages > 0) { %>
            <a class="BlogImages" href="<%= Url.Action("ViewImages", new { id = Model.BlogId, blogTitle = Model.UrlFriendlyTitle }) %>">
                <%= Model.NumImages%> Image<%= (Model.NumImages != 1 ? "s" : "") %>
                <span class="Hidden"> for <em><%= Html.Encode(Model.Title)%></em>.</span>
            </a>
        <% } %>
        
        <a class="<%= (Model.NumComments > 0 ? "Comments" : "NoComments")%>" href="#comments">
            <%= Model.NumComments %> Comment<%= (Model.NumComments != 1 ? "s" : "")%>
            <span class="Hidden"> for <em><%= Html.Encode(Model.Title) %></em>.</span>
        </a>
    </p>

    <p class="Abstract">
        <strong><%= Html.Encode(Model.BlogType) %></strong> - <%= Html.Encode(Model.Abstract) %>
    </p>

    <%= Model.BlogText %>
    
    <% if (Model.HasPreviousPage() || Model.HasNextPage()) { %>
        <span class="NextPrevNav BlogPageNav fc">
            <% if (Model.HasPreviousPage()) { %>
                <a class="Prev" href="<%= "?page=" + (Model.PageNumber - 1) %>">Previous Page</a>
            <% } %>
            <% if (Model.HasNextPage()) { %>
                <a class="Next" href="?page=<%= (Model.PageNumber + 1) %>">Next Page</a>
            <% } %>    
        </span>
    <% } %>
    
    <% if (Model.BlogPages.Count > 1) { %>
        <div class="PageSelector fc">
            <p>Jump to Page...</p>
            <ul>
            <%  foreach (var page in Model.BlogPages)
                {
                    if (Model.PageNumber == page.PageNumber)
                    { %>
                    <li class="Selected">
                        <%= Html.Encode(page.PageName)%>
                    </li>
                <%  }
                    else
                    { %>
                    <li class="<%= page.PageNumber < Model.PageNumber ? "Previous" : "Next" %>">
                        <a href="<%= Url.Action("View", new { id = Model.BlogId, blogTitle = Model.UrlFriendlyTitle, page = page.PageNumber }) %>">
                            <%= Html.Encode(page.PageName)%>
                        </a>
                    </li>
                <%  }
                } %>
            </ul>
        </div>
    <% } %>
    
    <div id="CommentsSection">
        <h2 id="comments"><%= Model.NumComments %> Comment<%= (Model.NumComments != 1 ? "s" : "")%> on "<%= Html.Encode(Model.ShortTitle) %>"</h2>
        <span><a href="#postcomment">Post a Comment</a></span>
        
        <% Html.RenderPartial("CommentList", Model.Comments); %>
        
        <% Html.RenderPartial("CommentForm", Model.CommentForm); %>
    </div>

</asp:Content>