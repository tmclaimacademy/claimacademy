using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    internal class Pirate : Person
    {
        // Fields (variables) needed for constructor)

        PirateCrew Crew;
        (string, string) DevilFruit;

        // Constructor. Constructor tells C# how to create the object from the class.
        // The constructor name must be the same as the class and be public
        // The constructor is a special type of method (though not actually a method) that is used
        // to create objects in memory.

        // Default constructor. If you don't create a constructor, then C# will create one for you.
        // The below constructor is the minimum needed for a constructor definition and sp
        // that is what C# creates
        public Pirate()
        {

        }

        public Pirate(string name, int bounty, PirateCrew crew, List<Haki> skills, (string, string) devilFruit)
        {
            this.Name = name;
            this.Bounty = bounty;
            this.Crew = crew;
            this.Skills = skills;
            this.DevilFruit = devilFruit;
            Console.WriteLine($"I am a Pirate. My name is {Name}.");
        }
    }
}
