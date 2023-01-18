using System.Collections.Generic;
using System.Linq;

namespace SX.Shared.Models
{
    public class NotificationMessage
    {
        public string Subject { get; protected set; } = "";
        public string Text { get; protected set; } = "";
        public string Sender { get; protected set; } = "";
        public Recipients Recipients { get; protected set; } = new Recipients();
        public List<FileData> Attachments { get; protected set; } = new List<FileData>();

        protected NotificationMessage() { }

        public NotificationMessage(string subject, string text, Recipients? recipients = null, string sender = "")
        {
            this.Subject = subject ?? "";
            this.Text = text ?? "";
            this.Recipients = recipients ?? new Recipients();
            this.Sender = sender ?? "";
        }

        public override string ToString()
        {
            return $"Message: '{this.Subject}'";
        }

        public virtual NotificationMessage Copy(Recipients recipients)
        {
            return new NotificationMessage()
            {
                Subject = this.Subject,
                Text = this.Text,

                Sender = this.Sender,
                Recipients = recipients ?? new Recipients(),

                Attachments = new List<FileData>(this.Attachments)
            };
        }

        public void AddRecipients(Recipients recipients)
        {
            if (recipients == null)
                return;

            this.Recipients.Add(recipients);
        }
        public void AddRecipients(IEnumerable<Recipient> recipients) => this.AddRecipients(new Recipients(recipients));
        public void AddAttachments(IEnumerable<FileData> attachments)
        {
            if (attachments != null)
                this.Attachments = this.Attachments.Union(attachments).ToList();
        }

        public virtual List<FileData> GetAllFiles()
        {
            var result = new List<FileData>();
            if (this.Attachments != null && this.Attachments.Count > 0)
                result.AddRange(this.Attachments);
            return result;
        }
    }
}
