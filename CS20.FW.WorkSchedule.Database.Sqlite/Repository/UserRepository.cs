using System.Collections.Generic;
using CS20.FW.WorkSchedule.Core.Model;
using CS20.FW.WorkSchedule.Domain.IRepository;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CS20.FW.WorkSchedule.Database.Repository
{
    public class UserRepository:IUserRepository
    {
        private ScheduleApplicationContext _scheduleApplicationContext;

        public UserRepository(ScheduleApplicationContext scheduleApplicationContext)
        {
            _scheduleApplicationContext = scheduleApplicationContext;
        }

        public User CreateUser(User user)
        {
            var userEntity = new Convert().Converter(user);
            _scheduleApplicationContext.Users.Add(userEntity);
            
            return new Convert().Converter(userEntity);
        }

        public List<User> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public User ReadById(int id)
        {
            throw new System.NotImplementedException();
        }

        public User ReadByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public User Update(User user)
        {
            throw new System.NotImplementedException();
        }

        public User Delete(User user)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Convert
    {
        public UserEntity Converter(User user)
        {
            return new UserEntity()
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role,
                Password = user.Password,
            };
        }

        public User Converter(UserEntity userEntity)
        {
            return new User()
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Password = userEntity.Password,
                Role = userEntity.Role
            };
        }
    }

    public class WorkScheduleEntity
    {
    }

    public class WorkRecordEntity
    {
    }

    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
    }
}