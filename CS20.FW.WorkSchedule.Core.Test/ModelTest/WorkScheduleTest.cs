using System;
using CS20.FW.WorkSchedule.Core.Model;
using Xunit;

namespace CS20.FW.WorkSchedule.Core.Test.ModelTest
{
    public class WorkScheduleTest
    {
        #region Initialize

        [Fact]
        public void WorkingSchedule_CanBeInitialize()
        {
            var workingSchedule = new Model.WorkSchedule();
            Assert.NotNull(workingSchedule);
        }

        [Fact]
        public void WorkingSchedule_ShouldHaveId()
        {
            var workingSchedule = new Model.WorkSchedule()
            {
                Id = 1
            };
            Assert.Equal(1,workingSchedule.Id);

        }
        
        [Fact]
        public void WorkingSchedule_ShouldHaveUserId()
        {
            var workingSchedule = new Model.WorkSchedule()
            {
                UserId = 1
            };
            Assert.Equal(1,workingSchedule.UserId);

        }

        [Fact]
        public void WorkingSchedule_ShouldHaveStartTime()
        {
            var dateTime = new DateTime(2021,12,1,15,0,0);
            var workingSchedule = new Model.WorkSchedule
            {
                StartTime = dateTime
            };
            Assert.Equal(dateTime, workingSchedule.StartTime);
        }
        
        [Fact]
        public void WorkingSchedule_ShouldHaveEndTime()
        {
            var dateTime = new DateTime(2021,12,1,21,0,0);
            var workingSchedule = new Model.WorkSchedule
            {
                EndTime = dateTime
            };
            Assert.Equal(dateTime, workingSchedule.EndTime);
        }
    

        #endregion
    }
}