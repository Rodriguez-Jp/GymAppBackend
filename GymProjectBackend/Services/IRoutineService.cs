using GymProjectBackend.Entities;
using GymProjectBackend.Models.Routine;

namespace GymProjectBackend.Services
{
    public interface IRoutineService
    {
        Task<Routine?> CreateNewRoutineAsync(RoutineCreateDTO request, Guid userId);
        Task<string?> DeleteRoutineAsync(RoutineDeleteDTO request, Guid userId);
        Task<string?> EditRoutineAsync(RoutineEditDTO request, Guid userId);
        Task<RoutineResponseDTO?> GetRoutineAsync(Guid routineId, Guid userId);

    }
}
