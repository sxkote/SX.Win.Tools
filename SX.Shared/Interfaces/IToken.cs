using System;
using System.Collections.Generic;

namespace SX.Shared.Interfaces
{
    public interface IToken
    {
        Guid UserID { get; }
        Guid? ClientID { get; }
        string Name { get; }
        string Login { get; }
        string Email { get; }
        public DateTime? Expire { get; set; }
        List<string> Roles { get; }
        List<string> Permissions { get; }

        bool IsInRole(string role);
    }
}
