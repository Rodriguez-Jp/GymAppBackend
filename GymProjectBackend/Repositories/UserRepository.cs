using GymProjectBackend.Data;
using GymProjectBackend.Entities;
using GymProjectBackend.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace GymProjectBackend.Repositories;

public class UserRepository (GymAppDbContext context) : IUserRepository
{
    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        var response = await context.Users.FindAsync(userId);
        return response;
    }

    public async Task<User?> GetByUsername(UserDTO request)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);

        return user;
    }
    
    

    public async Task<bool> UserExistAsync(UserDTO request)
    {
        var response = await context.Users.AnyAsync(u => u.Username == request.Username);

        return response;
    }

    public async Task<User?> RegisterAsync(User user)
    {
        try
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<bool> SaveChangesAsync()
    {
        try
        {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}