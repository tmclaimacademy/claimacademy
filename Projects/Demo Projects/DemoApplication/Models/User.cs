using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApplication.Models
{
    // Represents a user
    public class User
    {
        public int UserId { get; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}