using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Infrastructure.Database.Seeding
{
    internal class ExerciseInit
    {
        public IList<Exercise> GetDefaultExercises()
        {
            return new List<Exercise>
            {
                new Exercise
                {
                    Id = 1,
                    Name = "Bench Press",
                    Description = "Základní cvik pro prsa"
                },
                new Exercise
                {
                    Id = 2,
                    Name = "Squat",
                    Description = "Dřepy pro nohy"
                },
                new Exercise
                {
                    Id = 3,
                    Name = "Deadlift",
                    Description = "Mrtvý tah pro záda"
                }
            };
        }
    }
}
