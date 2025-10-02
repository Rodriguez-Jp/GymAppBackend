using GymProjectBackend.Data;
using GymProjectBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymProjectBackend.Services
{
    public class ExerciseService(GymAppDbContext context) : IExerciseService
    {
        public async Task<Exercise?> GetExerciseAsync(Guid id)
        {
            var exercise = await context.Exercises.FindAsync(id);

            if (exercise is null)
                return null;

            return exercise;
        }

        public async Task<List<Exercise>> GetAllExercisesAsync()
        {
            var allExercises= await context.Exercises.ToListAsync();
            return allExercises;
        }
    }
}
