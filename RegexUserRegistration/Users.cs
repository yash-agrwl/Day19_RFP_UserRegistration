﻿using System;
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
        private string LastName;
        private string Email;

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

        public void TakeLastName()
        {
            do
            {
                Console.Write("Enter Last Name: ");
                this.LastName = Console.ReadLine();
                ValidationCheck = RegexPattern.ValidateLastName(this.LastName);
                DisplayOutput("LastName");
            }
            while (!ValidationCheck);
        }

        public void TakeEmail()
        {
            do
            {
                Console.Write("Enter Email: ");
                this.Email = Console.ReadLine();
                ValidationCheck = RegexPattern.ValidateEmail(this.Email);
                DisplayOutput("Email");
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
                case "LastName":
                    Console.WriteLine("Rule: Last Name starts with Capital and has minimum 3 characters.\n");
                    break;
                case "Email":
                    Console.WriteLine("  Rule:");
                    Console.WriteLine("- E.g.: abc.xyz@bl.co.in");
                    Console.WriteLine("- Email has 3 mandatory parts (abc, bl & co) and 2 optional(xyz & in) with precise @ and.positions\n");
                    break;
                default:
                    break;
            }
        }
    }
}
