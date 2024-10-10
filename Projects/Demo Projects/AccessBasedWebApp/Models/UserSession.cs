namespace AccessBasedWebApp.Models
{
    public class UserSession
    {
        public string SessionID { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastActivityDateTime {get;}
    }
}
