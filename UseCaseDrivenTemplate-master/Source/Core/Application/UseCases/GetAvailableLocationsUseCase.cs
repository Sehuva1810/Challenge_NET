using Data.Repositories;
using LocationAPI.Abstractions.UseCases;

namespace Application.UseCases;

public class GetAvailableLocationsUseCase(ILocationRepository locationRepository) : IGetAvailableLocationsUseCase
{
    public async Task<List<IGetAvailableLocationsUseCase.Output>> Execute(IGetAvailableLocationsUseCase.Input input)
    {
        var locations = await locationRepository.GetAvailableLocations();
        
        if (locations.Count == 0)
        {
            return [];
        }

        var outputLocations = locations.Select(location => new IGetAvailableLocationsUseCase.Output()
        {
            Id = location.Id,
            Name = location.Name,
            Type = location.Type,
            Availability = location.Availability.Select(ts => new IGetAvailableLocationsUseCase.TimeSlotDto()
            {
                Start = ts.Start,
                End = ts.End,
            }).ToList()
        }).ToList();

        return outputLocations;

    }
    
}
