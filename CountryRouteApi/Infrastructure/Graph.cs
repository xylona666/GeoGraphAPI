namespace CountryRouteApi.Infrastructure;

public class Graph
{
    // create dictionary to store data
    public Dictionary<string, string[]> Adj { get; } = new(StringComparer.OrdinalIgnoreCase) 
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
    //verify if country code exits

    public bool HasCountry(string code) => Adj.ContainsKey(code);
}
