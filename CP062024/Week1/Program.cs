using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter a number to add: ");
            //string firstInput; // To store text version of first number
            //firstInput = Console.ReadLine(); // Request the number input from keyboard (keyboard always produces characters, which is text)
            //Console.Write($"Enter a second number to add the first to: ");
            //string secondInput;
            //secondInput = Console.ReadLine(); // Request the second number input
            //int firstNumber = Convert.ToInt32(firstInput); // Convert text of firstInput to actual integer
            //int secondNumber = Convert.ToInt32(secondInput); // Convert text of secondInput to actual integer
            //int sum = firstNumber + secondNumber; // Since we now have integers, we can do math on the integers, like adding.
            //Console.WriteLine($"The sum of {firstInput} and {secondInput} is {sum}");

            // For Loop - Print the numbers 1 through 10
            //int c;

            //int[] intArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //foreach (int i in intArray)
            //{
            //    Console.WriteLine(i);
            //}

            // Call Add method that we created below
            //Add();

            // Call Add method with parameters
            //Add(3, 4);

            //Call AddWithReturn and assign to a sum
            //int a = 3;
            //int b = 4;
            //int sum = AddWithReturn(a, b);
            //Console.WriteLine($"The sum of {a} and {b} is {sum}.");

            //Creating a new Car object with Car constructor with parameters (parameterized constructor)
            Car car = new Car("Toyota", "Corolla", 2023, "Black");

            //Console.WriteLine("Hello World!");
            Console.ReadKey(); //Leave console window open until key is pressed
            
        }

        // Add without parameters
        static void Add()
        {
            // We are going to enter two numbers, add them, and print the sum to the console after.

            //Declare an int (integer) for the first number.
            int x;

            // Prompt for the first number using Console.ReadLine.
            // Since Console.ReadLine returns a string, we will need to convert the string of the number
            // to the number itself using Convert.To

            // Print message prompt, we will use Console.Write so the input is next to the prompt rather
            // than the next line.

            Console.Write("Please enter the first number: ");

            // Declare a string to hold the number input
            string firstNumberInput;

            // Wait for the user to enter the number, and then save the number to the firstNumberInput variable
            // The input should be an integer (whole number), otherwise the program will crash.
            // Later on, we will learn about exception handling to work around this problem.
            firstNumberInput = Console.ReadLine();

            // Once the number is entered, we will convert the string representation of the number to an integer
            // Once it is converted to an integer, we can then do math operations on the number.
            // This number will be saved to the int we declared above called "x"
            x = Convert.ToInt32(firstNumberInput);

            // We will then repeat this process with the second number
            int y; //Declare int for second number
            Console.Write("Please enter the second number: ");
            string secondNumberInput;
            secondNumberInput = Console.ReadLine();
            y = Convert.ToInt32(secondNumberInput);

            // We will the declare a third int called "sum" to store the sum (x + y)
            int sum = x + y;

            // Then we will print the sum to the Console
            Console.WriteLine($"The sum of {x} and {y} is {sum}.");
        }

        // Add with parameters
        static void Add(int x, int y)
        {
            int sum = x + y;
            Console.WriteLine($"The sum of {x} and {y} is {sum}.");
        }

        static int AddWithReturn(int x, int y) // Method name has to change here as parameters are the same
        {
            return x + y; // This return statement will "send" back the result. We can then assign a variable with the method call as if it were like typing an integer
        }
    }
}
