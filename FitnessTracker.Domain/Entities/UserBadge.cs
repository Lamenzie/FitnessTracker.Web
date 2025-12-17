using System;
using System.ComponentModel.DataAnnotations.Schema;
using FitnessTracker.Domain.Identity;

namespace FitnessTracker.Domain.Entities
{
    public class UserBadge
    {
        public Guid UserId { get; set; }
        public int BadgeId { get; set; }

        public DateTime EarnedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; } = null!;

        [ForeignKey(nameof(BadgeId))]
        public Badge Badge { get; set; } = null!;
    }
}
