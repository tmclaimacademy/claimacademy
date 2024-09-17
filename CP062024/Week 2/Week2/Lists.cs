using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    public class Lists
    {
        //Create a new list - Empty List
        static List<Person> persons = new List<Person>(); // Global variable to Lists class

        public void Run()
        {
            //Verify an empty list
            // persons != null ensures the list variable exists in memory. We did this by creating the new list above.
            // persons.Any() returns true if the list contains any entries or false if it contains no entries.
            // We do both checks as both checks must pass before we can do any read operations the list (i.e. loop through list, access an entry, etc)
            // Because both checks must pass, we use && (AND) on the if check below.

            // Add a name by the Add method
            persons.Add
                (
                    new Person
                    {
                        Name = "Manav",
                        Bounty = 25000
                    }
                );

            persons.Add
                (
                    new Person
                    {
                        Name = "Jack",
                        Bounty = 10000
                    }
                );

            

            // Print the initial list of persons - No names because we haven't added anything yet
            PrintNames();

            // Add the new name as a Person object to the persons list

            try
            {
                // Add name example
                Console.Write("Please type a name to add: ");
                string name = Console.ReadLine(); // Temp to store the name before we add it to the list
                Console.Write("Enter a bounty: ");
                long bounty = long.Parse(Console.ReadLine());

                persons.Add // Create the person and add to the Persons list in one operation
                (
                    new Person // Create the person object, setting the name and bounty we took from above
                    {
                        Name = name,
                        Bounty = bounty
                    }
                );

                Console.WriteLine($"Person {name} created with starting bounty ${bounty}.");
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            PrintNames();

            // Lookup example
            Console.Write("Enter a name to find: ");
            string nameToFind = Console.ReadLine();

            //Trim and Upper Case the temp nameToFind
            nameToFind = nameToFind.Trim();
            nameToFind = nameToFind.ToUpper();

            foreach (Person person in persons)
            {
                if (person.Name.Trim().ToUpper() == nameToFind)
                {
                    Console.WriteLine($"Person found: {person.Name} - ${person.Bounty}");
                    break; // Once we find the person, terminate the foreach loop with a break statement
                }
            }

            



            // Find a name and remove the name from the List
            Console.Write("Find a name to remove from the list: ");
            string nameToRemove = Console.ReadLine(); // Take in the name to remove

            // Trim any whitespace from the name input
            nameToRemove = nameToRemove.Trim();

            // Loop through the list and find the name

            if (persons != null && persons.Any())
            {
                foreach (Person person in persons)
                {
                    if (person.Name.ToUpper().Equals(nameToRemove.ToUpper()))
                    {
                        persons.Remove(person);
                        Console.WriteLine($"Name {nameToRemove} has been removed from the list.");
                        break; // Do not continue searching for persons once the name has been found and removed.
                    }
                }
            }

            else
            {
                Console.WriteLine("Name not found.");
            }

            PrintNames();
        }

        static void PrintNames()
        {
            if (persons != null && persons.Any())
            {
                int i = 1; // To number the persons when we print the list of persons. Start from 1 because lists read by humans should start from 1 rather than 0.

                foreach (Person person in persons)
                {
                    Console.WriteLine($"{i}. Name: {person.Name} Bounty: ${person.Bounty}.");
                    i++; // Increase the number before printing the next name
                }

                i = 1; // After printing all the persons, reset i to 1.
            }

            else
            {
                Console.WriteLine("No persons in the list."); // Should print because we have not yet added any persons.
            }
        }


    }
}
