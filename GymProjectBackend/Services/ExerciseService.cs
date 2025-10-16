using GymProjectBackend.Entities;
using GymProjectBackend.Repositories;


namespace GymProjectBackend.Services
{
    public class ExerciseService(IExerciseRepository exerciseRepository) : IExerciseService
    {
        public async Task<Exercise?> GetExerciseAsync(Guid id)
        {
            var exercise = await exerciseRepository.GetExerciseByIdAsync(id);

            return exercise ?? null;
        }

        public async Task<List<Exercise>> GetAllExercisesAsync()
        {
            var allExercises= await exerciseRepository.GetAllExercisesAsync();
            return allExercises;
        }
    }
}
