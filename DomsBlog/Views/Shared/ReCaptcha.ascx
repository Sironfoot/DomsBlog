<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<script type="text/javascript" src="http://api.recaptcha.net/challenge?k=<%= DomsBlog.Utils.BlogValues.CaptchaPublicKey() %>"></script>

<noscript>
    <div>
        <iframe src="http://api.recaptcha.net/noscript?k=<%= DomsBlog.Utils.BlogValues.CaptchaPublicKey() %>"></iframe>

        <textarea name="recaptcha_challenge_field" rows="3" cols="40"></textarea>
        <input type="hidden" name="recaptcha_response_field" value="manual_challenge" />
   </div>
</noscript>