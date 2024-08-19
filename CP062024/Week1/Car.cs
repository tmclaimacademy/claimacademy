using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        public Car(string make, string model, int year, string color)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            Console.WriteLine($"You have created a {Color} {Year} {Make} {Model}.");
        }
    }
}
