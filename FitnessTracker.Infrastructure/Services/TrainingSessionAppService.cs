using FitnessTracker.Application.Interfaces;
using FitnessTracker.Domain.Entities;
using FitnessTracker.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Services
{
    public class TrainingSessionAppService : ITrainingSessionAppService
    {
        private readonly FitnessTrackerDbContext _context;

        public TrainingSessionAppService(FitnessTrackerDbContext context)
        {
            _context = context;
        }

        public void Create(TrainingSession session)
        {
            session.Date = DateTime.Now;
            session.TotalWeight = session.Weight * session.Repetitions;

            _context.TrainingSessions.Add(session);
            _context.SaveChanges();
        }

        public IList<TrainingSession> GetMySessions(Guid userId)
        {
            return _context.TrainingSessions
                .Include(ts => ts.Exercise)
                .Where(ts => ts.UserId == userId)
                .OrderByDescending(ts => ts.Date)
                .ToList();
        }
    }
}
