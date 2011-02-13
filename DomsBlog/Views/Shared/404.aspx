<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	404
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MetaContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <ul class="Breadcrumbs">
        <li class="last">404</li>
    </ul>
    
    <h1 id="FirstHeader">404 - Page Cannot Be Found</h1>
    
    <p>Oh butter fingers!</p>

</asp:Content>