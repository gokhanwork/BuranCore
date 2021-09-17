using Buran.Core.Library.Utils;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Buran.Core.Library.Mail
{
    public class MailSender
    {
        private SmtpClient _smtp;

        private SmtpClient GetSmtpClient(string host = null, int port = 0, string userName = null, string password = null,
            bool enableSsl = false)
        {
            if (_smtp == null)
            {
                _smtp = !string.IsNullOrWhiteSpace(host) && port > 0
                    ? new SmtpClient { Host = host, Port = port, Timeout = 60000 }
                    : new SmtpClient();
                _smtp.EnableSsl = enableSsl;
                if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
                {
                    _smtp.Credentials = new NetworkCredential(userName, password);
                }
            }
            return _smtp;
        }
        public bool EmailTests(string email)
        {
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                   + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                   + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public void Send(string to, string bcc, string subject, string body,
            string emailFrom = null, string fromDisplay = null,
            string host = null, int port = 0, string userName = null, string password = null,
            bool enableSsl = false,
            Attachment attachment = null)
        {
            Send(to, bcc, subject, body, emailFrom, fromDisplay, host, port, userName, password, enableSsl,
                attachment != null ? new List<Attachment> { attachment } : null
            );
        }

        public void Send(string to, string bcc, string subject, string body,
            string emailFrom = null, string fromDisplay = null,
            string host = null, int port = 0, string userName = null, string password = null,
            bool enableSsl = false,
            List<Attachment> attachment = null)
        {
            var mail = new MailMessage
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,
                SubjectEncoding = Encoding.UTF8,
            };
            if (!emailFrom.IsEmpty() && !fromDisplay.IsEmpty())
                mail.From = new MailAddress(emailFrom, fromDisplay);
            else if (!emailFrom.IsEmpty())
                mail.From = new MailAddress(emailFrom);

            if (to.Contains(";"))
            {
                var sendMailAdressSplitted = to.Split(';');
                foreach (var item in sendMailAdressSplitted)
                {
                    if (item != null && !item.IsEmpty())
                        mail.To.Add(item);
                }
            }
            else
                mail.To.Add(to);

            if (!bcc.IsEmpty())
            {
                if (bcc.Contains(";"))
                {
                    var sendMailAdressSplitted = bcc.Split(';');
                    foreach (var item in sendMailAdressSplitted)
                    {
                        if (item != null && !item.IsEmpty())
                            mail.Bcc.Add(item);
                    }
                }
                else
                    mail.Bcc.Add(bcc);
            }

            if (attachment != null)
            {
                foreach (var a in attachment)
                {
                    mail.Attachments.Add(a);
                }
            }

            var sender = GetSmtpClient(host, port, userName, password, enableSsl);
            sender.Send(mail);
        }
    }
}
