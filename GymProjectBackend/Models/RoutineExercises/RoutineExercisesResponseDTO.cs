using GymProjectBackend.Models.Exercise;
using GymProjectBackend.Models.Routine;

namespace GymProjectBackend.Models.RoutineExercises
{
    public class RoutineExercisesResponseDTO
    {
        public RoutineResponseDTO Routine { get; set; }
        public ExerciseResponseDTO Exercise { get; set; }
        public string Reps { get; set; }
        public float Weight { get; set; }
    }
}
