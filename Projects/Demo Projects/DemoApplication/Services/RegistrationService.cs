using DemoApplication.Models;
using DemoApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace DemoApplication.Services
{
    public class RegistrationService
    {
        // Default Constructor
        public RegistrationService()
        {

        }

        public string RegisterUser(User user)
        {
            try
            {
                var userService = new UserService();
                userService.AddUser(user);
                return "Registration Successful!";
            }
            catch (Exception ex)
            {
                return "Error registering user";
            }

        }

        public List<string> VerifyRegistrationRequirements(string username, string password)
        {
            /*
             * Password Requirements:
             * Must be at least 8 characters
             * Must contain one upper case letter
             * Must contain one lower case letter
             * Must contain a number
             * Must contain a special character, any of ! @ # $ % ^ & * ( )
             * Must not contain any leading or trailing whitespace
             */

            // Create a list of strings that will bundle error messages as they occur
            var errorList = new List<string>();

            // Verify username is not blank
            if (string.IsNullOrWhiteSpace(username))
            {
                errorList.Add("Username cannot be blank.");
            }

            // Verify password is at least 8 characters, if not, add to the error list

            if (password.Trim().Length < 8)
            {
                errorList.Add("Password must be at least 8 characters.");
            }

            // Verify password contains at least 1 upper case letter

            var upperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var letterFound = false;

            foreach (var letter in password)
            {
                if (upperCaseLetters.Contains(letter))
                {
                    letterFound = true; // Set flag for letterFound to true
                    break; // If we find a letter in the password that is upper case, stop searching letters
                }
            }

            if (!letterFound)
            {
                errorList.Add("Password must contain at least one upper case letter.");
            }

            // Verify password contains at least 1 lower case letter
            letterFound = false; // Use previous upper case letterfound for lower case, set back to false for lower case check

            var lowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";

            foreach (var letter in password)
            {
                if (lowerCaseLetters.Contains(letter))
                {
                    letterFound = true; 
                    break;
                }
            }

            if (!letterFound)
            {
                errorList.Add("Password must contain at least one lower case character.");
            }

            // Verify password contains a number

            var numberList = "1234567890";
            var numberFound = false;

            foreach (var c in password)
            {
                if (numberList.Contains(c))
                {
                    numberFound = true;
                    break;
                }
            }

            if (!numberFound)
            {
                errorList.Add("Password must contain at least 1 number");
            }


            var symbolList = "!@#$%^&*()";
            var symbolFound = false;

            foreach (var c in password)
            {
                if (symbolList.Contains(c))
                {
                    symbolFound = true;
                    break;
                }
            }

            if (!symbolFound)
            {
                errorList.Add("Password must contain one of the following special characters: ! @ # $ % ^ & * ( )");
            }

            return errorList;
        }


    }
}