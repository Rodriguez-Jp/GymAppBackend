using System.ComponentModel.DataAnnotations;

namespace GymProjectBackend.Models.Exercise
{
    public class ExerciseResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}
