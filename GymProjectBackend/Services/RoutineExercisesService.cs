using GymProjectBackend.Entities;
using GymProjectBackend.Models.Exercise;
using GymProjectBackend.Models.Routine;
using GymProjectBackend.Models.RoutineExercises;
using GymProjectBackend.Repositories;

namespace GymProjectBackend.Services
{
    public class RoutineExercisesService (IRoutineExercisesRepository routineExercisesRepository, IExerciseRepository exerciseRepository, IRoutineRepository routineRepository) : IRoutineExercisesService
    {
        //Get handler
        public async Task<RoutineExercisesResponseDTO?> GetRoutineExerciseAsync(Guid routineExerciseId, Guid userId)
        {
            var routineExercise = await routineExercisesRepository.GetFullRoutineExercisesById(routineExerciseId);

            if (routineExercise is null || routineExercise.Routine.UserId != userId)
               return null;
            

            var response = MapToRoutineExercisesDto(routineExercise);

            return response;
            
        }
        //Post handler
        public async Task<RoutineExercises?> CreateRoutineExerciseAsync(RoutineExerciseDTO request, Guid userId)
        {
            var routine = await routineRepository.GetRoutineByIdAsync(request.RoutineId);

            if (routine is null || routine.UserId != userId)
                return null;

            var routineExercises = new RoutineExercises
            {
                RoutineId = request.RoutineId,
                //Routine = await routineRepository.GetRoutineByIdAsync(request.RoutineId),
                ExerciseId = request.ExerciseId,
                //Exercise = await exerciseRepository.GetExerciseByIdAsync(request.ExerciseId),
                Weight = request.Weight,
                Reps = request.Reps,
                Sets = request.Sets
            };

            if (await routineExercisesRepository.NewRoutineExercise(routineExercises))
            {
                return routineExercises;
            }

            return null;


        }
        
        //Put handler
        public async Task<RoutineExercisesResponseDTO?> UpdateRoutineExerciseAsync(RoutineExerciseEditDTO request, Guid userId)
        {
            var routineExercises = await routineExercisesRepository.GetFullRoutineExercisesById(request.Id);
            if (routineExercises is null)
                return null;
            
            //Check auth
            var routine = await routineRepository.GetRoutineByIdAsync(routineExercises.RoutineId);

            if (routine is null || routine.UserId != userId)
                return null;

            routineExercises.Reps = request.Reps == 0 ? routineExercises.Reps : request.Reps;
            routineExercises.Weight = request.Weight < 0 ? routineExercises.Weight : request.Weight;
            routineExercises.Sets = request.Sets < 0 ? routineExercises.Sets : request.Sets;
            
            await routineExercisesRepository.SaveChangesAsync();

            var response = MapToRoutineExercisesDto(routineExercises);

            return response;
        }

        //Delete handler
        public async Task<string?> DeleteRoutineExerciseAsync(Guid routineExerciseId, Guid userId)
        {
            var routineExercisesById = await routineExercisesRepository.GetFullRoutineExercisesById(routineExerciseId);

            if (routineExercisesById is null || routineExercisesById.Routine.UserId != userId)
                return null;

            if (await routineExercisesRepository.DeleteRoutineExercise(routineExercisesById))
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
                    Id = routineExercises.Routine.Id,
                    RoutineName = routineExercises.Routine.Name,
                    RoutineDescription = routineExercises.Routine.Description
                },
                Exercise = new ExerciseResponseDTO
                {
                    Id = routineExercises.Exercise.Id,
                    Name = routineExercises.Exercise.Name,
                    Description = routineExercises.Exercise.Description
                },
                Reps = routineExercises.Reps,
                Weight = routineExercises.Weight,
                Sets = routineExercises.Sets

            };
        }
    }
}
