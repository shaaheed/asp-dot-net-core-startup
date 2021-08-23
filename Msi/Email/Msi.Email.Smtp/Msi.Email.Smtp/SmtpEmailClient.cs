using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace Msi.Email.Smtp
{
    public class SmtpEmailClient : IEmailClient
    {
        public Task SendAsync(string to, string subject, string message, bool isHtml = true)
        {
            return SendAsync(new List<string> { to }, subject, message, isHtml);
        }

        public async Task SendAsync(IEnumerable<string> tos, string subject, string message, bool isHtml = true)
        {
            var _message = new MimeMessage();
            _message.From.Add(new MailboxAddress("_emailOptions.SenderName", "_emailOptions.SenderEmailAddress"));

            var addresses = tos.Select(x => MailboxAddress.Parse(x));
            _message.To.AddRange(addresses);
            _message.Subject = subject;

            var textFormat = isHtml ? TextFormat.Html : TextFormat.Plain;
            _message.Body = new TextPart(textFormat)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    // Accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await client.ConnectAsync("_emailOptions.SmtpServer", Convert.ToInt32("_emailOptions.SmtpPort"), false);

                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    // Note: only needed if the SMTP server requires authentication
                    await client.AuthenticateAsync("_emailOptions.SenderEmailAddress", "_emailOptions.Password");

                    await client.SendAsync(_message);
                    await client.DisconnectAsync(true);
                }
                catch (Exception)
                {
                    //_logger.LogError("Email send error: " + ex.Message);
                }
            }
        }
    }
}
