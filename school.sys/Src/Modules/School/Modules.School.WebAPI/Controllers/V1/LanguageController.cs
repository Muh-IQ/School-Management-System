using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Modules.School.Application.IServices;
using Modules.School.WebAPI.Extensions;

namespace Modules.School.WebAPI.Controllers.V1
{
    [Route("api/v1/language")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class LanguageController(ILanguageService languageService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await languageService.GetAllAsync();
            if (result.IsSuccess)
            {
                Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue
                {
                    Public = true,
                    MaxAge = TimeSpan.FromDays(365)
                };
                Response.Headers.CacheControl += ", immutable";
            }
            return result.ToApiResponse();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await languageService.GetByIdAsync(id);
            return result.ToApiResponse();
        }
    }
}
