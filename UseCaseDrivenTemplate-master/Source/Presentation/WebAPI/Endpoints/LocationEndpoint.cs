using LocationAPI.Abstractions.UseCases;

namespace WebAPI.Endpoints;

public static class LocationsEndpoint
{
    public static void RegisterLocationsEndpoint(this WebApplication app)
    {
        var endpoints = app.MapGroup("/locations");

        endpoints.MapGet("/", async (IGetAvailableLocationsUseCase getAvailableLocationsUseCase) =>
            {
                var output = await getAvailableLocationsUseCase.Execute(new IGetAvailableLocationsUseCase.Input());
            
                return output.Count == 0 ? Results.NotFound("No locations are available.") : Results.Ok(output);
            })
            .WithName("GetAvailableLocations")
            .WithOpenApi();
        
        
        endpoints.MapPost("/", async (IAddLocationUseCase addLocationUseCase, IAddLocationUseCase.Input input) =>
            {
                var output = await addLocationUseCase.Execute(input);
                if (string.IsNullOrWhiteSpace(output))
                {
                    Results.Problem("Unable to add the new location.", statusCode: 400);
                }

                return Results.Created($"/locations/{output}", output);
            })
            .WithName("AddNewLocation")
            .WithOpenApi();
    }
}