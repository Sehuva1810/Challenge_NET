using Data.Entities;

namespace Data.Repositories;

public interface ILocationRepository
{
    Task<List<Location>> GetAvailableLocations();
    Task<Location> AddNewLocation(Location input);
}