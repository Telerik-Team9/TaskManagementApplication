using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Models.Tests.CommentTests
{
    [TestClass]
    public class AuthorShould
    {
        [TestMethod]
        public void InitalizeCorrectlyWhen_ValidValuesArePassed()
        {
            //Assert
            string message = "This is a test message";
            IMember member = new FakeMember();

            //Act
            IComment comment = new Comment(message, member);

            //Assert
            Assert.IsInstanceOfType(comment.Author, typeof(IMember));
        }
    }
}
