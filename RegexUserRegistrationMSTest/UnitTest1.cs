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
    }
}
