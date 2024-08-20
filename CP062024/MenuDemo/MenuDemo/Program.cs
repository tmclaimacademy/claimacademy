using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDemo
{
    internal class Program
    {
        private static bool makeAnotherChoice = true; // Global variable, accessible to all methods in the class.

        // As long as the above is true, user can continue to make choices.

        static void Main(string[] args)
        {
            // Menu Example
            // To keep a menu going to keep a console app running
            // As long as makeAnotherChoice is true, keeping calling the menu

            while (makeAnotherChoice)
            {
                Menu();
            }

            Console.WriteLine("Goodbye!");
        }

        static void Menu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("---------");
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("1. Choice 1");
            Console.WriteLine("2. Choice 2");
            Console.WriteLine("3. Choice 3");
            Console.WriteLine("4. Choice 4");
            Console.WriteLine("5. Choice 5");
            Console.WriteLine(Environment.NewLine);
            Console.Write("What Choice do you want to make? ");

            // Take the choice input
            string choiceInput = Console.ReadLine();

            int choice = Convert.ToInt32(choiceInput);

            // Use switch block to evaluate the choices

            switch(choice)
            {
                case 1:
                    Console.WriteLine("You selected Choice 1");
                    break;
                case 2:
                    Console.WriteLine("You selected Choice 2");
                    break;
                case 3:
                    Console.WriteLine("You selected Choice 3");
                    break;
                case 4:
                    Console.WriteLine("You selected Choice 4");
                    break;
                case 5:
                    Console.WriteLine("You selcted Choice 5");
                    break;
                default:
                    break;
            }

            // Ask user to keep running
            Console.Write("Do you want to make another choice? (y/n) ");

            // Take the input
            choiceInput = Console.ReadLine();

            // If choice is anything other than Y, exit the application.
            if (choiceInput.ToUpper().Trim() != "Y") // != is not equals and == is equals
            {
                makeAnotherChoice = false;
            }

        }
    }
}
