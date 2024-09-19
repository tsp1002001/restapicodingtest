using RestApiCodingTest.Request;
using RestApiCodingTest.Models;

namespace RestApiCodingTest.Repository;

public interface IActivityRepository
{
    Task<Activity> GetActivity(Guid id);
    Task<Guid> CreateActivity(Activity activity);
    Task BulkUpdateActivityStaff(IEnumerable<Guid> activityIds, Guid staffId);
    Task UpdateActivity(Guid id, Activity activity);
    Task<List<Activity>> GetActivitiesByMatterId(Guid matterId, GetActivitiesByMatterRequest request);
}