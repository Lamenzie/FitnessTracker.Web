using FitnessTracker.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FitnessTracker.Infrastructure.Database.Seeding
{
    internal class UsersInit
    {
        public IList<AppUser> GetUsers()
        {
            AppUser admin = new AppUser
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@local.test",
                NormalizedEmail = "ADMIN@LOCAL.TEST",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            admin.PasswordHash = HashPassword(admin, "Admin123!");

            AppUser manager = new AppUser
            {
                Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                UserName = "manager",
                NormalizedUserName = "MANAGER",
                Email = "manager@local.test",
                NormalizedEmail = "MANAGER@LOCAL.TEST",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            manager.PasswordHash = HashPassword(manager, "Manager123!");

            return new List<AppUser> { admin, manager };
        }

        private string HashPassword(AppUser user, string password)
        {
            PasswordHasher<AppUser> hasher = new();
            return hasher.HashPassword(user, password);
        }
    }
}
