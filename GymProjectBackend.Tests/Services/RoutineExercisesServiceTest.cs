using GymProjectBackend.Models.RoutineExercises;
using GymProjectBackend.Repositories;

namespace GymProjectBackend.Tests.Services;
using Xunit;
using Moq;
using GymProjectBackend.Services;
using GymProjectBackend.Entities;


public class RoutineExercisesServiceTest
{
    [Fact]
    public async Task CreateRoutineExerciseAsync_WithNonExistentRoutineId_ShouldReturnFailure()
    {
        var nonExistentRoutineId = Guid.NewGuid();
        var existingExerciseId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        var request = new RoutineExerciseDTO
        {
            RoutineId = nonExistentRoutineId,
            ExerciseId = existingExerciseId,
            Reps = 20,
            Weight = 25
        };

        var mockRoutineRepository = new Mock<IRoutineRepository>();
        var mockExercisesRepository = new Mock<IExerciseRepository>();
        var mockRoutineExercisesRepository = new Mock<IRoutineExercisesRepository>();

        mockRoutineRepository
            .Setup(repo => repo.GetRoutineByIdAsync(nonExistentRoutineId))
            .ReturnsAsync((Routine?)null);

        mockExercisesRepository
            .Setup(repo => repo.GetExerciseByIdAsync(existingExerciseId))
            .ReturnsAsync(new Exercise { Id = existingExerciseId, Name = "Squat", Description = "Legs exercise" });
        
        mockRoutineExercisesRepository
            .Setup(r => r.NewRoutineExercise(It.IsAny<RoutineExercises>()))
            .ReturnsAsync(true);


        var service = new RoutineExercisesService(
            mockRoutineExercisesRepository.Object,
            mockExercisesRepository.Object,
            mockRoutineRepository.Object
        );

        var result = await service.CreateRoutineExerciseAsync(request, userId);
        
        Assert.Null(result);
        mockRoutineExercisesRepository.Verify(
            r => r.NewRoutineExercise(It.IsAny<RoutineExercises>()),
            Times.Never
        );
    }
}