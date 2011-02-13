using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.Extensions;

namespace DomsBlog.Models.Service
{
    public class CommentForm
    {
        public CommentForm()
        {
            YourName = "";
            EmailAddress = "";
            Website = "";
            EmailOnReply = false;

            Title = "";
            CommentText = "";

            PassesCaptchaValidation = true;
        }

        public int ContainerId { get; set; }
        public int? ParentCommentId { get; set; }
        public string YourName { get; set; }
        public string EmailAddress { get; set; }
        public string Website { get; set; }
        public bool EmailOnReply { get; set; }
        public string Title { get; set; }
        public string CommentText { get; set; }
        public string IpAddress { get; set; }
        public bool IsAdminComment { get; set; }
        public bool PassesCaptchaValidation { get; set; }

        public CommentView ReplyComment { get; set; }

        public const int NameMaxLength = 64;
        public const int EmailAddressMaxLength = 128;
        public const int WebsiteMaxLength = 128;
        public const int TitleMaxLength = 64;
        public const int CommentTextMaxLength = 4000;

        public bool IsValid(IValidationDictionary validationDictionary)
        {
            // Required fields
            if (Title.IsNullEmptyOrWhitespace())
            {
                validationDictionary.AddError("Title", "Required field.");
            }

            if (CommentText.IsNullEmptyOrWhitespace())
            {
                validationDictionary.AddError("CommentText", "Required field.");
            }

            if (EmailOnReply && EmailAddress.IsNullEmptyOrWhitespace())
            {
                validationDictionary.AddError("EmailAddress", "Email Address required for reply notification");
            }

            // Regex patterns
            if (!EmailAddress.IsNullEmptyOrWhitespace() && !EmailAddress.IsEmailAddress())
            {
                validationDictionary.AddError("EmailAddress", "Must be a valid email address.");
            }

            if (!Website.IsNullEmptyOrWhitespace() && !Website.IsHttpUrl())
            {
                validationDictionary.AddError("Website", "Must be a valid URL (include http:// part, or leave blank).");
            }

            // Max length violations
            if((Title ?? "").Trim().Length > TitleMaxLength)
            {
                validationDictionary.AddError("Title", "Cannot be longer than " + TitleMaxLength + " characters.");
            }

            if ((YourName ?? "").Trim().Length > NameMaxLength)
            {
                validationDictionary.AddError("YourName", "Cannot be longer than " + NameMaxLength + " characters.");
            }

            if ((EmailAddress ?? "").Trim().Length > EmailAddressMaxLength)
            {
                validationDictionary.AddError("EmailAddress", "Cannot be longer than " + EmailAddressMaxLength + " characters.");
            }

            if ((Website ?? "").Trim().Length > WebsiteMaxLength)
            {
                validationDictionary.AddError("Website", "Cannot be longer than " + WebsiteMaxLength + " characters.");
            }

            if ((CommentText ?? "").Trim().Length > CommentTextMaxLength)
            {
                validationDictionary.AddError("CommentText", "Cannot be longer than " + CommentTextMaxLength + " characters.");
            }

            // Recaptcha
            if (!PassesCaptchaValidation)
            {
                validationDictionary.AddError("Captcha", "Failed Captcha test, please try again.");
            }
            
            return validationDictionary.IsValid;
        }
    }
}