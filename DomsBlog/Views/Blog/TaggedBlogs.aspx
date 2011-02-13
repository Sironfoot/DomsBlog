<%@ Page  Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
    Inherits="System.Web.Mvc.ViewPage<DomsBlog.Models.ViewModels.BlogListingView>" %>
    
<asp:Content ID="headerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    All Blogs Tagged With <%= Html.Encode(ViewData["TagName"]) %>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="Breadcrumbs">
        <li><a href="/">Blogs</a></li>
        <li class="last">Tagged with <%= Html.Encode(ViewData["TagName"])%></li>
    </ul>
    
    <h1 id="FirstHeader">All Blogs Tagged With <%= Html.Encode(ViewData["TagName"]) %></h1>
    
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
                    <a class="BlogImages" href="#">
                        <%= item.NumImages %> Image<%= (item.NumImages != 1 ? "s" : "") %>
                        <span class="Hidden"> for <em><%= Html.Encode(item.Title)%></em>.</span>
                    </a>
                <% } %>
                
                <a class="<%= (item.NumComments > 0 ? "Comments" : "NoComments") %>" href="<%= Url.Action("View", "Blog", new { id = item.Id, blogTitle = item.UrlFriendlyTitle }) %>#comments">
                    <%= item.NumComments %> Comment<%= (item.NumComments != 1 ? "s" : "") %>
                    <span class="Hidden"> for <em><%= Html.Encode(item.Title) %></em>.</span>
                </a>
            </p>
            
            <p><strong><%= Html.Encode(item.BlogType) %></strong> - <%= Html.Encode(item.AbstractText) %></p>
        
            <h3>Tags<span class="Hidden"> for <em><%= Html.Encode(item.Title) %></em>.</span></h3>
            <ul class="BlogTags">
                <% foreach (var tag in item.Tags) { %>
                    <li><%= Html.ActionLink(tag.TagName, "TaggedWith", new { tag = tag.UrlFriendTagName, id = tag.Id }) %></li>
                <% } %>
            </ul>
        </li>
        
        <% } %>
    </ul>
    
</asp:Content>
