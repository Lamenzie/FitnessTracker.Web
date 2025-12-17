using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitnessTracker.Domain.Identity;

namespace FitnessTracker.Domain.Entities
{
    public class WarningLog
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public Guid TrainingSessionId { get; set; }

        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; } = null!;

        [ForeignKey(nameof(TrainingSessionId))]
        public TrainingSession TrainingSession { get; set; } = null!;
    }
}
