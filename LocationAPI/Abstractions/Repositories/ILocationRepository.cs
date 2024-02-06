using LocationAPI.Models;

namespace LocationAPI.UseCases.Repositories;

public interface ILocationRepository
{
    Task<List<Location>> GetAvailableLocations();
    Task<bool> AddNewLocation(Location input);
}