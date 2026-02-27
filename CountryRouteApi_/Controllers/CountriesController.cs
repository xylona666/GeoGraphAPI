using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CountryRouteApi.Contracts;
using CountryRouteApi.Services;

namespace CountryRouteApi.Controllers
{
    [ApiController]
    [Route("countries")]
    public class CountriesController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public CountriesController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        // GET /countries/PAN
        [HttpGet("{code}")]
        [ProducesResponseType(typeof(RouteResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public IActionResult GetRoute(string code)
        {
            if (string.IsNullOrWhiteSpace(code) || code.Trim().Length != 3)
            {
                return BadRequest(new ErrorResponse("INVALID_CODE", "code must be a 3-letter country code"));
            }

            var result = _routeService.GetRouteFromUsa(code);

            if (result == null)
            {
                return NotFound(new ErrorResponse("NOT_FOUND",
                    $"destination '{code.Trim().ToUpperInvariant()}' not found or unreachable"));
            }

            return Ok(result);
        }
    }
}