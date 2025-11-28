using GymProjectBackend.Data;
using GymProjectBackend.Entities;
using GymProjectBackend.Models.Exercise;
using GymProjectBackend.Models.Routine;
using GymProjectBackend.Models.RoutineExercises;
using GymProjectBackend.Repositories;

namespace GymProjectBackend.Services
{
    public class RoutineService(IRoutineRepository routineRepository, IUserRepository userRepository) : IRoutineService
    {
        public async Task<RoutineResponseDTO?> GetRoutineByIdAsync(Guid routineId, Guid userId)
        {
            
            var routine = await routineRepository.GetRoutineByIdAsync(routineId);
            
            
            if (routine is null || routine.UserId != userId)
            {
                return null;
            }

            var response = MapToRoutineResponseDto(routine);


            return response;
        }

        public async Task<List<RoutineResponseDTO>?> GetAllRoutines(Guid userId)
        {
            var routines = await routineRepository.GetAllRoutines(userId);

            if (routines is null)
                return null;

            //return routines.Select(routine => MapToRoutineResponseDto(routine)).ToList();
            var routinesMapped = new List<RoutineResponseDTO>();
            foreach (var routine in routines)
            {
                var routinetest = MapToRoutineResponseDto(routine);
                routinesMapped.Add(routinetest);
            }

            return routinesMapped;
        }

        public async Task<Routine?> CreateNewRoutineAsync(RoutineCreateDTO request, Guid userId)
        {
            var routine = new Routine
            {
                Name = request.RoutineName,
                Description = request.Description,
                UserId = userId
            };

            try
            {
                var response = await routineRepository.CreateRoutineAsync(routine);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            

        }

        public async Task<string?> DeleteRoutineAsync(RoutineDeleteDTO request, Guid userId)
        {
            var routine = await routineRepository.GetRoutineByIdAsync(request.RoutineId);

            if(routine is null || userId != routine.UserId)
            {
                return null;
            }

            try
            {
                var response = await routineRepository.DeleteRoutineAsync(routine);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public async Task<string?> EditRoutineAsync(RoutineEditDTO request, Guid userId)
        {
            var routine = await routineRepository.GetRoutineByIdAsync(request.RoutineId);

            if (routine is null || userId != routine.UserId)
            {
                return null;
            }
            
            //if request.name or request.description is empty, keep the same name
            routine.Name = request.RoutineName.Trim() == "" ? routine.Name : request.RoutineName;
            routine.Description = request.Description.Trim() == "" ? routine.Description : request.Description;

            var response = await routineRepository.EditRoutineAsync();
            return response;

        }

        private RoutineResponseDTO MapToRoutineResponseDto(Routine routine)
        {
            return new RoutineResponseDTO
            {
                Id = routine.Id,
                RoutineName = routine.Name,
                RoutineDescription = routine.Description,
                RoutineExercises = routine.routineExercises
                    .Select(re => new RoutineExercisesResponseDTO
                    {
                        Exercise = new ExerciseResponseDTO
                        {
                            Id = re.ExerciseId,
                            Name = re.Exercise.Name
                        },
                        Sets = re.Sets,
                        Reps = re.Reps,
                        Weight = re.Weight
                    })
                    .ToList()
            };
        }
    }
}
