using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace PhoneBook
{
    public class Program
    {
        static bool exit = false;
        static List<Contact> contactList = new List<Contact>();
        static void Main(string[] args)
        {
            try
            {
                Menu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void Menu()
        {
            while (!exit)
            {
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
                    var choice = int.Parse(Console.ReadLine());

                    switch(choice)
                    {
                        case 1:
                            AddContact();
                            Console.WriteLine();
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
            try
            {
                Console.Write("Enter Contact First Name: ");
                var firstName = Console.ReadLine();
                firstName = firstName.Trim();
                Console.Write("Enter Contact Last Name: ");
                var lastName = Console.ReadLine();
                lastName = lastName.Trim();
                Console.Write("Enter Contact Country Code (Max 3 digits): ");
                var countryCode = Console.ReadLine();
                countryCode = countryCode.Trim();
                if (int.TryParse(countryCode, out int countryCodeInt))
                {
                    if (countryCode.Length > 3)
                    {
                        throw new InvalidPhoneNumberException("Invalid Phone Number, try adding the contact again.");
                    }

                    else
                    {
                        Console.Write("Enter Contact Phone Number (after Country Code): ");
                        var phoneNumber = Console.ReadLine();
                        phoneNumber = phoneNumber.Trim();

                        if (long.TryParse(phoneNumber, out long phoneNumberLong))
                        {
                            phoneNumber = string.Concat("+", countryCode, phoneNumber);
                        }

                        else
                        {
                            throw new InvalidPhoneNumberException("Invalid Phone Number, try adding the contact again.");
                        }

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
                Console.WriteLine($"{Environment.NewLine}{ex.Message}");
                return;
            }

        }

        static void LookupContact()
        {

            if (contactList != null && contactList.Any())
            {
                Console.Write("Enter First Name to lookup: ");
                var firstName = Console.ReadLine();
                firstName = firstName.Trim();
                firstName = firstName.ToUpper();

                Console.Write("Enter Last Name to lookup: ");
                var lastName = Console.ReadLine();
                lastName = lastName.Trim();
                lastName = lastName.ToUpper();

                foreach (var contact in contactList)
                {
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

                Console.WriteLine($"Contact Not Found.{Environment.NewLine}");
                return;
            }

            Console.WriteLine("No contacts in Phonebook");
        }

        static void DeleteContact()
        {
            if (contactList != null && contactList.Any())
            {
                Console.WriteLine($"Select a contact to delete:{Environment.NewLine}");

                for (int i = 0; i < contactList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {contactList[i].FirstName} {contactList[i].LastName}");
                }

                try
                {
                    var choice = int.Parse(Console.ReadLine());
                    var contact = contactList[choice - 1];
                    contactList.Remove(contact);
                    Console.WriteLine($"Contact {contact.FirstName} {contact.LastName} deleted.{Environment.NewLine}");
                }
                catch(Exception ex) when (ex is FormatException || ex is IndexOutOfRangeException)
                {
                    Console.WriteLine($"Invalid input.{Environment.NewLine}");
                }
            }

            else
            {
                Console.WriteLine($"No contacts to delete.{Environment.NewLine}");
            }
        }

        static void DisplayAllContacts()
        {
            if (contactList != null && contactList.Any())
            {
                for (int i = 0; i < contactList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {contactList[i].FirstName}\t{contactList[i].LastName}\t{contactList[i].PhoneNumber}");
                }
            }

            else
            {
                Console.WriteLine("No contacts to display.");
            }
        }

        static void SaveContacts()
        {
            string directory = "C:\\Users\\Tavish\\Documents";
            string filename = "contactlist.json";
            string path = Path.Combine(directory, filename);
            var json = JsonConvert.SerializeObject(contactList, Formatting.Indented);
            File.WriteAllText(path, json);
            Console.WriteLine($"Contact List successfully saved to {path}");
        }

        static void LoadContacts()
        {
            string directory = "C:\\Users\\Tavish\\Documents";
            string filename = "contactlist.json";
            string path = Path.Combine(directory, filename);
            string json = File.ReadAllText(path);
            contactList = JsonConvert.DeserializeObject<List<Contact>>(json);
            Console.WriteLine($"Contact List successfully loaded from {path}");
        }

        static void Exit()
        {
            exit = true;
            Console.WriteLine("Good bye! Press any key to exit.");
            Console.ReadKey();
        }
    }
}
