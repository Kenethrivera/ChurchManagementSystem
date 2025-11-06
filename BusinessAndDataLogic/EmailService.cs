using MailKit.Net.Smtp;
using Microsoft.IdentityModel.Protocols;
using MimeKit;
using Microsoft.Extensions.Configuration;
using MailKit.Security;

namespace BusinessAndDataLogic
{
    public class EmailService
    {

        private readonly IConfiguration _configuration;


        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendWelcomeEmail(string recipientEmail, string recipientName, string ministryName)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(
                _configuration["EmailSettings:FromName"],
                _configuration["EmailSettings:FromEmail"])
            );
            message.To.Add(new MailboxAddress(recipientName, recipientEmail));
            message.Subject = "Welcome to " +
                "" +
                "" + ministryName +"!";

            string body = $@"
                <h2>Welcome to {ministryName}!</h2>
                <p>Dear <b>{recipientName}</b>,</p>
                <p>We are excited to have you as part of our {ministryName} team.</p>
                <p>May the Lord continue to use you mightily in His service!</p>
                <p><b>God bless you!</b><br/>– Church Management Team</p>
            ";

            message.Body = new TextPart("html")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.Connect(
                    _configuration["EmailSettings:SmtpHost"],
                    int.Parse(_configuration["EmailSettings:SmtpPort"]),
                    SecureSocketOptions.StartTls
                );
                client.Authenticate(
                    _configuration["EmailSettings:Username"],
                    _configuration["EmailSettings:Password"]
                );
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
