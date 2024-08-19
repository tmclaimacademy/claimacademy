using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IntroToCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car toyota = new Toyota("Corolla", "Red", 1997);
            toyota.GetDescription();
            toyota.Drive();
            toyota.Break();
            Console.ReadKey();
        }

        
    }
}
