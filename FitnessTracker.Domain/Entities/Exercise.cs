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
        [MinLength(3, ErrorMessage = "Název musí mít alespoň 3 znaky")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Popis je povinný")]
        [MinLength(5, ErrorMessage = "Popis musí mít alespoň 5 znaků")]
        public string Description { get; set; } = string.Empty;

        public ICollection<TrainingSession>? TrainingSessions { get; set; }
    }
}
