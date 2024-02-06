using LocationAPI.Abstractions.UseCases;
using LocationAPI.Data;
using LocationAPI.Models;
using LocationAPI.UseCases.Repositories;
using LocationsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationAPI.UseCases;

public class GetAvailableLocationsUseCase(ILocationRepository locationRepository) : IGetAvailableLocationsUseCase
{
    public async Task<IGetAvailableLocationsUseCase.Output> Execute(IGetAvailableLocationsUseCase.Input input)
    {
        var locations = await locationRepository.GetAvailableLocations();
        //return locations.Count == 0 ? [] : locations;
    }
    
}
