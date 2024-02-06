using Application.Abstractions;

namespace LocationAPI.Abstractions.UseCases;

public interface IGetAvailableLocationsUseCase: IUseCase<IGetAvailableLocationsUseCase.Input, List<IGetAvailableLocationsUseCase.Output>>
{
    public class Input
    {
        
    }
    
    public class Output
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } 
        public List<TimeSlotDto> Availability { get; set; }
    }

    public class TimeSlotDto
    {
        public int TimeSlotId { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public int LocationId { get; set; }
    }
    
}