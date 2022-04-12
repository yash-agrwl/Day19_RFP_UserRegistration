using System;

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
            user1.TakeFirstName();
            user1.TakeLastName();
            user1.TakeEmail();
            user1.TakeMobileNo();
            user1.TakePassword();
            Console.WriteLine("All the user details has been validated successfully.");
        }
    }
}
