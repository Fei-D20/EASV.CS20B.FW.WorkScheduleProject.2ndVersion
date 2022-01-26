using System.Collections.Generic;
using CS20.FW.WorkSchedule.Core.Model;
using CS20.FW.WorkSchedule.Domain.IRepository;
using CS20.FW.WorkSchedule.Domain.Test.ServiceTest;
using Moq;
using Xunit;

namespace CS20.FW.WorkSchedule.Domain.Test.IRepositoryTest
{
    public class IUserRepositoryTest
    {
        private readonly Mock<IUserRepository> _mockUserRepository;

        public IUserRepositoryTest()
        {
            _mockUserRepository = new Mock<IUserRepository>();
        }
        
        #region InterfaceAvaliableTest

        [Fact]
        public void IUserRepository_IsAvailable()
        {
            Assert.NotNull(_mockUserRepository.Object);
        }

        #endregion

        #region MethodTest

        [Fact]
        public void IUserRepository_Create_ParaUser_ReturnUser()
        {
            var user = new User();
            _mockUserRepository.Setup(repository => repository.CreateUser(user)).Returns(user);
            var actual = _mockUserRepository.Object.CreateUser(user);
            Assert.Equal(user,actual);
        }

        [Fact]
        public void IUserRepository_ReadAll_ReturnListOfUser()
        {
            var users = new List<User>();
            _mockUserRepository.Setup(repository => repository.ReadAll()).Returns(users);
            var actual = _mockUserRepository.Object.ReadAll();
            Assert.Equal(users,actual);
        }

        [Fact]
        public void IUserRepository_ReadById_ReturnUser()
        {
            var user = new User();
            _mockUserRepository.Setup(repository => repository.ReadById(1)).Returns(user);
            var actual = _mockUserRepository.Object.ReadById(1);
            Assert.Equal(user,actual);
        }

        [Fact]
        public void IUserRepository_ReadByName_ReturnUser()
        {
            var user = new User();
            _mockUserRepository.Setup(repository => repository.ReadByName("name")).Returns(user);
            var actual = _mockUserRepository.Object.ReadByName("name");
            Assert.Equal(user,actual);
        }

        [Fact]
        public void IUserRepository_Update_ParaUser_ReturnUser()
        {
            var user = new User();
            _mockUserRepository.Setup(repository => repository.Update(user)).Returns(user);
            var actual = _mockUserRepository.Object.Update(user);
            Assert.Equal(user,actual);
        }

        [Fact]
        public void IUserRepository_Delete_ParaUser_ReturnUser()
        {
            var user = new User();
            _mockUserRepository.Setup(repository => repository.Delete(user)).Returns(user);
            var actual = _mockUserRepository.Object.Delete(user);
            Assert.Equal(user,actual);
        }
        
        #endregion
    }
}