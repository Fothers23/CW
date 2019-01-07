using CW.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW.Data
{
    public class DbSeeder
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();
            String adminId1 = "";

            string role1 = "Admin";
            string desc1 = "This is the adminstrator role";

            string role2 = "Customer";
            string desc2 = "This is the customers' role";

            string password = "Password123!";
            
            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }

            if (await userManager.FindByNameAsync("Member1@email.com") == null)
            {
                var member1 = new ApplicationUser
                {
                    UserName = "Member1@email.com",
                    Email = "Member1@email.com",
                    Name = "Selina Kyle"
                };
                var result = await userManager.CreateAsync(member1);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(member1, password);
                    await userManager.AddToRoleAsync(member1, role1);
                }
                adminId1 = member1.Id;
            }
            if (await userManager.FindByNameAsync("Customer1@email.com") == null)
            {
                var customer1 = new ApplicationUser
                {
                    UserName = "Customer1@email.com",
                    Email = "Customer1@email.com",
                    Name = "Harleen Quinzel"
                };
                var result = await userManager.CreateAsync(customer1);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(customer1, password);
                    await userManager.AddToRoleAsync(customer1, role2);
                }
            }
            if (await userManager.FindByNameAsync("Customer2@email.com") == null)
            {
                var customer2 = new ApplicationUser
                {
                    UserName = "Customer2@email.com",
                    Email = "Customer2@email.com",
                    Name = "Edward Nigma"
                };
                var result = await userManager.CreateAsync(customer2);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(customer2, password);
                    await userManager.AddToRoleAsync(customer2, role2);
                }
            }
            if (await userManager.FindByNameAsync("Customer3@email.com") == null)
            {
                var customer3 = new ApplicationUser
                {
                    UserName = "Customer3@email.com",
                    Email = "Customer3@email.com",
                    Name = "Oswald Cobblepot"
                };
                var result = await userManager.CreateAsync(customer3);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(customer3, password);
                    await userManager.AddToRoleAsync(customer3, role2);
                }
            }

            if (await userManager.FindByNameAsync("Customer4@email.com") == null)
            {
                var customer4 = new ApplicationUser
                {
                    UserName = "Customer4@email.com",
                    Email = "Customer4@email.com",
                    Name = "Harvey Dent"
                };
                var result = await userManager.CreateAsync(customer4);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(customer4, password);
                    await userManager.AddToRoleAsync(customer4, role2);
                }
            }
            if (await userManager.FindByNameAsync("Customer5@email.com") == null)
            {
                var customer5 = new ApplicationUser
                {
                    UserName = "Customer5@email.com",
                    Email = "Customer5@email.com",
                    Name = "Jonathan Crane"
                };
                var result = await userManager.CreateAsync(customer5);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(customer5, password);
                    await userManager.AddToRoleAsync(customer5, role2);
                }
            }
        }

        //public static void CreateUsers(UserManager<IdentityUser> userManager)
        //{
        //    IdentityUser member1 = new IdentityUser
        //    {
        //        UserName = "Member1@email.com",
        //        Email = "Member1@email.com",
        //    };
        //    userManager.CreateAsync(member1, "Password123!").Wait();

        //    IdentityUser customer1 = new IdentityUser
        //    {
        //        UserName = "Customer1@email.com",
        //        Email = "Customer1@email.com",
        //    };
        //    userManager.CreateAsync(customer1, "Password123!").Wait();

        //    IdentityUser customer2 = new IdentityUser
        //    {
        //        UserName = "Customer2@email.com",
        //        Email = "Customer2@email.com",
        //    };
        //    userManager.CreateAsync(customer2, "Password123!").Wait();

        //    IdentityUser customer3 = new IdentityUser
        //    {
        //        UserName = "Customer3@email.com",
        //        Email = "Customer3@email.com",
        //    };
        //    userManager.CreateAsync(customer3, "Password123!").Wait();

        //    IdentityUser customer4 = new IdentityUser
        //    {
        //        UserName = "Customer4@email.com",
        //        Email = "Customer4@email.com",
        //    };
        //    userManager.CreateAsync(customer4, "Password123!").Wait();

        //    IdentityUser customer5 = new IdentityUser
        //    {
        //        UserName = "Customer5@email.com",
        //        Email = "Customer5@email.com",
        //    };
        //    userManager.CreateAsync(customer5, "Password123!").Wait();
        //}
    }
}
