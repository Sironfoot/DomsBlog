<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage<DomsBlog.Models.ViewModels.SitemapView>" %>

<asp:Content ID="headerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Sitemap
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="Breadcrumbs">
        <li><a href="/About">About</a></li>
        <li class="last">Sitemap</li>
    </ul>
    
    <div id="SitemapSection">

        <h1 id="FirstHeader">Sitemap</h1>
        
        <ul class="Sitemap">
            <li>
                <h2><a href="/">Blogs</a></h2>
                <ul>
                    <% foreach(var blog in Model.Blogs) { %>
                        <li>
                            <a href="<%= blog.Url %>"><%= Html.Encode(blog.Title) %></a>
                            <% if(blog.HasImages) { %>
                                <ul>
                                    <li><a href="<%= blog.Url %>/Images">Images</a></li>
                                </ul>
                            <% } %>
                        </li>
                    <% } %>
                </ul>
            </li>
            <li>
                <h2><a href="/Portfolio">Portfolio</a></h2>
                <ul>
                    <li><a href="/Portfolio/Dominics-Blog">DominicPettifer.co.uk (this Blog)</a></li>
                    <li><a href="/Portfolio/Borders-Health-In-Hand">Borders Health In Hand</a></li>
                    <li><a href="/Portfolio/Private-Menorca">Private Menorca</a></li>
                    <li><a href="/Portfolio/SCRI-Seed-Archive-System">SCRI - Seed Archive System</a></li>
                </ul>
            </li>
            <li>
                <h2><a href="/About">About</a></h2>
                <ul>
                    <li><a href="/About/CV">Dominic's Curriculum Vitae</a></li>
                    <li><a href="/About/Contact">Contact Dominic</a></li>
                    <li><a href="/About/Sitemap">Sitemap</a></li>
                    <li><a href="/About/Legal">Legal Stuff & Acknowledgements</a></li>
                </ul>
            </li>
            <li>
                <h2><a href="/Links">Links</a></h2>
            </li>
            <li>
                <h2><a href="/Polls">Polls</a></h2>
                <ul>
                    <% foreach(var poll in Model.Polls) { %>
                        <li>
                            <a href="<%= poll.Url %>"><%= Html.Encode(poll.Title) %></a>
                        </li>
                    <% } %>
                </ul>
            </li>
        </ul>
        
    </div>

</asp:Content>
