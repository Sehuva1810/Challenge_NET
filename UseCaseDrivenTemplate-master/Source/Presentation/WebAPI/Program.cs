using Application;
using Data;
using Microsoft.EntityFrameworkCore;
using WebAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("LocationsDb"));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<HttpResponseMiddleware>();
app.UseHttpsRedirection();
app.RegisterHealthCheckEndpoint();
app.RegisterLocationsEndpoint();
app.Run();