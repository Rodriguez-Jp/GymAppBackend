using System.ComponentModel.DataAnnotations;

namespace GymProjectBackend.Models.Routine
{
    public class RoutineCreateDTO
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "Do not enter more than 20 characters")]
        public string RoutineName { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Do not enter more than 50 characters")]
        public string Description { get; set; }
    }
}
