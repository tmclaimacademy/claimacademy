using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class InvalidPhoneNumberException : Exception
    {
        // Default Constructor
        public InvalidPhoneNumberException()
        {

        }

        // Constructor with custom message (message is a string)
        public InvalidPhoneNumberException(string message) : base(message)
        {

        }

        // Constructor with custom message as a string and also the Inner Exception if we wish to throw that instead.
        public InvalidPhoneNumberException(string message,  Exception innerException) : base(message, innerException)
        {

        }
    }
}
