<%@ Import Namespace="MvcLibrary.UrlTools" %>
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage<DomsBlog.Models.ViewModels.BlogListingView>" %>
    
<asp:Content ID="headerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Dominic's Latest Blogs
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="Breadcrumbs">
        <li class="last">Blogs</li>
    </ul>
    
    <h1 id="FirstHeader">Dominic's Latest Blogs</h1>
    
    <ul class="ContentListing">
        <% foreach (var item in Model.Blogs) { %>
    
        <li>
            <h2>
                <a href="<%= Url.Action("View", "Blog", new { id = item.Id, blogTitle = item.UrlFriendlyTitle }) %>">
                    <%= Html.Encode(item.Title) %>
                </a>
            </h2>

            <p class="BlogInfo">
                <span><%= item.PostedDate %> / by Dominic Pettifer.</span>
                
                <% if (item.NumImages > 0) { %>
                    <a class="BlogImages" href="<%= Url.Action("ViewImages", "Blog", new { id = item.Id, blogTitle = item.UrlFriendlyTitle }) %>">
                        <%= item.NumImages %> Image<%= (item.NumImages != 1 ? "s" : "") %>
                        <span class="Hidden"> for <em><%= Html.Encode(item.Title)%></em>.</span>
                    </a>
                <% } %>
                
                <a class="<%= (item.NumComments > 0 ? "Comments" : "NoComments") %>" href="<%= Url.Action("View", "Blog", new { id = item.Id, blogTitle = item.UrlFriendlyTitle }) %>#comments">
                    <%= item.NumComments %> Comment<%= (item.NumComments != 1 ? "s" : "") %>
                    <span class="Hidden"> for <em><%= Html.Encode(item.Title) %></em>.</span>
                </a>
            </p>
            
            <p>
                <% if (item.PreviewImage != null) { %>
                    <a class="BlogPreviewPic" href="<%= item.PreviewImage.FullUrl %>">
                        <img alt="<%= item.PreviewImage.AltText %>" title="<%= item.PreviewImage.Caption %>" src="<%= item.PreviewImage.ThumbUrl %>" />
                    </a>
                <% } %>
                <strong><%= Html.Encode(item.BlogType) %></strong> - <%= Html.Encode(item.AbstractText) %>
            </p>
        
            <h3>Tags<span class="Hidden"> for <em><%= Html.Encode(item.Title) %></em>.</span></h3>
            <ul class="BlogTags">
                <% foreach (var tag in item.Tags) { %>
                    <li><%= Html.ActionLink(tag.TagName, "TaggedWith", new { tag = tag.UrlFriendTagName, id = tag.Id }) %></li>
                <% } %>
            </ul>
        </li>
        
        <% } %>
    </ul>
    
    <% if (Model.HasNextPage || Model.HasPreviousPage) { %>
        <span class="NextPrevNav">
            <% if (Model.HasPreviousPage) { %>
                <a class="Next" href="<%= (Model.CurrentPage > 2 ? "?page=" + (Model.CurrentPage - 1) : "/") %>">Newer entries</a>
            <% } %>
            <% if (Model.HasNextPage) { %>
                <a class="Prev" href="?page=<%= (Model.CurrentPage + 1) %>">Older entries</a>
            <% } %>
        </span>
    <% } %>
    
</asp:Content>