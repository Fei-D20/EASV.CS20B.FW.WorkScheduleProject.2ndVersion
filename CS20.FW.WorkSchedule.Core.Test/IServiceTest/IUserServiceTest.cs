using System.Collections.Generic;
using CS20.FW.WorkSchedule.Core.Model;
using Moq;
using Xunit;

namespace CS20.FW.WorkSchedule.Core.Test.IServiceTest
{
    public class IUserServiceTest
    {
        
        #region InterfaceAvaliableTest

        [Fact]
        public void IUserService_IsAvailable()
        {
            var mock = new Mock<IUserService>();

            var userService = mock.Object;

            Assert.NotNull(userService);
        }

        #endregion

        #region GetMethodTest

        [Fact]
        public void IUserService_GetAllUsers_NoParameter_ReturnListOfUsers()
        {
            var mock = new Mock<IUserService>();
            mock.Setup(service => service.GetUsers()).Returns(new List<User>());
            var userService = mock.Object;
            var actual = userService.GetUsers();
            var expected = new List<User>();
            Assert.Equal(expected, actual);
        }

        #endregion

        #region GetUserByIdTest

        [Fact]
        public void IUserService_GetById_ParameterId_ReturnsUser()
        {
            var user = new User
            {
                Id = 1,
                Name = "user"
            };
            var mock = new Mock<IUserService>();
            mock.Setup(service => service.GetUserById(1)).Returns(user);
            var userService = mock.Object;
            var actual = userService.GetUserById(1);
            Assert.Equal(user, actual);
        }

        #endregion

        #region CreateUserTest

        [Fact]
        public void IUserService_Create_ParameterUser_ReturnUser()
        {
            var user = new User
            {
                Id = 1,
                Name = "user"
            };
            var mock = new Mock<IUserService>();
            var userService = mock.Object;
            mock.Setup(service => service.CreateUser(user)).Returns(user);
            var actual = userService.CreateUser(user);
            Assert.Equal(user, actual);
        }

        #endregion

        #region RemoveUserTest

        [Fact]
        public void IUserService_Remove_ParameterId_ReturnUser()
        {
            var user = new User
            {
                Id = 1,
                Name = "user"
            };

            var mock = new Mock<IUserService>();
            var userService = mock.Object;
            mock.Setup(service => service.RemoveUser(1))
                .Returns(user);

            // Act
            var actual = userService.RemoveUser(1);

            // Assert
            Assert.Equal(user, actual);
        }

        #endregion

        #region UpdateUserTest

        [Fact]
        public void IUserService_Update_ParameterUser_ReturnUser()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "Name1"
            };

            var mock = new Mock<IUserService>();
            var userService = mock.Object;
            mock.Setup(service => service.UpdateUser(user))
                .Returns(user);

            // Act
            var actual = userService.UpdateUser(user);

            // Assert
            Assert.Equal(user, actual);
        }

        #endregion
    }

    public interface IUserService
    {
        List<User> GetUsers();
        User GetUserById(int id);
        User CreateUser(User user);
        User RemoveUser(int id);
        User UpdateUser(User user);
    }
}