using Microsoft.AspNetCore.Mvc;
using CountryRouteApi.Contracts;
using CountryRouteApi.Services;

namespace CountryRouteApi.Controllers
{
    [ApiController]
    [Route("countries")]
    public class CountriesController : ControllerBase
    {
        private readonly RouteService _routeService;
        public CountriesController(RouteService routeService)
        {
            _routeService = routeService;
        }

        // GET /countries/PAN
        [HttpGet("{code}")]
        public IActionResult GetRoute(string code)
        {
            if (code == null)
            {
                return BadRequest(new ErrorResponse("INVALID_CODE", "code is required"));
            }
            code = code.Trim().ToUpperInvariant();

           
            if (code.Length != 3)
            {
                return BadRequest(new ErrorResponse("INVALID_CODE", "code must be a 3-letter country code"));
            }// return 400 && body
            var result = _routeService.GetRouteFromUsa(code);

            if (result == null)
            {
                return NotFound(new ErrorResponse("NOT_FOUND", $"destination '{code}' not found or unreachable"));
            }// return 404 && body

            return Ok(result);  // return 200 && Routeresponse JSON
        }
    }
}