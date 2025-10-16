using GymProjectBackend.Data;
using GymProjectBackend.Entities;
using GymProjectBackend.Models.Routine;
using GymProjectBackend.Repositories;

namespace GymProjectBackend.Services
{
    public class RoutineService(IRoutineRepository routineRepository, IUserRepository userRepository) : IRoutineService
    {
        public async Task<RoutineResponseDTO?> GetRoutineAsync(Guid routineId)
        {
            var routine = await routineRepository.GetRoutineByIdAsync(routineId);

            if (routine is null)
            {
                return null;
            }

            var response = MapToRoutineResponseDto(routine);


            return response;
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
            var user = await userRepository.GetUserByIdAsync(userId);

            if(routine is null || user is null)
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
            var user = await userRepository.GetUserByIdAsync(userId);

            if (routine is null || user is null)
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
                RoutineName = routine.Name,
                RoutineDescription = routine.Description
            };
        }
    }
}
