using System.Collections.Generic;

namespace CountryRouteApi.Infrastructure
{
    public interface IGraph
    {
        IReadOnlyDictionary<string, string[]> Adj { get; }
        bool HasCountry(string code);
    }
}

