using FitnessTracker.Application.Interfaces;
using FitnessTracker.Domain.Entities;
using FitnessTracker.Infrastructure.Database;

namespace FitnessTracker.Infrastructure.Services
{
    public class ExerciseAppService : IExerciseAppService
    {
        private readonly FitnessTrackerDbContext _context;

        public ExerciseAppService(FitnessTrackerDbContext context)
        {
            _context = context;
        }

        public IList<Exercise> GetAllExercises()
        {
            return _context.Exercises.ToList();
        }
    }
}
