using GymProjectBackend.Entities;

namespace GymProjectBackend.Repositories;

public interface IExerciseRepository
{
    Task<Exercise?> GetExerciseByIdAsync(Guid id);
    Task<List<Exercise>> GetAllExercisesAsync();
}