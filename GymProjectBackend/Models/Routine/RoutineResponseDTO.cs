using System.ComponentModel.DataAnnotations;

namespace GymProjectBackend.Models.Routine
{
    public class RoutineResponseDTO
    {
        [Required]
        public string RoutineName { get; set; }
        [Required]
        public string RoutineDescription { get; set; }
    }
}
