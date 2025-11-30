using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Application.Interfaces
{
    public interface IExerciseAppService
    {
        IList<Exercise> Select();
        void Create(Exercise exercise);
        void Delete(int id);
    }
}
