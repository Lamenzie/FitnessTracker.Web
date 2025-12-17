using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitnessTracker.Domain.Identity;

namespace FitnessTracker.Domain.Entities
{
    public class TrainingSession
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int ExerciseId { get; set; }

        [ForeignKey(nameof(ExerciseId))]
        public Exercise Exercise { get; set; } = null!;

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; } = null!;

        [Required]
        public double Weight { get; set; }

        [Required]
        public int Repetitions { get; set; }

        public double TotalWeight { get; set; }
        public int XPGained { get; set; }
        public string? Notes { get; set; }
    }
}
