using MetuljmaniaDatabase.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.Helpers
{
    public class NotificationHelper
    {
        private readonly SmtpClient smtpClient;
        public NotificationHelper()
        {
            var fromAddress = new MailAddress(Constants.FromAddress, "From Name");

            smtpClient = new SmtpClient
            {
                Host = Constants.Host,
                Port = Constants.Port,
                EnableSsl = Constants.EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, Constants.GmailPassword),
                Timeout = Constants.Timeout
            };
        }

        public void Send(string toAddress, string subject, string body, string attachmentFilepath)
        {
            using var message = new MailMessage(Constants.FromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            message.Attachments.Add(new Attachment(attachmentFilepath));

            smtpClient.Send(message);
        }

        public void Send(string toAddress, string subject, string body)
        {
            using var message = new MailMessage(Constants.FromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            smtpClient.Send(message);
        }
    }
}
