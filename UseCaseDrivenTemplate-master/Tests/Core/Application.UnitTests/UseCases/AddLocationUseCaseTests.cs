using Application.UseCases;
using Data.Entities;
using Data.Repositories;
using LocationAPI.Abstractions.UseCases;
using NSubstitute;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.UseCases;

public class AddLocationUseCaseTests
{
    private readonly ILocationRepository locationRepository;
    private readonly AddLocationUseCase addLocationUseCase;

    public AddLocationUseCaseTests()
    {
        locationRepository = Substitute.For<ILocationRepository>();
        addLocationUseCase = new AddLocationUseCase(locationRepository);
    }

    [Fact]
    public async Task ShouldAddLocationSuccessfully()
    {
        var timeSlotDtos = new List<CreateTimeSlotRequest> { new CreateTimeSlotRequest { Start = "09:00", End = "10:00" } };
        var input = new IAddLocationUseCase.Input() 
        {
            Name = "Test Location",
            Type = "Test Type",
            Availability = timeSlotDtos
        };
        
        var expectedId = 1; 
        locationRepository.AddNewLocation(Arg.Any<Location>()).Returns(new Location { Id = expectedId});

        // Act
        var result = await addLocationUseCase.Execute(input);

        // Assert
        Assert.NotEmpty(result); 
        Assert.Equal(expectedId.ToString(), result); 
    }


}
