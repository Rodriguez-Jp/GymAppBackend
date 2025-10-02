using GymProjectBackend.Data;
using GymProjectBackend.Entities;
using GymProjectBackend.Models.Routine;

namespace GymProjectBackend.Services
{
    public class RoutineService(GymAppDbContext context) : IRoutineService
    {
        public async Task<RoutineResponseDTO?> GetRoutineAsync(Guid routineId)
        {
            var routine = await context.Routines.FindAsync(routineId);

            if (routine is null)
            {
                return null;
            }

            var response = MapToRoutineResponseDTO(routine);


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

            await context.Routines.AddAsync(routine);

            await context.SaveChangesAsync();

            return routine;

        }

        public async Task<string?> DeleteRoutineAsync(RoutineDeleteDTO request, Guid userId)
        {
            var routine = await context.Routines.FindAsync(request.RoutineId);
            var user = await context.Users.FindAsync(userId);

            if(routine is null || user is null)
            {
                return null;
            }

            context.Routines.Remove(routine);

            await context.SaveChangesAsync();

            return "Routine deleted";
        }

        public async Task<string?> EditRoutineAsync(RoutineEditDTO request, Guid userId)
        {
            var routine = await context.Routines.FindAsync(request.RoutineId);
            var user = await context.Users.FindAsync(userId);

            if (routine is null || user is null)
            {
                return null;
            }

            //if request.name or request.description is empty, keep the same name

            routine.Name = request.RoutineName.Trim() == "" ? routine.Name : request.RoutineName;
            routine.Description = request.Description.Trim() == "" ? routine.Description : request.Description;

            await context.SaveChangesAsync();

            return "Routine deleted";
        }

        private RoutineResponseDTO MapToRoutineResponseDTO(Routine routine)
        {
            return new RoutineResponseDTO
            {
                RoutineName = routine.Name,
                RoutineDescription = routine.Description
            };
        }
    }
}
