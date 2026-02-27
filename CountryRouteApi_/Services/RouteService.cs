using System;
using System.Collections.Generic;
using CountryRouteApi.Contracts;
using CountryRouteApi.Infrastructure;

namespace CountryRouteApi.Services
{
    public class RouteService : IRouteService
    {
        private const string Origin = "USA";

        private readonly IGraph _graph;

        public RouteService(IGraph graph)
        {
            _graph = graph;
        }

        // controller will call this
        public RouteResponse? GetRouteFromUsa(string destination)
        {
            if (string.IsNullOrWhiteSpace(destination))
            {
                return null;
            }

            destination = destination.Trim().ToUpperInvariant();

            if (!_graph.HasCountry(destination))
            {
                return null;
            }

            List<string>? route = FindShortestPath(Origin, destination);
            if (route == null)
            {
                return null;
            }

            var response = new RouteResponse(destination, route);
            return response;
        }

        private List<string>? FindShortestPath(string start, string goal)
        {
            if (string.Equals(start, goal, StringComparison.OrdinalIgnoreCase))
            {
                return new List<string> { start };
            }

            Queue<string> queue = new Queue<string>();
            Dictionary<string, string?> previous = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
            queue.Enqueue(start);
            previous[start] = null;

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();

                if (!_graph.Adj.TryGetValue(current, out var neighbors))
                {
                    continue;
                }

                for (int i = 0; i < neighbors.Length; i++)
                {
                    string next = neighbors[i];
                    if (previous.ContainsKey(next))
                    {
                        continue;
                    }

                    previous[next] = current;
                    if (string.Equals(next, goal, StringComparison.OrdinalIgnoreCase))
                    {
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
}