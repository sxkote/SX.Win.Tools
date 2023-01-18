using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System;
using SX.Shared.Infrastructure.Models;
using SX.Shared.Infrastructure.Contracts;
using SX.Shared.Models;
using SX.Shared.Exceptions;
using System.Linq;

namespace SX.Shared.Infrastructure.Services
{
    public class EmailNotificationService : IEmailNotificationService
    {
        protected SMTPServerConfig _config;

        public EmailNotificationService(SMTPServerConfig config)
        { _config = config; }

        public EmailNotificationService(string connectionString)
        { _config = new SMTPServerConfig(connectionString); }

        public MailAddress GetDefaultSender() => new MailAddress(_config.Address ?? "", _config.Name);

        protected virtual SmtpClient BuildSMTPClient()
        {
            if (_config == null)
                return new SmtpClient();

            ServicePointManager.SecurityProtocol = _config.SecurityProtocol;

            var client = new SmtpClient(_config.Server, _config.Port);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_config.Login, _config.Password);
            client.EnableSsl = _config.SSL;

            return client;
        }

        protected virtual List<string> GetRecipents(Recipients recipients)
        {
            if (recipients == null)
                return new List<string>();

            return recipients
                .Where(r => r.Address.Contains("@"))
                .Select(r => r.Address)
                .Where(a => !String.IsNullOrWhiteSpace(a))
                .ToList();
        }

        protected virtual MailMessage? BuildMessage(MailAddress? from, Recipients recipients, IEnumerable<FileData>? attachments = null)
        {
            var message = new MailMessage();

            if (from != null)
            {
                message.From = from;
                message.Sender = from;
                message.ReplyToList.Add(from);
            }
            else
            {
                message.From = this.GetDefaultSender();
            }

            // получатели Email сообщения
            var messageRecipents = this.GetRecipents(recipients);
            if (messageRecipents == null || messageRecipents.Count <= 0)
                return null;

            foreach (var r in messageRecipents)
                message.To.Add(r);


            if (attachments != null)
                foreach (var file in attachments)
                    message.Attachments.Add(new Attachment(new MemoryStream(file.Data), file.FileName));

            return message;
        }

        protected List<LinkedResource> BuildLinkedResources(ref string content, IEnumerable<FileData> files = null)
        {
            var result = new List<LinkedResource>();

            if (files == null)
                return result;

            foreach (var file in files)
            {
                // create new Linked Resource
                var linkedResource = new LinkedResource(new MemoryStream(file.Data), MimeMappingsService.GetMimeMapping(file.FileName));

                // generate new GUID to Resource
                linkedResource.ContentId = Guid.NewGuid().ToString();

                // add Resource to the result collection
                result.Add(linkedResource);

                // replace File link (href) to Resource GUID
                content = Regex.Replace(content, $"=\"{file.FileName}\"", $"=\"cid:{linkedResource.ContentId}\"");
            }

            return result;
        }

        protected AlternateView BuildHtmlView(string htmlText, IEnumerable<FileData> htmlResources = null)
        {
            // get content to modify by internal resources links
            var viewContent = htmlText;

            // get Linked Resources from files
            var viewResources = this.BuildLinkedResources(ref viewContent, htmlResources);

            // create new HTML View 
            var view = AlternateView.CreateAlternateViewFromString(viewContent, null, "text/html");

            // add all Linked Resources to View
            foreach (var res in viewResources)
                view.LinkedResources.Add(res);

            return view;
        }

        public void SendEmail(EmailNotificationMessage message)
        {
            if (message == null)
                throw new CustomArgumentException("Не задано сообщение для отправки e-mail!");

            if (message.Recipients == null || message.Recipients.Count <= 0)
                return;

            var email = this.BuildMessage(null, message.Recipients, message.Attachments);
            if (email == null)
                return;

            email.Subject = message.Subject.Trim();
            email.IsBodyHtml = message.IsHtml();

            if (email.IsBodyHtml)
            {
                // add HTML View to the Message
                email.AlternateViews.Add(this.BuildHtmlView(message.Text, message.Resources));
            }
            else
            {
                email.Body = message.Text;
            }

            using (var smtp = this.BuildSMTPClient())
            {
                smtp.Send(email);
            }
        }
    }
}
