using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace FitnessTracker.Domain.Entities
{
    [Table("WarningLogs")]
    public class WarningLog : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid TrainingSessionId { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public User? User { get; set; }
        public TrainingSession? TrainingSession { get; set; }
    }
}
