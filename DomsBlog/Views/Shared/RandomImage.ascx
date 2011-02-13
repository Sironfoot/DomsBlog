<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DomsBlog.Models.ViewModels.RandomImageView>" %>

<% if (Model != null){ %>

<div id="RandomImage">
    <h2>Random Image</h2>
    
    <a href="<%= Model.LargeImageUrl %>"> 
        <img title="<%= Html.AttributeEncode(Model.Caption) %>" alt="<%= Html.AttributeEncode(Model.AltText) %>" src="<%= Model.ThumbnailUrl %>" />
    </a>

    <p>
        <%= Html.Encode(Model.Caption)%>
        <span>
            (from the blog
            <a href="<%= Url.Action("View", "Blog", new { id = Model.BlogId, blogTitle = Model.BlogUrlFriendlyTitle }) %>">
                <%= Html.Encode(Model.BlogTitle)%>
            </a>)
        </span>
    </p>
</div>

<% } %>