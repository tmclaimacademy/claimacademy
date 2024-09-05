using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    public class Exceptions
    {
        // Divide By Zero example
        public void Run()
        {
            int x = 100;
            int y = 0;
            int z = 0;

            try
            {
                z = x / y;
                Console.WriteLine("This line will never run.");
            }

            catch(DivideByZeroException ex)
            {
                Console.WriteLine("Division by zero is not permitted.");
            }
            finally
            {
                Console.WriteLine("This line will always run.");
            }
        }

        // Null Reference Exception
        public void Run2()
        {
            try
            {
                Car nullCar = null;
                Console.Write(nullCar.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine("Object is null");
            }
        }

        // FormatException
        public void Run3()
        {
            try
            {
                Console.Write("Enter a number: ");
                string number = Console.ReadLine();
                int num = int.Parse(number);
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Input is not a number.");
            }
            
        }
    }
}
