using System.ComponentModel.DataAnnotations;
using GymProjectBackend.Models.Exercise;
using GymProjectBackend.Models.RoutineExercises;

namespace GymProjectBackend.Models.Routine
{
    public class RoutineResponseDTO
    {
        public Guid Id { get; set; }
        public string RoutineName { get; set; }
        public string RoutineDescription { get; set; }
        public List<RoutineExercisesResponseDTO> RoutineExercises { get; set; }
    }
}
