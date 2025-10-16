using System.ComponentModel.DataAnnotations;

namespace GymProjectBackend.Models.Exercise
{
    public class ExerciseResponseDTO
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
    }
}
