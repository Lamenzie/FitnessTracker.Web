using FitnessTracker.Domain.Entities;
using FitnessTracker.Domain.Identity;
using FitnessTracker.Infrastructure.Database.Seeding;
using FitnessTracker.Infrastructure.Database.SeedingIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Database
{
    public class FitnessTrackerDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public FitnessTrackerDbContext(DbContextOptions<FitnessTrackerDbContext> options)
            : base(options)
        {
        }

        // DOMAIN entity
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }
        public DbSet<UserBadge> UserBadges { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<WarningLog> WarningLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===== RELACE =====
            modelBuilder.Entity<UserBadge>()
                .HasKey(ub => new { ub.UserId, ub.BadgeId });

            modelBuilder.Entity<TrainingSession>()
                .HasOne(ts => ts.Exercise)
                .WithMany(e => e.TrainingSessions)
                .HasForeignKey(ts => ts.ExerciseId);

            // ===== DOMAIN SEEDING =====
            modelBuilder.Entity<Exercise>()
                .HasData(new ExerciseInit().GetDefaultExercises());

            modelBuilder.Entity<Badge>()
                .HasData(new BadgeInit().GetDefaultBadges());

            // ===== IDENTITY SEEDING =====
            modelBuilder.Entity<AppRole>()
                .HasData(new RolesInit().GetRoles());

            modelBuilder.Entity<AppUser>()
                .HasData(new UsersInit().GetUsers());

            modelBuilder.Entity<IdentityUserRole<Guid>>()
                .HasData(new UserRolesInit().GetUserRoles());
        }
    }
}
