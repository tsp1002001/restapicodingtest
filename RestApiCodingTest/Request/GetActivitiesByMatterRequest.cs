using RestApiCodingTest.Models;

namespace RestApiCodingTest.Request
{
    public class GetActivitiesByMatterRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public ActivityType? Type { get; set; }
        public DateTimeOffset? DateStarted { get; set; }
        public DateTimeOffset? DateFinished { get; set; }
        public string Description { get; set; }
    }
}
