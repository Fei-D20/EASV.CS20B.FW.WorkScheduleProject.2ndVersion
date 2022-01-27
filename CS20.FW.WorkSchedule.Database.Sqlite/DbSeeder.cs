using CS20.FW.WorkSchedule.Core.Model;
using CS20.FW.WorkSchedule.Database.Entity;

namespace CS20.FW.WorkSchedule.Database
{
    public class DbSeeder
    {
        private ScheduleApplicationContext _scheduleApplicationContext;

        public DbSeeder(ScheduleApplicationContext scheduleApplicationContext)
        {
            _scheduleApplicationContext = scheduleApplicationContext;
        }

        public void SeedDevelopment()
        {
            // 3. In here the development model, we can ensure deleted the database to clean
            // and ensure created to create new database
            _scheduleApplicationContext.Database.EnsureDeleted();
            _scheduleApplicationContext.Database.EnsureCreated();
            _scheduleApplicationContext.Users.Add(new UserEntity() { Name = "name1", Role = Role.Admin });
            _scheduleApplicationContext.Users.Add(new UserEntity() { Name = "name1", Role = Role.Employee });
            _scheduleApplicationContext.Users.Add(new UserEntity() { Name = "name1", Role = Role.Employee });
            _scheduleApplicationContext.SaveChanges();
        }
    }
}