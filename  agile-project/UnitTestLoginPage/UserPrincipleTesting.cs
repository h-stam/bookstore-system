using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreTests
{
    [TestClass]
    public class UserPrincipleTesting
    {
        Principle userData = new Principle();
        DALUserPrinciple userPrinciple = new DALUserPrinciple();
        string inputName, inputPassword;
        

        [TestMethod]
        public void CorrectNameAndPassword()
        {
            inputName = "bialkowc";
            inputPassword = "cb1234";

            Boolean expectedReturn = true;
            int expectedUserId = 1;

            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            int actualUserId = userData.ID;

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void IncorrectNameAndCorrectPassword()
        {
            inputName = "bialkowc";
            inputPassword = "ds4573";

            Boolean expectedReturn = false;
            int expectedUserId = -1;

            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            int actualUserId = userData.ID;

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void CorrectNameAndInorrectPassword()
        {
            inputName = "dorne112";
            inputPassword = "cb1234";

            Boolean expectedReturn = false;
            int expectedUserId = -1;

            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            int actualUserId = userData.ID;

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void IncorrectNameAndIncorrectPassword()
        {
            inputName = "corne112";
            inputPassword = "ds4573";

            Boolean expectedReturn = false;
            int expectedUserId = -1;

            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            int actualUserId = userData.ID;

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void BlankNameAndPassword()
        {
            inputName = "";
            inputPassword = "cb1234";

            Boolean expectedReturn = false;
            int expectedUserId = -1;

            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            int actualUserId = userData.ID;

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void NameAndBlankPassword()
        {
            inputName = "bialkowc";
            inputPassword = "";

            Boolean expectedReturn = false;
            int expectedUserId = -1;

            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            int actualUserId = userData.ID;

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void BlankNameAndBlankPassword()
        {
            inputName = "";
            inputPassword = "";

            Boolean expectedReturn = false;
            int expectedUserId = -1;

            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            int actualUserId = userData.ID;

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        PasswordValidator passwordValidator = new PasswordValidator();
        string testPassword;
        [TestMethod]
        public void ValidPassword()
        {
            testPassword = "cb1234";

            Boolean expectedReturn = true;

            Boolean actualReturn = passwordValidator.Validate(testPassword);

            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void InvalidPasswordLessThan6Chars()
        {
            testPassword = "cb12";

            Boolean expectedReturn = false;

            Boolean actualReturn = passwordValidator.Validate(testPassword);

            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void InvalidPasswordStartwithNonLetter()
        {
            testPassword = "12cb12";

            Boolean expectedReturn = false;

            Boolean actualReturn = passwordValidator.Validate(testPassword);

            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void InvalidPasswordContainingNonLetterOrNumber()
        {
            testPassword = "cb1234$";

            Boolean expectedReturn = false;

            Boolean actualReturn = passwordValidator.Validate(testPassword);

            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}
