using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApplication.Models
{
    // Represents a Registration, 3 properties below
    public class Registration
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}