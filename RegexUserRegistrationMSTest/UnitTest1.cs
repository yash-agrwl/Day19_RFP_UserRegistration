using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegexUserRegistration;

namespace RegexUserRegistrationMSTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        //Arrange
        [DataRow("Yash",true)]
        [DataRow("yash",false)]
        public void GivenFirstNameShouldReturnTrueOrFalse(string firstName, bool expected)
        {

            //Act
            bool actual = RegexPattern.ValidateFirstName(firstName);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        //Arrange
        [DataRow("Agarwal", true)]
        [DataRow("agarwal", false)]
        public void GivenLastNameShouldReturnTrueOrFalse(string lastName, bool expected)
        {

            //Act
            bool actual = RegexPattern.ValidateLastName(lastName);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("agarwal@gmail.com", true)]
        [DataRow("a.com", false)]
        public void GivenEmailShouldReturnTrueOrFalse(string email, bool expected)
        {

            //Act
            bool actual = RegexPattern.ValidateEmail(email);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("91 9345345790", true)]
        [DataRow("94358888", false)]
        public void GivenMobileNumShouldReturnTrueOrFalse(string mobile, bool expected)
        {

            //Act
            bool actual = RegexPattern.ValidateMobile(mobile);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
