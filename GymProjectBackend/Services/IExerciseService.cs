using GymProjectBackend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GymProjectBackend.Services
{
    public interface IExerciseService
    {
        public Task<Exercise?> GetExerciseAsync(Guid id);
        public Task<List<Exercise>> GetAllExercisesAsync();
    }
}
