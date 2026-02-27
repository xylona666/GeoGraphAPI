using System.Collections.Generic;
using CountryRouteApi.Infrastructure;
using CountryRouteApi.Services;
using Xunit;

namespace CountryRouteApi.Tests;

public class RouteServiceTests
{
    private readonly RouteService _service;

    public RouteServiceTests()
    {
        // 使用真实的 Graph，保证测试和生产配置一致
        var graph = new Graph();
        _service = new RouteService(graph);
    }

    [Fact]
    public void GetRouteFromUsa_PAN_ReturnsExpectedRoute()
    {
        var result = _service.GetRouteFromUsa("PAN");

        Assert.NotNull(result);
        Assert.Equal("PAN", result!.Destination);
        Assert.Equal(
            new List<string> { "USA", "MEX", "GTM", "HND", "NIC", "CRI", "PAN" },
            result.Route
        );
    }

    [Fact]
    public void GetRouteFromUsa_BLZ_ReturnsExpectedRoute()
    {
        var result = _service.GetRouteFromUsa("BLZ");

        Assert.NotNull(result);
        Assert.Equal("BLZ", result!.Destination);
        Assert.Equal(
            new List<string> { "USA", "MEX", "BLZ" },
            result.Route
        );
    }

    [Fact]
    public void GetRouteFromUsa_USA_ReturnsSingleNodeRoute()
    {
        var result = _service.GetRouteFromUsa("USA");

        Assert.NotNull(result);
        Assert.Equal("USA", result!.Destination);
        Assert.Equal(
            new List<string> { "USA" },
            result.Route
        );
    }

    [Fact]
    public void GetRouteFromUsa_InvalidCode_ReturnsNull()
    {
        var result = _service.GetRouteFromUsa("XYZ");

        Assert.Null(result);
    }

    [Fact]
    public void GetRouteFromUsa_IsCaseInsensitive()
    {
        var upper = _service.GetRouteFromUsa("PAN");
        var lower = _service.GetRouteFromUsa("pan");

        Assert.NotNull(upper);
        Assert.NotNull(lower);
        Assert.Equal(upper!.Destination, lower!.Destination);
        Assert.Equal(upper.Route, lower.Route);
    }
}

