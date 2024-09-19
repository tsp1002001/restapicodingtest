using Microsoft.AspNetCore.Mvc;
using RestApiCodingTest.Contracts;
using RestApiCodingTest.Request;
using RestApiCodingTest.Models;
using RestApiCodingTest.Repository;
using RestApiCodingTest.RequestBuilder;
using RestApiCodingTest.Validators;
using Swashbuckle.AspNetCore.Annotations;

namespace RestApiCodingTest;

[ApiController]
public class ActivityController : ControllerBase
{
    private readonly IActivityRepository _activityRepository;
    private readonly IActivityValidator _activityValidator;
    private readonly IActivityBuilder _activityBuilder;

    public ActivityController(IActivityRepository activityRepository, IActivityValidator activityValidator, IActivityBuilder activityBuilder)
    {
        _activityRepository = activityRepository;
        _activityValidator = activityValidator;
        _activityBuilder = activityBuilder;
    }

    [HttpGet]
    [Produces("application/json")]
    [SwaggerResponse(200, Type = typeof(Activity))]
    [SwaggerResponse(404, Description = "if activity not found.")]
    [Route("api/v1/activities/{id}")]
    public async Task<IActionResult> GetActivityAsync(Guid id)
    {
        try
        {
            var activity = await _activityRepository.GetActivity(id);

            return Ok(activity);
        }
        catch
        {
            return NotFound("Activity not found.");
        }
    }

    [HttpPost]
    [Produces("application/json")]
    [SwaggerResponse(200, Type = typeof(Activity))]
    [Route("api/v1/activities/bulk-update-staff")]
    public async Task<IActionResult> BulkUpdateActivityStaffAsync(
        [FromBody] BulkUpdateActivityStaffRequest request)
    {
       await _activityRepository.BulkUpdateActivityStaff(request.ActivityIds, request.StaffId);

       return Ok();
    }

    [HttpPost]
    [Produces("application/json")]
    [SwaggerResponse(200, Type = typeof(Guid))]
    [SwaggerResponse(400, Description = "if request is invalid.")]
    [Route("api/v1/activities")]
    public async Task<IActionResult> CreateActivityAsync([FromBody] ActivityRequest request)
    {
        var validateResult = _activityValidator.Validate(request);

        if (!string.IsNullOrEmpty(validateResult))
        {
            return BadRequest(validateResult);
        }

        var activity = _activityBuilder.Build(request);
        var id = await _activityRepository.CreateActivity(activity);

        return Ok(id);
    }

    [HttpPut]
    [Produces("application/json")]
    [Route("api/v1/activities/{id}")]
    public async Task<IActionResult> UpdateActivityAsync(Guid id, [FromBody] UpdateActivityRequest request)
    {
        var activity = await _activityRepository.GetActivity(id);
        if (activity == null)
        {
            return BadRequest("Invalid request");
        }
        var validateResult = _activityValidator.Validate(activity, request);
        if (!string.IsNullOrEmpty(validateResult))
        {
            return BadRequest(validateResult);
        }
        var updatedActivity = _activityBuilder.Build(activity, request);
        await _activityRepository.UpdateActivity(id, updatedActivity);

        return Ok(updatedActivity);
    }
        
}