using AdvertiseService.Domain.Entities;
using AdvertiseService.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Infrastructure.Data
{

    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<string>>>();

            // ایجاد نقش‌ها
            string[] roles = { "Admin", "Advertiser", "Customer" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole<string>(role){Id = Guid.NewGuid().ToString()});
                }
            }

            // ایجاد کاربر ادمین
            var adminUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@example.com",
                Email = "admin@example.com",
                FullName = "Admin User",
                PasswordHash = "Admin@1234",
                HashedPassword = "Admin@1234",
                Role = "Admin"
            };
            await userManager.CreateAsync(adminUser, "Admin@1234");
            await userManager.AddToRoleAsync(adminUser, "Admin");

            // ایجاد کاربر آگهی‌دهنده
            var advertiserUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "advertiser@example.com",
                Email = "advertiser@example.com",
                FullName = "Advertiser User",
                PasswordHash = "Admin@1234",
                HashedPassword = "Admin@1234",
                Role = "Admin"
            };
            await userManager.CreateAsync(advertiserUser, "Advertiser@1234");
            await userManager.AddToRoleAsync(advertiserUser, "Advertiser");
        }
    }

}
