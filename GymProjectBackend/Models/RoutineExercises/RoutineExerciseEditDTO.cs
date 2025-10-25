using System.ComponentModel.DataAnnotations;

namespace GymProjectBackend.Models.RoutineExercises
{
    public class RoutineExerciseEditDTO
    {
        [Required]
        public Guid Id { get; set; }
        //No necessary routineId implicit in the RoutineExercise entity
        //[Required(ErrorMessage = "RoutineId cannot be null")]
        //public Guid RoutineId { get; set; }
        public required int Reps { get; set; }
        public float Weight { get; set; }
    }
}
