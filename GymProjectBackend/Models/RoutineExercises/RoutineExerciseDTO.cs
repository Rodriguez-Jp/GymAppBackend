using System.ComponentModel.DataAnnotations;

namespace GymProjectBackend.Models.RoutineExercises
{
    public class RoutineExerciseDTO
    {
        [Required(ErrorMessage = "RoutineId cannot be null")]
        public Guid RoutineId { get; set; }
        
        [Required(ErrorMessage = "ExerciseId cannot be null")]
        public Guid ExerciseId { get; set; }
        
        [Required(ErrorMessage = "Reps cannot be null")]
        [Range(1, 100, ErrorMessage = "Reps should be at least 1 and max 100")]
        public int Reps { get; set; } = 0;
        
        [Required(ErrorMessage = "Weight cannot be null")]
        [Range(0.1, float.MaxValue, ErrorMessage = "Weight should be greater than zero")]
        public float Weight { get; set; }
        
        [Required(ErrorMessage = "Sets cannot be null")]
        [Range(1, 100, ErrorMessage = "Sets should be at least 1 and max 100")]
        public int Sets { get; set; }
    }
}
