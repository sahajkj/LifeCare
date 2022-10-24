using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace src.Utils
{
    public class EmailSender
    {
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("sahajkjain@gmail.com", "Lifecare Services");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }
    }
}