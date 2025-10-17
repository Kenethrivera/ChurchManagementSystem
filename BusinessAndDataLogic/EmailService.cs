using MailKit.Net.Smtp;
using MimeKit;

namespace BusinessAndDataLogic
{
    public class EmailService
    {

        private readonly string smtpHost = "sandbox.smtp.mailtrap.io";
        private readonly int smtpPort = 587;
        private readonly string smtpUser = "9401367f6acf76";
        private readonly string smtpPass = "1d8ea046b9f43c";

        public EmailService()
        {

        }

        public void SendWelcomeEmail(string recipientEmail, string recipientName, string ministryName)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Church CMS", "no-reply@churchcms.com"));
            message.To.Add(new MailboxAddress(recipientName, recipientEmail));
            message.Subject = "Welcome to the " + ministryName + " Ministry!";

            string body = $@"
                <h2>Welcome to the {ministryName} Ministry!</h2>
                <p>Dear {recipientName},</p>
                <p>We are excited to have you as part of our {ministryName} ministry team.</p>
                <p>May the Lord continue to use you mightily in His service!</p>
                <p><b>God bless you!</b><br/>– Church Management Team</p>
            ";

            message.Body = new TextPart("html")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.Connect(smtpHost, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate(smtpUser, smtpPass);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
