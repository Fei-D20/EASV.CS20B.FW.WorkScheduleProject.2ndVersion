using System.Collections.Generic;
using CS20.FW.WorkSchedule.Core.Model;

namespace CS20.FW.WorkSchedule.Domain.IRepository
{
    public interface IUserRepository
    {
        User CreateUser(User user);
        List<User> ReadAll();
        User ReadById(int id);
        User ReadByName(string name);
        User Update(User user);
        User Delete(User user);
    }
}