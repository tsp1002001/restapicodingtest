using RestApiCodingTest.Models;

namespace RestApiCodingTest.Database.Setup
{
    public class ActivityDBInitialiser
    {
        public static void Initialise(ActivityDBContext context)
        {
            Console.WriteLine("Database Initialisation Commenced.");
            
            Console.WriteLine("Creating Database ...");
            context.Database.EnsureCreated();
            Console.WriteLine("Database Successfully Created.");

            Console.WriteLine("Seeding Database ...");
            if (context.Activities.Any())
            {
                Console.WriteLine("Database has already been seeded.");
            }
            else
            {
                var activities = new Activity[]
                {
                    new Activity(
                        new Guid("B529F581-8674-4865-9FDB-C87DAD209AA9"),
                            Guid.NewGuid(),
                            Guid.NewGuid(),
                            "Letter to Mr Bobson Dugnutt",
                            ActivityType.Document,
                            DateTime.Parse("2020-06-05T13:34:00.0000000-10:00"),
                            DateTime.Parse("2020-06-05T13:35:00.0000000-10:00")),

                    new Activity(
                        new Guid("454F94AC-7113-4C35-A9C8-705021663745"),
                            Guid.NewGuid(),
                            Guid.NewGuid(),
                            "Regarding Your Pending Divorce Settlement",
                            ActivityType.Email,
                            DateTime.Parse("2020-06-05T13:30:00.0000000-10:00"),
                            DateTime.Parse("2020-06-05T13:32:00.0000000-10:00")),

                    new Activity(
                        new Guid("870D1A0E-9507-4CDA-9F15-8C4F65E77ABB"),
                            Guid.NewGuid(),
                            Guid.NewGuid(),
                            "Phone Call with 04XXXXXXXX",
                            ActivityType.PhoneCall,
                            DateTime.Parse("2020-06-05T13:35:00.0000000-10:00"),
                            DateTime.Parse("2020-06-05T13:49:00.0000000-10:00")),
                };

                foreach (Activity a in activities) 
                    context.Activities.Add(a);
                
                context.SaveChanges();
                Console.WriteLine("Database successfully seeded.");
            }
            Console.WriteLine("Database Initialisation Complete.");
        }
    }
}
