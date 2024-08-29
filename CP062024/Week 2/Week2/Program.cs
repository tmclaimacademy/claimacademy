using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    internal class Program
    {
        private static long bounty;
        static void Main(string[] args)
        {
            // Execute this while loop while the value of bounty is less than or equal to 0.
            // Since we did not set bounty to any value at this point, it has no value, th
            while (bounty <= 0)
            {
                Console.WriteLine("The bounty is " + GetBounty() + ".");
                ChangeBounty(1000);
            }

            Console.WriteLine($"The bounty is {GetBounty()}.");

            Console.ReadLine(); //Keep window open
        }

        // Set a new bounty and assign to the global bounty variable declared above.
        private static void ChangeBounty(long newBounty)
        {
            bounty = newBounty;
        }

        private static long GetBounty()
        {
            return bounty;
        }
    }
}
