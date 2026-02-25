using Microsoft.AspNetCore.Mvc;
using Modules.School.Application.IServices;
using Modules.School.Domain.Entities;
using Modules.School.WebAPI.Extensions;

namespace Modules.School.WebAPI.Controllers.V1
{
    [Route("api/v1/policy")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class PolicyController(IPolicyService Service) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreatePolicy(Policy newPolicy)
        {
            var result = await Service.CreateAsync(newPolicy);
            return result.ToApiResponse(successStatusCode: 201);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPolicyById(Guid id)
        {
            var result = await Service.GetByIdAsync(id);
            return result.ToApiResponse();
        }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdatePolicy(Guid id, Policy updatedPolicy)
        {
            updatedPolicy.Id = id;
            var result = await Service.UpdateAsync(updatedPolicy);
            return result.ToApiResponse(successStatusCode: 204);
        }

        
    }
}
