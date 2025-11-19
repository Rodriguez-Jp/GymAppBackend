namespace GymProjectBackend.Models.Auth;

public class SignUpResponseDTO
{
    public required Guid id { get; set; }
    public required string username { get; set; }
}