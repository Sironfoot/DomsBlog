<%@ Import Namespace="DomsBlog.Utils" %>
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="headerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Dominic's Portfolio of Work
</asp:Content>

<asp:Content ID="metaContent" ContentPlaceHolderID="MetaContent" runat="server">
    <meta name="description" content="A portfolio of my work which includes an ASP.NET MVC site (this one), various NHS websites built with Umbraco, and custom built ASP.NET apps." />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="Breadcrumbs">
        <li class="last">Portfolio</li>
    </ul>
    
    <h1 id="FirstHeader">Dominic's Portfolio of Work</h1>
    
    <ul class="ContentListing">
        <li>
            <h2><a href="<%= Url.Action("Detail", new { name = "Dominics-Blog" }) %>">DominicPettifer.co.uk (this Blog)</a></h2>
            <p class="PorfolioInfo">
                <span>Completed Date April 2009.</span>
                <span class="SiteInfo">Webite: <a href="http://www.dominicpettifer.co.uk">www.dominicpettifer.co.uk</a></span>
            </p>
            <p>
                <a href="<%= Url.ResourceFolder() %>/Portfolio/Full/doms-blog.png"><img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/doms-blog.png" alt="" /></a>
                My own personal blogging site. Originally written in ASP.NET 2.0 Webforms,
                it has now been converted over to ASP.NET MVC 1. They say you have to rewrite something 3 times
                until you produce your best work, so maybe once I port it over to MVC2 it'll be the best blog in the world :)
            </p>
            
            <ul class="PortfolioTools">
                <li>ASP.NET MVC 1.0 / C#</li>
                <li>Visual Studio 2008</li>
                <li>Subversion source code control</li>
                <li>NHibernate</li>
                <li>SQL Server 2005</li>
            </ul>
        </li>
        
        <li>
            <h2><a href="<%= Url.Action("Detail", new { name = "Borders-Health-In-Hand" }) %>">Borders Health In Hand</a></h2>
            <p class="PorfolioInfo">
                <span>Completed Date January 2009.</span>
                <span class="SiteInfo">Webite: <a href="http://www.bordershealthinhand.scot.nhs.uk">www.bordershealthinhand.scot.nhs.uk</a></span>
            </p>
            <p>
                <a href="<%= Url.ResourceFolder() %>/Portfolio/Full/borders-health-in-hand-website.png">
                    <img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/borders-health-in-hand-website.png" alt="" />
                </a>
                NHS Education for Scotland portal website, providing health information on various subjects and in difference languages.
                Built on top of Umbraco, an open source .NET Content Management System, the primary CMS used where I work.
            </p>
            
            <ul class="PortfolioTools">
                <li>ASP.NET 3.5/Visual Studio 2008</li>
                <li>C# 3.0</li>
                <li>Umbraco CMS v3</li>
                <li>Google Maps API</li>
                <li>XSLT</li>
            </ul>
        </li>
        
        <li>
            <h2><a href="<%= Url.Action("Detail", new { name = "Private-Menorca" }) %>">Private Menorca</a></h2>
            <p class="PorfolioInfo">
                <span>Completed Date Feb 2007.</span>
                <span class="SiteInfo">Webite: <a href="http://www.privatemenorca.com">www.privatemenorca.com</a></span>
            </p>
            <p>
                <a href="<%= Url.ResourceFolder() %>/Portfolio/Full/private-menorca.png">
                    <img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/private-menorca.png" alt="" />
                </a>
                Promotional website for properties to rent in Menorca. Completely bespoke/custom built site with mini content
                management system, which allows changes to property information, prices, property availability calendar
                and image gallery (complete with photo uploader tool). Originally built in JavaServlets and JSP, and later ported
                to ASP.NET 2.0.
            </p>
            
            <ul class="PortfolioTools">
                <li>ASP.NET 2.0</li>
                <li>C# 2.0</li>
                <li>Visual Studio 2008</li>
                <li>XHTML/CSS</li>
                <li>SubSonic ORM</li>
                <li>SQL Server 2005</li>
            </ul>
        </li>
        
        <li>
            <h2><a href="<%= Url.Action("Detail", new { name = "SCRI-Seed-Archive-System" }) %>">SCRI - Seed Archive System</a></h2>
            <p class="PorfolioInfo">
                <span>Completed Date Sept 2005.</span>
                <span class="SiteInfo">Webite: N/A (Intranet Site)</span>
            </p>
            <p>
                <a href="<%= Url.ResourceFolder() %>/Portfolio/Full/seed-archive-system.png">
                    <img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/seed-archive-system.png" alt="" />
                </a>
                An intranet web based database application for staff at SCRI (Scottish Crops Research Institute) to manage,
                store and log the whereabouts and uses of plant seed samples. This was built by a team of 3 students (including
                myself) as a final year project for university, but was a real live project to be used by staff on delivery.
            </p>
            
            <ul class="PortfolioTools">
                <li>ASP 3.0 (classic ASP, not .NET kind)</li>
                <li>VB Script</li>
                <li>SQL Server 2000</li>
                <li>Database theory &amp Design (Normalisation etc.)</li>
                <li>Stored Procedures / Transactions / Isolation levels etc.</li>
            </ul>
        </li>
    </ul>

</asp:Content>