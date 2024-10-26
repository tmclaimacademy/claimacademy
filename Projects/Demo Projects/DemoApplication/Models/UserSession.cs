using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApplication.Models
{
    // Represents a User Session
    public class UserSession
    {
        public string SessionID { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastActivityDateTime { get; }
    }
}