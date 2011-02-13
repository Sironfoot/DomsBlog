<%@ Import Namespace="DomsBlog.Utils" %>
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Private Menorca - Portfolio
</asp:Content>

<asp:Content ID="metaContent" ContentPlaceHolderID="MetaContent" runat="server">
    <meta name="description" content="Custom built promotional site for Properties to rent in Menorca. Includes it's own Content Management System." />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="Breadcrumbs">
        <li><a href="/Portfolio">Portfolio</a></li>
        <li class="last">Private Menorca</li>
    </ul>

    <h1 class="BlogTitle" id="FirstHeader">Private Menorca</h1>
    
    <p class="PorfolioInfo">
        <span>Completed Date Feb 2007.</span>
        <span class="SiteInfo">
            Webite:
            <a href="http://www.privatemenorca.com/">www.privatemenorca.com</a>
        </span>
    </p>

    <p class="Abstract">
        Promotional website for properties to rent in Menorca. Completely bespoke/custom built site
        with mini content management system, which allows changes to property information, prices,
        property availability calendar and image gallery (complete with photo uploader tool). Originally
        built in JavaServlets and JSP, and later ported to ASP.NET 2.0.
    </p>
    
    <a class="PortfolioMainImage" href="<%= Url.ResourceFolder() %>/Portfolio/Full/private-menorca.png">
        <img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/private-menorca.png" alt="Private Menorca - front page." />
    </a>
    
    <h2 class="NoClear">Core Technologies &amp; Skills</h2>

    <ul>
        <li>ASP.NET 2.0</li>
        <li>C# 2.0</li>
        <li>Visual Studio 2008</li>
        <li>XHTML/CSS</li>
        <li>SubSonic ORM</li>
        <li>SQL Server 2005</li>
    </ul>
    
    <h2>Description</h2>
    
    <p>
        Private Menorca (formally MenorcanMagic) was originally written in JavaServlets/JSP and MySQL
        and has since been ported over to ASP.NET 2.0 and SQL Server. It's a promotional website for
        acommodation available to rent (for holidays etc.) in Menorca, in the Mediterranean.
    </p>
    
    <p>
        Private Menorca is a completely bespoke/custom build web application with it's own
        <abbr title="Content Management System">CMS</abbr>. This CMS features a login that enables an
        administrator, when logged in, to browse the site in 'edit' mode, rather than implement a separate
        admin website for editting the content, the admin edits the data directly from the site itself. When
        logged, in various navigation and interface elements appear that allow the administrator to edit text,
        edit/add/remove photos, and change prices and availability. Most of the site can be editted this way.
    </p>
    
    <p>
        The admin section features a photo repository where photos can be stored to be used in other areas of the
        website. The photo uploader page will automatically resize the images (to scale) for the user to generate
        the thumbnail version of the images, so a separate thumbnail and fullsize version is stored.
    </p>
    
    <p><a href="http://subsonicproject.com/">Subsonic</a> was used as an <acronym title="Object Relational Mapper">ORM</acronym>.</p>
    
    <h2>Images</h2>
    
    <ul class="ImagesList">
        <li class="Odd">
            <a href="<%= Url.ResourceFolder() %>/Portfolio/Full/private-menorca.png">
                <img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/private-menorca.png" alt="Front page." title="Front page." />
            </a>
        </li>
        <li>
            <a href="<%= Url.ResourceFolder() %>/Portfolio/Full/private-menorca-calendar.png">
                <img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/private-menorca-calendar.png" alt="Compare availability calendar." title="Compare availability calendar." />
            </a>
        </li>
        <li class="Odd">
            <a href="<%= Url.ResourceFolder() %>/Portfolio/Full/private-menorca-admin-edit-photo.png">
                <img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/private-menorca-admin-edit-photo.png" alt="Admin section showing editting a photo." title="Admin section showing editting a photo." />
            </a>
        </li>
        <li>
            <a href="<%= Url.ResourceFolder() %>/Portfolio/Full/private-menorca-admin-edit-text.png">
                <img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/private-menorca-admin-edit-text.png"
                    alt="Editting text content for a property, complete with FCKEditor rich text editor."
                    title="Editting text content for a property, complete with FCKEditor rich text editor." />
            </a>
        </li>
        <li class="Odd">
            <a href="<%= Url.ResourceFolder() %>/Portfolio/Full/private-menorca-admin-photo-repository.png">
                <img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/private-menorca-admin-photo-repository.png"
                    alt="Admin section photo repository." title="Admin section photo repository." />
            </a>
        </li>
        
        
    </ul>

</asp:Content>
