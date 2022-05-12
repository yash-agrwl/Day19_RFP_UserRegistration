using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RegexUserRegistration
{
    public class UserRegistrationReflector
    {
        /// <summary>
        /// Create Object of Users class with Default Constructor using Reflection.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <returns></returns>
        /// <exception cref="UserRegistrationCustomException"></exception>
        public static object CreateUsers_UsingDefaultConstructor(string className, string constructorName)
        {
            Type type = typeof(Users);

            if (type.Name == className || type.FullName == className)
            {
                if (type.Name == constructorName)
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type userType = executing.GetType(className);
                    return Activator.CreateInstance(userType);
                }
                else
                    throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor Not Found");
            }
            else
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
        }
    }
}
