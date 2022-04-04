using System;

namespace RegexUserRegistration
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the User Registration System Problem.\n");

            Users user1 = new();
            user1.TakeFirstName();
            user1.TakeLastName();
            user1.TakeEmail();
        }
    }
}
