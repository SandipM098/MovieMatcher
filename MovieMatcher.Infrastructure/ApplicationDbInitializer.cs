using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieMatcher.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MovieMatcher.Infrastructure
{
    public static class ApplicationDbInitializer
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            await context.Database.MigrateAsync();

            await SeedUsersAsync(userManager);
        }

        private static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (await userManager.FindByEmailAsync("admin@gmail.com") == null)
            {
                var admin = new AppUser
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(admin, "Admin@123");
            }

            if (await userManager.FindByEmailAsync("sandip@gmail.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "sandip",
                    Email = "sandip@gmail.com",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, "Sandip@123");
            }
        }
    }
}
