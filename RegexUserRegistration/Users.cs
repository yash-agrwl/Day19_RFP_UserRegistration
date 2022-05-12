using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexUserRegistration
{
    public class Users
    {

        private static bool ValidationCheck;
        private string FirstName;
        private string LastName;
        private string Email;
        private string MobileNo;
        private string Password;

        public void TakeFirstName()
        {
            ValidationCheck = false;
            do
            {
                Console.Write("Enter First Name: ");
                this.FirstName = Console.ReadLine();
                try
                {
                    ValidationCheck = RegexPattern.ValidateFirstName(this.FirstName);
                    DisplayOutput();
                }
                catch (UserRegistrationCustomException ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}.\nPlease Try Again.");
                    DisplayRules("FirstName");
                }
            }
            while (!ValidationCheck);
        }

        public void TakeLastName()
        {
            ValidationCheck = false;
            do
            {
                Console.Write("Enter Last Name: ");
                this.LastName = Console.ReadLine();
                try
                {
                    ValidationCheck = RegexPattern.ValidateLastName(this.LastName);
                    DisplayOutput();
                }
                catch(UserRegistrationCustomException ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}.\nPlease Try Again.");
                    DisplayRules("LastName");
                }
            }
            while (!ValidationCheck);
        }

        public void TakeEmail()
        {
            ValidationCheck = false;
            do
            {
                Console.Write("Enter Email: ");
                this.Email = Console.ReadLine();
                try
                {
                    ValidationCheck = RegexPattern.ValidateEmail(this.Email);
                    DisplayOutput();
                }
                catch (UserRegistrationCustomException ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}.\nPlease Try Again.");
                    DisplayRules("Email");
                }
            }
            while (!ValidationCheck);
        }

        public void TakeMobileNo()
        {
            ValidationCheck = false;
            do
            {
                Console.Write("Enter Mobile.No: ");
                this.MobileNo = Console.ReadLine();
                try
                {
                    ValidationCheck = RegexPattern.ValidateMobile(this.MobileNo);
                    DisplayOutput();
                }
                catch (UserRegistrationCustomException ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}.\nPlease Try Again.");
                    DisplayRules("MobileNo");
                }
            }
            while (!ValidationCheck);
        }

        public void TakePassword()
        {
            ValidationCheck = false;
            do
            {
                Console.Write("Enter Password: ");
                this.Password = Console.ReadLine();
                try
                {
                    ValidationCheck = RegexPattern.ValidatePassword(this.Password);
                    DisplayOutput();
                }
                catch (UserRegistrationCustomException ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}.\nPlease Try Again.");
                    DisplayRules("Password");
                }
            }
            while (!ValidationCheck);
        }

        public static void DisplayOutput()
        {
            if (ValidationCheck)
                Console.WriteLine("\nThe Entered Input is Valid.\n");
        }

        public static void DisplayRules(string option)
        {
            switch (option)
            {
                case "FirstName":
                    Console.WriteLine("Rule: First Name starts with Capital and has minimum 3 characters.\n");
                    break;
                case "LastName":
                    Console.WriteLine("Rule: Last Name starts with Capital and has minimum 3 characters.\n");
                    break;
                case "Email":
                    Console.WriteLine("  Rule:");
                    Console.WriteLine("- E.g.: abc.xyz@bl.co.in");
                    Console.WriteLine("- Email has 3 mandatory parts (abc, bl & co) and 2 optional(xyz & in) with precise @ and.positions\n");
                    break;
                case "MobileNo":
                    Console.WriteLine("  Rule:");
                    Console.WriteLine("- E.g.: 91 9919819801");
                    Console.WriteLine("- Country code follow by space and 10 digit number.\n");
                    break;
                case "Password":
                    Console.WriteLine("Rule1: minimum 8 characters.");
                    Console.WriteLine("Rule2: Should have atleast 1 Upper Case.");
                    Console.WriteLine("Rule3: Should have atleast 1 Numeric number.");
                    Console.WriteLine("Rule4: Has exactly 1 special Characters.\n");
                    break;
                default:
                    break;
            }
        }
    }
}