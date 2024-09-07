using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Exceptions
{
    internal class ExcessFundsException : Exception
    {
        // Default constructor
        public ExcessFundsException()
        {

        }

        // Custom message exception
        public ExcessFundsException(string message) : base(message)
        {

        }

        public ExcessFundsException(string message, ExcessFundsException innerException) : base(message, innerException)
        {

        }
    }
}
