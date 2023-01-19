using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using TodoApp.DataVerifier;

namespace TodoApp.EmailService.Services
{
    public class EmailSender : IEmailSender
    {
        private SmtpClient smtpClient;
        private readonly IConfigurationRoot config;
        private string errmsg;
        public string ErrMsg => errmsg;
        public EmailSender()
        {
            var builder = new ConfigurationBuilder().AddJsonFile(@"D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\TodoApp.EmailService\mailconfig.json");

            config = builder.Build();
        }

        /// <summary>
        /// Send email message for receiver configured in mailconfig.json.
        /// </summary>
        /// <param name="email">String representation of user's email.</param>
        /// <param name="subject">String representation of message title.</param>
        /// <param name="content">Content to send.</param>
        /// <returns>Returns 1 if the message was succesfully send, otherwise -1.</returns>
        /// <exception cref="ArgumentNullException">When email is null or empty or is not email format. Also for subject and title.</exception>
        public int SendEmail(string email, string subject, string content)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException(nameof(content));
            }

            if (string.IsNullOrEmpty(subject))
            {
                throw new ArgumentNullException(nameof(subject));
            }

            if (Verifier.Verify(email, EntityDataType.EMAIL) is false)
            {
                return -1;
            }

            MailAddress addressFrom = new MailAddress(email);
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = addressFrom;
            mailMessage.Subject = subject;
            mailMessage.Body = content;
            
            var host = config["smtpConfig:Host"];

            var port = Convert.ToInt32(config["smtpConfig:Port"]);
            var username = config["smtpConfig:Username"];
            var password = config["smtpConfig:Password"];

            mailMessage.To.Add(new MailAddress("help@todoapp.com"));

            smtpClient = new SmtpClient(host, port);
            smtpClient.Credentials = new NetworkCredential(username, password);
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mailMessage);
                errmsg = "Email was send.";
            }
            catch(SmtpException)
            {
                errmsg = "Unable to send message";
                return -1;
            }

            return 1;
        }
    }
}
