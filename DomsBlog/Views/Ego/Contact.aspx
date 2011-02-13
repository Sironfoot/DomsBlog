<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="headerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Contact Dominic
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul class="Breadcrumbs">
        <li><a href="/About">About</a></li>
        <li class="last">Contact</li>
    </ul>
    
    <div id="ContactSection">

        <h1 id="FirstHeader">Contact Dominic</h1>
        
        <dl>
            <dt>Email:</dt>
            <dd><a href="mailto:sironfoot@msn.com">sironfoot@msn.com</a></dd>
            <dt>Twitter:</dt>
            <dd><a href="http://twitter.com/Sironfoot">twitter.com/Sironfoot</a></dd>
        </dl>
        
        <h2>Contact</h2>
        
        <p>
            You can email me at <a href="mailto:sironfoot@msn.com">sironfoot@msn.com</a> or use the contact form below.
            If you have an enquiry regarding any of the blogs, please do use the blog commentting feature,
            I do read them and respond to any queries, and you might get a good response from another reader.
        </p>
        
        <p>
            Alternatively, if you're a fan of Twitter, you can follow me at <a href="http://twitter.com/Sironfoot">twitter.com/Sironfoot</a>
        </p>
        
        <h2>Contact Form</h2>
        
        <% if (Request.QueryString["success"] == "true") { %>
            <p class="sendSuccess successFade">Your message was successfully sent. Thank you!</p>
        <% } %>
        
        <% using (Html.BeginForm()) { %>
            <fieldset class="StandardForm">
                <legend>Contact Form</legend>
                                
                <div class="FormRow">
                    <label for="name">Your Name:</label>
                    <%= Html.TextBox("name")%> *
                    <%= Html.ValidationMessage("name") %>
                </div>
                
                <div class="FormRow">
                    <label for="email">Email:</label>
                    <%= Html.TextBox("email")%> *
                    <%= Html.ValidationMessage("email")%>
                </div>
                
                <div class="FormRow">
                    <label for="message">Message:</label>
                    <%= Html.TextArea("message", new { cols = 50, rows = 10 })%> *
                    <%= Html.ValidationMessage("message")%>
                </div>
                
                <div class="FormRowCaptcha">
                    <label>Anti-spam Test</label>
                
                    <% Html.RenderPartial("ReCaptcha"); %>
                    
                    <%= Html.ValidationMessage("Captcha")%>
                </div>
                
                <div class="FormButtons">
                    <input type="submit" value="Send Message" />
                </div>
            </fieldset>
        <% } %>
        
    </div>

</asp:Content>