using CountryRouteApi.Infrastructure;      
using CountryRouteApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddOpenApi();
builder.Services.AddSingleton<Graph>(); // data dependency injection
builder.Services.AddSingleton<RouteService>(); //server


var app = builder.Build();
app.MapOpenApi();

app.MapControllers(); // ?
app.Run();
