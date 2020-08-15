using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Models.Tests.CommentTests
{
    [TestClass]
    public class Message_Should
    {
        [TestMethod]
        public void InitializeCorrectlyWhen_ValidValuesArePassed()
        {
            //Assert
            string message = "This is a test message";
            IMember member = new FakeMember();

            //Act
            IComment comment = new Comment(message, member);

            //Assert
            Assert.AreEqual(message, comment.Message);
        }

        [TestMethod]
        public void ThrowWhen_MsgIsEmpty()
        {
            //Assert
            string message = "    ";
            IMember member = new FakeMember();

            //Act and assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IComment comment = new Comment(message, member);

            });
        }

        [TestMethod]
        public void ThrowWhen_MsgIsNull()
        {
            //Assert
            string message = null;
            IMember member = new FakeMember();

            //Act and assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IComment comment = new Comment(message, member);

            });
        }

        [TestMethod]
        public void ThrowWhen_MsgIsShorterThanMin()
        {
            //Assert
            string message = "a";
            IMember member = new FakeMember();

            //Act and assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IComment comment = new Comment(message, member);

            });
        }

        [TestMethod]
        public void ThrowWhen_MsgIsLongerThanMax()
        {
            //Assert
            string message = new string('a', 51);
            IMember member = new FakeMember();

            //Act and assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IComment comment = new Comment(message, member);

            });
        }
    }
}
