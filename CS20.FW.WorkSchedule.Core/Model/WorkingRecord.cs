using System;

namespace CS20.FW.WorkSchedule.Core.Model
{
    public class WorkingRecord
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public TimeSpan WorkingHours { get; set; }
    }
}