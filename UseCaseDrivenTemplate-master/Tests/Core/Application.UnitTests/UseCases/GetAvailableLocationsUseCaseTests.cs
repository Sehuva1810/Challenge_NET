using Application.UseCases;
using Data.Repositories;
using LocationAPI.Abstractions.UseCases;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Xunit;

namespace Application.UnitTests.UseCases;

public class GetAvailableLocationsUseCaseTests
{
    private readonly ILocationRepository locationRepository;
    private readonly GetAvailableLocationsUseCase getAvailableLocationsUseCase;

    public GetAvailableLocationsUseCaseTests()
    {
        locationRepository = Substitute.For<ILocationRepository>();
        getAvailableLocationsUseCase = new GetAvailableLocationsUseCase(locationRepository);
    }

    [Fact]
    public async Task ShouldReturnAvailableLocations()
    {
        var mockLocations = new List<Location>
        {
            new Location
            {
                Id = 1,
                Name = "Location 1",
                Type = "Type1",
                Availability = new List<TimeSlot>
                {
                    new TimeSlot { Start = TimeSpan.FromHours(9), End = TimeSpan.FromHours(10) }
                }
            }
        };
        locationRepository.GetAvailableLocations().Returns(mockLocations);
        
        var result = await getAvailableLocationsUseCase.Execute(new IGetAvailableLocationsUseCase.Input());
        
        result.ShouldNotBeEmpty();
        result.Count.ShouldBe(mockLocations.Count);
        result.First().Name.ShouldBe("Location 1");
    }

    [Fact]
    public async Task ShouldReturnEmptyWhenNoLocationsAvailable()
    {
        locationRepository.GetAvailableLocations().Returns(new List<Location>());
        
        var result = await getAvailableLocationsUseCase.Execute(new IGetAvailableLocationsUseCase.Input());
        
        result.ShouldBeEmpty();
    }
}

