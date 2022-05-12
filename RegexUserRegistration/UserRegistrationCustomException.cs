using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexUserRegistration
{
    public class UserRegistrationCustomException : Exception
    {

        public enum ExceptionType
        {
            EMPTY_INPUT,
            INVALID_INPUT
        }

        public readonly ExceptionType Type;

        public UserRegistrationCustomException(ExceptionType type, string message) : base(message)
        {
            this.Type = type;
        }
    }
}
