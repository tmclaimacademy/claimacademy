using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Exceptions
{
    // See: https://learn.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
    internal class ExcessChargeException : Exception
    {
        // Default constructor

        public ExcessChargeException()
        {

        }

        // For custom exception message
        public ExcessChargeException(string message) : base(message)
        {

        }

        // Custom message with inner exception
        public ExcessChargeException(string message, ExcessChargeException innerException) : base(message, innerException)
        {


        }
    }
}
