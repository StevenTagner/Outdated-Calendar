using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EventAppPage.Models;

namespace EventAppPage.Data
{
    public class EventAppPageContext : DbContext
    {
        public EventAppPageContext (DbContextOptions<EventAppPageContext> options)
            : base(options)
        {
        }

        public DbSet<EventAppPage.Models.EventObject> EventObject { get; set; }
    }
}
