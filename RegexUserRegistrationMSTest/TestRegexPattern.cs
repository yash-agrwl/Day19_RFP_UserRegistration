using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegexUserRegistration;

namespace RegexUserRegistrationMSTest
{
    [TestClass]
    public class TestRegexPattern
    {
        /// <summary>
        /// TC 1: Given First Name Should Return True or False. 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="expected"></param>
        [TestCategory("PatternValidation")]
        [TestMethod]
        //Arrange
        [DataRow("Yash",true)]
        [DataRow("yash",false)]
        public void GivenFirstNameShouldReturnTrueOrFalse(string firstName, bool expected)
        {
            bool actual;

            try
            {
                // Act
                actual = RegexPattern.ValidateFirstName(firstName);
            }
            catch(UserRegistrationCustomException)
            {
                // Act
                actual = false;
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TC 2: Given Last Name should return True or False.
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="expected"></param>
        [TestCategory("PatternValidation")]
        [TestMethod]
        //Arrange
        [DataRow("Agarwal", true)]
        [DataRow("agarwal", false)]
        public void GivenLastNameShouldReturnTrueOrFalse(string lastName, bool expected)
        {
            bool actual;

            try
            {
                // Act
                actual = RegexPattern.ValidateLastName(lastName);
            }
            catch (UserRegistrationCustomException)
            {
                // Act
                actual = false;
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TC 3: Given Email Should Return True or False.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="expected"></param>
        [TestCategory("PatternValidation")]
        [TestMethod]
        [DataRow("agarwal@gmail.com", true)]
        [DataRow("a.com", false)]
        public void GivenEmailShouldReturnTrueOrFalse(string email, bool expected)
        {
            bool actual;

            try
            {
                // Act
                actual = RegexPattern.ValidateEmail(email);
            }
            catch (UserRegistrationCustomException)
            {
                // Act
                actual = false;
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TC 4: Given Mobile Number should return True or False.
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="expected"></param>
        [TestCategory("PatternValidation")]
        [TestMethod]
        [DataRow("91 9345345790", true)]
        [DataRow("94358888", false)]
        public void GivenMobileNumShouldReturnTrueOrFalse(string mobile, bool expected)
        {
            bool actual;

            try
            {
                // Act
                actual = RegexPattern.ValidateMobile(mobile);
            }
            catch (UserRegistrationCustomException)
            {
                // Act
                actual = false;
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TC 5: Given Password Should Return True or False.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="expected"></param>
        [TestCategory("PatternValidation")]
        [TestMethod]
        //Arrange
        [DataRow("sabdP0+s", true)]
        [DataRow("sabd", false)]
        public void GivenPasswordShouldReturnTrueOrFalse(string password, bool expected)
        {
            bool actual;

            try
            {
                // Act
                actual = RegexPattern.ValidatePassword(password);
            }
            catch (UserRegistrationCustomException)
            {
                // Act
                actual = false;
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Given Users Class Name should return Users Object using Reflection.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("RegexUserRegistration.Users", "Users")]
        [DataRow("RegexUserRegistration.Users", "InvalidConstructorName")]
        [DataRow("InvalidClassName", "Mood")]
        public void GivenUsersClassName_ShouldReturnObject_UsingDefaultConstructor(string className, string constructorName)
        {
            try
            {
                object expected = new Users();
                object obj = UserRegistrationReflector.CreateUsers_UsingDefaultConstructor(className, constructorName);
                expected.Equals(obj);
            }
            catch (UserRegistrationCustomException e)
            {
                if (e.Message == "Constructor is Not Found")
                    Assert.AreEqual("Constructor is Not Found", e.Message);
                else if (e.Message == "Class Not Found")
                    Assert.AreEqual("Class Not Found", e.Message);
            }
        }
    }
}
