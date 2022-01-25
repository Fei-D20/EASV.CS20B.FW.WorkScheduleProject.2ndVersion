using System.Collections.Generic;
using CS20.FW.WorkSchedule.Core.Model;
using CS20.FW.WorkSchedule.Domain.Test.ServiceTest;
using Moq;
using Xunit;

namespace CS20.FW.WorkSchedule.Domain.Test.IRepositoryTest
{
    public class IUserRepositoryTest
    {
        private readonly Mock<IRepository> _mock;

        public IUserRepositoryTest()
        {
            _mock = new Mock<IRepository>();
        }
        
        #region InterfaceAvaliableTest

        [Fact]
        public void IUserRepository_IsAvailable()
        {
            var repository = _mock.Object;
            Assert.NotNull(repository);
        }

        #endregion

        #region MethodTest

        [Fact]
        public void IUserRepository_Create_ParaUser_ReturnUser()
        {
            var user = new User();
            _mock.Setup(repository => repository.CreateUser(user)).Returns(user);
            var actual = _mock.Object.CreateUser(user);
            Assert.Equal(user,actual);
        }

        [Fact]
        public void IUserRepository_ReadAll_ReturnListOfUser()
        {
            var users = new List<User>();
            _mock.Setup(repository => repository.ReadAll()).Returns(users);
            var actual = _mock.Object.ReadAll();
            Assert.Equal(users,actual);
        }

        [Fact]
        public void IUserRepository_ReadById_ReturnUser()
        {
            var user = new User();
            _mock.Setup(repository => repository.ReadById(1)).Returns(user);
            var actual = _mock.Object.ReadById(1);
            Assert.Equal(user,actual);
        }

        [Fact]
        public void IUserRepository_ReadByName_ReturnUser()
        {
            var user = new User();
            _mock.Setup(repository => repository.ReadByName("name")).Returns(user);
            var actual = _mock.Object.ReadByName("name");
            Assert.Equal(user,actual);
        }

        [Fact]
        public void IUserRepository_Update_ParaUser_ReturnUser()
        {
            var user = new User();
            _mock.Setup(repository => repository.Update(user)).Returns(user);
            var actual = _mock.Object.Update(user);
            Assert.Equal(user,actual);
        }

        [Fact]
        public void IUserRepository_Delete_ParaUser_ReturnUser()
        {
            var user = new User();
            _mock.Setup(repository => repository.Delete(user)).Returns(user);
            var actual = _mock.Object.Delete(user);
            Assert.Equal(user,actual);
        }
        
        #endregion
    }

    public interface IRepository
    {
        User CreateUser(User user);
        List<User> ReadAll();
        User ReadById(int id);
        User ReadByName(string name);
        User Update(User user);
        User Delete(User user);
    }
}