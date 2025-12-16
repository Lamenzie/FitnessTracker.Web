using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Domain.Entities
{
    [Table("Exercises")]
    public class Exercise : Entity<int>
    {
        [Required(ErrorMessage = "Název je povinný")]
        [FirstLetterCapitalizedCZ]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Popis je povinný")]
        [FirstLetterCapitalizedCZ]
        public string Description { get; set; } = string.Empty;

        public ICollection<TrainingSession>? TrainingSessions { get; set; }
    }
}
