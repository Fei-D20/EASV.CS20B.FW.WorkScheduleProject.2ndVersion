using System;
using CS20.FW.WorkSchedule.Core.Model;
using Xunit;

namespace CS20.FW.WorkSchedule.Core.Test.ModelTest
{
    public class WorkRecordTest
    {
        /// <summary>
        /// This class is testing about the WorkingRecord of employee check in and check out.
        /// include the Id of record, employee Id, check in date time. check out date time and working hours per day.
        /// 
        /// </summary>
        public class WorkingRecordTest
        {
            #region Initial

            [Fact]
            public void WorkingRecord_CanBeInitial()
            {
                var workingRecord = new WorkRecord();
                Assert.NotNull(workingRecord);
            }

            [Fact]
            public void WorkingRecord_HaveId()
            {
                var workingRecord = new WorkRecord()
                {
                    Id = 1
                };
                Assert.Equal(1, workingRecord.Id);
            }

            [Fact]
            public void WorkingRecord_HaveUserId()
            {
                var workingRecord = new WorkRecord()
                {
                    UserId = 1
                };
                Assert.Equal(1, workingRecord.UserId);
            }

            [Fact]
            public void WorkingRecord_HaveCheckInTime()
            {
                var dateTime = DateTime.Now;
                var workingRecord = new WorkRecord()
                {
                    CheckInTime = dateTime
                };
                Assert.Equal(dateTime, workingRecord.CheckInTime);
            }

            [Fact]
            public void WorkingRecord_HaveCheckOutTime()
            {
                var dateTime = DateTime.Now;
                var workingRecord = new WorkRecord()
                {
                    CheckOutTime = dateTime
                };
                Assert.Equal(dateTime, workingRecord.CheckOutTime);
            }

            [Fact]
            public void WorkingRecord_HaveWorkingHours()
            {
                var timeSpan = new TimeSpan(5, 0, 0);
                var workingRecord = new WorkRecord()
                {
                    WorkingHours = timeSpan
                };
                Assert.Equal(timeSpan, workingRecord.WorkingHours);
            }

            #endregion
        }
    }
}