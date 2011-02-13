<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage<DomsBlog.Models.Service.PollDetailView>" %>
    
<asp:Content ID="headerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Poll: <%= Html.Encode(Model.Question) %>
</asp:Content>

<asp:Content ID="metaContent" ContentPlaceHolderID="MetaContent" runat="server">
    <meta name="description" content="Poll: '<%= Html.AttributeEncode(Model.Question) %>', posted on <%= Model.DatePosted.ToString("d MMMM yyyy") %>." />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="Breadcrumbs">
        <li><a href="/Polls">Polls</a></li>
        <li class="last"><%= Html.Encode(Model.Question) %></li>
    </ul>
    
    <div id="PollContainer">
    
        <h1 id="FirstHeader">Poll: <%= Html.Encode(Model.Question) %></h1>
        <p class="PollInfo">
            <span>
                Date Posted - <%= Model.DatePosted.ToString("d MMMM yyyy") %> /
                <%= Model.TotalVotes %> vote<%= (Model.TotalVotes != 1 ? "s" : "") %>
            </span>
            
            <a class="NoComments" href="#comments">
                <%= Model.NumComments%> Comment<%= (Model.NumComments != 1 ? "s" : "")%>
                <span class="Hidden"> for <em><%= Html.Encode(Model.Question) %></em>.</span>
            </a>
        </p>
        
        
        
        <ul class="PollResults">
            <% foreach (DomsBlog.Models.Service.PollOptionDetailView option in Model.Options) { %>
            
                <li>
                    <%= option.PercentageOfTotal %>% -
                    <strong><%= Html.Encode(option.Answer) %></strong> (<%= option.Votes %>)
                    <span style="width: <%= (option.PercentageOfTotal > 0 ? option.PercentageOfTotal + "%" : "1px") %>;"></span>
                </li>
            
            <% } %>
        </ul>
        
        <div id="CommentsSection">
            <h2>
                <%= Model.NumComments %> Comment<%= (Model.NumComments != 1 ? "s" : "")%>
                for "<%= Html.Encode(Model.Question) %>"
            </h2>
            <span><a href="#postcomment">Post a Comment</a></span>
            
            <% Html.RenderPartial("CommentList", Model.Comments); %>
        
            <% Html.RenderPartial("CommentForm", Model.CommentForm); %>
        
        </div>
    </div>
    

</asp:Content>