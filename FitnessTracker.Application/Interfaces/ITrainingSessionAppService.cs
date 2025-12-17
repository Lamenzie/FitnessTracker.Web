using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Application.Interfaces
{
    public interface ITrainingSessionAppService
    {
        void Create(TrainingSession session);
        IList<TrainingSession> GetMySessions(Guid userId);
    }
}
