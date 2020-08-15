using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.CommentTests
{
    [TestClass]
    public class PrintInfo_Should
    {
        [TestMethod]
        public void ReturnCorrectMessage()
        {
            //Assert
            string message = "This is a test message";
            IMember member = new Member("Pesho");

            //Act
            IComment comment = new Comment(message, member);
            string expected = $"Pesho: This is a test message";

            //Assert
            Assert.AreEqual(expected, comment.PrintInfo());
        }
    }
}
