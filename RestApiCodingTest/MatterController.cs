using Microsoft.AspNetCore.Mvc;
using RestApiCodingTest.Models;
using RestApiCodingTest.Repository;
using RestApiCodingTest.Request;
using Swashbuckle.AspNetCore.Annotations;

namespace RestApiCodingTest
{
    public class MatterController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;

        public MatterController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        [HttpGet("api/matter/{id}/activities")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<Activity>))]
        [SwaggerResponse(404, Description = "if activity not found.")]
        public async Task<IActionResult> GetActivitiesAsync(Guid id, [FromQuery] GetActivitiesByMatterRequest request)
        {
            var activities = await _activityRepository.GetActivitiesByMatterId(id, request);
            return Ok(activities);
        }
    }
}
