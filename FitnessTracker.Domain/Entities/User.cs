using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.Domain.Interfaces;

namespace FitnessTracker.Domain.Entities
{
    public class User : Entity<Guid>, IUser<Guid>
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public int XP { get; set; }
        public int Level { get; set; }
        public int WeeklyStreak { get; set; }
        public DateTime? LastTrainingDate { get; set; }

        public ICollection<TrainingSession>? TrainingSessions { get; set; }
        public ICollection<UserBadge>? UserBadges { get; set; }
        public ICollection<WarningLog>? WarningLogs { get; set; }
    }
}
