using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    public class Toyota : Car // Inheriting from base class Car
    {
        public override string Make
        {
            get { return "Toyota"; }
            set {}
        }

        public override void Drive()
        {
            Console.WriteLine($"The {Make} is driving.");
        }
    }
}
