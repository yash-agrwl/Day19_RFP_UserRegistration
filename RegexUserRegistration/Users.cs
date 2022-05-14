using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexUserRegistration
{
    public class Users
    {

        private static bool ValidationCheck;

        [Required(ErrorMessage = "{0} cannot be empty.")]
        [RegularExpression(RegexPattern.FirstNamePattern, ErrorMessage = "{0} doesn't match the required constraints.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty.")]
        [RegularExpression(RegexPattern.LastNamePattern, ErrorMessage = "{0} doesn't match the required constraints.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty.")]
        [RegularExpression(RegexPattern.EmailPattern, ErrorMessage = "{0} doesn't match the required constraints.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty.")]
        [RegularExpression(RegexPattern.MobilePattern, ErrorMessage = "{0} doesn't match the required constraints.")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty.")]
        [RegularExpression(RegexPattern.PasswordPattern, ErrorMessage = "{0} doesn't match the required constraints.")]
        public string Password { get; set; }

        public void TakeFirstName()
        {
            Console.Write("Enter First Name: ");
            this.FirstName = Console.ReadLine();
        }

        public void TakeLastName()
        {
            Console.Write("Enter Last Name: ");
            this.LastName = Console.ReadLine();
        }

        public void TakeEmail()
        {
            Console.Write("Enter Email: ");
            this.Email = Console.ReadLine();
        }

        public void TakeMobileNo()
        {
            Console.Write("Enter Mobile.No: ");
            this.MobileNo = Console.ReadLine();
        }

        public void TakePassword()
        {
            Console.Write("Enter Password: ");
            this.Password = Console.ReadLine();
        }

        public void ValidateFirstNameUsingRegex()
        {
            ValidationCheck = false;
            do
            {
                this.TakeFirstName();
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

        public void ValidateLastNameusingRegex()
        {
            ValidationCheck = false;
            do
            {
                this.TakeLastName();
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

        public void ValidateEmailUsingRegex()
        {
            ValidationCheck = false;
            do
            {
                this.TakeEmail();
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

        public void ValidateMobileNoUsingRegex()
        {
            ValidationCheck = false;
            do
            {
                this.TakeMobileNo();
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

        public void ValidatePasswordUsingRegex()
        {
            ValidationCheck = false;
            do
            {
                this.TakePassword();
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

        public static void ValidateUserUsingAnnotation(Users user)
        {
            loop:
            Console.WriteLine("-----------Enter User Details-----------\n");
            user.TakeFirstName();
            user.TakeLastName();
            user.TakeEmail();
            user.TakeMobileNo();
            user.TakePassword();
            Console.WriteLine();

            // Inbuilt class for validation to pass object, service and dictionary
            // if services and dictionaries are not used we can make it as null.
            ValidationContext context = new(user, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(user, context, results, true);

            // Condition if the fields are not valid.
            if (!valid)
            {
                // Foreach loop is used to transverse the data if error occurs prints the error messages in different colours.
                foreach (ValidationResult Totalresult in results)
                {
                    Console.WriteLine("Error :: {0}", Totalresult.ErrorMessage);
                }
                Console.WriteLine();
                goto loop;
            }
            else
            {
                Console.WriteLine("All the user details has been validated successfully.");
            }
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