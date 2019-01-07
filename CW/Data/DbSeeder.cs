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
        public static void Seed(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            CreateData(context);
            CreateUsers(userManager);
        }

        public static void CreateData(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            context.ApplicationUsers.Add(new ApplicationUser() { Name = " " });
            context.SaveChanges();
        }

        public static void CreateUsers(UserManager<IdentityUser> userManager)
        {
            IdentityUser member1 = new IdentityUser
            {
                UserName = "Member1@email.com",
                Email = "Member1@email.com",
            };
            userManager.CreateAsync(member1, "Password123!").Wait();

            IdentityUser customer1 = new IdentityUser
            {
                UserName = "Customer1@email.com",
                Email = "Customer1@email.com",
            };
            userManager.CreateAsync(customer1, "Password123!").Wait();

            IdentityUser customer2 = new IdentityUser
            {
                UserName = "Customer2@email.com",
                Email = "Customer2@email.com",
            };
            userManager.CreateAsync(customer2, "Password123!").Wait();

            IdentityUser customer3 = new IdentityUser
            {
                UserName = "Customer3@email.com",
                Email = "Customer3@email.com",
            };
            userManager.CreateAsync(customer3, "Password123!").Wait();

            IdentityUser customer4 = new IdentityUser
            {
                UserName = "Customer4@email.com",
                Email = "Customer4@email.com",
            };
            userManager.CreateAsync(customer4, "Password123!").Wait();

            IdentityUser customer5 = new IdentityUser
            {
                UserName = "Customer5@email.com",
                Email = "Customer5@email.com",
            };
            userManager.CreateAsync(customer5, "Password123!").Wait();
        }
    }
}
