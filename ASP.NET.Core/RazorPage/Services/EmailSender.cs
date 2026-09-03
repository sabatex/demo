using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RazorPage.Services
{
    public class EmailSender : IEmailSender
    {
        public readonly IConfiguration Configuration;
        public EmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mailServer = Configuration.GetSection("MailServer");
            var pass = mailServer["Pass"];
            var login = mailServer["Login"];
            var host = mailServer["Host"];
            var port = mailServer["Port"];
            var enableSsl = mailServer["EnableSsl"];
            var smtpClient = new SmtpClient()
            {
                Host = host,// smtp.gmail.com
                Port = int.Parse(port),//587
                EnableSsl = bool.Parse(enableSsl),//true
                Credentials = new NetworkCredential(login, pass)

            };
            using (var mail = new MailMessage(login, email, subject, htmlMessage))
            {
                mail.IsBodyHtml = true;
                await smtpClient.SendMailAsync(mail);

            }
        }
    }
}
