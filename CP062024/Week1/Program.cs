using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
            //Car car = new Car("Toyota", "Corolla", 2023, "Black");

            // Demonstrating conditionals
            //Conditionals();

            // Demonstrating Iterations
            Iterations();
            //Console.WriteLine("Hello World!");
            Console.ReadKey(); //Leave console window open until key is pressed
            
        }

        static void Conditionals()
        {
            // Recall that booleans are true and false values
            //bool isTrue = true;
            //bool isFalse = false;

            //// These booleans are typically used to judge if-else statements.

            //int x = 3;

            //if (x > 5) // x > 5 evaluates to "true" since x > 5, x being 10.
            //{
            //    Console.WriteLine($"variable x is greater than 5. x is {x}");
            //}

            //else // Whatever is in the else block will be executed if whatever is in the parentheses in the if block is false
            //{
            //    Console.WriteLine($"x is not greater than 5. x is {x}");
            //}

            // Another type of conditional statement, is the "while" statement.
            // Unlike if-else statements, which executes once for a given true-false condition, while statements continue to execute
            // as long as the while condition is true.

            //int n = 0;

            //while (n == 0)
            //{
            //    n++; // Increment (increase by 1)
            //    Console.WriteLine(n);
            //}

            // Another type of conditional is called a switch block. Inside the switch block, we use case statements to evaluate if something equals
            // what is in the switch.

            // For Console applications, this is useful to do a menu.

            Console.Write("Enter a choice: ");
            string enteredChoice = Console.ReadLine();

            int choice = Convert.ToInt32(enteredChoice);

            switch(choice)
            {
                case 1:
                    Console.WriteLine("You entered 1");
                    break; // Prevents other choices from being evaluated.
                case 2:
                    Console.WriteLine("You entered 2");
                    break;
                case 3:
                    Console.WriteLine("You entered 3");
                    break;
                case 4:
                    Console.WriteLine("You entered 4");
                    break;
                case 5:
                    Console.WriteLine("You entered 5");
                    break;
                default: // If choice is anything not covered by above cases
                    Console.WriteLine($"You entered {choice}");
                    break;
            }
        }

        static void Iterations()
        {
            // Iterations are loops which go through a pre-defined list or number of items

            // For Loop
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Loop has run {i} number of times.");
            }

            // Foreach loop
            // Foreach loop runs with an array (a data list of data of all the same type) or List (a .NET class which can be used with
            // many data types, including other classes, and has methods which has more than what an array type can offer.

            // Array - A simple int array of 10 ints
            //int[] intArray = new int[10]; // Empty array of size 10
            //intArray[0] = 1; // arrays start from 0 rather than 1. This assigns the value to the first position, or "slot" in the array.

            // However, we want to assign all 10 positions or "slots" in the array all at once
            // We do that like this:

            int[] intArray = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            // NOTE: assigning all the array values at once has to be done when the array is declared.

            // Now we can loop through the array with a foreach loop.

            foreach (int num in intArray) // Must declare int variable to represent each int in the array and then reference the array itself with the word "in"
            {
                Console.WriteLine(num);
            }
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
