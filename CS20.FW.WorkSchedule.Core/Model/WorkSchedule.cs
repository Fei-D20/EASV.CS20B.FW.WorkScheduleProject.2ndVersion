using System;

namespace CS20.FW.WorkSchedule.Core.Model
{
    /// <summary>
    /// The WorkSchedule model expression as the schedule who are employee should following to work.
    /// Id: Which are serial number can be recognized each of schedule.
    /// Employee ID: To recognize the each of employee.
    /// Start Time: To set up when the work start.
    /// End Time: To set up finish time.
    /// WeekDay: To simplified to recognize each of week the work.
    /// </summary>
    public class WorkSchedule   
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DayOfWeek WeekDay { get; set; }
    }
}