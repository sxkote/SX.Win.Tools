using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SX.Shared.Models
{
    public class Recipient
    {
        public string Address { get; protected set; }

        public Recipient(string address)
        {
            this.Address = address ?? "";
        }

        public override string ToString() =>this.Address ?? "";

        public bool IsMultiple() => Regex.IsMatch(this.Address, Recipients.SEPARATORS);

        //static public RecipientType DefineRecipientType(string address)
        //{
        //    if (String.IsNullOrWhiteSpace(address))
        //        return RecipientType.Name;

        //    if (address.Contains("@"))
        //        return RecipientType.Email;
        //    if (address.IsPhoneNumber())
        //        return RecipientType.Phone;

        //    return RecipientType.Name;
        //}

        static public implicit operator Recipient(string value) => new Recipient(value);

        static public implicit operator string(Recipient recipient) => recipient?.Address ?? "";
    }

    public class Recipients : List<Recipient>
    {
        public const string SEPARATORS = @",|;";

        public Recipients(IEnumerable<Recipient> collection)
            : base() { this.Add(collection); }

        public Recipients(params Recipient[] recipients)
            : base() { this.Add(recipients); }

        public Recipients(string recipients)
            : base() { this.Add(Recipients.GetRecipients(recipients)); }

        protected bool Contains(string address) => this.Any(r => r.Address.Equals(address, StringComparison.OrdinalIgnoreCase));

        new public void Add(Recipient? recipient)
        {
            var address = recipient?.Address;

            if (String.IsNullOrWhiteSpace(address))
                return;

            if (recipient.IsMultiple())
                this.Add(Recipients.GetRecipients(address));
            else if (!this.Contains(address))
                base.Add(recipient);
        }

        public void Add(IEnumerable<Recipient> recipients)
        {
            if (recipients != null)
                foreach (var r in recipients)
                    this.Add(r);
        }

        public override string ToString() => this.ToString(";");

        public string ToString(string separator) => String.Join(separator, this.Select(r => r.Address));


        static public Recipients GetRecipients(string recipients)
        {
            var result = new Recipients();

            if (String.IsNullOrWhiteSpace(recipients))
                return result;

            var addresses = Regex.Split(recipients, Recipients.SEPARATORS)
                .Where(a => !String.IsNullOrWhiteSpace(a));

            foreach (var address in addresses)
                result.Add(address);

            return result;
        }

        static public implicit operator Recipients(string value) => new Recipients(value);

        static public implicit operator Recipients(Recipient recipient) => new Recipients(recipient);
    }
}
