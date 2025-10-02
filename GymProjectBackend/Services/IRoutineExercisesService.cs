using GymProjectBackend.Entities;
using GymProjectBackend.Models.RoutineExercises;

namespace GymProjectBackend.Services
{
    public interface IRoutineExercisesService
    {
        public Task<RoutineExercisesResponseDTO?> GetRoutineExerciseAsync(Guid routineExerciseId);

        public Task<RoutineExercises?> CreateRoutineExerciseAsync(RoutineExerciseDTO request);

        public Task<RoutineExercisesResponseDTO?> UpdateRoutineExerciseAsync(RoutineExerciseEditDTO request);

        public Task<string?> DeleteRoutineExerciseAsync(Guid routineExerciseId);

    }
}
