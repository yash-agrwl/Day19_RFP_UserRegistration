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
            return Regex.IsMatch(firstName, FirstNamePattern);
        }

        public static bool ValidateLastName(string lastName)
        {
            return Regex.IsMatch(lastName, LastNamePattern);
        }

        public static bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, EmailPattern);
        }

        public static bool ValidateMobile(string mobileNo)
        {
            return Regex.IsMatch(mobileNo, MobilePattern);
        }

        public static bool ValidatePassword(string password)
        {
            return Regex.IsMatch(password, PasswordPattern);
        }

        public static void ValidateEmailSamples(string[] emailSamples)
        {
            foreach (string email in emailSamples)
            {
                bool result = ValidateEmail(email);
                if (result)
                    Console.WriteLine(" " + email + " ------> is Valid\n");
                else
                    Console.WriteLine(" " + email + " ------> is Invalid\n");
            }
        }
    }
}
