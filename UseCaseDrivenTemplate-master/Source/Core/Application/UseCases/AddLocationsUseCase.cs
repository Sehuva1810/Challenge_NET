using Data.Entities;
using Data.Repositories;
using LocationAPI.Abstractions.UseCases;

namespace Application.UseCases;

public class AddLocationUseCase(ILocationRepository locationRepository) : IAddLocationUseCase
{
    public async Task<string> Execute(IAddLocationUseCase.Input input)
    {
        var locationToAdd = new Location
        {
            Name = input.Name,
            Type = input.Type,
            Availability = input.Availability.Select(a => new TimeSlot
            {
                Start = TimeSpan.Parse(a.Start),
                End = TimeSpan.Parse(a.End)
            }).ToList()
        };
        var result = await locationRepository.AddNewLocation(locationToAdd);

        return result?.Id.ToString() ?? string.Empty;
    }
}


