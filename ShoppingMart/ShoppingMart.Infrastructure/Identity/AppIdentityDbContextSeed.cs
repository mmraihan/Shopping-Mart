using Microsoft.AspNetCore.Identity;
using ShoppingMart.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMart.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "raihan",
                    Email = "raihan@test.com",
                    UserName = "raihan@test.com",
                    Address = new Address
                    {
                        FirstName = "Mubasshir",
                        LastName = "Raihan",
                        Street = "Ctg",
                        City = "Ctg",
                        State = "Ctg",
                        ZipCode="564"
                    }
                };

                await userManager.CreateAsync(user, "Seven.9@Ten");
            }
        }
    }
}
