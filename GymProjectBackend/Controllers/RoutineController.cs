using GymProjectBackend.Entities;
using GymProjectBackend.Models.Routine;
using GymProjectBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GymProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutineController(IRoutineService routineService) : ControllerBase
    {
        [Authorize]
        [HttpGet ("{id}")]
        public async Task<ActionResult<Routine>> GetRoutine([FromRoute]Guid id)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdString is null)
                return Unauthorized();

            var routine = await routineService.GetRoutineAsync(id);

            if (routine is null)
            {
                return NotFound();
            }

            return Ok(routine);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Routine>> CreateRoutine(RoutineCreateDTO request)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdString is null)
                return Unauthorized();

            var UserId = Guid.Parse(userIdString);
            var routine = await routineService.CreateNewRoutineAsync(request, UserId);

            return Ok(routine);
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<string>> DeleteRoutine(RoutineDeleteDTO request)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdString is null)
                return Unauthorized();

            var UserId = Guid.Parse(userIdString);

            var result = await routineService.DeleteRoutineAsync(request, UserId);

            if (result is null)
                return BadRequest();

            return result;

        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<string>> EditRoutine(RoutineEditDTO request)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdString is null)
                return Unauthorized();

            var UserId = Guid.Parse(userIdString);

            var result = await routineService.EditRoutineAsync(request, UserId);

            if (result is null)
                return BadRequest();

            return result;

        }


    }
}
