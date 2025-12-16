using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FitnessTracker.Infrastructure.Database.SeedingIdentity
{
    internal class UserRolesInit
    {
        public IList<IdentityUserRole<Guid>> GetUserRoles()
        {
            return new List<IdentityUserRole<Guid>>
            {
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    RoleId = Guid.Parse("11111111-1111-1111-1111-111111111111") // Admin
                },
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    RoleId = Guid.Parse("22222222-2222-2222-2222-222222222222") // Manager
                }
            };
        }
    }
}
