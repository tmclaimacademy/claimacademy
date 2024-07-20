using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GradeManager
{
    public class GradeManager
    {
        private static readonly string applicationName = "Grade Manager"; //Declare application name as a string, make global and readonly as this value will not change.
        private static bool exit = false; // Create a boolean (true or false value, see Week 1 code under Booleans) called "exit", set to false by default as we want application to continue to run until we want to exit
        private static List<Student> students;
        public static void Main(string[] args)
        { 

            Console.WriteLine(applicationName); //Print application name on first line
            Console.WriteLine(new String('-', applicationName.Length)); //Print line on name equal to length of application name. This is a dynamically-built string. We are creating a String object, calling the String class constructor with the new keyword. It is accepting two parameters, the first is a character to print, the second is an integer representing the count of characters to build the string. The Length property on the applicationName string gives us the integer count of applicationName so the count of dashes matches the length of the title.
            Console.WriteLine('\n'); // Create 2 blank lines to start menu. WriteLine method call does first blank line, extra '\n' (newline character) creates second blank line (like hitting Enter twice on a keyboard).

            // Create some students
            students = new List<Student>()
            {
                new Student("Tavish", "Misra"), // Student 0 (student number is index (position) number in the List)
                new Student("Jibreel", "Muhammad"), //Student 1
                new Student("Hassan", "Fofana"),  // Student 2
                new Student("Jarvis", "Potter"), // Student 3
                new Student("Greg", "Leeker") // Student 4
            }; // Create a List of students and instantiate (create) the students from the start.
               // We call the new keyword on each Student object in the List because each Student object must be created.

            while(!exit) // Keep menu running after each studentChoice until application is exited. !exit checks for false (! is not operator, checks for opposite of what the current boolean value is), exit checks for true
            {
                Menu();
            }
        }

        // Methods for features. We can make these private rather than public because we are not calling these methods outside of this class.

        private static void Menu()
        {
            Console.WriteLine("1. Save all students to file.");
            Console.WriteLine("2. Load all students from file.");
            Console.WriteLine("3. Print all student grades.");
            Console.WriteLine("4. Add student grade.");
            Console.WriteLine("5. Calculate Class Average");
            Console.WriteLine("6. Print highest grade");
            Console.WriteLine("7. Print lowest grade");
            Console.WriteLine("8. Delete Student");
            Console.WriteLine("9. Edit student grade");
            Console.WriteLine("10. Exit");
            Console.WriteLine("\n"); //Line break
            Console.Write("Enter a studentChoice (number): "); //See User Input code from Week 1

            string choiceInput = Console.ReadLine(); //Keyboard input is always a string
            int choice = int.Parse(choiceInput); //We use int's (Integer) Parse method to convert the string into an integer. If you don't enter an integer, program will crash without exception handling which we will cover later.

            // Menu choices in a Console application are typically driven by a switch-case code block
            // See https://www.w3schools.com/cs/cs_switch.php or https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements

            switch (choice)
            {
                case 1:
                    SaveStudents();
                    break;
                case 2:
                    LoadStudents(); //Loaded students from file will be returned via LoadStudents method and assigned to students variable.
                    break;
                case 3:
                    PrintStudentGrades(); // Call PrintStudentGrades method for 1st studentChoice.
                    break; //Each case must end with break statement, otherwise all cases will execute.
                case 4:
                    AddStudentGrade();
                    break;
                case 5:
                    CalculateClassAverage();
                    break;
                case 6:
                    PrintHighestGrade();
                    break;
                case 7:
                    PrintLowestGrade();
                    break;
                case 8:
                    DeleteStudent();
                    break;
                case 9:
                    EditStudentGrade();
                    break;
                case 10:
                    Exit();
                    break;
                default: //Execute default case, if studentChoice does not match any of the cases. We add no code and just put break statement which will end the switch block.
                    break;
            }
        }

        private static void SaveStudents()
        {
            // Serialize the students List object to a string using Newtonsoft.Json. The resulting string will be JSON Text.
            var studentsJson = JsonConvert.SerializeObject(students, Formatting.Indented);

            //Write the JSON string to a file
            var path = "C:\\Users\\Tavish\\Documents\\grademanagerstudent.json"; //Double \\ to escape \ for character in string
            File.WriteAllText(path, studentsJson);
            Console.WriteLine($"\nStudents saved to {path}.");
        }

        private static void LoadStudents()
        {
            var path = "C:\\Users\\Tavish\\Documents\\grademanagerstudent.json"; // File path
            var json = File.ReadAllText(path); // Load JSON text from file
            students = JsonConvert.DeserializeObject<List<Student>>(json); // Convert JSON text back to object
            Console.WriteLine($"\nStudents loaded successfully from file {path}.");
        }

        private static void PrintStudentGrades()
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
                    var studentGradeList = student.Grades;  // Get the student grade list

                    // Print the grades if they exist, if not, say no grades
                    Console.WriteLine(string.Empty); // Line break

                    if (studentGradeList != null && studentGradeList.Count > 0) // Student grade list exists in memory AND contains grades
                    {
                        foreach (var grade in studentGradeList)
                        {
                            Console.WriteLine($"{student.FirstName} {student.LastName}        {grade}");
                        }
                    }

                    else
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName}        No Grades");
                    }
                }
            }

            else
            {
                Console.WriteLine("There are no students in the system.");
            }
            
            
        }

        private static void AddStudentGrade()
        {
            // Check for students to add grades for

            if (students != null && students.Count > 0)
            {
                Console.WriteLine("\nWhich student do you want to add a grade for?\n\n"); // \n for line break
                int studentListNumber = 1; // To list students. Start from 1 as list items for users typically start from 1 rather than 0.

                foreach (var student in students)
                {
                    Console.WriteLine($"{studentListNumber}. {student.FirstName} {student.LastName}");
                    studentListNumber++; // Increase list number by 1 for each student listed.
                }

                string studentChoiceInput = Console.ReadLine();
                int studentChoice = int.Parse(studentChoiceInput);

                // Add the grade for the student. Based on the student studentChoice, we must select the right student in the Student List to add the grade for
                // Since the list starts at 0, rather than 1, we must subtract 1 from the studentChoiceObject so the right student is selected from the list.

                studentChoice--; //Decrement by 1 for the Student List index number (position).

                string studentFirstChoiceName = students[studentChoice].FirstName; //Access student from list. Format listVariableName[indexNumber]
                string studentChoiceLastName = students[studentChoice].LastName;

                //Capture student grade from keyboard input and parse to int
                Console.Write($"Enter grade for student {studentFirstChoiceName} {studentChoiceLastName}: ");
                string gradeInput = Console.ReadLine();
                int grade = int.Parse(gradeInput);

                //Add the grade to the student grade list
                students[studentChoice].Grades.Add(grade); 
            }

            else
            {
                Console.WriteLine("There are no students in the system.");
            }
        }

        private static void CalculateClassAverage()
        {
            // Take each student grade and average them all out.

            // For each student, we want to add all the grades to one value and keep track of the total grade count
            // as well as the sum, as the class average would be total grade count / sum.

            double average = 0;
            int gradeSum = 0;
            int gradeCount = 0;

            // Loop through all the students
            foreach (var student in students)
            {
                //Compute individual averages to save to file. Since individual grades will be saved to file,
                // Class average can be computed when loading from file.

                student.ComputeAverage(); // Compute the individual average for each student

                // For each student, get each grade, add it to the gradeSum, and increment the gradeCount each time.

                foreach (var grade in student.Grades)
                {
                    gradeSum += grade; // Adding the grade to the gradeSum
                    gradeCount++; // Increasing the grade count by 1.
                }
            }

            // When student completes, compute the average

            average = gradeSum / gradeCount;

            // Print the class average

            Console.WriteLine($"\nThe class average is {average}.");
        }

        private static void PrintHighestGrade()
        {
            int maxGrade = 0; //Create a variable called maxGrade to hold the current maxGrade as we loop through all the grades.
            int count = 0; //Master grade count. If 0, then we are starting from the beginning.
            foreach (var student in students)
            {
                foreach (var grade in student.Grades)
                {
                    if (count == 0 || grade > maxGrade) // If we are starting OR the next grade is greater than maxGrade, then assign the new highest grade to maxGrade.
                    {
                        maxGrade = grade;
                    }

                    count++; // Increment count outside of if because we want to increment this regardless of the case.
                }
            }

            Console.WriteLine($"\nThe highest grade is {maxGrade}\n.");
        }

        private static void PrintLowestGrade()
        {
            int minGrade = 0; //Create a variable called minGrade to hold the current minGrade as we loop through all the grades.
            int count = 0; //Master grade count. If 0, then we are starting from the beginning.
            foreach (var student in students)
            {
                foreach (var grade in student.Grades)
                {
                    if (count == 0 || grade < minGrade) // If we are starting OR the next grade is lesser than minGrade, then assign the new lowest grade to minGrade.
                    {
                        minGrade = grade;
                    }

                    count++; // Increment count outside of if because we want to increment this regardless of the case.
                }
            }

            Console.WriteLine($"\nThe lowest grade is {minGrade}\n.");
        }

        private static void DeleteStudent()
        {
            Console.WriteLine("Which student do you want to delete?\n");
            int studentNumber = 1; // Start from 1 for the menu.

            foreach (var student in students)
            {
                Console.WriteLine($"{studentNumber}. {student.FirstName} {student.LastName}");
                studentNumber++; // Increase the student number for each student name printed.
            }

            string choiceInput; // Storing input for the studentChoice
            choiceInput = Console.ReadLine(); // Take studentChoice input from keyboard
            int choice = int.Parse(choiceInput); // Convert string studentChoice to int.

            choice--; // Decrease studentChoice by 1 to map with List numbers starting from 0.

            var studentChoice = students[choice]; // Store the chosen student in a Student variable.
            var studentName = $"{studentChoice.FirstName} {studentChoice.LastName}";
            // Store student name in variable for confirmation message when deleted. Once student is deleted, we can no longer access the name.

            // Delete the student, use RemoveAt method because we want to use the studentChoice to remove the specific student.
            // RemoveAt uses the integer representing the position in the list, and removes the student at that position.
            students.RemoveAt(choice);

            Console.WriteLine($"Student {studentName} Deleted");
        }

        private static void EditStudentGrade()
        {
            // Get the student for which we are editing a grade for.
            Console.WriteLine("Which student do you want to edit a grade for? ");

            // Start student numbers at 1 for menu.
            int studentNumber = 1;

            // Loop through students to list students
            foreach (var student in students)
            {
                Console.WriteLine($"{studentNumber}. {student.FirstName} {student.LastName}");
                studentNumber++;
            }

            // Take the numeric input for the studentChoice, convert to integer, and decrement to map to List positions.
            string studentChoiceInput = Console.ReadLine();
            int studentChoice = int.Parse(studentChoiceInput);
            studentChoice--;

            // Assign the student studentChoice to its own variable
            var studentChoiceObject = students[studentChoice];

            // Pick the grade to be changed
            Console.WriteLine($"Which grade for student {studentChoiceObject.FirstName} {studentChoiceObject.LastName} do you want to edit?");

            // Start from 1 for menu
            int gradeOption = 1;

            //Loop through listing the grades
            foreach (var grade in studentChoiceObject.Grades)
            {
                Console.WriteLine($"{gradeOption}. {grade}");
                gradeOption++;
            }

            // Pick the grade to change
            string gradeChoiceInput = Console.ReadLine();
            int gradeChoice = int.Parse(gradeChoiceInput);
            gradeChoice--;

            // Enter the new grade, convert to integer, save to newGrade variable
            Console.WriteLine("Enter the new grade.");
            string newGradeInput = Console.ReadLine();
            int newGrade = int.Parse(newGradeInput);

            // Update the grade in the list
            studentChoiceObject.Grades[gradeChoice] = newGrade;

            // Update the Student object in student list with new grade
            students[studentChoice] = studentChoiceObject;

        }

        private static void Exit()
        {
            Console.WriteLine("Good Bye!");
            exit = true; //Set exit to true so application will exit.
        }
    }
}
