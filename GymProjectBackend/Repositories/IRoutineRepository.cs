using GymProjectBackend.Entities;
using GymProjectBackend.Models.Routine;

namespace GymProjectBackend.Repositories;

public interface IRoutineRepository
{
    Task<Routine?> CreateRoutineAsync(Routine routine);
    Task<string?> DeleteRoutineAsync(Routine routine);
    Task<string?> EditRoutineAsync();
    Task<Routine?> GetRoutineByIdAsync(Guid routineId);
}