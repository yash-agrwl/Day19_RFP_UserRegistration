using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexUserRegistration
{
    public class RegexPattern
    {

        static string FirstNamePattern = "^[A-Z][a-z]{2,}$";
        static string LastNamePattern = "^[A-Z][a-z]{2,}$";
        static string EmailPattern = @"^[a-z0-9]+([-+_.][a-z0-9]+)?[@][a-z0-9]+[.][a-z0-9]{2,3}([.][a-z]{2})?$";
        static string MobilePattern = @"^[0-9]{2}\s[0-9]{10}";
        static string PasswordPattern = @"^(?=.{8,}$)(?=.*[A-Z])(?=.*[0-9])[\w\d]{0,}[\W]{1}[\w\d]{0,}$";

        public static bool ValidateFirstName(string firstName)
        {
            CheckEmpty(firstName);
            bool match = Regex.IsMatch(firstName, FirstNamePattern);
            if (match)
                return true;
            else
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.INVALID_INPUT, "The Entered Input is Invalid");
        }

        public static bool ValidateLastName(string lastName)
        {
            CheckEmpty(lastName);
            bool match = Regex.IsMatch(lastName, LastNamePattern);
            if (match)
                return true;
            else
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.INVALID_INPUT, "The Entered Input is Invalid");
        }

        public static bool ValidateEmail(string email)
        {
            CheckEmpty(email);
            bool match = Regex.IsMatch(email, EmailPattern);
            if (match)
                return true;
            else
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.INVALID_INPUT, "The Entered Input is Invalid");
        }

        public static bool ValidateMobile(string mobileNo)
        {
            CheckEmpty(mobileNo);
            bool match = Regex.IsMatch(mobileNo, MobilePattern);
            if (match)
                return true;
            else
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.INVALID_INPUT, "The Entered Input is Invalid");
        }

        public static bool ValidatePassword(string password)
        {
            CheckEmpty(password);
            bool match = Regex.IsMatch(password, PasswordPattern);
            if (match)
                return true;
            else
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.INVALID_INPUT, "The Entered Input is Invalid");
        }

        public static void CheckEmpty(string input)
        {
            if (input == "")
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.EMPTY_INPUT, "Input cannot be empty");
        }

        public static void ValidateEmailSamples(string[] emailSamples)
        {
            foreach (string email in emailSamples)
            {
                try
                {
                    bool result = ValidateEmail(email);
                    Console.WriteLine(" " + email + " ------> is Valid\n");
                }
                catch (UserRegistrationCustomException)
                {
                    Console.WriteLine(" " + email + " ------> is Invalid\n");
                }     
            }
        }
    }
}
