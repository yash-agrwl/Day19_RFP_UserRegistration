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

        private static readonly string FirstNamePattern = "^[A-Z][a-z]{2,}$";
        private static readonly string LastNamePattern = "^[A-Z][a-z]{2,}$";
        private static readonly string EmailPattern = @"^[a-z0-9]+([-+_.][a-z0-9]+)?[@][a-z0-9]+[.][a-z0-9]{2,3}([.][a-z]{2})?$";
        private static readonly string MobilePattern = @"^[0-9]{2}\s[0-9]{10}";
        private static readonly string PasswordPattern = @"^(?=.{8,}$)(?=.*[A-Z])(?=.*[0-9])[\w\d]{0,}[\W]{1}[\w\d]{0,}$";

        /// <summary>
        /// A Delegate taking two input parameters and referring to the Regex.IsMatch method.
        /// </summary>
        private static Func<string, string, bool> IsPatternMatch = (input, pattern) => Regex.IsMatch(input, pattern);

        /// <summary>
        /// Refers to a lambda expression taking an input parameter and throws custom exception if the value is empty.
        /// </summary>
        private static Action<string> CheckEmpty = input =>
        {
            if (input == "")
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.EMPTY_INPUT, "Input cannot be empty");
        };

        /// <summary>
        /// Refers to a lambda expression taking an input parameter and throws custom expression or returns true based on it's value.
        /// </summary>
        private static Func<bool, bool> CheckResult = x =>
        {
            if (x)
                return true;
            else
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.INVALID_INPUT, "The Entered Input is Invalid");
        };

        public static bool ValidateFirstName(string firstName)
        {
            CheckEmpty(firstName);
            bool match = IsPatternMatch(firstName, FirstNamePattern);
            return CheckResult(match);
        }

        public static bool ValidateLastName(string lastName)
        {
            CheckEmpty(lastName);
            bool match = IsPatternMatch(lastName, LastNamePattern);
            return CheckResult(match);
        }

        public static bool ValidateEmail(string email)
        {
            CheckEmpty(email);
            bool match = IsPatternMatch(email, EmailPattern);
            return CheckResult(match);
        }

        public static bool ValidateMobile(string mobileNo)
        {
            CheckEmpty(mobileNo);
            bool match = IsPatternMatch(mobileNo, MobilePattern);
            return CheckResult(match);
        }

        public static bool ValidatePassword(string password)
        {
            CheckEmpty(password);
            bool match = IsPatternMatch(password, PasswordPattern);
            return CheckResult(match);
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
