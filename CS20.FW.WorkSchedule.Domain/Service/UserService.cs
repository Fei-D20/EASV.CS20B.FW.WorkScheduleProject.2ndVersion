using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CS20.FW.WorkSchedule.Core.IService;
using CS20.FW.WorkSchedule.Core.Model;
using CS20.FW.WorkSchedule.Domain.IRepository;

namespace CS20.FW.WorkSchedule.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new InvalidDataException("The Repository can not be null");
        }

        public List<User> GetUsers()
        {
            return _userRepository.ReadAll();
        }

        public User GetUserById(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("The user id can not be 0 or smaller!");
            }

            var readById = _userRepository.ReadById(id);
            if (readById == null)
            {
                throw new TargetException("The user is not exist!");
            }
            return readById;
        }

        public User CreateUser(User user)
        {
            if (user.Id != 0)
            {
                throw new InvalidDataException("The user's id should not be input!");
            }

            if (user.Password.Length < 13 || user.Password.Length > 30)
            {
                throw new InvalidDataException("Please input password more than 13 letters and not more than 30!");
            }
            return _userRepository.CreateUser(user);
        }

        public User RemoveUser(User user)
        {
            var delete = _userRepository.Delete(user);
            if (delete == null)
            {
                throw new TargetException("The user is not exist!");
            }

            return delete;
        }

        public User UpdateUser(User user)
        {
            var updateUser = _userRepository.Update(user);
            if (updateUser == null)
            {
                throw new TargetException("The user is not exist!");
            }

            return updateUser;
        }
    }
    
    public class Comparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id == y.Id && x.Name == y.Name && x.Password == y.Password && x.Role == y.Role;
        }

        public int GetHashCode(User obj)
        {
            return HashCode.Combine(obj.Id, obj.Name, obj.Password, (int)obj.Role);
        }
    }
}
