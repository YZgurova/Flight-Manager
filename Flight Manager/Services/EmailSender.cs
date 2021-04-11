using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Flight_Manager.Common.GlobalConstants;

namespace Flight_Manager.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string toMail, string subject, string messageBody)
        {
            var apiKey = Email.ApiKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(Email.SystemEmail, SystemName);
            var to = new EmailAddress(toMail);

            var msg = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                messageBody,
                messageBody);

            await client.SendEmailAsync(msg);
        }
    }
}
