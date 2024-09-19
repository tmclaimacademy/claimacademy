using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace PhoneBook
{
    public class Program
    {
        // Exit boolean to control exit behavior. false means default behavior to keep running, when true, application will exit
        static bool exit = false;

        // Create the contactList, at this stage, it is empty
        static List<Contact> contactList = new List<Contact>();
        static void Main(string[] args)
        {
            try
            {
                // Call the Menu method to start, encapsulate this in try-catch to catch any exception the application may throw that would not be handled downstream
                Menu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void Menu()
        {
            while (!exit) // !exit = exit is false, ! is not which negates this, so the check is for "not false" which is true
            {
                // Menu prints
                Console.WriteLine("PhoneBook");
                Console.WriteLine($"---------{Environment.NewLine}");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Lookup Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Display All Contacts");
                Console.WriteLine("5. Save Contacts To File");
                Console.WriteLine("6. Load Contacts From File");
                Console.WriteLine("7. Exit");
                Console.WriteLine(Environment.NewLine);

                try
                {
                    // After menu prints, wait for menu choice with this block of code here
                    // Console.ReadLine() is string input from keyboard, which is also inside int.Parse
                    // so the input will be taken and then parsed in one step.
                    var choice = int.Parse(Console.ReadLine());

                    // Take the menu choice and execute the case that corresponds with the choice

                    switch(choice)
                    {
                        case 1:
                            AddContact();
                            Console.WriteLine(); // Blank Console.WriteLine is for a line break so console output looks cleaner
                            break;

                        case 2:
                            LookupContact();
                            Console.WriteLine();
                            break;

                        case 3:
                            DeleteContact();
                            Console.WriteLine();
                            break;

                        case 4:
                            DisplayAllContacts();
                            Console.WriteLine();
                            break;

                        case 5:
                            SaveContacts();
                            Console.WriteLine();
                            break;

                        case 6:
                            LoadContacts();
                            Console.WriteLine();
                            break;

                        case 7:
                            Exit();
                            Console.WriteLine();
                            break;

                        default:
                            break;

                    }
                }
                catch(FormatException ex)
                {
                    Console.WriteLine($"{Environment.NewLine}Invalid Choice, try again.{Environment.NewLine}");
                    continue;
                }
            }
        }

        static void AddContact()
        {
            // Enclose in try block, to catch InvalidPhoneNumberException below
            try
            {
                // Take First Name and assign to temp variable to save to new Contact later to add to list.
                Console.Write("Enter Contact First Name: ");
                var firstName = Console.ReadLine();
                // Trim firstName temp to get rid of any whitespace around the text representing the first name.
                firstName = firstName.Trim();

                // Take Last Name and assign to temp variable to save to new Contact later to add to list.
                Console.Write("Enter Contact Last Name: ");
                var lastName = Console.ReadLine();

                // Trim lastName temp to get rid of any whitespace around the text representing the last name.
                lastName = lastName.Trim();

                // Enter country code, capture in temp countryCode variable, trim so that the length only equals what was entered by user
                // Use int.TryParse to verify only numbers entered (if any non-number characters are entered, this TryParse will fail with InvalidPhoneNumberException)

                Console.Write("Enter Contact Country Code (Max 3 digits): ");
                var countryCode = Console.ReadLine();
                countryCode = countryCode.Trim();
                if (int.TryParse(countryCode, out int countryCodeInt)) // TryParse is a bool, will return false if the parse fails, if true, will assign parsed output to the out variable declared (this out parameter is required).
                {
                    if (countryCode.Length > 3) // Check if country code is greater than 3 digits, if it is, throw the InvalidPhoneNumber exception
                    {
                        throw new InvalidPhoneNumberException("Invalid Phone Number, try adding the contact again.");
                    }

                    else // Else, if the country code is valid, continue executing with the code below
                    {
                        // Collect the Phone Number, save in temporary phoneNumber variable, trim to get rid of white space
                        Console.Write("Enter Contact Phone Number (after Country Code): ");
                        var phoneNumber = Console.ReadLine();
                        phoneNumber = phoneNumber.Trim();

                        // Validate the phone number, we are using long here rather than int because int is good for only 10 digits,
                        // so long will accommodate much larger numbers for phone numbers.
                        if (long.TryParse(phoneNumber, out long phoneNumberLong)) // Same as country code, if TryParse fails, InvalidPhoneNumberException thrown, else we assign phoneNumber to phoneNumberLong
                        {
                            phoneNumber = string.Concat("+", countryCode, phoneNumber); // Concatenate (put together) the + for the phone number, country code, and phone number itself
                        }

                        else // If the phone number is not good, then throw the InvalidPhoneNumberException for the phone number portion, just like with the country code portion above.
                        {
                            throw new InvalidPhoneNumberException("Invalid Phone Number, try adding the contact again.");
                        }

                        // At this point, we have checked the 3 required pieces of data for the Contact and have validated all of it
                        // So now we can take the 3 temp variables, create the new contact, and add it to the list all in one operation.
                        contactList.Add
                        (
                            new Contact
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                PhoneNumber = phoneNumber
                            }
                        );

                        Console.WriteLine($"{Environment.NewLine}Contact {firstName} {lastName} successfully added.");
                    }
                }

                else
                {
                    throw new InvalidPhoneNumberException($"{Environment.NewLine}Invalid Phone Number, try adding the contact again.");
                }
            }
            catch(InvalidPhoneNumberException ex)
            {
                // Catch InvalidPhoneNumber exception thrown above, print the exception message, return ends the method and goes back to the Menu.
                Console.WriteLine($"{Environment.NewLine}{ex.Message}");
                return;
            }

        }

        static void LookupContact()
        {
            // Check if the contactList exists (if a new contactList was created with new keyword)
            // AND if the contactList has any contacts in it
            // Both conditions must be true to lookup any contacts in the list
            if (contactList != null && contactList.Any())
            {
                Console.Write("Enter First Name to lookup: ");
                var firstName = Console.ReadLine();
                firstName = firstName.Trim(); // Trim to get rid of whitespace
                firstName = firstName.ToUpper(); //Upper Case the name to make lookup case insensitive, as what is in the list and what we are searching for will both be upper-cased to compare

                // Repeat with Last Name
                Console.Write("Enter Last Name to lookup: ");
                var lastName = Console.ReadLine();
                lastName = lastName.Trim();
                lastName = lastName.ToUpper();

                //Once we capture the first name and last name in temp variables, loop through the list to look for a matching entry
                foreach (var contact in contactList)
                {
                    // Match the trimmed and UpperCased (case-insensitive) input from above with the entry in the list, if there is a match
                    // on both first and last name, print out the below, and end the method with return statement as a match has been found,
                    // because no further searching is needed because a match has been found.
                    if (contact.FirstName.Trim().ToUpper().Equals(firstName) && contact.LastName.Trim().ToUpper().Equals(lastName))
                    {
                        Console.WriteLine($"Contact Found: {Environment.NewLine}");
                        Console.WriteLine($"First Name: {contact.FirstName}");
                        Console.WriteLine($"Last Name: {contact.LastName}");
                        Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                        Console.WriteLine(Environment.NewLine);
                        return;
                    }
                }

                // If nothing is found in the list, the foreach will complete without a match and this is now the next line to be executed.
                // If the foreach completes, then this means a contact wasn't found, so then print "Contact Not Found" and then end the method with return.
                Console.WriteLine($"Contact Not Found.{Environment.NewLine}");
                return;
            }

            // From the start of the method, if the contactList doesn't exist or is empty, then print this message.
            // No return statement needed as this is already the end of the method.
            Console.WriteLine("No contacts in Phonebook");
        }

        static void DeleteContact()
        {
            // Do the list exists and empty check like in Lookuup
            if (contactList != null && contactList.Any())
            {
                // List contacts by number, add 1 to the printed number because list starts from 0
                Console.WriteLine($"Select a contact to delete:{Environment.NewLine}");

                for (int i = 0; i < contactList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {contactList[i].FirstName} {contactList[i].LastName}");
                }

                try
                {
                    // Take the choice
                    var choice = int.Parse(Console.ReadLine());

                    // Extract the contact from the list by array index, subtracting 1 from the choice to select the appropriate contact based on the index number, which starts from 0.
                    var contact = contactList[choice - 1];
                    contactList.Remove(contact);
                    Console.WriteLine($"Contact {contact.FirstName} {contact.LastName} deleted.{Environment.NewLine}");
                }
                // Catch exception based on what type of exce[tion
                // FormatException for when we enter a letter for a number
                // IndexOutOfRangeException when we enter a number not in the list (i.e. Contact list is 5 contacts but we enter 8 instead)
                catch(Exception ex) when (ex is FormatException || ex is IndexOutOfRangeException)
                {
                    Console.WriteLine($"Invalid input.{Environment.NewLine}");
                }
            }

            // If contactList doesn't exist (null) or is empty, then proint "No contacts to delete" and go back to Menu.
            else
            {
                Console.WriteLine($"No contacts to delete.{Environment.NewLine}");
            }
        }

        static void DisplayAllContacts()
        {
            // Do the same check as above
            if (contactList != null && contactList.Any())
            {
                // List all the contacts based on startin from 1 rather than 0 and print First Name, Last Name, Phone number separated bv tabs (\t)
                for (int i = 0; i < contactList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {contactList[i].FirstName}\t{contactList[i].LastName}\t{contactList[i].PhoneNumber}");
                }
            }

            else // If non-existant or empty, print the message below.
            {
                Console.WriteLine("No contacts to display.");
            }
        }

        static void SaveContacts()
        {
            // Define directory
            string directory = "C:\\Users\\Tavish\\Documents";

            // Define filename
            string filename = "contactlist.json";

            // Create file path based on directory and file name
            string path = Path.Combine(directory, filename);

            // Convert the contact list in memory to JSON text, indented
            var json = JsonConvert.SerializeObject(contactList, Formatting.Indented);

            // Write the indented JSON text to the file defined by the path
            File.WriteAllText(path, json);

            // Confirm save
            Console.WriteLine($"Contact List successfully saved to {path}");
        }

        static void LoadContacts()
        {
            // Define directory, file name, and path
            string directory = "C:\\Users\\Tavish\\Documents";
            string filename = "contactlist.json";
            string path = Path.Combine(directory, filename);

            // Read the JSON text from the file and save in a temp string
            string json = File.ReadAllText(path);

            // Conver the JSON text back into the contactList in memory (defining List<Contact> as .NET doesn't know data type from JSON file)
            contactList = JsonConvert.DeserializeObject<List<Contact>>(json);

            // Confirm load
            Console.WriteLine($"Contact List successfully loaded from {path}");
        }

        static void Exit()
        {
            // Set exit to true to enable application behavior to exit
            exit = true;
            Console.WriteLine("Good bye! Press any key to exit.");
            Console.ReadKey();
        }
    }
}
