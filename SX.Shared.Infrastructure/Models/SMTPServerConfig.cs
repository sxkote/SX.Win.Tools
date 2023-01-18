using SX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace SX.Shared.Infrastructure.Models
{
    public class SMTPServerConfig : ServerConfig
    {
        public const string CONFIG_NAME = "SMTPServerConfig";
        /// <summary>
        /// Адрес отправителя (e-mail)
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Имя отправителя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Использование SSL при подключении
        /// </summary>
        public bool SSL { get; set; }
        /// <summary>
        /// Протокол подключения к SMTP: TLS1.2 | TLS1.1 | TLS1.0 | SSL3
        /// 0 - использовать по умолчанию
        /// </summary>
        public SecurityProtocolType SecurityProtocol { get; set; } = 0;
        /// <summary>
        /// Таймаут для отправки сообщения через SMTP сервер
        /// 0 - использовать по умолчанию
        /// </summary>
        public int Timeout { get; set; } = 0;


        public override int DefaultPort => 465; // 587 // 25

        public SMTPServerConfig() { }

        public SMTPServerConfig(string connectionString)
            : base(connectionString) { }

        protected override void FetchParams(List<KeyValuePair<string, string>> parametres)
        {
            base.FetchParams(parametres);

            this.Address = parametres.GetValue("Address") ?? "";
            this.Name = parametres.GetValue("Name") ?? "";

            if (parametres.Contains("SSL"))
            {
                var value = parametres.GetValue("SSL");
                this.SSL = !String.IsNullOrWhiteSpace(value) && value.Equals("true", Helpers.STRING_COMPARE);
            }

            if (parametres.Contains("Timeout"))
            {
                var value = parametres.GetValue("Timeout");
                int timeout = 0;
                if (Int32.TryParse(value, out timeout))
                    this.Timeout = timeout;
            }
        }
    }
}
