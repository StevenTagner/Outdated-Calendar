using Microsoft.EntityFrameworkCore;
using MvcAccount.Models;
using MvcAccounts.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcAccountsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcAccountsContext>>()))
            {
                // Look for any movies.
                if (context.Account.Any())
                {
                    return;   // DB has been seeded
                }

                context.Account.AddRange(
                    new Account
                    {
                        Email = "smtagner@uncg.edu",
                        Birthday = DateTime.Parse("2000-9-17"),
                        Password = "passwordOne",
                        Age = 21
                    },

                    new Account
                    {
                        Email = "aperson@uncg.edu",
                        Birthday = DateTime.Parse("1989-10-21"),
                        Password = "passwordTwo",
                        Age = 21
                    },

                    new Account
                    {
                        Email = "adog@uncg.edu",
                        Birthday = DateTime.Parse("2010-2-17"),
                        Password = "passwordThree",
                        Age = 21
                    },

                    new Account
                    {
                        Email = "acat@uncg.edu",
                        Birthday = DateTime.Parse("2020-5-04"),
                        Password = "passwordFour",
                        Age = 21
                    }
                );
                context.SaveChanges();
            }
        }
    }
}