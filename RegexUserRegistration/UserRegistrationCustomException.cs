using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexUserRegistration
{
    public class UserRegistrationCustomException : Exception
    {
        /// <summary>
        /// Enum for Custom Exception.
        /// </summary>
        public enum ExceptionType
        {
            EMPTY_INPUT,
            INVALID_INPUT,
            NO_SUCH_CLASS,
            NO_SUCH_METHOD
        }

        /// <summary>
        /// Variable to indicate the type of Custom Exception.
        /// </summary>
        public readonly ExceptionType Type;

        /// <summary>
        /// Parameterized Constructor sets the Exception Type and message.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public UserRegistrationCustomException(ExceptionType type, string message) : base(message)
        {
            this.Type = type;
        }
    }
}
