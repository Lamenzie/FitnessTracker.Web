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

        public IList<Exercise> Select()
        {
            return _context.Exercises.ToList();
        }

        public void Create(Exercise exercise) { 
            _context.Exercises.Add(exercise);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var exercise = _context.Exercises.FirstOrDefault(e => e.Id == id);

            if (exercise != null) { 
            _context.Exercises.Remove(exercise); 
            _context.SaveChanges();
            }
        }
    }
}
