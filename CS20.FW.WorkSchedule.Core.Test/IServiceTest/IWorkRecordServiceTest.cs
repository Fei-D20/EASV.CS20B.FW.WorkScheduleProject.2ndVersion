using System;
using System.Collections.Generic;
using CS20.FW.WorkSchedule.Core.IService;
using CS20.FW.WorkSchedule.Core.Model;
using Moq;
using Xunit;

namespace CS20.FW.WorkSchedule.Core.Test.IServiceTest
{
    public class IWorkRecordServiceTest
    {
        /// <summary>
        /// This is the test of interface of Record Service
        /// it is working for let the employee can check-in check-out, searching the record, calculate the working hours
        /// and the Administrator can modify the record. 
        /// </summary>
        private readonly Mock<IWorkRecordService> _iWorkRecordMock;

        private readonly WorkRecord _workRecord;

        public IWorkRecordServiceTest()
        {
            _iWorkRecordMock = new Mock<IWorkRecordService>();
            _workRecord = new WorkRecord();
        }

        [Fact]
        public void IWorkRecordTest_IsAvailable()
        {
            var workRecordService = _iWorkRecordMock.Object;
            Assert.NotNull(workRecordService);
        }

        #region Method

        /// <summary>
        /// This method is working for check-in interface method should be call
        /// the parameter is working record with employeeId and check-in time
        /// the repository will add an Id for it and return a working record with id, employee id, check-in time.
        /// rest check-out time and working hours will be null.
        /// </summary>
        [Fact]
        public void IWorkRecordTest_CheckIn_ParaRecordContainEmployeeIDCheckIn_ReturnRecord()
        {
            var workRecord = new WorkRecord();
            _iWorkRecordMock
                .Setup(service => service.CheckIn(workRecord))
                .Returns(workRecord);
            var checkIn = _iWorkRecordMock.Object.CheckIn(workRecord);
            Assert.Equal(checkIn,workRecord);
        }

        /// <summary>
        /// This is testing check out interface method should be call
        /// the parameter is work record with id, employee id, check-in time.
        /// method will invoke search method from repository by id and get the record
        /// and then insert the check-out time and auto calculate the work hours
        /// </summary>
        [Fact]
        public void IWorkRecordTest_CheckOut_ParaRecordContainIdCheckOut_ReturnRecord()
        {
            var workRecord = new WorkRecord();
            _iWorkRecordMock
                .Setup(service => service.CheckOut(workRecord))
                .Returns(workRecord);
            var checkOut = _iWorkRecordMock.Object.CheckOut(workRecord);
            Assert.Equal(checkOut,workRecord);

        }
        
        
        /// <summary>
        /// this method is working for modify the record if there is some situation like mistake.
        /// so only administrator have the right to modify it.
        /// the parameter is the new record with the id which record should be change.
        /// return new record.
        /// </summary>
        [Fact]
        public void IWorkRecordTest_ModifyRecord_ParaRecord_ReturnRecord()
        {
            var workRecord = new WorkRecord();
            _iWorkRecordMock
                .Setup(service => service.Modify(workRecord))
                .Returns(workRecord);
            var modify = _iWorkRecordMock.Object.Modify(workRecord);
            Assert.Equal(modify,workRecord);

        }
        
        /// <summary>
        /// This is the delete the record, only administrator can do it.
        /// parameter is which record will be delete.
        /// return the record be delete
        /// </summary>
        [Fact]
        public void IWorkRecordTest_DeleteRecord_ParaRecord_ReturnRecord()
        {
            var workRecord = new WorkRecord();
            _iWorkRecordMock
                .Setup(service => service.Delete(workRecord))
                .Returns(workRecord);
            var delete = _iWorkRecordMock.Object.Delete(workRecord);
            Assert.Equal(delete,workRecord);

        }
        
        /// <summary>
        /// This is test the working record of get all
        /// return all the record by a list.
        /// </summary>
        [Fact]
        public void IWorkRecordTest_GetAll_ReturnListOfRecord()
        {
            var workRecords = new List<WorkRecord>();
            _iWorkRecordMock
                .Setup(service => service.GetAll())
                .Returns(workRecords);
            var all = _iWorkRecordMock.Object.GetAll();
            Assert.Equal(all,workRecords);

        }
        
        /// <summary>
        /// This is test get by id
        /// parameter is the record id which we want to search
        /// return the record
        /// </summary>
        [Fact]
        public void IWorkRecordTest_GetById_ParaId_ReturnRecord()
        {
            var workRecord = new WorkRecord()
            {
                Id = 1
            };
            _iWorkRecordMock
                .Setup(service => service.GetById(workRecord))
                .Returns(workRecord);
            var byId = _iWorkRecordMock.Object.GetById(workRecord);
            Assert.Equal(byId,workRecord);

        }
        
        /// <summary>
        /// This is test get by employee id
        /// parameter is the id which employee we want to search
        /// return is the list of all record by the employee
        /// </summary>
        [Fact]
        public void IWorkRecordTest_GetByEmployeeId_ParaRecord_ReturnListOfRecord()
        {
            var workRecord = new WorkRecord()
            {
                EmployeeId = 1
            };
            var expect = new List<WorkRecord>();
            _iWorkRecordMock
                .Setup(service => service.GetByEmployeeId(workRecord.EmployeeId))
                .Returns(expect);
            var actual = _iWorkRecordMock.Object.GetByEmployeeId(workRecord.EmployeeId);
            Assert.Equal(actual,expect);

        }
        
        /// <summary>
        /// This is test to get record by date
        /// parameter is the date which day we want to search
        /// return the all employee record on the date.
        /// </summary>
        [Fact]
        public void IWorkRecordTest_GetByDate_ParaDate_ReturnListOfRecord()
        {
            var dateTime = new DateTime(2021,12,1);
            var workRecord = new WorkRecord()
            {
                CheckInTime = dateTime
            };
            var workingRecords = new List<WorkRecord>();
            _iWorkRecordMock
                .Setup(service => service.GetByDate(workRecord.CheckInTime))
                .Returns(workingRecords);
            var byDate = _iWorkRecordMock.Object.GetByDate(workRecord.CheckInTime);
            Assert.Equal(byDate,workingRecords);

        }
        #endregion
    }
}