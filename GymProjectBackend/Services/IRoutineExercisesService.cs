using GymProjectBackend.Entities;
using GymProjectBackend.Models.RoutineExercises;

namespace GymProjectBackend.Services
{
    public interface IRoutineExercisesService
    {
        public Task<RoutineExercisesResponseDTO?> GetRoutineExerciseAsync(Guid routineExerciseId, Guid userId);

        public Task<RoutineExercises?> CreateRoutineExerciseAsync(RoutineExerciseDTO request, Guid userId);

        public Task<RoutineExercisesResponseDTO?> UpdateRoutineExerciseAsync(RoutineExerciseEditDTO request, Guid userId);

        public Task<string?> DeleteRoutineExerciseAsync(Guid routineExerciseId, Guid userId);

    }
}
