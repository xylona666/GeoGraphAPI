using System;
using System.Collections.Generic;

namespace CountryRouteApi.Infrastructure
{
    public class Graph : IGraph
    {
        // 邻接表：表示国家与其邻接国家
        public IReadOnlyDictionary<string, string[]> Adj { get; } =
            new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
            {
                ["CAN"] = new[] { "USA" },
                ["USA"] = new[] { "CAN", "MEX" },
                ["MEX"] = new[] { "USA", "GTM", "BLZ" },
                ["BLZ"] = new[] { "MEX", "GTM" },
                ["GTM"] = new[] { "MEX", "BLZ", "SLV", "HND" },
                ["SLV"] = new[] { "GTM", "HND" },
                ["HND"] = new[] { "GTM", "SLV", "NIC" },
                ["NIC"] = new[] { "HND", "CRI" },
                ["CRI"] = new[] { "NIC", "PAN" },
                ["PAN"] = new[] { "CRI" }
            };

        public bool HasCountry(string code) => Adj.ContainsKey(code);
    }
}

