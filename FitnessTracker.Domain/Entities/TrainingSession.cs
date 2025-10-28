using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTracker.Domain.Entities
{
    [Table("Badges")]
    public class TrainingSession : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public int ExerciseId { get; set; }
        public DateTime Date {  get; set; }
        public double Weight { get; set; }
        public int Repetitions { get; set; }
        public double TotalWeight { get; set; }
        public int XPGained {  get; set; }
        public string? Notes { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [ForeignKey(nameof(ExerciseId))]
        public Exercise? Exercise { get; set; }
    }
}
