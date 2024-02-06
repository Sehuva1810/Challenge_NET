using Application.Abstractions;

namespace LocationAPI.Abstractions.UseCases;

public interface IAddLocationUseCase: IUseCase<IAddLocationUseCase.Input, string>
{
    public class Input
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<CreateTimeSlotRequest> Availability { get; set; }
    }
}
public class CreateTimeSlotRequest
{
    public string Start { get; set; }
    public string End { get; set; }
}