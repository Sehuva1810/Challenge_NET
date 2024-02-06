using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class LocationRepository(AppDbContext context): ILocationRepository
{
    public async Task<List<Location>> GetAvailableLocations()
    {
        // Only to ensure seed data is inserted.
        await context.Database.EnsureCreatedAsync();

        return await context.Locations
            .Include(l => l.Availability)
            .Where(l => l.Availability.Any(ts => ts.Start.Hours >= 10 && ts.End.Hours <= 13))
            .ToListAsync();
    }
    
    public async Task<Location> AddNewLocation(Location input)
    {
        // Only to ensure seed data is inserted.
        await context.Database.EnsureCreatedAsync();
        
        context.Locations.Add(input);
        await context.SaveChangesAsync();

        return input;
    }
}