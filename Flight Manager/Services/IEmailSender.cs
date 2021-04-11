using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(
            string toMail,
            string subject,
            string messageBody);
    }
}
