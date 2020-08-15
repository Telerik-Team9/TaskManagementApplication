using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Models.Tests.CommentTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateCommentWhen_PassedValuesAreCorrect()
        {
            //Assert
            string message = "This is a test message";
            IMember member = new FakeMember();

            //Act
            IComment comment = new Comment(message, member);

            //Assert
            Assert.AreEqual(message, comment.Message);
            Assert.IsInstanceOfType(comment, typeof(IComment));
        }
    }
}
