using GymProjectBackend.Data;
using GymProjectBackend.Entities;
using GymProjectBackend.Models.Exercise;
using GymProjectBackend.Models.Routine;
using GymProjectBackend.Models.RoutineExercises;
using Microsoft.EntityFrameworkCore;

namespace GymProjectBackend.Services
{
    public class RoutineExercisesService (GymAppDbContext context) : IRoutineExercisesService
    {
        //Get handler
        public async Task<RoutineExercisesResponseDTO?> GetRoutineExerciseAsync(Guid routineExerciseId)
        {
            var routineExercise = await context.RoutineExercises
                .Include(re => re.Routine)
                .Include(re => re.Exercise)
                .FirstOrDefaultAsync(re => re.Id == routineExerciseId);

            if (routineExercise is null)
                return null;

            var response = MapToRoutineExercisesDTO(routineExercise);

            return response;


        }
        //Post handler
        public async Task<RoutineExercises?> CreateRoutineExerciseAsync(RoutineExerciseDTO request)
        {

            var routine = new RoutineExercises
            {
                RoutineId = request.RoutineId,
                Routine = await context.Routines.FindAsync(request.RoutineId),
                ExerciseId = request.ExerciseId,
                Exercise = await context.Exercises.FindAsync(request.ExerciseId),
                Weight = request.Weight,
                Reps = request.Reps
            };

            await context.RoutineExercises.AddAsync(routine);
            await context.SaveChangesAsync();

            return routine;
        }
        
        //Put handler
        public async Task<RoutineExercisesResponseDTO?> UpdateRoutineExerciseAsync(RoutineExerciseEditDTO request)
        {
            var routineExercises = await context.RoutineExercises
                .Include(re => re.Routine)
                .Include(re => re.Exercise)
                .FirstOrDefaultAsync(re => re.Id == request.Id);

            if (routineExercises is null)
                return null;

            routineExercises.Reps = request.Reps.Trim() == string.Empty ? routineExercises.Reps : request.Reps.Trim();
            routineExercises.Weight = request.Weight < 0 ? routineExercises.Weight : request.Weight;

            await context.SaveChangesAsync();

            var response = MapToRoutineExercisesDTO(routineExercises);

            return response;
        }

        public async Task<string?> DeleteRoutineExerciseAsync(Guid routineExerciseId)
        {
            var routineExercise = await context.RoutineExercises.FindAsync(routineExerciseId);

            if (routineExercise is null)
                return null;

            context.RoutineExercises.Remove(routineExercise);

            await context.SaveChangesAsync();

            return "Routine Exercise Deleted";

        }

        private RoutineExercisesResponseDTO MapToRoutineExercisesDTO(RoutineExercises routineExercises)
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
