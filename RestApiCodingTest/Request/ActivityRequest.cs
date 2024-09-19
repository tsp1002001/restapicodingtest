using RestApiCodingTest.Models;

namespace RestApiCodingTest.Request
{
    public class ActivityRequest
    {
        public Guid MatterId { get; set; }

        public Guid StaffId { get; set; }

        public string Name { get; set; }

        public ActivityType Type { get; set; }

        public DateTimeOffset DateTimeStarted { get; set; }

        public DateTimeOffset DateTimeFinished { get; set; }
    }
}
