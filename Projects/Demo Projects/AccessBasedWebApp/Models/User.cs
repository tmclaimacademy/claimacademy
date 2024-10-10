namespace AccessBasedWebApp.Models
{
    public class User
    {
        public int UserId { get; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
