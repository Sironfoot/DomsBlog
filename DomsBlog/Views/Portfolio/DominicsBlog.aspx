<%@ Import Namespace="DomsBlog.Utils" %>
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="headerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    DominicPettifer.co.uk (this Blog) - Portfolio
</asp:Content>

<asp:Content ID="metaContent" ContentPlaceHolderID="MetaContent" runat="server">
    <meta name="description" content="Personal blogging site. Written in ASP.NET MVC 1.0." />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="Breadcrumbs">
        <li><a href="/Portfolio">Portfolio</a></li>
        <li class="last">DominicPettifer.co.uk</li>
    </ul>

    <h1 class="BlogTitle" id="FirstHeader">DominicPettifer.co.uk (this Blog)</h1>
    
    <p class="PorfolioInfo">
        <span>Completed Date April 2009.</span>
        <span class="SiteInfo">
            Webite:
            <a href="http://www.dominicpettifer.co.uk">www.dominicpettifer.co.uk</a>
        </span>
    </p>

    <p class="Abstract">
        My own personal blogging site. Originally written in ASP.NET 2.0 Webforms, it has now been converted over to
        ASP.NET MVC 1. They say you have to rewrite something 3 times until you produce your best work, so maybe once
        I port it over to MVC2 it'll be the best blog in the world :)
    </p>
    
    <a class="PortfolioMainImage" href="<%= Url.ResourceFolder() %>/Portfolio/Full/doms-blog.png">
        <img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/doms-blog.png" alt="" />
    </a>
    
    <h2 class="NoClear">Core Technologies &amp; Skills</h2>

    <ul>
        <li>ASP.NET MVC 1.0 / C#</li>
        <li>Visual Studio 2008</li>
        <li>Subversion source code control</li>
        <li>NHibernate</li>
        <li>SQL Server 2008</li>
        <li>XHTML/CSS</li>
    </ul>
    
    <h2>Description</h2>
    
    <p>
        The original version of this blog was written as a way for me to learn ASP.NET 2.0. It was completed
        in November 2006 and was my first real ASP.NET application. The newer version of this blog you see before you
        has been written in ASP.NET MVC and was rewritten for similar reasons, as a way for me to learn ASP.NET MVC, and also
        to apply new skills and techniques for building websites that I have learnt since 2006.
    </p>
    
    <p>
        These new techniques include more sematic, standards compliant XHTML/CSS, leading to better accessibility,
        <abbr title="Search Engine Optimisation">SEO</abbr>, and website download speed (slimmer HTML payload). The
        old version of the site used some table based layout, and mixed in some more presentational based mark-up, instead of keeping it 
        in the CSS.
    </p>
    
    <h2>Code base</h2>
    
    <p>
        The old version of this blog used a custom built Data Access Layer using the Provider Model Design Pattern, which the WebForms
        code behind pages spoke directly to. In this rewrite I have used NHibernate <abbr title="Object Relational Mapper">ORM</abbr>
        as the data access layer. The DAL is hidden behind an interface based Repository layer which serves domain centric objects,
        this is to make the data layer plugable. I can strip out the NHibernate Repository and replace it with something else such
        as LINQ 2 SQL, or Entiry Framework, or even a cloud hosted DB such as AmazonDB or Microsoft Azure, all without having to
        make any changes to other parts of the code base which speak to the Repository.
    </p>
    
    <p>
        An interface based Service Layer sits between the MVC Controller and the Repository, The Service layer handles all of the
        business and validation logic. The Service and Repository layers make up the Model in MVC. Seperating the Model like this
        serves to make the Model more testable with Unit tests, as everything sits behind interfaces, those interfaces are easier to
        mock with Mocking frameworks such as RhinoMock. It also keeps the Controller logic as thin as possible. It's often
        said that an MVC application should have a thick Model, a thin Controller and a dumb View.
    </p>
    
    <p>
        For the View part of MVC, I always strive to serve strongly typed ViewModel specific objects to the aspx view page, never data objects
        sent from the Repository. This serves to keep the View relatively clean of code segments, as any conditional logic or decisions
        the View needs to make can be contained in the ViewModel object. For instance, encoding a blog title into a format suitable for URLs
        so that /Blog/123/ASP.NET Tips &amp; Tricks becomes /Blog/123/asp-net-tips-and-tricks, the View just calls a Property
        <em>Model.UrlFriendlyTitle</em> on the ViewModel object instead of having to import namespaces and call code in the View.
    </p>
    
    <h2>Future Work</h2>
    
    <p>
        Right now, in order to get the website up and running and out of the door, I have taken on a lot of so called
        '<a href="http://martinfowler.com/bliki/TechnicalDebt.html">Technical Dept</a>', where I have implemented a lot of
        things in a quick 'n' dirty way, with the intention of implementng it properly later on (paying off the Technical Dept,
        <a href="http://martinfowler.com/bliki/TechnicalDebt.html">read the article</a>, it's a brilliant analogy). There are
        currently no Unit tests and there is no <acronym title="Inversion Of Control">IOC</acronym> container in place,
        recommended agile programming practices for an ASP.NET MVC application. There are also a few dependencies between
        the Service Layer and the Controler. I plan to continue developing the blog engine and fix these shortcommings, where I plan
        to eventually make the blog engine open-source. Watch this space.
    </p>

</asp:Content>
