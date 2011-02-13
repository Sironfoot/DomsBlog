<%@ Import Namespace="DomsBlog.Utils" %>
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="headerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Borders Health In Hand - Portfolio
</asp:Content>

<asp:Content ID="metaContent" ContentPlaceHolderID="MetaContent" runat="server">
    <meta name="description" content="Umbraco based content site for NHS Education for Scotland." />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="Breadcrumbs">
        <li><a href="/Portfolio">Portfolio</a></li>
        <li class="last">Borders Health In Hand</li>
    </ul>

    <h1 class="BlogTitle" id="FirstHeader">Borders Health In Hand</h1>
    
    <p class="PorfolioInfo">
        <span>Completed Date January 2009.</span>
        <span class="SiteInfo">
            Webite:
            <a href="http://www.bordershealthinhand.scot.nhs.uk/home.aspx">www.bordershealthinhand.scot.nhs.uk</a>
        </span>
    </p>

    <p class="Abstract">
        NHS Education for Scotland portal website, providing health information on various subjects and
        in difference languages. Built on top of Umbraco, an open source .NET Content Management
        System, the primary CMS used where I work. 
    </p>
    
    <a class="PortfolioMainImage" href="<%= Url.ResourceFolder() %>/Portfolio/Full/borders-health-in-hand-website.png">
        <img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/borders-health-in-hand-website.png" alt="Borders Health In Hand - Front page" />
    </a>
    
    <h2 class="NoClear">Core Technologies &amp; Skills</h2>

    <ul>
        <li>ASP.NET 3.5/Visual Studio 2008</li>
        <li>C# 3.0</li>
        <li>Umbraco CMS v3</li>
        <li>Google Maps API</li>
        <li>XSLT</li>
    </ul>
    
    <h2>Description</h2>
    
    <p>
        Borders Health in Hand is a portal type website build using <a href="http://www.umbraco.org">Umbraco</a>, an Open Source
        <abbr title="Content Management System">CMS</abbr> built on top of ASP.NET. The site integrates with a search trawling/indexing
        technology we use at work called <a href="http://www.fastsearch.com/">FAST</a>.
    </p>
    
    <p>
        It also integrates Google Maps technology as it allows users to search for health centers in an area as specified by a
        postal code, or address. This includes using the Google Maps API to place points on the map indicating where there
        health centers are located, with a description tooltip when they click on a point.
    </p>
    
    <p>
        I have made heavy use of PNG sprites for this site as their were a lot of CSS images in the original design.
        This reduced HTTP lookups to improve the responsiveness of the site.
    </p>
    
    <h2>XSLT</h2>
    
    <p>
        The site also makes heavy use of XSLT to display the search results. These search results are delivered from FAST as XML,
        and the XSLT transforms that XML into valid XHTML. This is an easier approach to make compared to the alternative of
        writting lots of C# code to parse through a complex XML file and write out some XHTML via StringBuilders.
    </p>
    
    <p>
        In fact Umbraco actively encourages the use of XSLT to diplay data from it's CMS, as all it's data is stored as a
        cached, in memory, chunk of XML. Using XSLT makes it easy to tranverse this XML to get at the data we need using
        XPath. Much of the site is rendered this way, including navigation, and lists.
    </p>
    
    <p>
        This is the approach we take to writing most of our Umbraco based sites, although if we need more complex functionality,
        Umbraco does allow use to use standard ASP.NET UserControls and ServerControls as well. These were used for the contact forms.
    </p>
    
    <h2>Images</h2>
    
    <ul class="ImagesList">
        <li class="Odd">
            <a href="<%= Url.ResourceFolder() %>/Portfolio/Full/borders-health-in-hand-website.png">
                <img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/borders-health-in-hand-website.png" alt="Front page." title="Front page." />
            </a>
        </li>
        <li>
            <a href="<%= Url.ResourceFolder() %>/Portfolio/Full/borders-health-in-hand-google-maps.png">
                <img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/borders-health-in-hand-google-maps.png" alt="Showing Google Maps integration." title="Showing Google Maps integration." />
            </a>
        </li>
        <li class="Odd">
            <a href="<%= Url.ResourceFolder() %>/Portfolio/Full/borders-health-in-hand-finding-your-way-page.png">
                <img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/borders-health-in-hand-finding-your-way-page.png" alt="Finding your way page." title="Finding your way page." />
            </a>
        </li>
        <li>
            <a href="<%= Url.ResourceFolder() %>/Portfolio/Full/borders-health-in-hand-search.png">
                <img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/borders-health-in-hand-search.png" alt="Search results page." title="Search results page." />
            </a>
        </li>
        
    </ul>

</asp:Content>
