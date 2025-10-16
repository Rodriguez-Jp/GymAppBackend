using GymProjectBackend.Entities;

namespace GymProjectBackend.Repositories;

public interface IAuthRepository
{
    Task<User?> GetUserByIdAsync(Guid userId);
}