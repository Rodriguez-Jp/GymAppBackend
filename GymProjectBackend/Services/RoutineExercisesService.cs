using GymProjectBackend.Data;
using GymProjectBackend.Entities;
using GymProjectBackend.Models.Exercise;
using GymProjectBackend.Models.Routine;
using GymProjectBackend.Models.RoutineExercises;
using GymProjectBackend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymProjectBackend.Services
{
    public class RoutineExercisesService (IRoutineExercisesRepository routineExercisesRepository, IExerciseRepository exerciseRepository, IRoutineRepository routineRepository) : IRoutineExercisesService
    {
        //Get handler
        public async Task<RoutineExercisesResponseDTO?> GetRoutineExerciseAsync(Guid routineExerciseId, Guid userId)
        {
            var routineExercise = await routineExercisesRepository.GetFullRoutineExercisesById(routineExerciseId);

            if (routineExercise is null)
                return null;

            var response = MapToRoutineExercisesDto(routineExercise);

            return response;


        }
        //Post handler
        public async Task<RoutineExercises?> CreateRoutineExerciseAsync(RoutineExerciseDTO request, Guid userId)
        {

            var routine = new RoutineExercises
            {
                RoutineId = request.RoutineId,
                Routine = await routineRepository.GetRoutineByIdAsync(request.RoutineId),
                ExerciseId = request.ExerciseId,
                Exercise = await exerciseRepository.GetExerciseByIdAsync(request.ExerciseId),
                Weight = request.Weight,
                Reps = request.Reps
            };

            if (await routineExercisesRepository.NewRoutineExercise(routine))
            {
                return routine;
            }

            return null;


        }
        
        //Put handler
        public async Task<RoutineExercisesResponseDTO?> UpdateRoutineExerciseAsync(RoutineExerciseEditDTO request,
            Guid userId)
        {
            
            var routineExercises = await routineExercisesRepository.GetFullRoutineExercisesById(request.Id);

            if (routineExercises is null)
                return null;

            routineExercises.Reps = request.Reps == 0 ? routineExercises.Reps : request.Reps;
            routineExercises.Weight = request.Weight < 0 ? routineExercises.Weight : request.Weight;

            await routineExercisesRepository.SaveChangesAsync();

            var response = MapToRoutineExercisesDto(routineExercises);

            return response;
        }

        public async Task<string?> DeleteRoutineExerciseAsync(Guid routineExerciseId, Guid userId)
        {
            var routineExercise = await routineExercisesRepository.GetRoutineExercisesById(routineExerciseId);

            if (routineExercise is null)
                return null;

            if (await routineExercisesRepository.DeleteRoutineExercise(routineExercise))
            {
                return "Routine Exercise Deleted";
            }

            return null;

        }

        private RoutineExercisesResponseDTO MapToRoutineExercisesDto(RoutineExercises routineExercises)
        {
            return new RoutineExercisesResponseDTO
            {
                Routine = new RoutineResponseDTO
                {
                    RoutineName = routineExercises.Routine.Name,
                    RoutineDescription = routineExercises.Routine.Description
                },
                Exercise = new ExerciseResponseDTO
                {
                    Name = routineExercises.Exercise.Name,
                    Description = routineExercises.Exercise.Description
                },
                Reps = routineExercises.Reps,
                Weight = routineExercises.Weight

            };
        }
    }
}
