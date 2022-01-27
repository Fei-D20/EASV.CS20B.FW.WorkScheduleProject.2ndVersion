using System;
using System.Collections.Generic;
using CS20.FW.WorkSchedule.Core.Model;
using CS20.FW.WorkSchedule.Domain.IRepository;
using Moq;
using Xunit;

namespace CS20.FW.WorkSchedule.Domain.Test.IRepositoryTest
{
    public class IWorkRecordRepositoryTest
    {
        private readonly Mock<IWorkRecordRepository> _mockWorkRecordRepository;
        private readonly WorkRecord _workRecord;
        private readonly List<WorkRecord> _workRecords;

        public IWorkRecordRepositoryTest()
        {
            _mockWorkRecordRepository = new Mock<IWorkRecordRepository>();
            _workRecord = new WorkRecord()
            {
                Id = 1,
                UserId = 1,
                CheckInTime = new DateTime(),
                CheckOutTime = new DateTime()
            };
            _workRecords = new List<WorkRecord>();
        }

        [Fact]
        public void IWorkRecordRepository_IsAvailable()
        {
            Assert.NotNull(_mockWorkRecordRepository.Object);
        }

        #region MethodTest

        [Fact]
        public void IWorkRecordRepository_Create_ParaWorkRecord_ReturnWorkRecord()
        {
            _mockWorkRecordRepository.Setup(repository => repository.Create(_workRecord)).Returns(_workRecord);
            var actual = _mockWorkRecordRepository.Object.Create(_workRecord);
            Assert.Equal(_workRecord,actual);
        }
        
        [Fact]
        public void IWorkRecordRepository_ReadAll_ReturnListOfWorkRecord()
        {
            _mockWorkRecordRepository.Setup(repository => repository.ReadAll()).Returns(_workRecords);
            var actual = _mockWorkRecordRepository.Object.ReadAll();
            Assert.Equal(_workRecords,actual);
        }
        
        [Fact]
        public void IWorkRecordRepository_ReadById_ParaId_ReturnWorkRecord()
        {
            _mockWorkRecordRepository.Setup(repository => repository.ReadById(1)).Returns(_workRecord);
            var actual = _mockWorkRecordRepository.Object.ReadById(1);
            Assert.Equal(_workRecord,actual);
        }
        
        [Fact]
        public void IWorkRecordRepository_ReadByUserId_ParaUserId_ReturnListOfWorkRecord()
        {
            _mockWorkRecordRepository.Setup(repository => repository.ReadByUserId(1)).Returns(_workRecords);
            var actual = _mockWorkRecordRepository.Object.ReadByUserId(1);
            Assert.Equal(_workRecords,actual);
        }

        [Fact]
        public void IWorkRecordRepository_ReadByDate_ParaDate_ReturnListOfWorkRecord()
        {
            _mockWorkRecordRepository.Setup(repository => repository.ReadByDate(DateTime.Today)).Returns(_workRecords);
            var actual = _mockWorkRecordRepository.Object.ReadByDate(DateTime.Today);
            Assert.Equal(_workRecords,actual);
        }
        
        [Fact]
        public void IWorkRecordRepository_ReadByWeek_ParaWeekDay_ReturnListOfWorkRecord()
        {
            _mockWorkRecordRepository.Setup(repository => repository.ReadByWeek(DayOfWeek.Friday)).Returns(_workRecords);
            var actual = _mockWorkRecordRepository.Object.ReadByWeek(DayOfWeek.Friday);
            Assert.Equal(_workRecords,actual);
        }

        [Fact]
        public void IWorkRecordRepository_ReadByUserIdAndMonth_PareUserIdAndDateTime_ReturnListOfWorkRecord()
        {
            _mockWorkRecordRepository.Setup(repository => repository.ReadByUserIdAndMonth(1,DateTime.Today)).Returns(_workRecords);
            var actual = _mockWorkRecordRepository.Object.ReadByUserIdAndMonth(1,DateTime.Today);
            Assert.Equal(_workRecords,actual);
        }
        
        #endregion
    }
}