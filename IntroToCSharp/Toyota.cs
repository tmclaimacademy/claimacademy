using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IntroToCSharp
{
    internal class Toyota : Car
    {
        public Toyota(string model, string color, int year) : base("Toyota", model, color, year)
        {

        }

        public override void Drive()
        {
            Console.WriteLine("Toyota is driving");
        }

        public override void Break()

        {
            Console.WriteLine($"Toyota is breaking");
        }
    }
}
