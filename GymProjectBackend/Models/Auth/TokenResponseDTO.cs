namespace GymProjectBackend.Models.Auth
{
    public class TokenResponseDTO
    {
        public required string Username { get; set; }
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }
}
