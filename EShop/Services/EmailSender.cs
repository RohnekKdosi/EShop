using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace EShop.Services
{
    public class EmailSender
    {
        public IConfiguration Configuration { get; protected set; }
        private string _fromName = "IronMan";
        private string _from = "iron@stark.com";
        private int _port = 2525;
        private string _server = "smtp.mailtrap.io";
        private string _userName = "xxxxxxxxxxx";
        private string _password = "xxxxxxxxxxx";
        public EmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
            _fromName = Configuration["EmailSender:FromName"];
            _from = Configuration["EmailSender:From"];
            _port = int.Parse(Configuration["EmailSender:Port"]);
            _server = Configuration["EmailSender:Server"];
            _userName = Configuration["EmailSender:Username"];
            _password = Configuration["EmailSender:Password"];
        }

        public Task SendEmailAsync(string emailAddress, string subject, string text)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_fromName, _from));
            message.To.Add(new MailboxAddress(emailAddress));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = text;
            bodyBuilder.HtmlBody = "<p style=\"color: red;\">" + text + "</p>";
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(_server, _port, true);
                client.Authenticate(_userName, _password);
                client.Send(message);
                client.Disconnect(true);
                return Task.FromResult(0);
            }
        }
    }
}
