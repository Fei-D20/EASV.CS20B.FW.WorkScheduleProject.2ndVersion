using System;

namespace CS20.FW.WorkSchedule.Core.Model
{
    public class WorkingSchedule
    {
        public int Id { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}