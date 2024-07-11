using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    public class Week1
    {
        public static void Main(string[] args)
        {
            // Official Microsoft C# Documentation: https://learn.microsoft.com/en-us/dotnet/csharp/

            // Week 1

            // Data Types
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types#835-simple-types

            //Integer: Whole numbers. 32-bit values go up from -2,147,483,648 to 2,147,483,647 which is (2^32 / 2) - 1.
            // Max value given by int.MaxValue  (32-bit)
            Console.WriteLine($"Max Integer Value: {int.MaxValue}");

            // Min Value given by int.MinValue (32-bit)
            Console.WriteLine($"Min Integer Value: {int.MinValue}");

            // 64-bit Integers can be accessed with Int64 struct or long primitive type
            // Max Int64 size 18,446,744,073,709,551,615


            //Declare without initial assignment
            int num; // All statements must be ended with ;

            //Assignment: Giving a value to the variable

            num = 6;

            // We can also declare and assign a value at once.

            int num2 = 8;

            //Floating point types: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types

            // Doubles - Floating point numbers, with decimals. Range is ±5.0 × 10^−324 to ±1.7 × 10^308
            double dbl = 1.25d;

            // Floats - Decimals. Range: ±1.5 x 10^−45 to ±3.4 x 10^38
            float floatnum = 4.7589f;

            // Decimal type: Range: ±1.0 x 10^-28 to ±7.9228 x 10^28
            decimal decimalNum = 8.567M;

            // Booleans: Can only be true or false, used to determine the binary state of something. i.e. true/false, on/off, etc.

            bool boolTrue = true;
            bool boolFalse = false;

            // Characters: Single ASCII or UTF-8 value (depending on character set used, these are the most common character sets)
            //More info: https://learn.microsoft.com/en-us/windows/win32/intl/character-sets

            char lowerA = 'a';
            char upperA = 'A';

            int lowerAValue = (int)lowerA;
            Console.WriteLine($"Integer value of lower-case a: {lowerA}");

            // Strings: Arrays of characters

            string helloWorld = "Hello World";

            //Convert to character array
            char[] helloWorldCharArray = helloWorld.ToCharArray();



        }
    }
}
