using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CS20.FW.WorkSchedule.Core.IService;
using CS20.FW.WorkSchedule.Core.Model;
using CS20.FW.WorkSchedule.Domain.IRepository;
using CS20.FW.WorkSchedule.Domain.Service;
using Moq;
using Xunit;

namespace CS20.FW.WorkSchedule.Domain.Test.ServiceTest
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly IUserService _userService;
        private readonly List<User> _users;


        public UserServiceTest()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockUserRepository.Object);
            
            _users = new List<User>();
            _users.Add(new User()
            {
                Id = 1,
                Name = "User1",
                Password = "123456",
                Role = Role.Admin
            });
            _users.Add(new User()
            {
                Id = 2,
                Name = "User2",
                Password = "654321",
                Role = Role.Employee
            });
            _users.Add(new User()
            {
                Id = 3,
                Name = "User3",
                Password = "111111",
                Role = Role.Employee
            });
        }

        #region Initialization Test

        [Fact]
        public void UserService_CanBeInitialized()
        {
            // Assert
            Assert.NotNull(_userService);
        }

        [Fact]
        public void UserService_ImplementInterface()
        {
            // Assert
            Assert.True(_userService is IUserService);
        }

        #endregion

        #region Dependency Injection Test

        [Fact]
        public void UserService_DI_IRepository_NotNull()
        {
            Assert.NotNull(_mockUserRepository);
        }

        [Fact]
        public void UserService_DI_IRepository_IsNull_ThrowsException()
        {
            var invalidDataException = Assert.Throws<InvalidDataException>(() => new UserService(null));
            Assert.Equal("The Repository can not be null", invalidDataException.Message);
        }

        #endregion

        #region Service Test Create

        [Fact]
        public void UserService_Add_ParameterUser_ReturnUser()
        {
            // Arrange
            var user = new User()
            {
                Name = "User4",
                Password = "1234567890123",
                Role = Role.Employee
            };
            _mockUserRepository.Setup(repository => repository.CreateUser(user))
                .Returns(user);

            // Act
            var actual = _userService.CreateUser(user);

            // Assert
            Assert.Equal(user, actual);
        }

        [Fact]
        public void UserService_Create_ParameterUserWithId_ThrowException()
        {
            // Arrange
            var user = new User()
            {
                Id = 5,
                Name = "name5",
                Password = "333333",
                Role = Role.Employee
            };
            _mockUserRepository.Setup(repository => repository.CreateUser(user))
                .Returns(user);
            // Act
            var invalidDataException = Assert.Throws<InvalidDataException>(() => _userService.CreateUser(user));
            // Assert
            Assert.Equal("The user's id should not be input!", invalidDataException.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("123456789012")] // min -1
        [InlineData("1234567890123456789012345678901")] // max -1

        public void UserService_Create_ParameterUserWithNotEnoughPassword_ThrowException(string password)
        {
            // Arrange
            var user = new User()
            {
                Name = "name",
                Password = password,
                Role = Role.Employee
            };
            _mockUserRepository.Setup(repository => repository.CreateUser(user))
                .Returns(user);
            // Act
            var invalidDataException = Assert.Throws<InvalidDataException>(() => _userService.CreateUser(user));
            // Assert
            Assert.Equal("Please input password more than 13 letters and not more than 30!", invalidDataException.Message);
        }

        [Theory]
        [InlineData("1234567890123")]
        [InlineData("12345678901234")]
        [InlineData("12345678901234567890123456789")] // min -1


        public void UserService_Create_ParameterUserWithEnoughPassword_ReturnUser(string password)
        {
            // Arrange
            var user = new User()
            {
                Name = "feiNotHappy..",
                Password = password,
                Role = Role.Employee
            };
            _mockUserRepository.Setup(repository => repository.CreateUser(user))
                .Returns(user);
            // Act
            var actual = _userService.CreateUser(user);
            // Assert
            Assert.Equal(user, actual);
        }

        #endregion

        #region Service test Get

        [Fact]
        public void UserService_GetAll_NoParameter_ReturnListOfUser()
        {
            // Arrange
            _mockUserRepository.Setup(repository => repository.ReadAll())
                .Returns(_users);
            // Act
            var actual = _userService.GetUsers();
            // Assert
            Assert.Equal(_users, actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void UserService_GetById_ParameterId_ReturnUser(int id)
        {
            // Arrange
            var find = _users.Find(user => user.Id == id);
            _mockUserRepository.Setup(repository => repository.ReadById(id))
                .Returns(find);
            // Act
            var actual = _userService.GetUserById(id);
            // Assert
            Assert.Equal(find, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        public void UserService_GetById_ParaWrongId_ThrowException(int id)
        {
            // Arrange
            var find = _users.Find(user => user.Id == id);
            _mockUserRepository.Setup(repository => repository.ReadById(id))
                .Returns(find);
            // Act
            var invalidDataException = Assert.Throws<InvalidDataException>(() => _userService.GetUserById(id));
            // Assert
            Assert.Equal("The user id can not be 0 or smaller!",invalidDataException.Message);

        }
        
        
        [Theory]
        [InlineData(10)]
        public void UserService_GetById_ParaNotExistId_ThrowException(int id)
        {
            // Arrange
            var find = _users.Find(user => user.Id == id);
            _mockUserRepository.Setup(repository => repository.ReadById(id))
                .Returns(find);
            // Act
            var targetException = Assert.Throws<TargetException>(() => _userService.GetUserById(id));
            // Assert
            Assert.Equal("The user is not exist!",targetException.Message);

        }
        #endregion

        #region Service Test Modify
        [Theory]
        [InlineData(1, "name1","1234567890123",Role.Admin)]
        [InlineData(1, "name2","1234567890123",Role.Admin)]
        [InlineData(1, "name2","0000000000000",Role.Admin)]
        [InlineData(1, "name3","0000000000000",Role.Employee)]

        public void UserService_Modify_ParameterUser_ReturnUser(int id, string name,string password,Role role)
        {
            // Arrange
            var changeUser = new User()
            {
                Id = id,
                Name = name,
                Password = password,
                Role = role
            };
            var find = _users.Find(user => user.Id == id);
            if (find != null)
            {
                find.Name = name;
                find.Password = password;
                find.Role = role;
            }
            
            _mockUserRepository.Setup(repository => repository.Update(changeUser))
                .Returns(find);
            // Act
            var actual = _userService.UpdateUser(changeUser);
            // Assert
            Assert.Equal(changeUser, actual, new Comparer());
        }
        
        [Theory]
        [InlineData(10)]
        public void UserService_Modify_ParameterIdNotExist_ThrowException(int id)
        {
            var user = new User()
            {
                Id = id
            };
            var find = _users.Find(findUser => findUser.Id == id);
            _mockUserRepository.Setup(repository => repository.Update(user)).Returns(find);
            var targetException = Assert.Throws<TargetException>(() => _userService.UpdateUser(user));
            Assert.Equal("The user is not exist!",targetException.Message);
        }
        

        #endregion

        #region Service Test Delete
        
        [Fact]
        public void UserService_Delete_ParameterUser_ReturnUser()
        {
            // Arrange
            var user = new User()
            {
                Id = 1,
                Name = "name",
                Password = "222222",
                Role = Role.Employee
            };
            _mockUserRepository.Setup(repository => repository.Delete(user))
                .Returns(user);
            // Act
            var actual = _userService.RemoveUser(user);
            // Assert
            Assert.Equal(user, actual);
        }

        [Fact]
        public void UserService_Delete_ParameterUserNotExist_ThrowException()
        {
            var user = new User()
            {
                Id = 10,
            };

            var find = _users.Find(findUser => findUser.Id == user.Id);
            _mockUserRepository.Setup(repository => repository.Delete(user)).Returns(find);
            var targetException = Assert.Throws<TargetException>(() => _userService.RemoveUser(user));
            Assert.Equal("The user is not exist!",targetException.Message);
        }
        #endregion
    }
}