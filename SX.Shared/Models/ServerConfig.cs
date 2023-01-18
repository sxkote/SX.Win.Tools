using SX.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SX.Shared.Models
{
    public class ServerConfig
    {
        /// <summary>
        /// Адрес сервера для подключения
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// Порт Сервера для подключения
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Логин для авторизации
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль для авторизации
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Порт по умолчанию
        /// </summary>
        public virtual int DefaultPort { get => 80; }

        public ServerConfig() { }

        public ServerConfig(string connectionString)
        {
            var connectionParams = ParseConnectionString(connectionString, ';');

            this.FetchParams(connectionParams);
        }

        protected virtual void FetchParams(List<KeyValuePair<string, string>> parametres)
        {
            if (parametres == null || !parametres.Any())
                return;

            this.Server = parametres.GetValue("Server") ?? "";
            this.Login = parametres.GetValue("Login") ?? "";
            this.Password = parametres.GetValue("Password") ?? "";

            if (parametres.Contains("Port"))
            {
                var value = parametres.GetValue("Port");
                this.Port = String.IsNullOrWhiteSpace(value) ? this.DefaultPort : Convert.ToInt32(value);
            }

            //if (parametres.Contains("SSL"))
            //{
            //    var value = parametres.GetValue("SSL");
            //    this.SSL = !String.IsNullOrWhiteSpace(value) && value.Equals("true", StringComparison.OrdinalIgnoreCase);
            //}
        }

        static public List<KeyValuePair<string, string>> ParseConnectionString(string text, params char[] separators)
        {
            var result = new List<KeyValuePair<string, string>>();

            if (String.IsNullOrWhiteSpace(text))
                return result;

            var items = text.SplitFormatted(separators);
            foreach (var item in items)
            {
                if (String.IsNullOrWhiteSpace(item))
                    continue;

                var split = item.SplitFormatted('=').ToList();
                if (split == null || split.Count != 2)
                    throw new CustomFormatException("Param's Name and Value should be separated by '='");

                var name = split[0].Trim();
                if (name.Length > 2 && name[0] == name[name.Length - 1] && name[0] == '\'')
                    name = name.Substring(1, name.Length - 2);

                var value = split[1].Trim();
                if (value.Length > 2 && value[0] == value[value.Length - 1] && value[0] == '\'')
                    value = value.Substring(1, value.Length - 2);

                result.Add(new KeyValuePair<string, string>(name, value));
            }

            return result;
        }
    }
}
