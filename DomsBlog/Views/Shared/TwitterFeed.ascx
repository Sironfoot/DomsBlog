<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DomsBlog.Models.Service.TwitterFeed>" %>

<div id="Tweets">
    <h2>Latest Tweets</h2>
    
    <% if (Model.Exception == null)
       { %>
    
    <ul>
        <% foreach (var tweet in Model.Tweets)
           {%>
        
            <li>
                <p><%= tweet.Text%></p>
                <span><%= tweet.DisplayFriendlyPostedDate %> from <a href="<%= Html.Encode(tweet.ClientUrl) %>"><%= Html.Encode(tweet.ClientName)%></a></span>
            </li>
        
        <% } %>
    </ul>
    
    <% }
       else
       {
    %>
       <p class="TwitterFail">Problem loading Twitter Feed! Please try again later.</p>
    <%
       }
    %>
    
    <p>View <a href="http://twitter.com/<%= Html.AttributeEncode(Model.Username) %>">Dominic Pettifer's Twitter page</a>.</p>

</div>