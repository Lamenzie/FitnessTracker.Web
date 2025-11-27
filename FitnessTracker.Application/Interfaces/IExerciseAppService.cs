using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Application.Interfaces
{
    public interface IExerciseAppService
    {
        IList<Exercise> GetAllExercises();
    }
}
