namespace AccessBasedWebApp.Models
{
    public class Blog
    {
        public int BlogEntryId { get; set; }
        public int UserId { get; set; }
        public DateTime BlogCreateDateTime { get; set; } 
        public DateTime BlogUpdateDateTime { get; set; }
        public string BlogText { get; set; }
    }
}
