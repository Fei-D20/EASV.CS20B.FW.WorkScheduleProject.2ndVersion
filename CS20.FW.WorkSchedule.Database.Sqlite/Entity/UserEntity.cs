using CS20.FW.WorkSchedule.Core.Model;

namespace CS20.FW.WorkSchedule.Database.Entity
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
    }
}