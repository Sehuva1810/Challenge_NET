// TimeSlot.cs

using LocationAPI.Models;

namespace LocationsApi.Models
{
    public class TimeSlot
    {
        public int TimeSlotId { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}