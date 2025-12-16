using FitnessTracker.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FitnessTracker.Infrastructure.Database.SeedingIdentity
{
    internal class RolesInit
    {
        public IList<AppRole> GetRoles()
        {
            return new List<AppRole>
            {
                new AppRole
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "role-admin"
                },
                new AppRole
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Manager",
                    NormalizedName = "MANAGER",
                    ConcurrencyStamp = "role-manager"
                },
                new AppRole
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "role-user"
                }
            };
        }
    }
}
