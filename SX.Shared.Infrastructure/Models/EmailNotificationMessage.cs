using SX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SX.Shared.Infrastructure.Models
{
    public class EmailNotificationMessage : NotificationMessage
    {
        public List<FileData> Resources { get; set; } = new List<FileData>();

        protected EmailNotificationMessage() { }
        public EmailNotificationMessage(string subject, string text, Recipients? recipients = null, string sender = "")
            : base(subject, text, recipients, sender) { }

        public bool IsHtml() => IsHtml(this.Text);

        new public EmailNotificationMessage Copy(Recipients recipients)
        {
            return new EmailNotificationMessage()
            {
                Subject = this.Subject,
                Text = this.Text,

                Sender = this.Sender,
                Recipients = recipients ?? new Recipients(),

                Attachments = new List<FileData>(this.Attachments),
                Resources = new List<FileData>(this.Resources)
            };
        }

        public void AddResources(IEnumerable<FileData> resources)
        {
            if (resources != null)
                this.Resources = this.Resources.Union(resources).ToList();
        }

        public override List<FileData> GetAllFiles()
        {
            var result = base.GetAllFiles();
            if (this.Resources != null && this.Resources.Count > 0)
                result.AddRange(this.Resources);
            return result;
        }

        public static bool IsHtml(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
                return false;

            return Regex.IsMatch(text, @"<\/p>|<\/div>|<\/html>|<\/body>", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.RightToLeft);
        }
    }
}
