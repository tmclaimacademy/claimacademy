using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeManager
{
    public class Student
    {
        public string FirstName {  get; set; } //Private field names should start with underscore (_)
        public string LastName { get; set; }

        public double Average { get; set; } = 0; // Default to 0
        public List<double> Grades = new List<double>(); //For lists, see: https://www.tutorialsteacher.com/csharp/csharp-list or https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-8.0

        // Constructors: See Constructor section in Week1 code for more info

        public Student()
        {
            // Default constructor - No arguments/parameters and no code
        }

        public Student(string firstName, string lastName)
        {
            //Parameterized constructor, accepts arguments as parameters (in this case, 2 strings are being accepted as arguments)

            FirstName = firstName; //Set the private field via the parameter passed into public constructor
            LastName = lastName;
        }

        // Getters and setters
        // Setter methods can be void as no return value is needed.
        // We will not use the static keyword on these methods as we are not using these methods inside of the Student class, but rather outside of the class when a Student object is created with the new keyword.
        // See Week1 powerpoint and code on Classes
        

        public void ComputeAverage()
        {
            double totalPoints = 0; // To keep track of total grade points to compute the average

            foreach (double grade in Grades) //See ForEach in Week1 code
            {
                totalPoints += grade; // Add up all the student points for the student. This is the same as totalPoints = totalPoints + grade;
            }

            // Compute the average
            int gradeCount = Grades.Count; // Gets the number of grades in the Grades List, assign it to an int variable called "gradeCount"

            Average = totalPoints / gradeCount; // Calculate the average by dividing total points by the number of grades.

        }

    }

    

   
}
