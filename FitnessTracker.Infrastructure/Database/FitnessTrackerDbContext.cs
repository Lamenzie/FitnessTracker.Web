using FitnessTracker.Domain.Entities;
using FitnessTracker.Infrastructure.Database.Seeding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Database
{
    public class FitnessTrackerDbContext : DbContext
    {
        public FitnessTrackerDbContext(DbContextOptions<FitnessTrackerDbContext> options)
            : base(options)
        {
        }

        // DbSety pro entity z Domain vrstvy
        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }
        public DbSet<UserBadge> UserBadges { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<WarningLog> WarningLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // složený klíč UserBadge
            modelBuilder.Entity<UserBadge>()
                .HasKey(ub => new { ub.UserId, ub.BadgeId });

            // seeding
            ExerciseInit exerciseInit = new ExerciseInit();
            modelBuilder.Entity<Exercise>().HasData(exerciseInit.GetDefaultExercises());

            BadgeInit badgeInit = new BadgeInit();
            modelBuilder.Entity<Badge>().HasData(badgeInit.GetDefaultBadges());
        }

    }
}

