using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    public class Strings
    {
        public void Demo()
        {
            // More Strings

            //Compare Method - https://learn.microsoft.com/en-us/dotnet/api/system.string.compare?view=net-8.0

            string firstString = "Tavish";
            string secondString = "Tavish";

            // Compare the two strings

            int match = string.Compare(firstString, secondString); // Returns int. 0 if matches 1 if it does not

            Console.WriteLine(match);

            // Concat Method - https://learn.microsoft.com/en-us/dotnet/api/system.string.concat?view=net-8.0

            firstString = "Hello";
            secondString = "Hello";

            // Create a new string by using the Concat function to concatenate the values of first string and second string

            string concatString = string.Concat(firstString, secondString);

            // concatString should say "HelloWorld"
            Console.WriteLine(concatString);

            // Contains method - https://learn.microsoft.com/en-us/dotnet/api/system.string.contains?view=net-8.0
            // Looks for any sequential subset of characters in a string
            // Returns a boolean - true if the string is there, false if it is not

            string daysOfWeekString = "Sunday Monday Tuesday Wednesday Thursday Friday Saturday";
            string dayOfWeek = "Christmas";

            if (daysOfWeekString.Contains(dayOfWeek))
            {
                Console.WriteLine($"{dayOfWeek} is in the string.");
            }

            else
            {
                Console.WriteLine("String not found");
            }

            // EndsWith Method - https://learn.microsoft.com/en-us/dotnet/api/system.string.endswith?view=net-8.0
            // Checks if a string ends with a particular sequence
            // Boolean - true if it does, false if not

            if (dayOfWeek.EndsWith("day"))
            {
                Console.WriteLine($"{dayOfWeek} ends with day.");
            }

            else
            {
                Console.WriteLine("It does not end with day");
            }

            // Equals method - https://learn.microsoft.com/en-us/dotnet/api/system.string.equals?view=net-8.0
            // Checks if two strings are the same value
            // Boolean - true if the same, false if not

            var boolean = firstString.Equals(secondString);
            Console.WriteLine(boolean);

            // Length property (not a method) - Gives us how many characters are in a string

            string helloWorld = "Hello World!"; // Should return 12 (int)
            int helloWorldLength = helloWorld.Length;
            Console.WriteLine(helloWorldLength); // 12

            // Format - case by case basis, depending on what is being formatted, use this
            // Common use for DateTimes to figure out how to print out a Date.

            //IndexOf, returns an zero-based (where first position is 0 rather than 1)
            //int representing the position of a character or sequence of characters in a string is found
            // returns -1 if nothing found

            string pemdas = "Please excuse my Dear Aunt Sally.";
            int positionOfWordDear = pemdas.IndexOf("Dear"); // Should return 17
            Console.WriteLine(positionOfWordDear); // 17

            //IsNullOrEmpty and IsNullOrWhitespace methods
            // Determines whether a string is null (nothing in memory), empty which is just "", or whitespace " ";
            // Essentially determines if the strings contains any readable text for a human to read.

            //IsNullOrEmpty checks only for null or empty
            //IsNullOrWhitespace checks for null, empty, AND whitespace

            string testString = null;
            Console.WriteLine(NullEmptyWhiteSpaceCheck(testString)); // Should say "testString is null or empty"
            testString = string.Empty;
            Console.WriteLine(NullEmptyWhiteSpaceCheck(testString)); // Should say "testString is null or empty"
            testString = "   "; //whitespace
            Console.WriteLine(NullEmptyWhiteSpaceCheck(testString)); // Should say "testString is null, empty or only contains whitespace
            testString = "Claim Academy";
            Console.WriteLine(NullEmptyWhiteSpaceCheck(testString)); // Should say "testString is neither null, empty, nor only contains whitespace"

            // Join Method - https://learn.microsoft.com/en-us/dotnet/api/system.string.join?view=net-8.0
            // Takes an array of strings and then joins them with a separator, like a comma (,)

            string[] items = { "Bread", "Eggs", "Milk", "Vegetables", "Beef", "Chicken", "Fish" };

            string groceries = string.Join($",{Environment.NewLine}", items);

            // groceries should be
            // Bread,
            // Eggs,
            // Milk,
            // Vegetables,
            // Beef,
            // Chicken,
            // Fish,

            Console.WriteLine(groceries);


            //PadLeft and PadRight methods - Prepend (PadLeft) or Append (PadRight) a string with a number of the same kind of characters.
            // PadLeft - If you have a member number for health insurance that is 8 digits but another software application needs this member number
            // as 11 digits

            string eightDigitMemberNumber = "12345678";

            // Make member number 11 digits for system that requires, can only prepend with 0's to avoid making the member number something else
            string elevenDigitMemberNumber = eightDigitMemberNumber.PadLeft(11, '0'); // Add 3 0's to beginning of member number
            Console.WriteLine($"8 digit member number: {eightDigitMemberNumber}");
            Console.WriteLine($"11 digit member number: {elevenDigitMemberNumber}");

            // Remove - removes a number of characters from the string

            helloWorld = "HelloWorld";
            string helloWorldNew = helloWorld.Remove(1); // Should return just "H"
            Console.WriteLine(helloWorldNew);
            helloWorldNew = helloWorld; // Reset back to "HelloWorld"
            helloWorldNew = helloWorld.Remove(0, 1); // Should return "elloWorld"
            Console.WriteLine(helloWorldNew);

            // Replace - Return a new string replacing text from another string

            string csv = "1,2,3,4,5"; // Make it 1|2|3|4|5
            string pipe = csv.Replace(',', '|'); // Replace commas with pipes
            Console.WriteLine($"CSV: {csv}");
            Console.WriteLine($"Pipe: {pipe}");

            string original = "Jarvis Jibreel Caleb Nikembi Greg";
            string newString = original.Replace("Greg", "Tavish");
            Console.WriteLine($"Original Name List: {original}");
            Console.WriteLine($"New Name List: {newString}");
            newString = newString.Replace(" ", ",");
            Console.WriteLine($"New Name List with spaces replaced by commas: {newString}");

            //Split - opposite of Join, split a string into array of strings based on a character separator like a comma

            string[] newNameArray = newString.Split(',');

            // StartsWith - Check if a string starts with a character or sequence of characters as a string

            // Use Case: Claim numbers that start with X, i.e. Claim Nbr: X874939039484
            // We want to group these claim numbers based on all the ones that start with X

            string[] ClaimNbrs = {"X7498375934850", "X843759430795", "X0934833029484", "X489302484930", "X894385409359",
                                   "C8493890243890554", "C448393909309", "C438973448932", "C3489030545389", "C43098854579405"};

            // Want to pick just the claim numbers that start with X

            foreach (var nbr in ClaimNbrs)
            {
                if (nbr.StartsWith("X"))
                {
                    Console.WriteLine(nbr);
                }
            }

            // Substring - create a new string based on part of another string

            // Use case: 25-character field in a database, some data is longer than 25, so limit that data to 25 characters

            string data = "CHG834975089435784239758423723895729837";
            // Can't save this in 25-character field in database so, limit to 25

            string data25 = data.Substring(0, 25); // Save only the first 25 characters to a new string

            Console.WriteLine($"Over 25 character data: {data}");
            Console.WriteLine($"25 character data: {data25}");

            FindAllOccurences(data, '4');

            // CharArray Method - Turn a string into a physical char array
            string wordTest = "Test";
            char[] wordTestArray = wordTest.ToCharArray();
            Console.WriteLine();

            // ToLower method - Make a string lower case

            string upperTest = "TEST";
            string lowerTest = upperTest.ToLower(); // Changes TEST to test
            Console.WriteLine(lowerTest); // Should print test

            // Trim method - gets rid of all extraneous whitespace around a string

            string testWithWhiteSpace = "  TEST  ";

            // Does this equal with TEST

            bool doesEquals = testWithWhiteSpace.Equals("TEST"); // False
            Console.WriteLine(doesEquals);

            // Trim the whitespace
            string testTrimmed = testWithWhiteSpace.Trim();
            doesEquals = testTrimmed.Equals("TEST"); // True
            Console.WriteLine(doesEquals);
        }

        static string NullEmptyWhiteSpaceCheck(string testString)
        {
            if (string.IsNullOrEmpty(testString))
            {
                return "testString is null or empty";
            }

            else if (string.IsNullOrWhiteSpace(testString))
            {
                return "testString is null, empty, or only contains whitespace";
            }

            else
            {
                return "testString is neither null, empty, nor only contains whitespace";
            }
        }

        static void FindAllOccurences(string test, char example)
        {

            for (int i = 0; i < test.Length; i++) // Iterate (go through one by one) the string
            {
                if (test[i] == example) // Test at each character if it matches what you are trying to match
                {
                    Console.WriteLine($"{test[i]} was found at position {i}"); // If the match is there, print out the character and the position
                }
            }
        }
    }
}
