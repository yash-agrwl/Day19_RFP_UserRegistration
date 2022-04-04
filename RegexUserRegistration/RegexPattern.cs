using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexUserRegistration
{
    internal class RegexPattern
    {

        static string FirstNamePattern = "^[A-Z][a-z]{2,}$";
        static string LastNamePattern = "^[A-Z][a-z]{2,}$";

        public static bool ValidateFirstName(string firstName)
        {
            return Regex.IsMatch(firstName, FirstNamePattern);
        }

        public static bool ValidateLastName(string lastName)
        {
            return Regex.IsMatch(lastName, LastNamePattern);
        }
    }
}
