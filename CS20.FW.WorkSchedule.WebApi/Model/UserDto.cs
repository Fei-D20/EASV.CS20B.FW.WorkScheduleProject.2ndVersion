using CS20.FW.WorkSchedule.Core.Model;

namespace CS20.FW.WorkSchedule.WebApi.Model
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}