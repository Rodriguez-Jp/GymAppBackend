using System.ComponentModel.DataAnnotations;

namespace GymProjectBackend.Models.Routine
{
    public class RoutineEditDTO
    {
        [Required]
        public Guid RoutineId { get; set; }
        [DataType(DataType.Text)]
        public string RoutineName { get; set; }
        [DataType(DataType.Text)]
        public string Description { get; set; }
    }
}
