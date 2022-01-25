namespace CS20.FW.WorkSchedule.Core.Model
{
    /// <summary>
    /// The user model represent the user account.
    /// Id: the user register unique number to recognize the user.
    /// Name: the user's full name.
    /// Password: the user's login password.
    /// Role: the user's position.
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}