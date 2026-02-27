using CountryRouteApi.Contracts;

namespace CountryRouteApi.Services
{
    public interface IRouteService
    {
        RouteResponse? GetRouteFromUsa(string destination);
    }
}

