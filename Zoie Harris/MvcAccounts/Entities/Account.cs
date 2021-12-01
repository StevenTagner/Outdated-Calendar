using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace MvcAccounts.Entities
{
    public partial class Account : IdentityUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }
        public decimal Age { get; set; }
    }
}
