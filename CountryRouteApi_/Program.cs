using CountryRouteApi.Infrastructure;      
using CountryRouteApi.Services;
using CountryRouteApi.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddOpenApi();

// 使用接口注册，方便后续扩展与测试
builder.Services.AddSingleton<IGraph, Graph>(); 
builder.Services.AddSingleton<IRouteService, RouteService>(); 

var app = builder.Build();

app.MapOpenApi();
app.MapControllers();

// 支持 GET /PAN 这种根路径访问形式，贴合题目示例
app.MapGet("/{code}", (string code, IRouteService routeService) =>
{
    if (string.IsNullOrWhiteSpace(code) || code.Trim().Length != 3)
    {
        return Results.BadRequest(new ErrorResponse("INVALID_CODE", "code must be a 3-letter country code"));
    }

    var result = routeService.GetRouteFromUsa(code);

    if (result == null)
    {
        return Results.NotFound(new ErrorResponse("NOT_FOUND",
            $"destination '{code.Trim().ToUpperInvariant()}' not found or unreachable"));
    }

    return Results.Ok(result);
});

app.Run();
