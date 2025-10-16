using System.ComponentModel.DataAnnotations;

namespace GymProjectBackend.Models.Routine
{
    public class RoutineDeleteDTO
    {
        [Required]
        public Guid RoutineId { get; set; }
    }
}
