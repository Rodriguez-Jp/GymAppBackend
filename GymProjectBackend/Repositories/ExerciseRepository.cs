using GymProjectBackend.Data;
using GymProjectBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymProjectBackend.Repositories;

public class ExerciseRepository(GymAppDbContext context) : IExerciseRepository
{
    public async Task<Exercise?> GetExerciseByIdAsync(Guid id)
    {
        try
        {
            var response = await context.Exercises.FindAsync(id);
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Exercise>> GetAllExercisesAsync()
    {
        var response = await context.Exercises.ToListAsync();
        return response;
    }
}