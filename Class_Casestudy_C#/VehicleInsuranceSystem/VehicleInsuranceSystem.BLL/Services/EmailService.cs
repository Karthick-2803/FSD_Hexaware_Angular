using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using VehicleInsuranceSystem.BLL.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace VehicleInsuranceSystem.BLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailWithAttachmentAsync(string toEmail, string subject, string body, byte[] attachmentBytes, string fileName)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_configuration["EmailSettings:From"]));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = subject;

            var builder = new BodyBuilder { TextBody = body };

            if (attachmentBytes != null)
            {
                builder.Attachments.Add(fileName, attachmentBytes);
            }

            message.Body = builder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(_configuration["EmailSettings:SmtpServer"], int.Parse(_configuration["EmailSettings:Port"]), true);
            await client.AuthenticateAsync(_configuration["EmailSettings:Username"], _configuration["EmailSettings:Password"]);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}