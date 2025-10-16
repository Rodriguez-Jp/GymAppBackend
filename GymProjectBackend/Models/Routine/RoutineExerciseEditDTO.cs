using System.ComponentModel.DataAnnotations;

namespace GymProjectBackend.Models.RoutineExercises
{
    public class RoutineExerciseEditDTO
    {
        [Required]
        public Guid Id { get; set; }
        public required int Reps { get; set; }
        public float Weight { get; set; }
    }
}
