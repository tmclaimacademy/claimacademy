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
        private static string Name;
        static void Main(string[] args)
        {
            // Execute this while loop while the value of bounty is less than or equal to 0.
            // Since we did not set bounty to any value at this point, it has a value of 0.
            // So the loop runs at least once.

            while (bounty <= 0)
            {
                // Print "The bounty is 0." using the GetBounty method since here, its value is 0.
                Console.WriteLine("The bounty is " + GetBounty() + ".");

                // Change the value of the bounty to 1000 by using the ChangeBounty method.
                ChangeBounty(1000);

                // The while loop will run once more to check if bounty is still less than or equal to 0.
                // Since we changed it to 1000, this is no longer the case, and the program goes to the next statement
                // after the while loop.
            }

            // After bounty is validated as not less than or equal to 0 (i.e. it is a positive value),
            // Print the value of bounty using the GetBounty method.

            Console.WriteLine($"The bounty is {GetBounty()}.");

            //Set name to set sail
            SetName("Tavish");

            // Set Sail! Call the SetSail method
            SetSail();


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

        private static void SetName(string name)
        {
            Name = name;
        }

        private static void SetSail()
        {
            Console.WriteLine($"{Name} has set sail!");
        }
    }
}
