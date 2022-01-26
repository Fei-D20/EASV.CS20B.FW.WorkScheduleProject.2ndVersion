using System.Collections.Generic;
using CS20.FW.WorkSchedule.Core.Model;

namespace CS20.FW.WorkSchedule.Core.IService
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUserById(int id);
        User CreateUser(User user);
        User RemoveUser(User user);
        User UpdateUser(User user);
    }
}