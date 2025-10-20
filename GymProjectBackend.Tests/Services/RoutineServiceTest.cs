using GymProjectBackend.Models.Routine;
using GymProjectBackend.Repositories;

namespace GymProjectBackend.Tests.Services;

using Xunit;
using Moq;
using GymProjectBackend.Services;
using GymProjectBackend.Entities;

public class RoutineServiceTest
{
    [Fact]
    public async Task EditRoutineAsync_UserTriesToEditAnotherUsersRoutine_ReturnsNull()
    {
        //Creamos el caso de prueba
        
        var routineId = Guid.NewGuid();
        var routineOwnerId = Guid.NewGuid();
        var maliciousUserId = Guid.NewGuid(); 
    
        var existingRoutine = new Routine
        {
            Id = routineId,
            Name = "Someone Else's Routine",
            Description = "Private routine",
            UserId = routineOwnerId 
        };

        var request = new RoutineEditDTO
        {
            RoutineId = routineId,
            RoutineName = "Routine updated (Wrong user)",
            Description = "Vulnerable Description"
        };

        var mockRoutineRepository = new Mock<IRoutineRepository>();
        var mockUserRepository = new Mock<IUserRepository>();

        mockRoutineRepository
            .Setup(repo => repo.GetRoutineByIdAsync(routineId))
            .ReturnsAsync(existingRoutine);

        mockUserRepository
            .Setup(repo => repo.GetUserByIdAsync(maliciousUserId))
            .ReturnsAsync(new User { Id = maliciousUserId });

        mockRoutineRepository
            .Setup(repo => repo.EditRoutineAsync())
            .ReturnsAsync("Routine updated");

        var service = new RoutineService(mockRoutineRepository.Object, mockUserRepository.Object);
        
        //Accionamos
        var result = await service.EditRoutineAsync(request, maliciousUserId);
        
        //Verificamos
        Assert.Null(result); 
        mockRoutineRepository.Verify(
            r => r.EditRoutineAsync(),
            Times.Never 
        );
    }
}