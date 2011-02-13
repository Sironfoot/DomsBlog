<%@ Import Namespace="MvcLibrary.UrlTools" %>
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<DomsBlog.Models.Service.PollView>>" %>
    
<asp:Content ID="headerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Polls
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="Breadcrumbs">
        <li class="last">Polls</li>
    </ul>
    
    <h1 id="FirstHeader">Previous Polls</h1>
    
    <ul class="ContentListing PollList">
        <% foreach(DomsBlog.Models.Service.PollView poll in Model) { %>
        
            <li>
                <h2>
                    <a href="<%= Url.Action("View", "Poll", new { id = poll.Id, question = Url.ToFriendlyUrl(poll.Question) }) %>">
                        <%= Html.Encode(poll.Question) %>
                    </a>
                </h2>
                
                <p class="PollInfo">
                    <span>
                        Posted Date <%= poll.PostedDate.ToString("d MMMM yyyy") %> /
                        <%= poll.TotalVotes %> vote<%= (poll.TotalVotes != 1 ? "s" : "") %>.
                    </span>
                    
                    <a class="Comments" href="#comments">
                        <%= poll.NumComments %> Comment<%= (poll.NumComments != 1 ? "s" : "") %>
                        <span class="Hidden"> for <em><%= Html.Encode(poll.Question) %></em>.</span>
                    </a>
                </p>
                
                <ul>
                    <% foreach(DomsBlog.Models.Service.PollOptionView option in poll.Options) { %>
                    
                        <li>
                            <%= option.PercentageOfTotal %>% -
                            <strong><%= Html.Encode(option.Answer) %></strong> (<%= option.Votes %>)
                            <span style="width: <%= (option.PercentageOfTotal > 0 ? option.PercentageOfTotal + "%" : "1px") %>;"></span>
                        </li>
                    
                    <% } %>
                </ul>
            </li>
        
        <% } %>

    </ul>

</asp:Content>