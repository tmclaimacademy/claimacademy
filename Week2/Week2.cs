﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
            //StringBuilder sb = new StringBuilder();

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

            //Tuple<int, string> t1 = new Tuple<int, string>(1, "Tavish");

            //Console.WriteLine($"ID is {t1.Item1} and Name is {t1.Item2}");

            // Declare multiple ints

            //int a, b, c, d, e, f; // 6 ints
                                  // This is the same as
                                  // int a; // Declaration
                                  // int b;
                                  // int c;
                                  // int d;
                                  // int e;
                                  // int f;
                                  // You can assign all these on one statement, but can only assign a single value on one statement.

           // a = b = c = d = e = f = 1; // All 6 int variables are now equal to 1.
                                       // This is the same as
                                       // int a = 1; //Assignment
                                       // int b = 1;
                                       // int c = 1;
                                       // int d = 1;
                                       // int e = 1;
                                       // int f = 1;
                                       // However, if the 6 ints need to be separate values, then this must be done on separate statements.
            int g = 1;
            int h = 2;
            int i = 3;
            int j = 4;
            int k = 5;
            int l = 6;

            // Operators
            // Addition
            double a = 7;
            double b = 1.5;
            double c = a + b; // We are adding the 7 in a with the 1.5 in b --> 7 + 1.5 = 8.5, and then the 8.5 is assigned to c, which is also already declared in the statement.

            a += 2.5; // This is the same as doing a = a + 2.5. We are adding 2.5 to the value currently in a, which is 7 --> 7 + 2.5 = 9.5.
                      // We then replace the value of 7 in a with the new 9.5 value we got from adding, and replace it by assigning it to a.
                      // Subtraction
                      // a and b are already declared above, but we will reset them to 7 and 1.5 by assigning these back to a and b.
            a = 7;
            b = 1.5;

            // c is also declared above so we will just do the subtraction without declaring c again.
            
            c = a - b; // We are subtracting b (1.5) from a (7) --> 7 - 1.5 = 5.5. 5.5 is then being assigned to c.

            a -= 2.5; // This is the same as a = a - 2.5. We are subtracting 2.5 from a (7) --> 7 - 2.5 = 4.5.
                      // 4.5 is then replacing the old value of 7 in a by assignment (a = 4.5)

            // Multiplication

            // We are changing the values of a and b to 7 and 3 respectively
            a = 7;
            b = 3;

            c = a * b; // We are multiplying a (7) by b (3) --> 7 * 3 = 21
                       // 21 is the being assigned back to c (c = 21)
            a *= 3; // This is the same as a = a * 3. We are multiplying a (7) times 3 --> 7 * 3 = 21
                    // We are then replacing the old value of a (7) by assigning the new computed value of 21 back to a (a = 21)

            // Division

            // We will assign the values of a and b to 7 and 2 respectively

            a = 7;
            b = 2;
            c = a / b; // We will then divide a and b and assign the result to c. 7/2 = 3
                       // Since a and b are both ints, c will also be an int and so will be a whole number
                       // 7 / 2 is supposed to be 3.5, but it does not round up to 4. The int is whatever
                       // the whole number portion of the result would be, in this case with 3.5, it will
                       // be 3.
                       // To get the appropriate result of 3.5 when dividing 7 by 2, one or both of a or b must be a double.
                       // i.e. int a = 7; double b = 2; OR double a = 7; int b = 2 OR double a = 7; double b = 2;
                       // Modulus
                       // The Modulus operator (%) will give the remainder of a division operation
                       // i.e. 7 % 2 = 1 because dividing 7 by 2, we would have 3 remainder 1. (long division)
            /*
                 3
             2 |---
               | 7
               |-6
               ---
                1 <-- result of modulus operation of 7 and 2 (7 % 2 == 1)


             */

            // Modulus demonstration

            // We can use modulus to determinine even or odd numbers
            // If a number is even, it has a modulus of 0 because dividing an even number by 2 always results in a remainder of 0.
            // If a number is odd, it has a modulus of 1 because dividing an odd number by 2 will always results in a remainder of 1.

            //bool isEven = false;
            //bool isOdd = false; // Set isEven and isOdd to false by default because modulus should prove a number to be odd or even.
            // Proving the odd or even with the modulus check would then make it true.
            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //foreach (int number in numbers)
            //{
            //    if (number % 2 == 0) // If the number divided by 2 results in remainder 0, the number is even
            //    {
            //        Console.WriteLine($"The number {number} is even.");
            //    }

            //    else // If the number divided by 2 is not 0, it is odd. The modulus of a number and 2 can only be 0 or 1.
            //    {
            //        Console.WriteLine($"The number {number} is odd");
            //    }
            //}

            // Increment operator

            // ++ as a suffix means the number is incremented after the operation on that line

            a = 5;

            Console.WriteLine($"Suffix a: {a} and b: {a++} "); //On suffix, a and b are both 5 here because in b, a is being printed before it is incremented
            
            a = 5; //Reset a to 5 for prefix demo

            Console.WriteLine($"Prefix a: {a} and b: {++a} "); //On prefix, a will be 5 and b will be 6 because with the ++ before the a, it will increment first and print second.

            //Type casting

            // Explicit cast
            int t = 32;
            long v = t;

            // Implicit cast
            long x = 32;
            int y;
            y = (int)x;









            Console.Read(); // Leave Console window open until key press
        }
    }
}