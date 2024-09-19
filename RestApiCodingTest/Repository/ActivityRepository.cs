using Microsoft.EntityFrameworkCore;
using RestApiCodingTest.Database.Setup;
using RestApiCodingTest.Request;
using RestApiCodingTest.Models;
using RestApiCodingTest.Expression;

namespace RestApiCodingTest.Repository;

public class ActivityRepository : IActivityRepository
{
    private readonly ActivityDBContext _dbContext;

    public ActivityRepository(ActivityDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Activity> GetActivity(Guid id)
    {
        return await _dbContext.Activities.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Guid> CreateActivity(Activity activity)
    {
        _dbContext.Activities.Add(activity);
        await _dbContext.SaveChangesAsync();
        return activity.Id;
    }

    public async Task UpdateActivity(Guid id, Activity activity)
    {
        _dbContext.Activities.Update(activity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Activity>> GetActivitiesByMatterId(Guid matterId, GetActivitiesByMatterRequest request)
    {
        var rangeStart = (request.Page - 1) * request.PageSize;
        var rangeEnd = request.Page * request.PageSize;
        return await _dbContext.Activities.Where(Expressions.RetrieveActivitiesByMatter(matterId, request)).Take(rangeEnd).Skip(rangeStart).ToListAsync();
    }

    //--------------------------------------------------------------
    //DO NOT MODIFY THE BELOW FUNCTIONS UNTIL YOU ATTEMPT PART (iv)
    //--------------------------------------------------------------
    public async Task BulkUpdateActivityStaff(IEnumerable<Guid> activityIds, Guid staffId)
    {
        var activitiesToUpdate = BulkGetActivities(activityIds);

        //Filter activities to ensure we only write to activities which actually need to be updated
        activitiesToUpdate = activitiesToUpdate.Where(a => a.StaffId != staffId);

        foreach (var activity in activitiesToUpdate)
        {
            activity.StaffId = staffId;
        }

        //Attach modified activities to context 
        _dbContext.Activities.UpdateRange(activitiesToUpdate);

        await _dbContext.SaveChangesAsync();
    }

    private IEnumerable<Activity> BulkGetActivities(IEnumerable<Guid> activityIds)
    {
        var activityIdLookup = activityIds.ToHashSet();

        var query = _dbContext.Set<Activity>();
        var activities = query.AsNoTracking().Where(a => activityIdLookup.Contains(a.Id));

        return activities;
    }


}
