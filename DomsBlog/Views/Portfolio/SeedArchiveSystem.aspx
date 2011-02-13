<%@ Import Namespace="DomsBlog.Utils" %>
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SCRI: Seed Archive System - Portfolio
</asp:Content>

<asp:Content ID="metaContent" ContentPlaceHolderID="MetaContent" runat="server">
    <meta name="description" content="Intranet web based database application for staff to manage, store, and log the whereabouts and uses of plant seed samples." />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="Breadcrumbs">
        <li><a href="/Portfolio">Portfolio</a></li>
        <li class="last">Seed Archive System</li>
    </ul>

    <h1 class="BlogTitle" id="FirstHeader">SCRI - Seed Archive System</h1>
    
    <p class="PorfolioInfo">
        <span>Completed Date Sept 2005.</span>
        <span class="SiteInfo">
            Webite: N/A (Intranet Site)
        </span>
    </p>

    <p class="Abstract">
        An intranet web based database application for staff at SCRI (Scottish Crops Research Institute)
        to manage, store and log the whereabouts and uses of plant seed samples. This was built by a team of
        3 students (including myself) as a final year project for university, but was a real live project
        to be used by staff on delivery.
    </p>
    
    <a class="PortfolioMainImage" href="<%= Url.ResourceFolder() %>/Portfolio/Full/seed-archive-system.png">
        <img src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/seed-archive-system.png"
            alt="Seed Archive System - Seed Family/Genus/Species names section."
            title="Seed Archive System - Seed Family/Genus/Species names section." />
    </a>
    
    <h2 class="NoClear">Core Technologies &amp; Skills</h2>

    <ul>
        <li>ASP 3.0 (classic ASP, not .NET kind)</li>
        <li>VB Script</li>
        <li>SQL Server 2000</li>
        <li>Database theory &amp Design (Normalisation etc.)</li>
        <li>Stored Procedures / Transactions / Isolation levels etc.</li>
    </ul>
    
    <h2>Description</h2>
    
    <p>
        This was a fourth year honours project developed by 3 of us (there were suppose to be five but one left,
        and the other never did any work). Although it was for university, it was a real project nonetheless
        with real clients and a real company.
    </p>

    <p>
        The company was SCRI (Scottish Crops Research Institute) and they wanted an internal intranet web based
        application for monitoring, handling and searching seed and plant samples stored at their premises, used
        for various research projects. The also needed to store information about the seeds meta data (such as
        Species, Genus names etc.), about the storage locations at their premises and the various seed
        suppliers that they use, as well as the seed samples themselves.
    </p>
    
    <p>
        <a href="<%= Url.ResourceFolder() %>/Portfolio/Full/seed-archive-system-suppliers.jpg">
            <img class="ImageFloatRight" src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/seed-archive-system-suppliers.png"
                title="Updating Supplier records." alt="Updating Supplier records."/>
        </a>
        They also wanted two levels of access permission, ordinary user with restricted access and a curator/admin
        user with full access. The idea being that actions performed by the ordinary user would get validated by
        the curators, this was in order to maintain the integrity of data inside the database.
    </p>

    <p>
        The curators were also masters of the seed storage, requests for seed out of the storage would go to the
        curators via the system. Out of this Asis-Sas (Arable Seed Identification System – Seed Archive System)
        was born and we were able to deliver on those requirements.
    </p>
    
    <h2>Technical Details</h2>
    
    <p>
        <a href="<%= Url.ResourceFolder() %>/Portfolio/Full/seed-archive-system-search.jpg">
            <img class="ImageFloatLeft" src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/seed-archive-system-search.png"
                title="ASAS-SAS featured a comprehensive Seed Search system."
                alt="ASAS-SAS featured a comprehensive Seed Search system."/>
        </a>
        The project was developed in ASP 3.0 (not .NET kind) using VBScript and was backed up by a Microsoft
        SQL Server 2000 database.
    </p>

    <p>
        This application was one of the most complicated systems I’d ever been involved in, spanning 100’s
        of ASP pages, featured a fully normalise database and made use of many of SQL Server’s advance features such
        as stored procedures, and database tier paging of records for optimal performance.
    </p>

    <p>
        ASP classic isn’t an Object Oriented programming language, but we made do with server-side include files
        to group together common functionality, to facilite code reuse and maintainability, and avoid DRY (Don’t Repeat Yourself).
    </p>
    
    <p>
        This project was where I obtained most of my knowledge on database theory and design, and specifically
        with SQL Server’s more advance technical features.
    </p>

    <p>
        As mentioned the system makes use of Store Procedures, but also used SQL Server’s advance transaction handling
        capabilities and various levels of isolation locking in order to maintain the integrity of the database.
    </p>
    
    <p>
        This was especially important with this system because multiple users were able to make updates on the same
        sets of data, and updates were being made on multiple sets of data, at the same time, that all had to
        commit, or not commit at all. So it was important to avoid update anomalies such as Ghost Updates and Dirty reads.
    </p>
    
    <h2>Real Project</h2>
    
    <p>
        <a href="<%= Url.ResourceFolder() %>/Portfolio/Full/seed-archive-system-storage.jpg">
            <img class="ImageFloatLeft" src="<%= Url.ResourceFolder() %>/Portfolio/Thumbs/seed-archive-system-storage.png"
                title="Searching for storage locations."
                alt="Searching for storage locations."/>
        </a>
        As this was a real project, it introduced us to the process of Requirements gathering from a real
        client for the first time.
    </p>

    <p>
        Over the course of two semesters, we regularly met with staff at SCRI every two weeks, where we would
        try to extract the software requirements from them. This included a range technical and scientific staff members.
    </p>

    <p>
        They could also use this time to validate what we produced along the way so they could steer us in the right
        direction if necessary. A far cry from the meet once then build the whole thing to deliver to client, only to
        find it’s not what they want kind of methodology!
    </p>

    <p>
        A full compliment of requirements and software engineering documentation was produced for the project,
        such as Use Case and Sequence diagrams, Database diagrams, Requirements Specifications, Quality Plans and so on.
    </p>
    
    <h2>Conclusion</h2>
    
    <p>
        In the end we were able to deliver a fully working system to the client where the system is in use today.
        One of the term members, Robert McCreary working on the project now works for SCRI and helps to
        maintain the system and is currently doing Usability Testing. 
    </p>

</asp:Content>
