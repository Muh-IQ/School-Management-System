using Microsoft.AspNetCore.Mvc;
using Modules.School.Application.IServices;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.DTOs;
using Modules.School.WebAPI.Extensions;

namespace Modules.School.WebAPI.Contracts
{
    [Route("api/v1/city")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class CityController(ICityService _service) : ControllerBase
    {

        [HttpGet("{countryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(Guid countryId)
        {
            var result = await _service.GetAllByIdAsync(countryId);
            return result.ToApiResponse();
        }
    }
}