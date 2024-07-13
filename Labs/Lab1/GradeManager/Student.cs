using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeManager
{
    public class Student
    {
        private string _firstName {  get; set; } //Private field names should start with underscore (_)
        private string _lastName { get; set; }

        // Constructors: See Constructor section in Week1 code for more info

        public Student()
        {
            // Default constructor - No arguments/parameters and no code
        }

        public Student(string firstName, string lastName)
        {
            //Parameterized constructor, accepts arguments as parameters (in this case, 2 strings are being accepted as arguments)

            _firstName = firstName; //Set the private field via the parameter passed into public constructor
            _lastName = lastName;
        }

        // Getters and setters
        // Setter methods can be void as no return value is needed.
        // We will not use the static keyword on these methods as we are not using these methods inside of the Student class, but rather outside of the class when a Student object is created with the new keyword.
        // See Week1 powerpoint and code on Classes
        public void setFirstName(string firstName) //Parameter for set, because we are passing this data into the method 
        {
            _firstName = firstName;
        }

        public string getFirstName() // Return private _firstName value via public accessor method. Return type "string" needed here as we are returning the string value in _firstName.
        {                            // No parameters here because we are instead returning data from the method rather than passing data into the method.
            return _firstName; // return statement sends this data out of the method when the method is called. Typically you can assign to a string variable this method call like you would a value.
        }                      // i,e. from GradeManager: string firstName = studentname.getFirstName(), same like string FirstName = "First Name"

        public void setLastName(string lastName)
        {
            _lastName = lastName;
        }

        public string getLastName()
        {
            return _lastName;
        }
    }

    

   
}
