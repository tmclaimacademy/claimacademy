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
        private static bool studentsSaved = false; // Add a save students check
        private static List<Student> students;
        private static StringBuilder log;
        private static string logFilePath;
        private const string studentsJsonPath = "C:\\Users\\Tavish\\Documents\\grademanagerstudent.json";
        public static void Main(string[] args)
        {
            try
            {
                //Initiate application logging

                //Initialize our StringBuilder. We have already declared a global StringBuilder object called "log"
                //So we will initialize by creating the StringBuilder object with the declaration.

                log = new StringBuilder();

                //We will need a file path to log the file too. The file contents will be saved when we exit or when an exception is thrown.
                logFilePath = "C:\\Users\\Tavish\\Documents\\grademanagerlog.txt";

                //To add logs to our StringBuilder, which will be saved to our logfile later,
                //We will call log.Append("log message") for building out a single-line log message
                //or we will call log.AppendLine("log message") for line-by-line logging. This will be what we will call most of the time.
                //For timestamps, we will interpolate DateTime.Now for each log message

                log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - Starting GradeManager application.");
                Console.WriteLine(applicationName); //Print application name on first line
                Console.WriteLine(new String('-', applicationName.Length)); //Print line on name equal to length of application name. This is a dynamically-built string. We are creating a String object, calling the String class constructor with the new keyword. It is accepting two parameters, the first is a character to print, the second is an integer representing the count of characters to build the string. The Length property on the applicationName string gives us the integer count of applicationName so the count of dashes matches the length of the title.
                Console.WriteLine('\n'); // Create 2 blank lines to start menu. WriteLine method call does first blank line, extra '\n' (newline character) creates second blank line (like hitting Enter twice on a keyboard).

                // Check for students to load
                if (File.Exists(studentsJsonPath)) // Check if the student json exists
                {
                    log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - Loading file {studentsJsonPath} to check for students.");
                    var studentsJsonFile = File.Open(studentsJsonPath, FileMode.Open); // Open the file in memory if it exists in the specified file path.
                    log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - File {studentsJsonPath} is {studentsJsonFile.Length} bytes in size.");

                    if (studentsJsonFile.Length > 0 ) // Check if the file contains data (greater than 0 bytes in size), if it does, ask to load the file. 
                    {
                        studentsJsonFile.Close(); // Close the file as data checking is now done.
                        Console.Write("Do you want to load the existing saved Students file? (Y/N)");
                        string choice = Console.ReadLine().Trim(); // ReadLine reads input, the additional Trim call eliminates any whitespace from the input.

                        if (choice.ToUpper() == "Y") // ToUpper method changes any y or Y to Y.
                        {
                            log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - Closing file {studentsJsonPath} after student checking");
                            log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - Loading student JSON data.");
                            LoadStudents(); // Call Load Students
                        }
                        
                    }

                    

                }

                // If no students loaded from file, create new students
                if (students == null || students.Count == 0) 
                {
                    log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - Creating students...");

                    students = new List<Student>()
                    {
                        new Student("Tavish", "Misra"), // Student 0 (student number is index (position) number in the List)
                        new Student("Jibreel", "Muhammad"), //Student 1
                        new Student("Hassan", "Fofana"),  // Student 2
                        new Student("Jarvis", "Potter"), // Student 3
                        new Student("Greg", "Leeker") // Student 4
                    }; // Create a List of students and instantiate (create) the students from the start.
                       // We call the new keyword on each Student object in the List because each Student object must be created.


                    //Log created students after students list creation with names and timestamps

                    foreach (var student in students)
                    {
                        log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - Student {student.FirstName} {student.LastName} created.");
                    }
                }




                while (!exit) // Keep menu running after each studentChoice until application is exited. !exit checks for false (! is not operator, checks for opposite of what the current boolean value is), exit checks for true
                {
                    log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - Main Menu invoked.");
                    Menu();
                }

                // On application exit, write terminate message to logs, write log file, and end.
                log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - User Application Exit. Goodbye.");
                File.AppendAllText(logFilePath, log.ToString()); //AppendAllText rather than WriteAllText to avoid overwriting the log file each time GradeManager is run
                Console.WriteLine($"Log file written to {logFilePath}");
            }

            catch (Exception ex)
            {
                log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - Error: {ex.ToString()}");

                // Write the log file
                File.AppendAllText(logFilePath, log.ToString());
                Console.WriteLine($"Log file written to {logFilePath}");
                return; // Exit the application on any uncaught downstream Exception
            }
            
        }

        // Methods for features. We can make these private rather than public because we are not calling these methods outside of this class.

        private static void Menu()
        {
            try // For exception handling. The code in the try block will "try" to execute without fatal errors (errors that cause exceptions).
                // Fatal errors are errors which crash the application (not necessarily logical errors i.e. an error in coding which creates a behavior that is unexpected).
                // Fatal errors throw exceptions because the application does not have a path forward to continue running given the condition that caused the fatal error.
                // So we need to "handle" the exception, handling the fatal error in a way in which the application will not crash when the error occurs.
                // When the exception is handled, code in the "catch" block below is executed, as that code in the block serves as a path forward to continue running the application. 
                // This code handles a FormatException. If we try to enter a choice that is not a numeric character that can be parsed to an integer (such as a letter),
                // the catch block contains code which prints "Invalid input, try again" to prompt the user again to enter a numeric input in lieu of the application crashing.

            {
                Console.WriteLine("1. Print all student grades.");
                Console.WriteLine("2. Add student grade.");
                Console.WriteLine("3. Calculate Class Average");
                Console.WriteLine("4. Print highest grade");
                Console.WriteLine("5. Print lowest grade");
                Console.WriteLine("6. Delete Student");
                Console.WriteLine("7. Edit student grade");
                Console.WriteLine("8. Save all students to file.");
                Console.WriteLine("9. Load all students from file.");
                Console.WriteLine("10. Exit");
                Console.WriteLine("\n"); //Line break
                Console.Write("Enter a menu option (number): "); //See User Input code from Week 1

                string choiceInput = Console.ReadLine(); //Keyboard input is always a string
                int choice = int.Parse(choiceInput); //We use int's (Integer) Parse method to convert the string into an integer. If you don't enter an integer, program will crash without exception handling which we will cover later.

                // Menu choices in a Console application are typically driven by a switch-case code block
                // See https://www.w3schools.com/cs/cs_switch.php or https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements

                switch (choice)
                {
                    case 1:
                        PrintStudentGrades(); // Call PrintStudentGrades method for 1st studentChoice.
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
                        SaveStudents();
                        break;
                    case 9:
                        LoadStudents(); //Loaded students from file will be returned via LoadStudents method and assigned to students variable.
                        break;
                    case 10:
                        Exit();
                        break;
                    default: //Execute default case, if studentChoice does not match any of the cases. We add no code and just put break statement which will end the switch block.
                        break;
                }
            }
            catch (FormatException ex)
            {
                log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - Exception Thrown - {ex.Message}");
                Console.WriteLine("\nInvalid input, try again.\n");
            }
            
            
        }

        private static void SaveStudents()
        {
            // Serialize the students List object to a string using Newtonsoft.Json. The resulting string will be JSON Text.
            var studentsJson = JsonConvert.SerializeObject(students, Formatting.Indented);

            //Write the JSON string to a file
            File.WriteAllText(studentsJsonPath, studentsJson);
            log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - Students saved to {studentsJsonPath}.");
        }

        private static void LoadStudents()
        {
            try
            {
                var json = File.ReadAllText(studentsJsonPath); // Load JSON text from file
                students = JsonConvert.DeserializeObject<List<Student>>(json); // Convert JSON text back to object
                log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - Students loaded successfully from file {studentsJsonPath}.");
            }

            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                log.AppendLine($"Error: {ex.Message}");
            }
            
        }

        private static void PrintStudentGrades()
        {
            log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - PrintStudentGrades called.");
            string header = "Student Name        Grade";
            Console.WriteLine(header);
            Console.WriteLine(new String('-', header.Length) + '\n'); // Create a new string of dashes that is the length of the header

            //Check if there are existing students, if so, print their grades. If not, say there are no students.

            if (students != null && students.Count > 0) // Students list exists in memory AND contains students. || means "or". && means "and".
            {
                //Print the student grades
                foreach (var student in students)
                {
                    var studentGradeList = student.Grades;  // Get the student grade list

                    // Log the grade count for the student if they have grades
                    if (studentGradeList.Count > 0)
                    {
                        log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - {studentGradeList.Count} grades found for student {student.FirstName} {student.LastName}");
                    }
                    

                    // Print the grades if they exist, if not, say no grades

                    if (studentGradeList != null && studentGradeList.Count > 0) // Student grade list exists in memory AND contains grades
                    {
                        foreach (var grade in studentGradeList)
                        {
                            Console.WriteLine($"{student.FirstName} {student.LastName}        {grade}");
                        }

                        Console.WriteLine(string.Empty); // Add line break after student list
                    }

                    else
                    {
                        log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - No grades found for student {student.FirstName} {student.LastName}.");
                        Console.WriteLine($"{student.FirstName} {student.LastName}        No Grades");
                    }

                    
                }

                Console.WriteLine(string.Empty);
            }

            else
            {
                // Log and print the no students message
                var noStudentsMessage = "\nThere are no students in the system.\n";
                log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - {noStudentsMessage}");
                Console.WriteLine(noStudentsMessage);
            }
            
            
        }

        private static void AddStudentGrade()
        {
            log.AppendFormat("{0} - AddStudentGrade called\n", DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")); //Add timestamp to log by parameter, may be more readable in certain circumstances.

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

                string studentChoiceFirstName = students[studentChoice].FirstName; //Access student from list. Format listVariableName[indexNumber]
                string studentChoiceLastName = students[studentChoice].LastName;

                // Log the selected student
                log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - Student {studentChoiceFirstName} {studentChoiceLastName} selected to add grade for.");

                //Capture student grade from keyboard input and parse to int
                Console.Write($"Enter grade for student {studentChoiceFirstName} {studentChoiceLastName}: ");
                string gradeInput = Console.ReadLine();
                double grade = double.Parse(gradeInput);

                //Add the grade to the student grade list
                students[studentChoice].Grades.Add(grade);
                log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - Grade {grade} added for student {studentChoiceFirstName} {studentChoiceLastName}.");
            }

            else
            {
                var noStudentsMessage = "\nThere are no students in the system.\n";
                log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - {noStudentsMessage}");
                Console.WriteLine(noStudentsMessage);
            }
        }

        private static void CalculateClassAverage()
        {
            log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - CalculateClassAverage called.");
            // Take each student grade and average them all out.

            // For each student, we want to add all the grades to one value and keep track of the total grade count
            // as well as the sum, as the class average would be total grade count / sum.

            double average = 0;
            double gradeSum = 0;
            int gradeCount = 0;

            // Loop through all the students
            foreach (var student in students)
            {
                //Compute individual averages to save to file. Since individual grades will be saved to file,
                // Class average can be computed when loading from file.

                log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - Computing average for student {student.FirstName} {student.LastName}.");
                student.ComputeAverage(); // Compute the individual average for each student

                // For each student, get each grade, add it to the gradeSum, and increment the gradeCount each time.

                log.AppendLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} - Computing Class Average...");
                foreach (var grade in student.Grades)
                {
                    gradeSum += grade; // Adding the grade to the gradeSum
                    gradeCount++; // Increasing the grade count by 1.
                }
            }

            // When student completes, compute the average
            // If there are no students or no grades, compute as zero
            // If we do not do this check with no students or no grades,
            // we will get a divide by zero error.

            if (gradeCount == 0) // No need for explicit student check here, as if there are no students, then gradeCount will remain 0.
            {
                average = 0;
            }

            else
            {
                average = gradeSum / gradeCount;
            }

            // Print the class average

            Console.WriteLine($"\nThe class average is {average}.\n");
        }

        private static void PrintHighestGrade()
        {
            double maxGrade = 0; //Create a variable called maxGrade to hold the current maxGrade as we loop through all the grades.
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
            double minGrade = 0; //Create a variable called minGrade to hold the current minGrade as we loop through all the grades.
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
            if (students != null && students.Count > 0)
            {
                Console.WriteLine("\nWhich student do you want to delete?\n");
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

                Console.WriteLine($"\nStudent {studentName} Deleted\n");
            }

            else
            {
                Console.WriteLine("No students to delete");
            }
            
        }

        private static void EditStudentGrade()
        {
            // Check for students

            if (students != null && students.Count > 0)
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

                //Check for grades

                if (studentChoiceObject.Grades.Count > 0)
                {
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

                    // Update the grade in the list: gradeChoice is the numeric (integer) position in the list of grades.
                    // When the integer is inside of the [] of the Grades list, it represents the value of the grade at that numeric position.
                    // Assigning newGrade with = replaces the value at that position with the new grade.
                    studentChoiceObject.Grades[gradeChoice] = newGrade;

                    // We have now updated the studentChoiceObject with the new grade,
                    // but we also have to update the main students list with the updated studentChoiceObject that has the new grade.
                    // Do the same here like above.
                    students[studentChoice] = studentChoiceObject;
                }

                else
                {
                    Console.WriteLine($"Student {studentChoiceObject.FirstName} {studentChoiceObject.LastName} has no grades.");
                }
                
            }

            else
            {
                Console.WriteLine("\nThere are no students for which to edit grades.\n");
            }
           

        }

        private static void Exit()
        {
            Console.Write("Do you want to save student data to file? (Y/N) ");
            var choice = Console.ReadLine().Trim();

            if (choice.ToUpper() == "Y")
            {
                SaveStudents();
            }

            Console.WriteLine("Good Bye!");
            exit = true; //Set exit to true so application will exit.
        }
    }
}
