using CS20.FW.WorkSchedule.Core.Model;
using Xunit;

namespace CS20.FW.WorkSchedule.Core.Test.ModelTest
{
    public class UserTest
    {
         #region Initial
        
        /// <summary>
        /// Test User can be initialized
        /// if the object is not null.
        /// then that means we instantiation the object.
        /// </summary>
        [Fact]
        public void User_CanBeInitialized()
        {
            var user = new User();
            Assert.NotNull(user);
        }

        
        /// <summary>
        /// Test the object User have property Id.
        /// And can be assigned a value as int.
        /// </summary>
        [Fact]
        public void User_ShouldHaveId()
        {
            var user = new User()
            {
                Id = 1
            };
            Assert.Equal(1,user.Id);

        }

        /// <summary>
        /// Test about have the name property.
        /// and can be assigned a value as string.
        /// </summary>
        [Fact]
        public void User_ShouldHaveName()
        {
            var user = new User()
            {
                Name = "UserName"
            };
            Assert.Equal("UserName",user.Name);
        }
        
        
        /// <summary>
        /// Test about user should have property string password and it can be null.
        /// </summary>
        [Fact]
        public void User_ShouldHavePassword_CanBeNull()
        {
            var user = new User()
            {
                Password = null
            };
            Assert.Null(user.Password);
            user.Password = "user";
            Assert.True(user.Password is not null);
            Assert.Equal("user",user.Password );

        }

        /// <summary>
        /// Test The User have property role as Enum.
        /// Role have two element of enum, Admin and Employee.
        /// </summary>
        [Fact]
        public void User_ShouldHaveRole_AsEnum()
        {
            var user = new User()
            {
                Role = Role.Admin
            };
            user.Role = Role.Employee;
            Assert.Equal(Role.Employee, user.Role);
        }
        
        #endregion
    }
}