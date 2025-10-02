namespace GymProjectBackend.Entities
{
    public class Exercise
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigation
        public ICollection<RoutineExercises> routineExercises { get; set; }
    }
}
