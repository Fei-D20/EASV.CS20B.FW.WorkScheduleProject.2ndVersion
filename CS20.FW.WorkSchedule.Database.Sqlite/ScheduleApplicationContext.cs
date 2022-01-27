using CS20.FW.WorkSchedule.Database.Repository;
using Microsoft.EntityFrameworkCore;

namespace CS20.FW.WorkSchedule.Database
{
    public class ScheduleApplicationContext:DbContext
    {
        public ScheduleApplicationContext(DbContextOptions<ScheduleApplicationContext> options) : base(options)
        {
        }

        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<WorkRecordEntity> WorkRecords { get; set; }
        public virtual DbSet<WorkScheduleEntity> WorkSchedules { get; set; }

    }
}