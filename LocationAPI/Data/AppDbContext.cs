using LocationAPI.Models;
using LocationsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Location> Locations { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>().HasData(
            new Location { Id = 1, Name = "Central Pharmacy", Type = "Pharmacy" },
            new Location { Id = 2, Name = "Downtown Bakery", Type = "Bakery" }
            // Add more predefined locations here
        );

        modelBuilder.Entity<TimeSlot>().HasData(
            new TimeSlot { TimeSlotId = 1, Start = new TimeSpan(9, 0, 0), End = new TimeSpan(12, 0, 0), LocationId = 1 },
            new TimeSlot { TimeSlotId = 2, Start = new TimeSpan(10, 0, 0), End = new TimeSpan(13, 0, 0), LocationId = 2 }
            // Add more predefined time slots here
        );
    }

}