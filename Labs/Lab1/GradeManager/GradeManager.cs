using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var students = new List<Student>()
            {
                new Student("Tavish", "Misra"), // Student 0 (student number is index (position) number in the List)
                new Student("Jibreel", "Muhammad"), //Student 1
                new Student("Hassan", "Fofana"),  // Student 2
                new Student("Jarvis", "Potter"), // Student 3
                new Student("Greg", "Leeker") // Student 4
            }; // Create a List of students and instantiate (create) the students from the start.
               // We call the new keyword on each Student object in the List because each Student object must be created.

            while(!exit) // Keep menu running after each choice until application is exited. !exit checks for false (! is not operator, checks for opposite of what the current boolean value is), exit checks for true
            {
                Menu(students);
            }
        }

        // Methods for features. We can make these private rather than public because we are not calling these methods outside of this class.

        private static void Menu(List<Student> students)
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
                    PrintStudentGrades(students); // Call PrintStudentGrades method for 1st choice.
                    break; //Each case must end with break statement, otherwise all cases will execute.
                case 2:
                    AddStudentGrade(students);
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

        private static void PrintStudentGrades(List<Student> students)
        {
            string header = "Student Name        Grade";
            Console.WriteLine(header);
            Console.WriteLine(new String('-', header.Length)); // Create a new string of dashes that is the length of the header

            //Check if there are existing students, if so, print their grades. If not, say there are no students.

            if (students != null && students.Count > 0) // Students list exists in memory AND contains students. || means "or". && means "and".
            {
                //Print the student grades
                foreach (var student in students)
                {
                    var studentFirstName = student.getFirstName(); // Get first name
                    var studentLastName = student.getLastName(); // Get last name
                    var studentGradeList = student.GetGrades();  // Get the student grade list

                    // Print the grades if they exist, if not, say no grades
                    Console.WriteLine(string.Empty); // Line break

                    if (studentGradeList != null && studentGradeList.Count > 0) // Student grade list exists in memory AND contains grades
                    {
                        foreach (var grade in studentGradeList)
                        {
                            Console.WriteLine($"{studentFirstName} {studentLastName}        {grade}");
                        }
                    }

                    else
                    {
                        Console.WriteLine($"{studentFirstName} {studentLastName}        No Grades");
                    }
                }
            }

            else
            {
                Console.WriteLine("There are no students in the system.");
            }
            
            
        }

        private static void AddStudentGrade(List<Student> students)
        {
            // Check for students to add grades for

            if (students != null && students.Count > 0)
            {
                Console.WriteLine("\nWhich student do you want to add a grade for?\n\n"); // \n for line break
                int studentListNumber = 1; // To list students. Start from 1 as list items for users typically start from 1 rather than 0.

                foreach (var student in students)
                {
                    var studentFirstName = student.getFirstName();
                    var studentLastName = student.getLastName();
                    Console.WriteLine($"{studentListNumber}. {studentFirstName} {studentLastName}");
                    studentListNumber++; // Increase list number by 1 for each student listed.
                }

                string studentChoiceInput = Console.ReadLine();
                int studentChoice = int.Parse(studentChoiceInput);

                // Add the grade for the student. Based on the student choice, we must select the right student in the Student List to add the grade for
                // Since the list starts at 0, rather than 1, we must subtract 1 from the studentChoice so the right student is selected from the list.

                studentChoice--; //Decrement by 1 for the Student List index number (position).

                string studentFirstChoiceName = students[studentChoice].getFirstName(); //Access student from list. Format listVariableName[indexNumber]
                string studentChoiceLastName = students[studentChoice].getLastName();

                //Capture student grade from keyboard input and parse to int
                Console.Write($"Enter grade for student {studentFirstChoiceName} {studentChoiceLastName}: ");
                string gradeInput = Console.ReadLine();
                int grade = int.Parse(gradeInput);

                //Add the grade to the student grade list
                students[studentChoice].AddGrade(grade); 
            }

            else
            {
                Console.WriteLine("There are no students in the system.");
            }
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
