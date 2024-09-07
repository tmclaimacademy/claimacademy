using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Exceptions
{
    internal class InsufficientFundsException : Exception
    {
        // Default constructor
        public InsufficientFundsException()
        {

        }

        // Custom exception message

        public InsufficientFundsException(string message) : base(message)
        {

        }

        // Custom with inner exception
        public InsufficientFundsException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
