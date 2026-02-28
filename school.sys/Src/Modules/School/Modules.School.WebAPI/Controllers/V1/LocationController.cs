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
    public class LocationController(ICountryService _countryService,ICityService _cityService
        ,IAreaService _areaService) : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCountryAsync()
        {
            var result = await _countryService.GetAsync();
            return result.ToApiResponse();
        }
        [HttpGet("{countryId}/city")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCityWithIdAsync(Guid countryId)
        {
            var result = await _cityService.GetAllByIdAsync(countryId);
            return result.ToApiResponse();
        }

        [HttpGet("{countryId}/city/{cityId}/area")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAreaWithIdAsync(Guid countryId, Guid cityId)
        {
            var result = await _areaService.GetAllByIdAsync(countryId,cityId);
            return result.ToApiResponse();
        }
    }
}
