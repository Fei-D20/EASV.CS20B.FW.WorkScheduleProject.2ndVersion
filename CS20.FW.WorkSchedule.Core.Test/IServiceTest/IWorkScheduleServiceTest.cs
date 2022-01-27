using System;
using System.Collections.Generic;
using CS20.FW.WorkSchedule.Core.IService;
using Moq;
using Xunit;

namespace CS20.FW.WorkSchedule.Core.Test.IServiceTest
{
    public class IWorkScheduleServiceTest
    {
        /// <summary>
        /// make a Mock interface to test the method should be call
        /// </summary>
        private readonly Mock<IWorkScheduleService> _workScheduleService;

        private readonly Model.WorkSchedule _workSchedule;

        public IWorkScheduleServiceTest()
        {
            _workScheduleService = new Mock<IWorkScheduleService>();

            // create a workingSchedule
            _workSchedule = new Model.WorkSchedule();

        }


        /// <summary>
        /// Test the object of Interface is available to be initialized
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_IsAvailable()
        {
            var mock = new Mock<IWorkScheduleService>();
            Assert.NotNull(mock.Object);
        }

        #region MethodTest

        /// <summary>
        /// Test the create method pass in the work schedule where come from front end
        /// and return a work schedule object from repository
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_Create_ParaWorkSchedule_ReturnWorkSchedule()
        {
            // Arrange
            // get the new work schedule form constructor

            // setup mock method pass in the schedule and return the schedule
            _workScheduleService
                .Setup(service => service.Create(_workSchedule))
                .Returns(_workSchedule);

            // Act
            // Actually call the method
            var schedule = _workScheduleService.Object.Create(_workSchedule);

            // Assert
            // Test the method
            Assert.Equal(_workSchedule, schedule);
        }

        /// <summary>
        /// Test the modify method for change the record for working schedule.
        /// parameter should be new Object working schedule record from front end
        /// Return the new object from repository
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_Modify_ParaWorkSchedule_ReturnWorkSchedule()
        {
            // Arrange 

            _workScheduleService
                .Setup(service => service.Modify(_workSchedule))
                .Returns(_workSchedule);

            // Act
            var newSchedule = _workScheduleService.Object.Modify(_workSchedule);

            // Assert
            Assert.Equal(_workSchedule, newSchedule);
        }


        /// <summary>
        /// Test the delete method should be call
        /// pass in the working schedule should be remove
        /// return the removed working schedule
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_Delete_ParaWorkSchedule_ReturnWorkSchedule()
        {
            _workScheduleService
                .Setup(service => service.Delete(_workSchedule))
                .Returns(_workSchedule);

            var schedule = _workScheduleService.Object.Delete(_workSchedule);

            Assert.Equal(_workSchedule, schedule);
        }

        /// <summary>
        /// this is test for GetAll method return list 
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_GetAllWorkSchedule_ReturnListOfWorkSchedule()
        {
            var workSchedules = new List<Model.WorkSchedule>();
            _workScheduleService
                .Setup(service => service.GetAll())
                .Returns(workSchedules);

            var schedules = _workScheduleService.Object.GetAll();    
            
            Assert.Equal(schedules,workSchedules);
        }
        
        
        /// <summary>
        /// this test the use  id can get the work schedule
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_GetWorkingScheduleById_ReturnListOfWorkSchedule()
        {
            var workSchedules = new List<Model.WorkSchedule>();
            _workScheduleService
                .Setup(service => service.GetScheduleById(1))
                .Returns(workSchedules);
            var scheduleById = _workScheduleService.Object.GetScheduleById(1);
            Assert.Equal(scheduleById,workSchedules);
        }
        
        /// <summary>
        /// this test the use one user id can get all the working schedule by one user
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_GetWorkingScheduleByUserID_ReturnListOfWorkingSchedule()
        {
            var workSchedules = new List<Model.WorkSchedule>();
            _workScheduleService
                .Setup(service => service.GetScheduleByUserId(1))
                .Returns(workSchedules);
            var scheduleByUserId = _workScheduleService.Object.GetScheduleByUserId(1);
            Assert.Equal(scheduleByUserId,workSchedules);
        }
        
        /// <summary>
        /// Test get the working schedule by date,
        /// parameter is the date.
        /// return list of schedule on all the employee who working at that date
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_GetWorkScheduleByDate_ReturnListOfWorkSchedule()
        {
            var workingSchedules = new List<Model.WorkSchedule>();
            var date = new DateTime(2021,12,1);
            _workScheduleService
                .Setup(service => service.GetScheduleByDate(date))
                .Returns(workingSchedules);
            var scheduleByDate = _workScheduleService.Object.GetScheduleByDate(date);
            Assert.Equal(scheduleByDate,workingSchedules);
        }

        
        [Fact]
        public void IWorkingScheduleService_GetWorkScheduleByWeek_ReturnListOfWorkSchedule()
        {
            var workingSchedules = new List<Model.WorkSchedule>();
            _workScheduleService
                .Setup(service => service.GetScheduleByWeek(DayOfWeek.Monday))
                .Returns(workingSchedules);
            var scheduleByWeek = _workScheduleService.Object.GetScheduleByWeek(DayOfWeek.Monday);
            Assert.Equal(scheduleByWeek,workingSchedules);
        }
        
        /// <summary>
        /// Test the service search working schedule by user id and month,
        /// return all the month work schedule by one user
        /// </summary>
        [Fact]
        public void IWorkingScheduleService_GetWorkScheduleByUserIdAndMonth_ReturnListOfWorkingSchedule()
        {
            var workingSchedules = new List<Model.WorkSchedule>();
            _workScheduleService
                .Setup(service => service.GetScheduleByUserIdAndMonth(1,DateTime.Today))
                .Returns(workingSchedules);
            var scheduleByUserIdAndMonth = _workScheduleService.Object.GetScheduleByUserIdAndMonth(1,DateTime.Today);
            Assert.Equal(scheduleByUserIdAndMonth,workingSchedules);
        }
        
        #endregion
    }
}