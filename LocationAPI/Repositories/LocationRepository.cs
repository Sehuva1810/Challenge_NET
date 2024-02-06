using LocationAPI.Abstractions.UseCases;
using LocationAPI.Data;
using LocationAPI.Models;
using LocationAPI.UseCases.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LocationAPI.Repositories;

public class LocationRepository(AppDbContext context): ILocationRepository
{
    public async Task<List<Location>> GetAvailableLocations()
    {
        return await context.Locations
            .Include(l => l.Availability)
            .Where(l => l.Availability.Any(ts => ts.Start.Hours >= 10 && ts.End.Hours <= 13))
            .ToListAsync();
    }
    
    public async Task<bool> AddNewLocation(Location input)
    {
        context.Locations.Add(input);
        var result = await context.SaveChangesAsync();

        return result > 0;
    }
}