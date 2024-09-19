using Microsoft.EntityFrameworkCore;
using RestApiCodingTest.Models;

namespace RestApiCodingTest.Database.Setup
{
    public class ActivityDBContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }

        public ActivityDBContext(DbContextOptions<ActivityDBContext> options) : base(options)
        {
            ActivityDBInitialiser.Initialise(this);
        }

    }
}
