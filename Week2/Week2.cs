using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week2
{
    public class Week2
    {
        public static void Main(string[] args)
        {
            // StringBuilder Demo

            // Create a StringBuilder
            //Console.WriteLine("Creating StringBuilder");
            StringBuilder sb = new StringBuilder();

            //sb.Append("Hello World "); // Appends a string without a new line character
            //sb.AppendLine("Hello World with new line character."); // Appends a string with a new line, i.e. typing something and pressing Enter for the next line.
            //sb.Append("New line starts here");
            //// To convert the StringBuilder object (which is just a memory object to hold the string) to an actual String, we call the ToString method.

            //string sbText = sb.ToString();

            //// Every object in C# has a ToString method, because the parent class of every C# class is Object. And Object as a ToString method.

            //// After converting the StringBuilder to a string, we will print whatever text with one call to Console.Write.

            //Console.Write(sbText);

            // Writing multiple records to a file, each line in a file is a record, each piece of data in the record
            // is separated by a "delimiter", a character which separates each piece of data in the record
            // Delimiters can be commas, pipes (|), tabs (  ) represented by \t in C# code.

            // We are writing 10000 patients to a file, tab-delimited

            //Random Number Generator

            //Console.WriteLine("Generate Medical Records");
            //var random = new Random(); // Create a Random Number Generator

            //for (int i = 0; i < 10000; i++)
            //{
            //    var code = random.Next(1000, 9999); // Create a new random 4-digit number
            //    sb.AppendLine($"Patient number {i}: FirstName-{i}\tLastName-{i}\tMedical Code: {code}");
            //}

            //Console.WriteLine("Save Medical Records");
            //var contents = sb.ToString(); //Turn our 10000 records into a string
            //File.WriteAllText("C:\\Users\\Tavish\\Documents\\medicalrecords.txt", contents); // Write contents to the file path
            //Console.WriteLine("Done!");

            //DateTimes

            // DateTime is a C# Class, giving us DateTime functionality. A DateTime is simply MM/dd/yyyy HH:mm:ss AM/PM.
            // DateTimes are unique to the second.

            //Current DateTime can be obtained by calling DateTime.Now()

            //var now = DateTime.Now; // Capture current datetime to variable. DateTime will be whatever datetime is when it is assigned to now.

            //Console.WriteLine(now);

            // Print the current datetime each second

            //while (true) // Call infinite loop to keep going
            //{
            //    Console.WriteLine(DateTime.Now);
            //    Thread.Sleep(1000); // Pause execution for 1000 ms or 1 s.
            //}

            // Create a specific DateTime

            //var dt1 = new DateTime(2024, 07, 23); // Create a new DateTime object for 7/23/2024 12:00 AM.
            //Console.WriteLine($"DateTime dt1 is {dt1}");
            //var dt2 = new DateTime(2024, 08, 01, 09, 00, 00); //Create a DateTime object for 8/1/2024 9:00 AM.
            //Console.WriteLine($"DateTime dt2 is {dt2}");
            //var dt3 = new DateTime(2024, 08, 15, 15, 30, 00); // 08/15/2024 3:30 PM
            //Console.WriteLine($"DateTime dt3 is {dt3}");

            //Console.WriteLine("Adding 1 day to dt1");
            //dt1 = dt1.AddDays(1); //Add 1 Day to the dt1 DateTime and reassign to dt1. 
            //                      // AddDays is not a void method, it returns a new DateTime so must be re-assigned to dt1 for the new DateTime.
            //Console.WriteLine($"DateTime dt1 is now {dt1}");

            //Console.WriteLine("Adding 1 month to dt2");
            //dt2 = dt2.AddMonths(1);
            //Console.WriteLine($"DateTime dt2 is now {dt2}");

            //Console.WriteLine("Adding 1 hour to dt3");
            //dt3 = dt3.AddHours(1);
            //Console.WriteLine($"DateTime dt3 is now {dt3}");

            //// Computing a difference between DateTimes
            //var dtdiff = dt3 - dt1;
            //Console.WriteLine($"The time span between {dt3} and {dt1} is {dtdiff.TotalDays} days.");

            //enum

            //Console.WriteLine("Enums");
            //Console.WriteLine($"Male is {Gender.Male}");
            //Console.WriteLine($"Female is {Gender.Female}");

            ////Guid - A unique identifer generated randomly by Windows. GUID is Microsoft and Windows specific
            //// Generally known else as UUID (Unique Universal Identifier) GUID is Global Unique Identifer.

            //var guid = Guid.NewGuid();
            //Console.WriteLine($"New GUID is {guid.ToString()}");

            // Tuples - Tuples are groups of 2 or 3 data values that you can put in a variable

            Tuple<int, string> t1 = new Tuple<int, string>(1, "Tavish");

            Console.WriteLine($"ID is {t1.Item1} and Name is {t1.Item2}");

            

            


            Console.Read(); // Leave Console window open until key press
        }
    }
}
