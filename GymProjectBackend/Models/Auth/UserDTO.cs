using System.ComponentModel.DataAnnotations;

namespace GymProjectBackend.Models.Auth
{
    public class UserDTO
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "Do not enter more than 30 characters")]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        [DataType(DataType.Text)]
        [StringLength(14, ErrorMessage = "Password doesn't meet security requirements")]
        public string Password { get; set; } = string.Empty;
    }
}
