﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    public class Marine : Person
    {
        public Marine() 
        {
            Name = "Manav";
            Bounty = 100;
            Console.WriteLine($"I am a Marine. My name is {Name}.");
        }
    }
}
