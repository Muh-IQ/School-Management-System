using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.School.Domain.DTOs;
using Modules.School.Application.IServices;
using Modules.School.WebAPI.Extensions;

namespace Modules.School.WebAPI.Controllers.V1
{
    [Route("api/v1/school")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]

    public class SchoolController(ISchoolService Service) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateSchool(SchoolAddDTO newSchool)
        {
            var result = await Service.CreateAsync(newSchool);
            return result.ToApiResponse(successStatusCode: 201);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSchoolById(Guid id)
        {
            var result = await Service.GetByIdAsDtoAsync(id);
            return result.ToApiResponse();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteSchool(Guid id)
        {
            var result = await Service.DeleteAsync(id);
            return result.ToApiResponse(successStatusCode: 204);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateSchool(Guid id, SchoolUpdateDTO updatedSchool)
        {
            var result = await Service.UpdateAsync(id, updatedSchool);
            return result.ToApiResponse(successStatusCode: 204);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListSchools()
        {
            var result = await Service.GetAllAsDtoAsync(1, 10);
            return result.ToApiResponse();
        }
    }

}
