using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreTests
{
    [TestClass]
    public class RegistrationTesting
    {
        Principle userData = new Principle();
        string inputName, inputPassword;



        [TestMethod]
        public void IncorrectNameAndCorrectPasswordR()
        {
            inputName = "bialkowc";
            inputPassword = "ds4573";

            Boolean expectedReturn = true;
            int expectedUserId = 1;

            Boolean actualReturn = userData.SignUp(inputName, inputPassword);
            int actualUserId = userData.ID;

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }


        [TestMethod]
        public void CorrectNameAndPasswordR()
        {
            inputName = "bialkowc";
            inputPassword = "cb1234";

            Boolean expectedReturn = false;
            int expectedUserId = -1;

            Boolean actualReturn = userData.SignUp(inputName, inputPassword);
            int actualUserId = userData.ID;

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void CorrectNameAndInorrectPasswordR()
        {
            inputName = "dorne112";
            inputPassword = "cb1234";

            Boolean expectedReturn = true;
            int expectedUserId = 1;

            Boolean actualReturn = userData.SignUp(inputName, inputPassword);
            int actualUserId = userData.ID;

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void IncorrectNameAndIncorrectPasswordR()
        {
            inputName = "corne112";
            inputPassword = "ds4573";

            Boolean expectedReturn = true;
            int expectedUserId = 1;

            Boolean actualReturn = userData.SignUp(inputName, inputPassword);
            int actualUserId = userData.ID;

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void BlankNameAndPasswordR()
        {
            inputName = "";
            inputPassword = "cb1234";

            Boolean expectedReturn = false;
            int expectedUserId = -1;

            Boolean actualReturn = userData.SignUp(inputName, inputPassword);
            int actualUserId = userData.ID;

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void NameAndBlankPasswordR()
        {
            inputName = "bialkowc";
            inputPassword = "";

            Boolean expectedReturn = false;
            int expectedUserId = -1;

            Boolean actualReturn = userData.SignUp(inputName, inputPassword);
            int actualUserId = userData.ID;

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void BlankNameAndBlankPasswordR()
        {
            inputName = "";
            inputPassword = "";

            Boolean expectedReturn = false;
            int expectedUserId = -1;

            Boolean actualReturn = userData.SignUp(inputName, inputPassword);
            int actualUserId = userData.ID;

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }
    }
}
