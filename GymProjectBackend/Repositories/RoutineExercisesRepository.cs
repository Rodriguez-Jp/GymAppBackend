using GymProjectBackend.Data;
using GymProjectBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymProjectBackend.Repositories;

public class RoutineExercisesRepository(GymAppDbContext context) : IRoutineExercisesRepository
{
    public async Task<RoutineExercises?> GetFullRoutineExercisesById(Guid routineExerciseId)
    {
        var routineExercise = await context.RoutineExercises
            .Include(re => re.Routine)
            .Include(re => re.Exercise)
            .FirstOrDefaultAsync(re => re.Id == routineExerciseId);

        return routineExercise;
    }

    public async Task<bool> NewRoutineExercise(RoutineExercises routine)
    {
        try
        {
            await context.RoutineExercises.AddAsync(routine);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<RoutineExercises?> GetRoutineExercisesById(Guid routineExerciseId)
    {
        try
        {
            var response = await context.RoutineExercises.FindAsync(routineExerciseId);
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<bool> DeleteRoutineExercise(RoutineExercises routine)
    {
        try
        {
            context.RoutineExercises.Remove(routine);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}