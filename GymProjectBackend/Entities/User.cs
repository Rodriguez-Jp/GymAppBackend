using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymProjectBackend.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [MaxLength(20)]
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        //FKs
        //Navigation prop
        public ICollection<Routine> Routines { get; set; }
    }
}
