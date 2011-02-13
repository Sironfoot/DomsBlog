<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage<DomsBlog.Models.ViewModels.BlogImagesView>" %>
    
<asp:Content ID="headerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.Encode(Model.Title) %> (Images)
</asp:Content>

<asp:Content ID="metaContent" ContentPlaceHolderID="MetaContent" runat="server">
    <meta name="description" content="<%= Html.AttributeEncode(Model.Abstract) %>" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="Breadcrumbs">
        <li><a href="/">Blogs</a></li>
        <li>
            <a href="<%= Url.Action("View", new { id = Model.BlogId, blogTitle = Model.UrlFriendlyTitle }) %>">
                <%= Html.Encode(Model.ShortTitle) %>
            </a>
        </li>
        <li class="last">Images</li>
    </ul>

    <h1 class="BlogTitle" id="FirstHeader"><%= Html.Encode(Model.Title) %> (Images)</h1>
    
    <p class="BlogInfo">
        <span><%= Model.PostedDate.ToString("dd MMMM yyyy - h:mm tt")%> / by Dominic Pettifer.</span>
        
        <% if (Model.NumImages > 0) { %>
            <a class="BlogImages" href="#">
                <%= Model.NumImages%> Image<%= (Model.NumImages != 1 ? "s" : "") %>
                <span class="Hidden"> for <em><%= Html.Encode(Model.Title)%></em>.</span>
            </a>
        <% } %>
        
        <a class="<%= (Model.NumComments > 0 ? "Comments" : "NoComments")%>" href="<%= Url.Action("View", new { id = Model.BlogId, blogTitle = Model.UrlFriendlyTitle }) %>#comments">
            <%= Model.NumComments %> Comment<%= (Model.NumComments != 1 ? "s" : "")%>
            <span class="Hidden"> for <em><%= Html.Encode(Model.Title) %></em>.</span>
        </a>
    </p>

    <p class="Abstract">
        <strong><%= Html.Encode(Model.BlogType) %></strong> - <%= Html.Encode(Model.Abstract) %>
    </p>
    
    <h2>Images</h2>
    
    <ul class="ImagesList">
        <%
            int rowNum = 1;
            foreach (var image in Model.BlogImages) {
        %>
        <li<%= rowNum % 2 != 0 ? " class=\"Odd\"" : "" %>>
            <a href="<%= image.LargeImageUrl %>">
                <img title="<%= image.Caption %>" alt="<%= image.AltText %>" src="<%= image.ThumbnailUrl %>" />
            </a>
            <p><%= Html.Encode(image.Caption) %></p>
        </li>
        <%
            rowNum++;
            }
        %>
    </ul>

</asp:Content>