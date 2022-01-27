using System.Collections.Generic;
using System.IO;
using System.Linq;
using CS20.FW.WorkSchedule.Core.Model;
using CS20.FW.WorkSchedule.Database.Entity;
using CS20.FW.WorkSchedule.Domain.IRepository;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CS20.FW.WorkSchedule.Database.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly ScheduleApplicationContext _scheduleApplicationContext;

        public UserRepository(ScheduleApplicationContext scheduleApplicationContext)
        {
            _scheduleApplicationContext 
                = scheduleApplicationContext 
                  ?? throw new InvalidDataException("Repository should have a DbContext!");
        }

        public User CreateUser(User user) 
        {
            var userEntity = new UserEntityConvert().ConverterToEntity(user);
            _scheduleApplicationContext.Users.Add(userEntity);
            _scheduleApplicationContext.SaveChanges();
            
            return new UserEntityConvert().ConverterToUser(userEntity);
        }

        public List<User> ReadAll()
        {
            return _scheduleApplicationContext.Users.Select(entity => new User()
            {
                Id = entity.Id,
                Name = entity.Name,
                Password = entity.Name,
                Role = entity.Role
            }).ToList();
        }

        public User ReadById(int id)
        {
            return _scheduleApplicationContext
                .Users.Select(entity => new UserEntityConvert().ConverterToUser(entity))
                .FirstOrDefault(user => user.Id == id);
        }

        public User ReadByName(string name)
        {
            return _scheduleApplicationContext
                .Users.Select(entity => new UserEntityConvert().ConverterToUser(entity))
                .FirstOrDefault(user => user.Name.Equals(name));
        }

        public User Update(User user)
        {
            _scheduleApplicationContext.Users.Update(new UserEntityConvert().ConverterToEntity(user));
            _scheduleApplicationContext.SaveChanges();
            return user;
        }

        public User Delete(User user)
        {
            _scheduleApplicationContext.Users.Remove(new UserEntityConvert().ConverterToEntity(user));
            _scheduleApplicationContext.SaveChanges();
            return user;
        }
    }
}