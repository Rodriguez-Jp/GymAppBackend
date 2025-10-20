using GymProjectBackend.Repositories;

namespace GymProjectBackend.Tests.Services;
using Xunit;
using Moq;
using GymProjectBackend.Services;
using GymProjectBackend.Entities;

public class ExerciseServiceTest
{
    [Fact]
    public async Task GetExerciseAsync_ExerciseExists_ReturnsExercise()
    {
        //Creamos el caso de prueba
        var exerciseId = Guid.NewGuid();
        var expectedExercise = new Exercise
        {
            Id = exerciseId,
            Name = "Bench Press",
            Description = "Chest exercise"
        };
        
        var mockRepository = new Mock<IExerciseRepository>();

        mockRepository
            .Setup(repo => repo.GetExerciseByIdAsync(exerciseId))
            .ReturnsAsync(expectedExercise);
        
        var service = new ExerciseService(mockRepository.Object);

        //Accionamos
        var result = await service.GetExerciseAsync(exerciseId);

        //Verificamos
        Assert.NotNull(result);
        Assert.Equal(exerciseId, result.Id);
        Assert.Equal("Bench Press", result.Name);
        Assert.Equal("Chest exercise", result.Description);
    }

    [Fact]
    public async Task GetExerciseAsync_ExerciseDoesNotExist_ReturnsNull()
    {
        //Creamos el caso de prueba
        var exerciseId = Guid.NewGuid();
        
        var mockRepository = new Mock<IExerciseRepository>();

        
        mockRepository
            .Setup(repo => repo.GetExerciseByIdAsync(exerciseId))
            .ReturnsAsync((Exercise?)null);

        var service = new ExerciseService(mockRepository.Object);

        //Accionamos
        var result = await service.GetExerciseAsync(exerciseId);
        
        //Verificamos
        Assert.Null(result);
    }

    [Fact]
    public async Task GetExerciseAsync_CallsRepository_Once()
    {
        //Creamos el caso de prueba
        var exerciseId = Guid.NewGuid();
        var mockRepository = new Mock<IExerciseRepository>();

        mockRepository
            .Setup(repo => repo.GetExerciseByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Exercise?)null);

        var service = new ExerciseService(mockRepository.Object);

        //Accionamos
        await service.GetExerciseAsync(exerciseId);
        
        //Verificamos
        mockRepository.Verify(
            repo => repo.GetExerciseByIdAsync(exerciseId),
            Times.Once
            );
    }

    [Fact]
    public async Task GetAllExercisesAsync_ExercisesExist_ReturnsListExercises()
    {
        //Creamos el caso de prueba
        var exercise1Id = Guid.NewGuid();
        var exercise2Id = Guid.NewGuid();
        
        var expectedExerciseList = new List<Exercise>
        {
            new Exercise
            {
                Id = exercise1Id,
                Name = "Bench Press",
                Description = "Chest exercise"
            },
            new Exercise
            {
                Id = exercise2Id,
                Name = "Inclined Bench Press",
                Description = "Chest incline exercise"
            }
        };
        
        var mockRepository = new Mock<IExerciseRepository>();

        mockRepository
            .Setup(repo => repo.GetAllExercisesAsync())
            .ReturnsAsync(expectedExerciseList);

        var service = new ExerciseService(mockRepository.Object);

        //Accionamos
        var result = await service.GetAllExercisesAsync();

        
        //Verificamos
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(result, e => e.Name == "Bench Press");
        Assert.Contains(result, e => e.Name == "Inclined Bench Press");
        Assert.Contains(result, e => e.Id == exercise1Id);
        Assert.Contains(result, e => e.Id == exercise2Id);
        
        mockRepository.Verify(
            repo => repo.GetAllExercisesAsync(), 
            Times.Once
        );

    }

    [Fact]
    public async Task GetAllExercisesAsync_NoExercisesExist_ReturnsEmptyList()
    {
        //Creamos el caso de prueba
        var emptyList = new List<Exercise>();

        var mockRepository = new Mock<IExerciseRepository>();

        mockRepository
            .Setup(repo => repo.GetAllExercisesAsync())
            .ReturnsAsync(emptyList);

        var service = new ExerciseService(mockRepository.Object);

        //Accionamos
        var result = await service.GetAllExercisesAsync();

        //Verificamos
        Assert.NotNull(result);
        Assert.Empty(result);
    }
}
