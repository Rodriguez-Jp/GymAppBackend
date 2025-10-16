using Microsoft.EntityFrameworkCore;

namespace GymProjectBackend.Entities
{
    public class RoutineExercises
    {

        public Guid Id { get; set; } =  Guid.NewGuid();
        public float Weight { get; set; }
        public int Reps { get; set; }

        //FKs and Navigations
        public Guid RoutineId { get; set; }
        public Routine Routine { get; set; }
        public Guid ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
