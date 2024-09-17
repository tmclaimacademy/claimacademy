using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    internal class Program
    {
        //private static int Bounty;
        //private static string Name;

        static void Main(string[] args)
        {
            // Execute this while loop while the value of Bounty is less than or equal to 0.
            // Since we did not set Bounty to any value at this point, it has a value of 0.
            // So the loop runs at least once.

            //while (Bounty <= 0)
            //{
            //    // Print "The Bounty is 0." using the GetBounty method since here, its value is 0.
            //    Console.WriteLine("The Bounty is " + GetBounty() + ".");

            //    // Change the value of the Bounty to 1000 by using the ChangeBounty method.
            //    //ChangeBounty(1000);

            //    // The while loop will run once more to check if Bounty is still less than or equal to 0.
            //    // Since we changed it to 1000, this is no longer the case, and the program goes to the next statement
            //    // after the while loop.
            //}

            // After Bounty is validated as not less than or equal to 0 (i.e. it is a positive value),
            // Print the value of Bounty using the GetBounty method.

            //Console.WriteLine($"The Bounty is {GetBounty()}.");

            //Set name to set sail
            //SetName("Tavish");

            // Set Sail! Call the SetSail method
            //SetSail();

            // Create a new Pirate.
            // To do this, we will need to have objects for the constructor

            // We create objects by using the "new" keyword. This "new" keyword will execute the constructor code.
            //PirateCrew crew = new PirateCrew();
            //List<Haki> skills = new List<Haki>();
            //(string, string) devilFruit = ("devil", "fruit");

            // Create the Pirate object with the objects from above.
            //Pirate pirate = new Pirate(Name, Bounty, crew, skills, devilFruit);
            //Marine marine = new Marine();

            //var pirateBounty = pirate.GetBounty();
            //var marineBounty = marine.GetBounty();

            //Console.WriteLine($"The pirate's bounty is {pirateBounty}.");
            //Console.WriteLine($"The Marine's bounty is {marineBounty}.");

            //Car car = new Car(); // Create a new Car object
            //car.Drive();

            //Car toyota = new Toyota("Corolla", 1998, "CE");
            //toyota.Drive();

            ////Method Overloading

            //MethodOverloading mo = new MethodOverloading();

            ////int Add implementation
            //int intSum = mo.Add(2, 3);
            //double doubleSum = mo.Add(2.5, 4.3);

            //Console.WriteLine($"int sum: {intSum}");
            //Console.WriteLine($"double sum: {doubleSum}");

            // File Demo
            //FileDemo fileDemo = new FileDemo();
            //fileDemo.Run();

            // Exceptions
            //Exceptions exceptions = new Exceptions();
            //exceptions.Run3();

            //Strings

            //var demo = new Strings(); // Create instance of Strings class to use
            //demo.Demo(); // Run the Strings Demo

            // Lists demo
            var lists = new Lists();

            // Run the lists Demo
            lists.Run();

            Console.ReadLine(); //Keep window open
        }

        // Set a new Bounty and assign to the global Bounty variable declared above.
        //private static void ChangeBounty(int newBounty)
        //{
        //    Bounty = newBounty;
        //}

        //private static int GetBounty()
        //{
        //    return Bounty;
        //}

        //private static void SetName(string name)
        //{
        //    Name = name;
        //}

        //private static void SetSail()
        //{
        //    Console.WriteLine($"{Name} has set sail!");
        //}
    }
}
