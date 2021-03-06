using CS20.FW.WorkSchedule.Core.Model;

namespace CS20.FW.WorkSchedule.WebApi.Model
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
    }

    public class UserDtoConvert
    {
        public User ConverterToUser(UserDto userDto)
        {
            return new User()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Password = userDto.Password,
                Role = userDto.Role
            };
        }

        public UserDto ConverterUserDto(User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role
            };
        }
    }
}