using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToCSharp
{
    internal class Car
    {
        private string _make;
        private string _model;
        private string _color;
        private int _year;
        public Car(string make, string model, string color, int year)
        {
            _make = make;
            _model = model;
            _color = color;
            _year = year;
            Console.WriteLine($"You have created a Car.");
        }

        public void GetDescription()
        {
            Console.WriteLine($"{_year} {_color} {_make} {_model}");
        }

        public virtual void Drive()
        {
            Console.WriteLine($"Car is driving.");
        }

        public virtual void Break()
        {
            Console.WriteLine($"Car is breaking");
        }
    }

    
}
