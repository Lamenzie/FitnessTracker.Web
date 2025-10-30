using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Infrastructure.Database.Seeding
{
    internal class BadgeInit
    {
        public IList<Badge> GetDefaultBadges()
        {
            return new List<Badge>
            {
                new Badge
                {
                    Id = 1,
                    Name = "Nováček",
                    Description = "Získáno po prvním tréninku",
                    XPThreshold = 100
                },
                new Badge
                {
                    Id = 2,
                    Name = "Vytrvalec",
                    Description = "Získáno po 7 dnech v řadě",
                    XPThreshold = 500
                },
                new Badge
                {
                    Id = 3,
                    Name = "Šampion",
                    Description = "Získáno po 1000 XP",
                    XPThreshold = 1000
                }
            };
        }
    }
}
