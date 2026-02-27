using System;
using System.Collections.Generic;
using CountryRouteApi.Contracts; // request
using CountryRouteApi.Infrastructure; // data
namespace CountryRouteApi.Services;

    public class RouteService
    {
        private readonly Graph _graph;
        public RouteService(Graph graph)
        {
            _graph = graph;
        }
        public RouteResponse? GetRouteFromUsa(string destination)   // control will call this 
        {
            if (destination == null)
            {
                return null;
            }
            destination = destination.Trim().ToUpperInvariant();
            if (!_graph.HasCountry(destination)){
                return null;
            }
            List<string>? route = FindShortestPath("USA", destination);
            if (route == null)
            {
                return null;
            }
            //package as data transfer object， controller return this response
            RouteResponse response = new RouteResponse(destination, route);
            return response;
        }
        private List<string>? FindShortestPath(string start,string goal)
        {
            if(string.Equals(start,goal,StringComparison.OrdinalIgnoreCase))
            {
                return new List<string>{start};
            }
            Queue <string> queue = new Queue<string>();
            Dictionary<string, string?> previous = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
            queue.Enqueue(start);
            previous[start] = null;

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                string[] neighbors = _graph.Adj[current];
                for (int i = 0; i < neighbors.Length; i++)
                {
                    string next = neighbors[i];
                    if (previous.ContainsKey(next)){
                            continue;
                            }
                    previous[next] = current;
                    if (string.Equals(next, goal, StringComparison.OrdinalIgnoreCase)){
                        return BuildPath(previous, goal);
                        }
                    queue.Enqueue(next);
                    }
            }
            return null;
            }

            // 从 goal 沿着 previous 回溯到 start，再反转
        private static List<string> BuildPath(Dictionary<string, string?> previous, string goal)
        {
            List<string> path = new List<string>();
            string? at = goal;
            while (at != null)
            { 
                path.Add(at);
                at = previous[at];
            }
            path.Reverse();
            return path;
        }
    }


            