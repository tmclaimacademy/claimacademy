using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    public class MethodOverloading
    {
        // Method overloading demo

        public int Add(int x, int y)
        {
            Console.WriteLine("Calling int implementation of Add.");
            return x + y;
        }

        public double Add(double x, double y)
        {
            Console.WriteLine("Calling overloaded double implementation of Add.");
            return x + y;
        }
    }
}
