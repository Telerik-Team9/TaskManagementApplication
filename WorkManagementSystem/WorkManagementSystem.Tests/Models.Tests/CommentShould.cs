/*using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models;

namespace WorkManagementSystem.Tests.ModelsTests
{
    [TestClass]
    public class CommentShould
    {
        [TestMethod]
        public void ConstructorShould()
        {
            //Arrange
            string expectedMessage = "Test message";

            //Act
            Comment comment = new Comment(expectedMessage);
            string actualMessage = comment.Message;

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ShouldThrowExceptionOnNullInput()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Comment comment = new Comment(null);
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionOnShorterInputLength()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Comment comment = new Comment(new string('a', 1));
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionOnLongerInputLength()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Comment comment = new Comment(new string('a', 51));
            });
        }
    }
}
*/