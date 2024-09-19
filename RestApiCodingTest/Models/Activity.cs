namespace RestApiCodingTest.Models;

public class Activity
{
    public Activity(Guid id, Guid matterId, Guid staffId, string name, ActivityType type, DateTimeOffset dateTimeStarted, DateTimeOffset dateTimeFinished)
    {
        Id = id;
        MatterId = matterId;
        StaffId = staffId;
        Name = name;
        Type = type;
        DateTimeStarted = dateTimeStarted;
        DateTimeFinished = dateTimeFinished;
    }

    public Activity() { }

    public Guid Id { get; set; }

    public Guid MatterId { get; set; }

    public Guid StaffId { get; set; }

    public string Name { get; set; }

    public ActivityType Type { get; set; }

    public DateTimeOffset DateTimeStarted { get; set; }

    public DateTimeOffset DateTimeFinished { get; set; }
}