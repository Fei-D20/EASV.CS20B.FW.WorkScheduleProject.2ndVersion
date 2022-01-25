namespace CS20.FW.WorkSchedule.Core.Model
{
    /// <summary>
    /// Initial user
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}