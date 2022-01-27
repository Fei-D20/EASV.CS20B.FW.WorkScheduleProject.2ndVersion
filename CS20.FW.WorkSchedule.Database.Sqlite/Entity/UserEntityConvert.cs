using CS20.FW.WorkSchedule.Core.Model;

namespace CS20.FW.WorkSchedule.Database.Entity
{
    public class UserEntityConvert
    {
        public UserEntity ConverterToEntity(User user)
        {
            return new UserEntity()
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role,
                Password = user.Password,
            };
        }

        public User ConverterToUser(UserEntity userEntity)
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
}