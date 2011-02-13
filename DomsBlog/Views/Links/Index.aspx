<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="headerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Useful Links
</asp:Content>

<asp:Content ID="metaContent" ContentPlaceHolderID="MetaContent" runat="server">
    <meta name="description" content="Some links I have found extremely useful, though your mileage may vary." />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="Breadcrumbs">
        <li class="last">Links</li>
    </ul>
    
    <div class="LinksSection">
    
        <h1 id="FirstHeader">Useful Links</h1>
        
        
        <h2>Programming Blogs</h2>
        <ul class="Links">
            <li>
                <h3><a href="http://weblogs.asp.net/scottgu/">ScottGu's Blog</a></h3>
                <a class="LinkInfo" href="http://weblogs.asp.net/scottgu/rss.aspx">Show RSS</a>
                <p>
                    The legendary Gu, or "The Gu". He's Corporate Vice President in the Microsoft Developer Division,
                    and brains behind many key .NET technologies such as ASP.NET MVC and Silverlight.
                </p>
            </li>
            <li>
                <h3><a href="http://haacked.com/">Phil Haack</a></h3>
                <a class="LinkInfo" href="http://feeds.haacked.com/haacked">Show RSS</a>
                <p>
                    Senior Program Manager at Microsoft. Plenty of coverage on ASP.NET MVC.
                </p>
            </li>
            <li>
                <h3><a href="http://blog.codeville.net/">Steve Sanderson's blog</a></h3>
                <a class="LinkInfo" href="http://feeds.codeville.net/SteveCodeville?format=xml">Show RSS</a>
                <p>
                    Written the book <a href="http://apress.com/book/view/9781430210078">Pro ASP.NET MVC Framework</a>.
                    Covers a lot on MVC.
                </p>
            </li>
            <li>
                <h3><a href="http://www.codinghorror.com/blog/">Coding Horror</a></h3>
                <a class="LinkInfo" href="http://feeds2.feedburner.com/codinghorror">Show RSS</a>
                <p>
                    Jeff Atwood, ASP.NET developer, built <a href="http://stackoverflow.com/">stackoverflow.com</a>
                    a community maintained programming Q&amp;A site built with ASP.NET MVC.
                </p>
            </li>
            <li>
                <h3><a href="http://www.livz.org/">Weblivz</a></h3>
                <a class="LinkInfo" href="http://weblivz.blogspot.com/feeds/posts/default">Show RSS</a>
                <p>
                    Entrepreneur, .NET consultant and author based in Glasgow, Scotland. Friend of mine, runs the
                    celebrity validation service <a href="http://valebrity.com/">Valebrity.com</a> to validate
                    celebrities on social networking sites such as Facebook and Twitter.
                </p>
            </li>
            <li>
                <h3><a href="http://www.littlefool.com/">Littlefool.com</a></h3>
                <a class="LinkInfo" href="http://www.littlefool.com/GetRSS.aspx">Show RSS</a>
                <p>
                    A friend on mine from university. Covers ASP.NET, SQL Server, LINQ etc.
                </p>
            </li>
        </ul>
        
        
        
        <h2>Other Blogs</h2>
        <ul class="Links">
            <li>
                <h3><a href="http://www.alanjack.co.uk/">Alan Jack</a></h3>
                <a class="LinkInfo" href="http://www.alanjack.co.uk/gaming/atom.xml">Show RSS</a>
                <p>Games developer/designer. Friend from university.</p>
            </li>
        </ul>
        
        
        
        
        <h2>Useful Programming Related Sites</h2>
        <ul class="Links">
            <li>
                <h3><a href="http://stackoverflow.com/">StackOverflow.com</a></h3>
                <a class="LinkInfo" href="http://stackoverflow.com/feeds">Show RSS</a>
                <p>Collaborative/community maintained Question &amp; Answer site for programmers.</p>
            </li>
            <li>
                <h3><a href="http://www.codeproject.com/">The Code Project</a></h3>
                <a class="LinkInfo" href="http://www.codeproject.com/webservices/articlerss.aspx?cat=1">Show RSS</a>
                <p>.NET focused community driven site for resources, articles, and guides for programmers.</p>
            </li>
        </ul>
        
        
        
        <h2>Other Useful Sites</h2>
        <ul class="Links">
            <li>
                <h3><a href="http://valebrity.com/">Valebrity.com</a></h3>
                <a class="LinkInfo" href="http://valebrity.com/feed/">Show RSS</a>
                <p>
                    Celebrity validation service. Find out if celebrities are real on social networking sites
                    such as Twitter and Facebook.
                </p>
            </li>
        </ul>
        
        
        
        
        <h2>Sites I've Built/Helped Build</h2>
        <ul class="Links">
            <li>
                <h3><a href="http://www.privatemenorca.com">Private Menorca</a></h3>
                <p>Properties to rent in Menorca.</p>
            </li>
            <li>
                <h3><a href="http://www.blueislandsun.co.uk/">BlueIslandSun</a></h3>
                <p>More properties (or property) to rent in Menorca.</p>
            </li>
            <li>
                <h3><a href="http://www.bordershealthinhand.scot.nhs.uk">Borders Health In Hand</a></h3>
                <p>NHS Education for Scotland, information site.</p>
            </li>
            <li>
                <h3><a href="http://www.workforceplanning.scot.nhs.uk">Developing Workforce Planning Capability in Scotland</a></h3>
                <p>Another Umbraco based NHS Education for Scotland site.</p>
            </li>
            <li>
                <h3><a href="http://learningfromevent.scot.nhs.uk/home.aspx">NHSScotland Event 2008</a></h3>
                <p>Promotional/informational site for an NHS event take took place in 2008.</p>
            </li>
        </ul>
    
    </div>

</asp:Content>