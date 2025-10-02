namespace GymProjectBackend.Models.RoutineExercises
{
    public class RoutineExerciseDTO
    {
        public Guid RoutineId { get; set; }
        public Guid ExerciseId { get; set; }
        public string Reps { get; set; } = string.Empty;
        public float Weight { get; set; }
    }
}
