using BLL.IService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var form = _configuration[("EmailSettings:From")];
            var smtpServer = _configuration[("EmailSettings:SmtpServer")];
            var port = int.Parse(_configuration[("EmailSettings:SmtpPort")]!);
            var username = _configuration[("EmailSettings:Username")];
            var pass = _configuration[("EmailSettings:Password")];
            
            var message = new MailMessage(form!,toEmail,subject,body);
            message.IsBodyHtml = true;

            using var client = new SmtpClient(smtpServer!, port)
            {
                Credentials = new NetworkCredential(username, pass),
                EnableSsl = true
            };
            
            await client.SendMailAsync(message);
        }
    }
}
