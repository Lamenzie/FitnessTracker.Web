using FitnessTracker.Domain.Entities;
using FitnessTracker.Domain.Identity;
using FitnessTracker.Infrastructure.Database.Seeding;
using FitnessTracker.Infrastructure.Database.SeedingIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Database
{
    public class FitnessTrackerDbContext : IdentityDbContext<AppUser, AppRole, Guid>
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

            // ===== DOMAIN =====
            modelBuilder.Entity<UserBadge>()
                .HasKey(ub => new { ub.UserId, ub.BadgeId });

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

