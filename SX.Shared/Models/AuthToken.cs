using SX.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SX.Shared.Models
{
    public class AuthToken : IToken
    {
        public const string ROLE_ADMIN = "Administrator";

        public Guid UserID { get; set; }
        public Guid? ClientID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public DateTime? Expire { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Permissions { get; set; }

        public string Token { get; set; }

        public bool IsInRole(string role)
        {
            return this.Roles.Any(r => r.Equals(ROLE_ADMIN, StringComparison.OrdinalIgnoreCase))
                || this.Roles.Any(r => r.Equals(role, StringComparison.OrdinalIgnoreCase));
        }
    }
}
