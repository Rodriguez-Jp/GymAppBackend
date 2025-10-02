namespace GymProjectBackend.Entities
{
    public class Routine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //FKs
        public Guid UserId { get; set; }
        //Navigation for user
        public User User { get; set; }
        public ICollection<RoutineExercises> routineExercises { get; set; }
    }
}
