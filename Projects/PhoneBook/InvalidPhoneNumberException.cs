﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class InvalidPhoneNumberException : Exception
    {
        public InvalidPhoneNumberException()
        {

        }

        public InvalidPhoneNumberException(string message) : base(message)
        {

        }

        public InvalidPhoneNumberException(string message,  Exception innerException) : base(message, innerException)
        {

        }
    }
}
