using System.Collections.Generic;
using CS20.FW.WorkSchedule.Core.IService;
using CS20.FW.WorkSchedule.Core.Model;
using Moq;
using Xunit;

namespace CS20.FW.WorkSchedule.Core.Test.IServiceTest
{
    public class IUserServiceTest
    {
        private readonly Mock<IUserService> _mock;

        public IUserServiceTest()
        {
            _mock = new Mock<IUserService>();

        }

        #region InterfaceAvaliableTest
        [Fact]
        public void IUserService_IsAvailable()
        {

            var userService = _mock.Object;
            
            Assert.NotNull(userService);
        }

        #endregion

        #region GetMethodTest

        [Fact]
        public void IUserService_GetAllUsers_NoParameter_ReturnListOfUsers()
        {
            var users = new List<User>();
            _mock.Setup(service => service.GetUsers()).Returns(users);
            var actual = _mock.Object.GetUsers();
            Assert.Equal(users, actual);
        }
        
        [Fact]
        public void IUserService_GetById_ParameterId_ReturnsUser()
        {
            var user = new User();
            _mock.Setup(service => service.GetUserById(1)).Returns(user);
            var actual = _mock.Object.GetUserById(1);
            Assert.Equal(user, actual);
        }
        
        [Fact]
        public void IUserService_Create_ParameterUser_ReturnUser()
        {
            var user = new User();
            _mock.Setup(service => service.CreateUser(user)).Returns(user);
            var actual = _mock.Object.CreateUser(user);
            Assert.Equal(user, actual);
        }
        
        [Fact]
        public void IUserService_Remove_ParameterUser_ReturnUser()
        {
            var user = new User();
            _mock.Setup(service => service.RemoveUser(user)).Returns(user);
            var actual = _mock.Object.RemoveUser(user);
            Assert.Equal(user, actual);
        }
        
        [Fact]
        public void IUserService_Update_ParameterUser_ReturnUser()
        {
            var user = new User();
            _mock.Setup(service => service.UpdateUser(user)).Returns(user);
            var actual = _mock.Object.UpdateUser(user);
            Assert.Equal(user, actual);
        }

        #endregion
    }
}