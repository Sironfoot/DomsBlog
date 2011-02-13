<%@ Import Namespace="MvcLibrary.UrlTools" %>
<%@ Import Namespace="MvcLibrary.MvcHelpers" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DomsBlog.Models.Service.PollView>" %>

<p><%= Html.Encode(Model.Question) %></p>

<% if (Model.ResultsMode)
   { %>

<ul class="PollResults">
    <% foreach (var option in Model.Options.OrderByDescending(o => o.PercentageOfTotal))
       { %>
       
        <li>
            <span><%= option.PercentageOfTotal %>%</span> - <%= Html.Encode(option.Answer) %>
            <div style="width: <%= option.PercentageOfTotal %>%"></div>
        </li>
            
    
    <% } %>
</ul>

<p>Thank you for voting!</p>

<% }
   else
   { %>
                    
<% using (Html.BeginForm("Vote", "Poll"))
   {%>

    <fieldset>
        <legend>Poll Vote</legend>
        <ul>
            <% foreach (var option in Model.Options)
               { %>

                <li>
                    <input type="radio" id="pollOption_<%= option.Id %>" name="pollOptionId" value="<%= option.Id %>" />
                    <label for="pollOption_<%= option.Id %>"><%= Html.Encode(option.Answer)%></label>
                </li>
            
            <% } %>
        </ul>
        
        <input type="hidden" name="pollId" value="<%= Model.Id %>" />
        
        <input value="Vote" type="submit" />
                
        <a href="<%= Url.CurrentUrlWithQueryStrings(new { showResults = true }) %>">(see results)</a>
        
        <%= Html.AntiForgeryToken() %>

    </fieldset>
    
<% }
   } %>
   
   
<a class="PollComments" href="<%= Url.Action("View", "Poll", new { id = Model.Id, question = Url.ToFriendlyUrl(Model.Question) }) %>">View Comments (<%= Model.NumComments %>)</a>
<a class="PreviousPolls" href="/Polls">(See previous polls)</a>