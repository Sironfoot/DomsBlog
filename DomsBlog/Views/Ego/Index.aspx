<%@ Import Namespace="DomsBlog.Utils" %>
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="headerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Dominic's Ego Page
</asp:Content>

<asp:Content ID="metaContent" ContentPlaceHolderID="MetaContent" runat="server">
    <meta name="description" content="Dominic James Pettifer. Web Developer living in Scotland (near Glasgow). I develop with ASP.NET, C#, MVC, Umbraco, SQL Server, and Windows Server/IIS, and a bit of Silverlight." />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="Breadcrumbs">
        <li class="last">About</li>
    </ul>
    
    <h1 id="FirstHeader">Dominic's Ego Page</h1>
    
    <ul class="MiniContentListing">
        <li id="EgoLinkCV"><a href="About/CV">CV</a></li>
        <li id="EdoLinkContact"><a href="About/Contact">Contact</a></li>
        <li id="EgoLinkSitemap"><a href="About/Sitemap">Sitemap</a></li>
        <li id="EgoLinkLegal"><a href="About/Legal">Legal</a></li>
    </ul>
    
    <h2>Me</h2>
    
    <p>
        <a href="<%= Url.ResourceFolder() %>/About/Full/dominic-graduation.jpg">
            <img class="ImageFloatRight" src="<%= Url.ResourceFolder() %>/About/Thumbs/dominic-graduation.jpg" alt="Me on graduation day." />
        </a>
        My name is Dominic James Pettifer. I am a <%= ViewData["age"] %> year old Web Developer living in Motherwell, Scotland (near Glasgow).
        I develop primarily on the Microsoft stack, with ASP.NET, C#, SQL Server, and Windows Server/IIS, with a tiny bit of Silverlight
        thrown in.
    </p>
    
    <p>
        I put this website together as a showcase of my work, to blog about anything I'm interested in, and as a way to learn ASP.NET MVC.
        Web development and design is my passion, and I pay particularly close attention to issues surrounding using good accessible, sematic
        XHTML/CSS Standards compliant markup, SEO issues, and
        <a href="http://developer.yahoo.com/performance/">front-end web optimisation tricks</a>.
    </p>
    
    <p>
        Right now I am teaching myself agile programming techniques such as Test Driven Development, Dependency Injection and
        <a href="http://www.dimecasts.net/Casts/CastDetails/96">SOLID principles</a>.
    </p>
    
    <h2>Education</h2>
    
    <p>
        I have studied Computing (Applications Development) at the University of Abertay Dundee from September 2000 to
        June 2005. Yes that's 5 years! It was a 4 year degree but I failed 3rd year and had to repeat it, but
        I managed to pick myself up and get a 1st class honours in the end. I also have a Postgrad Diploma at the same university
        in Software Engineering (Internet Computing).
    </p>
    
    <h2>Work</h2>
    
    <p>
        I am currently employed as a Web Developer for <a href="http://www.conscia.co.uk">Conscia Enterprise Systems</a>, based in Glasgow,
        where I have been since Jan 2007. At work I mainly build systems for the NHS using
        <a href="http://www.umbraco.org">Umbraco, an open-source Content Management System</a>, but also write bespoke ASP.NET web
        applications as well.
    </p>
    
    <h2>Interests</h2>
    
    <p>
        As well as being interested in web development/design, I am also a keen video game fanatic. I mainly play games on the PC but
        also own an Xbox 360.
    </p>

</asp:Content>