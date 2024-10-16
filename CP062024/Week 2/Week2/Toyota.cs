﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    public class Toyota : Car // Inheriting from base class Car
    {
        // Default Constructor
        public Toyota()
        {

        }

        // Parameterized Constructor
        public Toyota(string model, int year, string trim) : base(model, year, trim)
        {
            Console.WriteLine("Creating a Toyota Object");
            Model = model;
            Year = year;
            Trim = trim;
        }
        public override string Make
        {
            get { return "Toyota"; }
            set {}
        }

        public override void Drive()
        {
            Console.WriteLine($"The {Year} {Make} {Model} {Trim} is driving.");
        }
    }
}
