using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexUserRegistration
{
    internal class Users
    {

        private static bool ValidationCheck;
        private string FirstName;

        public void TakeFirstName()
        {
            do
            {
                Console.Write("Enter First Name: ");
                this.FirstName = Console.ReadLine();
                ValidationCheck = RegexPattern.ValidateFirstName(this.FirstName);
                DisplayOutput("FirstName");
            }
            while (!ValidationCheck);
        }

        public static void DisplayOutput(string option)
        {
            if (ValidationCheck)
                Console.WriteLine("\nThe Entered Input is Valid.\n");
            else
            {
                Console.WriteLine("\nThe Entered Input is Invalid.\nPlease Try Again.");
                DisplayRules(option);
            }
        }

        public static void DisplayRules(string option)
        {
            switch (option)
            {
                case "FirstName":
                    Console.WriteLine("Rule: First Name starts with Capital and has minimum 3 characters.\n");
                    break;
                default:
                    break;
            }
        }
    }
}
