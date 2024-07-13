using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    public class Week1
    {
        public static void Main(string[] args)
        {
            // Official Microsoft C# Documentation: https://learn.microsoft.com/en-us/dotnet/csharp/

            // Week 1
            DataTypes();

            Console.ReadKey();
        }

        public static void DataTypes()
        {
            // Data Types (Primitive Types)
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types#835-simple-types

            Integers();
            FloatingPointTypes();
            Booleans();
            Characters();
            Strings();
            UserInput();
            ForLoops();
            ForEachLoops();
            Constructors();
            Inheritance();
            Polymorphism();
            Abstraction();
            Interfaces();
        }

        public static void Integers()
        {
            //Integer: Whole numbers. 32-bit values go up from -2,147,483,648 to 2,147,483,647 which is (2^32 / 2) - 1.
            // Max value given by int.MaxValue  (32-bit)
            Console.WriteLine($"Max Integer Value: {int.MaxValue}");

            //// Min Value given by int.MinValue (32-bit)
            Console.WriteLine($"Min Integer Value: {int.MinValue}");

            // 64-bit Integers can be accessed with Int64 struct or long primitive type
            // Max Int64 size 18,446,744,073,709,551,615


            //Declare without initial assignment
            int num; // All statements must be ended with ;

            //Assignment: Giving a value to the variable

            num = 6;

            // We can also declare and assign a value at once.

            int num2 = 8;
        }

        public static void FloatingPointTypes()
        {
            //Floating point types: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types

            // Doubles - Floating point numbers, with decimals. Range is ±5.0 × 10^−324 to ±1.7 × 10^308
            double dbl = 1.25d;

            // Floats - Decimals. Range: ±1.5 x 10^−45 to ±3.4 x 10^38
            float floatnum = 4.7589f;

            // Decimal type: Range: ±1.0 x 10^-28 to ±7.9228 x 10^28
            decimal decimalNum = 8.567M;
        }

        public static void Booleans()
        {
            // Booleans: Can only be true or false, used to determine the binary state of something. i.e. true/false, on/off, etc.

            bool boolTrue = true;
            bool boolFalse = false;
        }

        public static void Characters()
        {
            // Characters: Single ASCII or UTF-8 value (depending on character set used, these are the most common character sets)
            //More info: https://learn.microsoft.com/en-us/windows/win32/intl/character-sets

            char lowerA = 'a';
            char upperA = 'A';

            int lowerAValue = (int)lowerA;
            Console.WriteLine($"Integer value of lower-case a: {lowerAValue}");
        }

        public static void Strings()
        {
            // Strings: Arrays of characters

            string helloWorld = "Hello World";

            //Convert to character array
            char[] helloWorldCharArray = helloWorld.ToCharArray();
        }

        public static void UserInput()
        {
            // User Input

            Console.Write("Enter your name: "); // Console.Write will not create a new line (same as pressing Enter in notepad). Console.WriteLine will create a new line at the end of the text (like pressing Enter in Notepad)

            // We will declare a string variable called "name" and assign the user input to the string.

            string name = Console.ReadLine(); // This will create the string variable "name" and then await keyboard input from the user in the Console.

            // After taking in the user input from the keyboard, we will print back to the console what the user typed.

            Console.WriteLine($"Your name is {name}.");
            Console.ReadKey(); // Keep console window open until key is pressed to end program and close console window.

        }

        public static void ForLoops()
        {
            //For Loops

            //Declare count variable for loop count

            int count = 10;

            for (int i = 0; i < count; i++) // First statement: int i = 0; Initializes a counter i and starts at 0
                                            // Second statement: i < count; Loop while i is less than the count, loop will stop when i = count.
                                            // Third statement: Increment (increase) i by 1 for each execution of the loop.
                                            // By structuring the for statement like this, starting at 0, and increasing by 1 until i is less than 10.
                                            // The next loop, i will equal 10, which stops the loop, so last execution of loop, i is 9
                                            // Since we are starting from 0, and going to 9, this is exactly 10 executions of the loop.
            {
                //Do something with each execution of the loop
                Console.WriteLine($"Loop count is {i}, but this is execution number {i + 1}.");
            }

            
        }

        public static void ForEachLoops()
        {
            //Foreach Loop - Use an Array/List/Collection to loop through the Array/List/Collection

            //Integer array of 10 values of 1 through 10
            //Size of array is used to control how many times the loop runs for (loop runs from beginning to end of array)

            int[] tenCountArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach (int i in tenCountArray)
            {
                Console.WriteLine($"The current value is {i}.");
            }
        }

        public static void Constructors()
        {
            // See https://www.w3schools.com/cs/cs_constructors.php
            // We will cover this later in the course but review the link above
        }

        public static void Inheritance()
        {
            // See https://www.w3schools.com/cs/cs_inheritance.php
            // We will cover this later in the course but review the link above
        }

        public static void Polymorphism()
        {
            // See https://www.w3schools.com/cs/cs_polymorphism.php
            // We will cover this later in the course but review the link above
        }

        public static void Abstraction()
        {
            // See https://www.w3schools.com/cs/cs_abstract.php
            // We will cover this later in the course but review the link above
        }

        public static void Interfaces()
        {
            // See https://www.w3schools.com/cs/cs_interface.php
            // We will cover this later in the course but review the link above
        }
    }
}
