using Microsoft.EntityFrameworkCore;
using GymProjectBackend.Entities;
using GymProjectBackend.Seed;

namespace GymProjectBackend.Data
{
    public class GymAppDbContext(DbContextOptions<GymAppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<RoutineExercises> RoutineExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Routine>()
                .HasOne(r => r.User)
                .WithMany(u => u.Routines)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<RoutineExercises>()
                .HasKey(re => new { re.Id });

            modelBuilder.Entity<RoutineExercises>()
                .HasOne(re => re.Routine)
                .WithMany(r => r.routineExercises)
                .HasForeignKey(re => re.RoutineId);

            modelBuilder.Entity<RoutineExercises>()
                .HasOne(re => re.Exercise)
                .WithMany(e => e.routineExercises)
                .HasForeignKey(re => re.ExerciseId);

            modelBuilder.Entity<Exercise>().HasData(ExerciseSeedData.AllExercises);



        }

    }
}
