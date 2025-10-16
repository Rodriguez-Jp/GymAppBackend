using GymProjectBackend.Entities;

namespace GymProjectBackend.Repositories;

public interface IRoutineExercisesRepository
{
    Task<RoutineExercises?> GetFullRoutineExercisesById(Guid routineExerciseId);
    Task<bool> NewRoutineExercise(RoutineExercises routine);
    Task<RoutineExercises?> GetRoutineExercisesById(Guid routineExerciseId);
    Task<bool> DeleteRoutineExercise(RoutineExercises routine);
    Task SaveChangesAsync();
}