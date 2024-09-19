using RestApiCodingTest.Request;
using RestApiCodingTest.Models;

namespace RestApiCodingTest.RequestBuilder
{
    public interface IActivityBuilder
    {
        Activity Build(ActivityRequest request);
        Activity Build(Activity existingAcitivity, UpdateActivityRequest request);
    }

    public class ActivityBuilder : IActivityBuilder
    {
        public Activity Build(ActivityRequest request)
        {
            return new Activity
            {
                Id = Guid.NewGuid(),
                MatterId = request.MatterId,
                StaffId = request.StaffId,
                Name = request.Name,
                Type = request.Type,
                DateTimeStarted = request.DateTimeStarted,
                DateTimeFinished = request.DateTimeFinished
            };
        }

        public Activity Build(Activity existingAcitivity, UpdateActivityRequest request)
        {
            existingAcitivity.Name = !string.IsNullOrEmpty(request.Name) ? request.Name : existingAcitivity.Name;
            existingAcitivity.DateTimeFinished = request.DateTimeFinished.HasValue ? request.DateTimeFinished.Value : existingAcitivity.DateTimeFinished;
            existingAcitivity.DateTimeStarted = request.DateTimeStarted.HasValue ? request.DateTimeStarted.Value : existingAcitivity.DateTimeStarted;
            return existingAcitivity;
        }
    }

}
