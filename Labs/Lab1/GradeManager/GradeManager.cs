using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeManager
{
    public class GradeManager
    {
        private static readonly string applicationName = "Grade Manager"; //Declare application name as a string, make global and readonly as this value will not change.
        private static bool exit = false; // Create a boolean (true or false value, see Week 1 code under Booleans) called "exit", set to false by default as we want application to continue to run until we want to exit
        public static void Main(string[] args)
        { 

            Console.WriteLine(applicationName); //Print application name on first line
            Console.WriteLine(new String('-', applicationName.Length)); //Print line on name equal to length of application name. This is a dynamically-built string. We are creating a String object, calling the String class constructor with the new keyword. It is accepting two parameters, the first is a character to print, the second is an integer representing the count of characters to build the string. The Length property on the applicationName string gives us the integer count of applicationName so the count of dashes matches the length of the title.
            Console.WriteLine('\n'); // Create 2 blank lines to start menu. WriteLine method call does first blank line, extra '\n' (newline character) creates second blank line (like hitting Enter twice on a keyboard).

            // Create some students
            Student student1 = new Student("Tavish", "Misra");
            Student student2 = new Student("Jibreel", "Muhammad");
            Student student3 = new Student("Hassan", "Fofana");
            Student student4 = new Student("Jarvis", "Potter");
            Student student5 = new Student("Greg", "Leeker");

            while(!exit) // Keep menu running after each choice until application is exited. !exit checks for false (! is not operator, checks for opposite of what the current boolean value is), exit checks for true
            {
                Menu();
            }
        }

        // Methods for features. We can make these private rather than public because we are not calling these methods outside of this class.

        private static void Menu()
        {
            Console.WriteLine("1. Print all student grades.");
            Console.WriteLine("2. Add student grade.");
            Console.WriteLine("3. Calculate Class Average");
            Console.WriteLine("4. Print highest grade");
            Console.WriteLine("5. Print lowest grade");
            Console.WriteLine("6. Delete Student");
            Console.WriteLine("7. Edit student grade");
            Console.WriteLine("8. Exit");
            Console.WriteLine("\n"); //Line break
            Console.Write("Enter a choice (number): "); //See User Input code from Week 1

            string choiceInput = Console.ReadLine(); //Keyboard input is always a string
            int choice = int.Parse(choiceInput); //We use int's (Integer) Parse method to convert the string into an integer. If you don't enter an integer, program will crash without exception handling which we will cover later.

            // Menu choices in a Console application are typically driven by a switch-case code block
            // See https://www.w3schools.com/cs/cs_switch.php or https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements

            switch (choice)
            {
                case 1:
                    PrintStudentGrades(); // Call PrintStudentGrades method for 1st choice.
                    break; //Each case must end with break statement, otherwise all cases will execute.
                case 2:
                    AddStudentGrade();
                    break;
                case 3:
                    CalculateClassAverage();
                    break;
                case 4:
                    PrintHighestGrade();
                    break;
                case 5:
                    PrintLowestGrade();
                    break;
                case 6:
                    DeleteStudent();
                    break;
                case 7:
                    EditStudentGrade();
                    break;
                case 8:
                    Exit();
                    break;
                default: //Execute default case, if choice does not match any of the cases. We add no code and just put break statement which will end the switch block.
                    break;
            }
        }

        private static void PrintStudentGrades()
        {
            Console.WriteLine("PrintStudentGrades method is called.");
        }

        private static void AddStudentGrade()
        {
            Console.WriteLine("AddStudentGrade method is called.");
        }

        private static void CalculateClassAverage()
        {
            Console.WriteLine("CalculateClassAverage method is called.");
        }

        private static void PrintHighestGrade()
        {
            Console.WriteLine("PrintHighestGrade method is called.");
        }

        private static void PrintLowestGrade()
        {
            Console.WriteLine("PrintLowestGrade method is called.");
        }

        private static void DeleteStudent()
        {
            Console.WriteLine("DeleteStudent method is called.");
        }

        private static void EditStudentGrade()
        {
            Console.WriteLine("EditStudentGrade method is called.");
        }

        private static void Exit()
        {
            Console.WriteLine("Good Bye!");
            exit = true; //Set exit to true so application will exit.
        }
    }
}
