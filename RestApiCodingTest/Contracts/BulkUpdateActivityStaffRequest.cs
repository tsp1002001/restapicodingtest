namespace RestApiCodingTest.Contracts
{
    public class BulkUpdateActivityStaffRequest
    {
        public IEnumerable<Guid> ActivityIds { get; set; }

        public Guid StaffId { get; set; }
    }
}
