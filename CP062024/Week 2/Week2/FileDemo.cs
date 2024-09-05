using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    public class FileDemo
    {
        // Creates and writes a basic CSV file
        public void Run()
        {
            StringBuilder sb = new StringBuilder(); // StringBuilder to build text for the file
            string header = "Name,Number"; // CSV Header, required for first line of CSV
            sb.AppendLine(header); // Append (Add) the header as the first line

            while (true)
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter number: ");
                string number = Console.ReadLine();
                sb.AppendLine($"{name},{number}");
                Console.Write("Record added, do you want to add another? (Y/N)? ");
                string choice = Console.ReadLine();

                if (choice.ToUpper().Trim() != "Y")
                {
                    break; // If choice is not Y, then break the infinite while loop.
                }

                // After adding our records, we want to dump this to a CSV file.
                string records = sb.ToString(); // Take StringBuilder contents, change to a string, and save in records variable.
                File.WriteAllText("C:\\Users\\Tavish\\Documents\\records.csv", records); // Write records to the CSV file at the given path
            }
        }
    }
}
