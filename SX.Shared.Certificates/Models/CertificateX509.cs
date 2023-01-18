using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace SX.Shared.Certificates.Models
{
    public sealed class CertificateX509 //: ICertificate
    {
        public X509Certificate2 X509 { get; private set; }

        public string Thumbprint => this.X509.Thumbprint;
        public string SerialNumber => this.X509.SerialNumber;
        public DateTime NotBefore => this.X509.NotBefore;
        public DateTime NotAfter => this.X509.NotAfter;
        public string Subject => this.X509.Subject;
        public string SubjectCommonName => GetParamValue(this.Subject, "CN");
        public string PersonName => GetParamValue(this.Subject, "SN") + " " + GetParamValue(this.Subject, "G");
        public string PersonPost => GetSubjectProperty("T");
        public string Organization => GetSubjectProperty("O");
        public string CountryCode => GetSubjectProperty("C");
        public string Street => GetSubjectProperty("STREET");
        public string Region => GetSubjectProperty("S");
        public string Locality => GetSubjectProperty("L");
        public string Email => GetSubjectProperty("E");
        public string INN
        {
            get
            {
                var result = "";

                // новый формат для ИНН орнанизации
                if (String.IsNullOrEmpty(result))
                    result = GetSubjectProperty("INNLE");
                if (String.IsNullOrEmpty(result))
                    result = GetSubjectProperty("ИННЮЛ");
                if (String.IsNullOrEmpty(result))
                    result = GetSubjectProperty("OID.1.2.643.100.4");
                if (String.IsNullOrEmpty(result))
                    result = GetSubjectProperty("1.2.643.100.4");

                if (!String.IsNullOrWhiteSpace(result))
                    return result;

                if (String.IsNullOrEmpty(result))
                    result = GetSubjectProperty("ИНН");
                if (String.IsNullOrEmpty(result))
                    result = GetSubjectProperty("INN");
                if (String.IsNullOrEmpty(result))
                    result = GetSubjectProperty("OID.1.2.643.3.131.1.1");
                if (String.IsNullOrEmpty(result))
                    result = GetSubjectProperty("1.2.643.3.131.1.1");
                return result;
            }
        }
        public string OGRN
        {
            get
            {
                var result = this.GetSubjectProperty("ОГРН");
                if (String.IsNullOrEmpty(result))
                    result = this.GetSubjectProperty("ОГРНИП");
                if (String.IsNullOrEmpty(result))
                    result = this.GetSubjectProperty("OGRN");
                if (String.IsNullOrEmpty(result))
                    result = this.GetSubjectProperty("OGRNIP");
                if (String.IsNullOrEmpty(result))
                    result = this.GetSubjectProperty("OID.1.2.643.100.1");
                if (String.IsNullOrEmpty(result))
                    result = this.GetSubjectProperty("1.2.643.100.1");
                return result;
            }
        }
        public string SNILS
        {
            get
            {
                var result = this.GetSubjectProperty("СНИЛС");
                if (String.IsNullOrEmpty(result))
                    result = this.GetSubjectProperty("SNILS");
                if (String.IsNullOrEmpty(result))
                    result = this.GetSubjectProperty("SNILS");
                if (String.IsNullOrEmpty(result))
                    result = this.GetSubjectProperty("OID.1.2.643.100.3");
                if (String.IsNullOrEmpty(result))
                    result = this.GetSubjectProperty("1.2.643.100.3");
                return result;
            }
        }
        public string Issuer => this.X509.Issuer;
        public string IssuerCommonName => GetParamValue(this.Issuer, "CN");

        public bool IsIP() => !String.IsNullOrEmpty(this.OGRN) && this.OGRN.Length == 15;

        public CertificateX509(X509Certificate2 certificate)
        {
            this.X509 = certificate ?? throw new ArgumentNullException("Сертификат не задан"); ;
        }

        public CertificateX509(byte[] rawData)
        {
            this.X509 = new X509Certificate2(rawData);
        }

        public CertificateX509(string base64data)
        {
            this.X509 = new X509Certificate2(Convert.FromBase64String(base64data));
        }

        public override string ToString()
        {
            return this.SubjectCommonName + "  [" + this.IssuerCommonName + "]";
        }

        public string GetSubjectProperty(string name) => GetParamValue(this.X509?.SubjectName?.Name, name);

        //private string GetSubjectProperty(string pattern)
        //{
        //    string result = "";
        //    string subject = this.CertificateX509.SubjectName.Name;
        //    pattern = pattern.ToLower();

        //    string[] parts = subject.Split(new char[1] { ',' });
        //    for (int i = 0; i < parts.Length; i++)
        //    {
        //        if (parts[i].Trim().ToLower().StartsWith(pattern + "="))
        //        {
        //            result = parts[i].Replace(pattern + "=", "").Replace(pattern.ToUpper() + "=", "").Trim();
        //            break;
        //        }
        //    }

        //    if (result.StartsWith("\"") && result.EndsWith("\""))
        //        result = result.Substring(1, result.Length - 2);

        //    result = result.Replace("\"\"", "\"");

        //    return result.Trim();
        //}

        public byte[] Export(X509ContentType type = X509ContentType.Pfx) => this.X509.Export(type);
        public string ExportBase64(X509ContentType type = X509ContentType.Pfx) => Convert.ToBase64String(this.Export(type));

        //static private string GetParam(string text, string param_name)
        //{
        //    if (text == null || text == "")
        //        return "";

        //    var items = text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //    if (items == null || items.Length <= 0)
        //        return "";

        //    var item = items.FirstOrDefault(i => i.Trim().ToLower().StartsWith(param_name.Trim().ToLower() + "="));
        //    if (item == null)
        //        return "";

        //    string[] args = item.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
        //    return (args == null || args.Length < 2) ? "" : args[1].Trim();
        //}

        static public string GetParamValue(string text, string name)
        {
            string result = "";

            // пустой ввод или пустое имя параметра
            if (String.IsNullOrWhiteSpace(text) || String.IsNullOrWhiteSpace(name))
                return result;

            if (name.Equals("ИННЮЛ", StringComparison.OrdinalIgnoreCase))
                text = text.Replace("ИНН ЮЛ", "ИННЮЛ");

            // разбираем строку по парам - значениям
            Regex regex = new Regex(@"(?<name>[\w\d\.]+)\=(?<value>  (?<opena>\"")(.*?)(?<-opena>\""),  |  (?<openb>\"")(.*?)(?<-openb>\"")$  |  [^,]+,?)", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
            foreach (Match match in regex.Matches(text))
                if ((match.Groups["name"]?.Value ?? "").Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    result = match.Groups["value"]?.Value ?? "";
                    break;
                }

            return result
                .TrimEnd(',')
                .TrimStart('"')
                .TrimEnd('"')
                .Replace("\"\"", "\"")
                .Trim();
        }

        //public CertificateData GetCertificateData()
        //{
        //    //var pn = this.PersonName;

        //    return new CertificateData()
        //    {
        //        SerialNumber = this.SerialNumber.ToLower(),
        //        Thumbprint = this.Thumbprint.ToLower(),
        //        Subject = this.Subject,
        //        Issuer = this.Issuer,
        //        DateFrom = this.NotBefore,
        //        DateTo = this.NotAfter,
        //        OrganizationTitle = this.Organization,
        //        PersonFullName = this.PersonName?.Trim() ?? "",
        //        PersonPost = this.PersonPost,
        //        INN = this.INN,
        //        OGRN = this.OGRN,
        //        SNILS = this.SNILS,
        //        Email = this.Email,
        //        CountryCode = this.CountryCode,
        //        Street = this.Street,
        //        Region = this.Region,
        //        City = this.Locality,
        //        Export = this.ExportBase64()
        //    };
        //}

        static public implicit operator CertificateX509(X509Certificate2 cert)
        {
            return new CertificateX509(cert);
        }

        //static public implicit operator CertificateData(Certificate certificate)
        //{
        //    return certificate?.GetCertificateData();
        //}
    }
}
