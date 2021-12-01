using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcAccount.Models;

namespace MvcAccounts.Data
{
    public class MvcAccountsContext : DbContext
    {
        public MvcAccountsContext (DbContextOptions<MvcAccountsContext> options)
            : base(options)
        {
        }

        public DbSet<MvcAccount.Models.Account> Account { get; set; }
    }
}
