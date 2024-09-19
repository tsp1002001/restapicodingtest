using RestApiCodingTest.Models;
using RestApiCodingTest.Request;
using System.Linq.Expressions;

namespace RestApiCodingTest.Expression
{
    public static class Expressions
    {
        public static Expression<Func<Activity, bool>> RetrieveActivitiesByMatter(Guid matterId, GetActivitiesByMatterRequest request)
        {
            if (request.Type.HasValue && request.DateFinished.HasValue && !string.IsNullOrEmpty(request.Description))
            {
                return activity => activity.MatterId == matterId && activity.Type == request.Type.Value && activity.DateTimeStarted.Date > request.DateStarted.Value && activity.DateTimeFinished.Date < request.DateFinished.Value && activity.Name.Contains(request.Description);
            }
            else if(request.Type.HasValue && request.DateFinished.HasValue)
            {
                return activity => activity.MatterId == matterId && activity.Type == request.Type.Value && activity.DateTimeStarted.Date >= request.DateStarted && activity.DateTimeFinished.Date <= request.DateFinished.Value;
            } else if(request.Type.HasValue && !string.IsNullOrEmpty(request.Description))
            {
                return activity => activity.MatterId == matterId && activity.Type == request.Type.Value && activity.Name.Contains(request.Description);
            } else if(request.DateFinished.HasValue && !string.IsNullOrEmpty(request.Description))
            {
                return activity => activity.MatterId == matterId && activity.DateTimeStarted.Date >= request.DateStarted && activity.DateTimeFinished.Date <= request.DateFinished.Value && activity.Name.Contains(request.Description);
            } else if(request.Type.HasValue)
            {
                return activity => activity.MatterId == matterId && activity.Type == request.Type.Value;
            } else if(request.DateFinished.HasValue)
            {
                return activity => activity.MatterId == matterId && activity.DateTimeStarted.Date >= request.DateStarted && activity.DateTimeFinished.Date <= request.DateFinished.Value;
            } else if(!string.IsNullOrEmpty(request.Description))
            {
                return activity => activity.MatterId == matterId && activity.Name.Contains(request.Description);
            } else
            {
                return activity => activity.MatterId == matterId;
            }
        }
    }
}
