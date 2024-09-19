namespace RestApiCodingTest.Request
{
    public class UpdateActivityRequest
    {
        
        public string Name { get; set; }

        public DateTimeOffset? DateTimeStarted { get; set; }

        public DateTimeOffset? DateTimeFinished { get; set; }
    }
}
