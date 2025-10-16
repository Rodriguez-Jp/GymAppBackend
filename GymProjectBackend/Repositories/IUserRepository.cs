using GymProjectBackend.Entities;
using GymProjectBackend.Models.Auth;

namespace GymProjectBackend.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(Guid userId);
    Task<User?> GetByUsername(UserDTO request);
    Task<bool> UserExistAsync(UserDTO request);
    Task<User?> RegisterAsync(User user);
    Task<bool> SaveChangesAsync();
}