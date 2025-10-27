using GymProjectBackend.Data;
using GymProjectBackend.Entities;
using GymProjectBackend.Models.Routine;
using Microsoft.EntityFrameworkCore;

namespace GymProjectBackend.Repositories;

public class RoutineRepository(GymAppDbContext context) : IRoutineRepository
{
    public async Task<Routine?> CreateRoutineAsync(Routine routine)
    {
        await context.Routines.AddAsync(routine);
        await context.SaveChangesAsync();
        return routine;
    }

    public async Task<string?> DeleteRoutineAsync(Routine routine)
    {
        try
        {
            context.Routines.Remove(routine);
            await context.SaveChangesAsync();
            return "Routine Deleted";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public async Task<string?> EditRoutineAsync()
    {
        try
        {   
            await context.SaveChangesAsync();
            return "Routine updated";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Routine?> GetRoutineByIdAsync(Guid routineId)
    {
        var response = await context.Routines
            .Include(r => r.routineExercises)
            .ThenInclude(re => re.Exercise)
            .FirstOrDefaultAsync(r => r.Id == routineId);
        //var response = await context.Routines.FindAsync(routineId);
        return response;
    }

    public async Task<List<Routine>?> GetAllRoutines(Guid userId)
    {
        var response = await context.Routines
            .Where(u => u.UserId == userId)
            .Include(r => r.routineExercises)
            .ThenInclude(re => re.Exercise)
            .ToListAsync();

        return response;
    }
}