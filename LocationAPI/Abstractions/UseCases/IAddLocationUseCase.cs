using LocationAPI.UseCases;

namespace LocationAPI.Abstractions.UseCases;

public interface IAddLocationUseCase: IUseCase<IAddLocationUseCase.Input, bool>
{
    public interface Input
    {
        
    }
}