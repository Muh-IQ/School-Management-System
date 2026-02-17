using Microsoft.AspNetCore.Http;
using Modules.School.WebAPI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Modules.School.Application.IServices;

namespace Modules.School.WebAPI.Controllers.V1
{
    [Route("api/v1/country")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class CountryController(ICountryService service) : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            var result = await service.GetAsync();
            return result.ToApiResponse();
        }
    }
}
