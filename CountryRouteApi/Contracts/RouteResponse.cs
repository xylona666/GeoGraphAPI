public class RouteResponse
{
    public string Destination { get; set; }
    public List<string> Route { get; set; }

    public RouteResponse(string destination, List<string> route)
    {
        Destination = destination;
        Route = route;
    }
}