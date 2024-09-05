using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    // Base Class
    public class Car
    {
        public virtual string Make {  get; set; }
        public virtual string Model { get; set; }
        public virtual int Year { get; set; }

        public virtual string Trim { get; set; }

        // Constructors


        // Default Constructor - Every class has one but if you are defining a custom constructor,
        // you will still need to define this by default
        public Car()
        {
            Console.WriteLine("Creating a basic Car object.");
        }
        public Car(string model, int year, string trim)
        {
            Console.WriteLine("Creating a Car object with parameters.");
            Model = model;
            Year = year;
            Trim = trim;
        }

        // Virtual methods to override

        public virtual void Drive()
        {
            Console.WriteLine("The car is driving.");
        }

        public virtual void Stop()
        {
            Console.WriteLine("The car is stopping.");
        }

        public virtual void Reverse()
        {
            Console.WriteLine("The car is reversing.");
        }
    }
}
