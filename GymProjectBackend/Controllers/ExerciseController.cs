using GymProjectBackend.Entities;
using GymProjectBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ExerciseController(IExerciseService exerciseService) : ControllerBase
    {
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise([FromRoute] Guid id)
        {
            var exercise = await exerciseService.GetExerciseAsync(id);

            if (exercise is null)
                return NotFound();

            return exercise;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Exercise>>> GetAllExercises()
        {
            var allExercises = await exerciseService.GetAllExercisesAsync();
            return allExercises;
        }
    }
}
