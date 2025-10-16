using GymProjectBackend.Data;
using GymProjectBackend.Entities;

namespace GymProjectBackend.Repositories;

public class AuthRepository (GymAppDbContext context) : IAuthRepository
{
    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        var response = await context.Users.FindAsync(userId);
        return response;
    }
}