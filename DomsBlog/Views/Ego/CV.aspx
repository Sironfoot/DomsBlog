<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="headerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Dominic's Curriculum Vitae
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="Breadcrumbs">
        <li><a href="/About">About</a></li>
        <li class="last">CV</li>
    </ul>
    
    <div id="CVSection">

        <h1 id="FirstHeader">Dominic's Curriculum Vitae</h1>
        
        <dl>
            <dt>Name:</dt>
            <dd>Dominic James Pettifer</dd>
            
            <dt>DOB:</dt>
            <dd>15th July 1981</dd>
            
            <dt>Email:</dt>
            <dd><a href="mailto:sironfoot@msn.com">sironfoot@msn.com</a></dd>
            
            <dt>Website:</dt>
            <dd><a href="http://www.dominicpettifer.co.uk">www.dompet.co.uk</a></dd>
        </dl>
        
        <h2>Career Objectives</h2>
        
        <ul>
            <li>
                Pursuing a career in Software Engineering, specifically in building web based applications,
                an area I have a keen interest in.
            </li>
            <li>
                Learning and keeping abreast of new technologies and acquiring new skills.
            </li>
        </ul>
        
        
        
        <h2>Education and Qualifications</h2>
        
        <div id="CV-Eduation">
            <h3>University of Abertay Dundee - MSc Software Engineering (Internet Computing)</h3>
            <p>Sept 2005 - Jan 2007</p>
            <p><strong>Results:</strong> PostGrad Diploma (PGDip)</p>
            
            <ul>
                <li>Emphasis on OO programming with Java, Swing, and distributed computing with EJBs.</li>
                <li>Web applications development with Java Servlets and JSP (some ASP, PHP and JavaScript).</li>
                <li>Mobile internet development with J2ME, WML, XHTML.</li>
                <li>XML technologies such as XSLT and XPath.</li>
                <li>Currently researching and developing web project based on Ajax technologies.</li>
            </ul>
            
            <h3>University of Abertay Dundee - BSc (Hons) Computing (Applications Development)</h3>
            <p>Sept 2000 – June 2005</p>
            <p><strong>Results:</strong> 1st class honours.</p>
            
            <ul>
                <li>Emphasis on internet technologies.</li>
                <li>Computer networking and security.</li>
                <li>User interaction and interface design.</li>
                <li>Client/Server software.</li>
                <li>Mobile web development.</li>
                <li>Databases – including theory (Normalisation etc.).</li>
                <li>Final year project – intranet database driven web application for a real company (see portfolio).</li>
            </ul>
            
            <h3>Fakenham Sixth Form College (A-Levels)</h3>
            <p>Sept 1997 – June 1999</p>
            <p><strong>Results:</strong> History (C), Design &amp; Technology (D), Psychology (B)</p>
        </div>
        
        
        
        <h2>Work Experience</h2>
        
        <h3>Conscia Enterprise Systems</h3>
        <p>Jan 2007 - Present</p>
        <p>Webite: <a href="http://www.conscia.co.uk">www.conscia.co.uk</a></p>
        
        <ul>
            <li>Web Developer</li>
            <li>ASP.NET 2.0/3.5, C#, SQL Server 2000/2005</li>
            <li>Extensive work with Umbraco (open-source CMS)</li>
            <li>Mainly NHS websites and systems</li>
        </ul>
        
        <h2>Technical Skills and Knowledge</h2>
        
        <dl id="CV-Technical">
            <dt>Programming:</dt>
            <dd>
                C#, ASP.NET 2.0/3.5, ASP.NET MVC 1.0, JavaScript (jQuery), ORMs (Object Relational Mappers)
                including NHibernate, LINQ 2 SQL, SubSonic, and Entity Framework.
            </dd>
            
            <dt>Databases:</dt>
            <dd>
                SQL Server 2000/2005, Database design/theory (normalisation etc.).
                Stored Procedures, triggers, views, security, optimisation.
            </dd>
            
            <dt>Web:</dt>
            <dd>
                XHTML/CSS, XML/XSLT, Semantic/Standards based mark-up, WAI (Web Accessibility), JavaScript/DHTML (with jQuery) and Ajax,
                SEO (Search Engine Optimisation) techniques, Advanced Website optimisation/performance techniques,
                Web application security concepts (SQL Injection, XSS, Session hijacking etc.), REST/SOAP, some Silverlight.
            </dd>
            
            <dt>Tools/Software:</dt>
            <dd>
                Visual Studio 2005/2008, Team Foundation Server, Subversion (VisualSVN), Umbraco Content Management System,
                Vista/Windows Server 2003/2008 + IIS 6/7, Office 2007.
            </dd>
        </dl>
        
        <h2>Project Portfolio</h2>
        
        <p>You can see a <a href="/Portfolio">portfolio of my work here</a>.</p>
        
        <h2>Personal Skills</h2>
        
        <h3>Communication</h3>
        
        <ul>
            <li>
                Collaborated with clients at SCRI (see portfolio) on a regular basis for requirements
                elicitation, and technical scientific knowledge extraction, for the Seed Archive System.
            </li>
            <li>
                Given presentations on complex technical subjects (web application security).
            </li>
        </ul>
        
        <h3>Working as a Team</h3>
        
        <ul>
            <li>Worked on a team of 3 for final year university project, successfully resulted in a finished product.</li>
            <li>Worked as lead developer for project at work, providing assistance to peers, and communicating ideas.</li>
        </ul>
        
        <h3>Analytical and Problem Solving Skills</h3>
        
        <ul>
            <li>
                Enjoy analysing and solving complex technical software engineering and programming problems,
                and analysing existing solutions to see how they work.
            </li>
            <li>Get a buzz when a solution comes together. </li>
        </ul>
        
        <h3>Passion for Learning</h3>
        
        <ul>
            <li>
                Reading about good software development/design practices such as Agile Methodologies,
                Design Patterns, architectural design solutions (n-tier, SOA) and coding practices.
            </li>
        </ul>
        
        <h2>Interests</h2>
        
        <ul>
            <li>
                Keen PC hardware enthusiast, enjoy building PCs, updating, tweaking and overclocking,
                reading up on latest hardware and innovations in technology.
            </li>
            <li>
                Keen video game fanatic, especially playing games online with friends. 
            </li>
            <li>
                Socialising with friends; music and films.
            </li>
        </ul>
        
        <h2>References</h2>
        
        <p>(Available on request)</p>
    
    </div>

</asp:Content>
