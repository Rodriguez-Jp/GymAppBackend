using GymProjectBackend.Entities;
using GymProjectBackend.Models.Auth;

namespace GymProjectBackend.Services
{
    public interface IAuthService
    {
        Task<SignUpResponseDTO?> RegisterAsync(UserDTO request);
        Task<TokenResponseDTO?> LoginAsync(UserDTO request);
        Task<TokenResponseDTO?> RefreshTokensAsync(RefreshTokenDTO request);
    }
}
