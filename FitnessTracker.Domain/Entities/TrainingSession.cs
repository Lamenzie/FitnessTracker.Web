using FitnessTracker.Domain.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTracker.Domain.Entities
{
    public class TrainingSession : Entity<Guid>
    {
        public DateTime Date { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; } = null!;  

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; } = null!;

        public double Weight { get; set; }
        public int Repetitions { get; set; }
        public double TotalWeight { get; set; }

        public string? Notes { get; set; }
        public int XPGained { get; set; }
    }
}
