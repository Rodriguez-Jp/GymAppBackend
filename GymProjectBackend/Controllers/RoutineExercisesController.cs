using GymProjectBackend.Entities;
using GymProjectBackend.Models.RoutineExercises;
using GymProjectBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GymProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutineExercisesController(IRoutineExercisesService routineExercisesService) : ControllerBase
    {
        [Authorize]
        [HttpGet("{routineExerciseId}")]
        public async Task<ActionResult<RoutineExercisesResponseDTO>> GetRoutineExercises([FromRoute]Guid routineExerciseId)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdString is null)
                return Unauthorized();

            var userId = Guid.Parse(userIdString);

            var result = await routineExercisesService.GetRoutineExerciseAsync(routineExerciseId, userId);

            if (result is null)
                return NotFound();

            return result;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<RoutineExercises?>> CreateRoutineExercises(RoutineExerciseDTO request)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdString is null)
                return Unauthorized();
            
            var userId = Guid.Parse(userIdString);

            var response = await routineExercisesService.CreateRoutineExerciseAsync(request, userId);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<RoutineExercisesResponseDTO?>> EditRoutineExercises(RoutineExerciseEditDTO request)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdString is null)
                return Unauthorized();
            
            var userId = Guid.Parse(userIdString);

            var result = await routineExercisesService.UpdateRoutineExerciseAsync(request, userId);

            if (result is null)
                return NotFound();

            return result;
        }

        [Authorize]
        [HttpDelete("{routineExerciseId}")]
        public async Task<ActionResult<string?>> DeleteRoutineExercises([FromRoute] Guid routineExerciseId)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdString is null)
                return Unauthorized();
            
            var userId = Guid.Parse(userIdString);

            var result = await routineExercisesService.DeleteRoutineExerciseAsync(routineExerciseId, userId);

            if (result is null)
                return NotFound();

            return result;
        }
    }
}
