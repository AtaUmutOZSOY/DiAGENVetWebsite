using System.Net.Mail;
using System.Net;

namespace DiagenVet.Core.Utilities.Helpers
{
    public class MailHelper
    {
        private readonly string _host;
        private readonly int _port;
        private readonly string _username;
        private readonly string _password;

        public MailHelper(string host, int port, string username, string password)
        {
            _host = host;
            _port = port;
            _username = username;
            _password = password;
        }

        public async Task SendEmailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            using (var client = new SmtpClient(_host, _port))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(_username, _password);

                var message = new MailMessage
                {
                    From = new MailAddress(_username),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isBodyHtml
                };
                message.To.Add(to);

                await client.SendMailAsync(message);
            }
        }
    }
} 