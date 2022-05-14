using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RegexUserRegistration
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("\tWelcome to the User Registration System Problem");
            Console.WriteLine("==================================================================\n");


            Console.WriteLine("      All Email Samples Validations");
            Console.WriteLine("==========================================\n");

            string[] validEmails = { "abc@yahoo.com", "abc-100@yahoo.com", "abc.100@yahoo.com", "abc111@abc.com", 
                "abc-100@abc.net", "abc.100@abc.com.au", "abc@1.com", "abc@gmail.com.co", "abc+100@gmail.com" };
            string[] invalidEmails = { "abc", "abc@.com.my", "abc123@gmail.a", "abc123@.com", "abc123@.com.com", 
                ".abc@abc.com", "abc()*@gmail.com", "abc@%*.com", "abc..2002@gmail.com", "abc.@gmail.com", 
                "abc@abc@gmail.com", "abc@gmail.com.1a", "abc@gmail.com.aa.au" };

            Console.WriteLine("===========Valid Emails===========\n");
            RegexPattern.ValidateEmailSamples(validEmails);
            Console.WriteLine("===========Invalid Emails===========\n");
            RegexPattern.ValidateEmailSamples(invalidEmails);


            Console.WriteLine("\tUser Details Validation");
            Console.WriteLine("==========================================\n");

            Users user1 = new();

            loop:
            Console.WriteLine("Press '1' to validate using Regex Pattern.");
            Console.WriteLine("Press '2' to validate using Annotations.");
            Console.WriteLine("Press '3' to exit.");
            Console.Write("Enter Choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("-----------Enter User Details-----------\n");
                    user1.ValidateFirstNameUsingRegex();
                    user1.ValidateLastNameusingRegex();
                    user1.ValidateEmailUsingRegex();
                    user1.ValidateMobileNoUsingRegex();
                    user1.ValidatePasswordUsingRegex();
                    Console.WriteLine("All the user details has been validated successfully.");
                    break;
                case "2":
                    Users.ValidateUserUsingAnnotation(user1);
                    break;
                case "3":
                    Console.WriteLine("Program exited successfully.");
                    break;
                default:
                    Console.WriteLine("Invalid Option\n");
                    goto loop;
            }
        }
    }
}
