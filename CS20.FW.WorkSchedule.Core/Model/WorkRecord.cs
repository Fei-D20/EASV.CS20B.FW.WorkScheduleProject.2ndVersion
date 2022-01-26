using System;

namespace CS20.FW.WorkSchedule.Core.Model
{
    /// <summary>
    /// The Work Record model represent the work record for each of the employee who already work
    /// and had the record for work.
    /// </summary>
    public class WorkRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public TimeSpan WorkingHours { get; set; }
    }
}