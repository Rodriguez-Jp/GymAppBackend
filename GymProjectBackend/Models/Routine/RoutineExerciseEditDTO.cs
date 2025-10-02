namespace GymProjectBackend.Models.RoutineExercises
{
    public class RoutineExerciseEditDTO
    {
        public Guid Id { get; set; }
        public required string Reps { get; set; }
        public float Weight { get; set; }
    }
}
