using LocationAPI.Abstractions.UseCases;
using LocationAPI.Data;
using LocationAPI.Models;
using LocationAPI.UseCases.Repositories;
using LocationsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationAPI.UseCases;

public class AddLocationUseCase(ILocationRepository locationRepository) : IAddLocationUseCase
{
    public async Task<bool> Execute(IAddLocationUseCase.Input input)
    {
        var result = await locationRepository.AddNewLocation(new Location(){});
    }
}


