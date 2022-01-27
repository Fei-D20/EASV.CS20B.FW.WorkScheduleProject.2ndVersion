using System;
using System.Collections.Generic;
using CS20.FW.WorkSchedule.Core.Model;
using Moq;
using Xunit;

namespace CS20.FW.WorkSchedule.Domain.Test.IRepositoryTest
{
    public class IWorkScheduleRepositoryTest
    {
        private Mock<IWorkScheduleRepository> _mockWorkScheduleRepository;
        private Core.Model.WorkSchedule _workSchedule;
        private List<Core.Model.WorkSchedule> _workSchedules;

        public IWorkScheduleRepositoryTest()
        {
            _mockWorkScheduleRepository = new Mock<IWorkScheduleRepository>();
            _workSchedule = new Core.Model.WorkSchedule();
            _workSchedules = new List<Core.Model.WorkSchedule>();
        }

        [Fact]
        public void IWorkScheduleRepository_IsAvailable()
        {
            Assert.NotNull(_mockWorkScheduleRepository.Object);
        }

        #region MethodTest

        [Fact]
        public void IWorkScheduleRepository_Create_ParaWorkSchedule_ReturnWorkSchedule()
        {
            _mockWorkScheduleRepository
                .Setup(repository => repository.Create(_workSchedule))
                .Returns(_workSchedule);

            var actual = _mockWorkScheduleRepository.Object.Create(_workSchedule);
            Assert.Equal(_workSchedule,actual);
        }

        [Fact]
        public void IWorkScheduleRepository_ReadAll_ReturnListOfWorkSchedule()
        {
            _mockWorkScheduleRepository
                .Setup(repository => repository.ReadAll())
                .Returns(_workSchedules);
            var actual = _mockWorkScheduleRepository.Object.ReadAll();
            Assert.Equal(_workSchedules,actual);
        }

        [Fact]
        public void IWorkScheduleRepository_ReadById_ParaId_ReturnWorkSchedule()
        {
            _mockWorkScheduleRepository
                .Setup(repository => repository.ReadById(1))
                .Returns(_workSchedule);
            var actual = _mockWorkScheduleRepository.Object.ReadById(1);
            Assert.Equal(_workSchedule,actual);
        }

        [Fact]
        public void IWorkScheduleRepository_ReadByUserId_ParaUserId_ReturnListOfWorkSchedule()
        {
            _mockWorkScheduleRepository
                .Setup(repository => repository.ReadByUserId(1))
                .Returns(_workSchedules);
            var actual = _mockWorkScheduleRepository.Object.ReadByUserId(1);
            Assert.Equal(_workSchedules,actual);
        }

        [Fact]
        public void IWorkScheduleRepository_ReadByWeek_ParaDateTime_ReturnListOfWorkSchedule()
        {
            _mockWorkScheduleRepository
                .Setup(repository => repository.ReadByWeek(DateTime.Today))
                .Returns(_workSchedules);
            var actual = _mockWorkScheduleRepository.Object.ReadByWeek(DateTime.Today);
            Assert.Equal(_workSchedules,actual);
        }

        [Fact]
        public void IWorkScheduleRepository_ReadByUserIdAndMonth_ParaUserIdAndMonth_ReturnListOfWorkSchedule()
        {
            _mockWorkScheduleRepository
                .Setup(repository => repository.ReadByUserIdAndMonth(1, DateTime.Today))
                .Returns(_workSchedules);
            var actual = _mockWorkScheduleRepository.Object.ReadByUserIdAndMonth(1,DateTime.Today);
            Assert.Equal(_workSchedules,actual);
        }

        [Fact]
        public void IWorkScheduleRepository_Update_ParaWorkSchedule_ReturnWorkSchedule()
        {
            _mockWorkScheduleRepository
                .Setup(repository => repository.Update(_workSchedule))
                .Returns(_workSchedule);
            var actual = _mockWorkScheduleRepository.Object.Update(_workSchedule);
            Assert.Equal(_workSchedule,actual);
        }
        #endregion
    }

    public interface IWorkScheduleRepository
    {
        Core.Model.WorkSchedule Create(Core.Model.WorkSchedule workSchedule);
        List<Core.Model.WorkSchedule> ReadAll();
        Core.Model.WorkSchedule ReadById(int id);
        List<Core.Model.WorkSchedule> ReadByUserId(int id);
        List<Core.Model.WorkSchedule> ReadByWeek(DateTime dateTime);
        List<Core.Model.WorkSchedule> ReadByUserIdAndMonth(int id, DateTime dateTime);
        Core.Model.WorkSchedule Update(Core.Model.WorkSchedule workSchedule);
    }
}