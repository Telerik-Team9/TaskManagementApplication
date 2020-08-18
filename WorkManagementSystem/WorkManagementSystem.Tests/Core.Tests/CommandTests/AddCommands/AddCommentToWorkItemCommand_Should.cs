using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.AddCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.AddCommands
{
    [TestClass]
    public class AddCommentToWorkItemCommand_Should
    {
        [TestMethod]
        public void Execute_Should_CorectlyAddCommentWhen_ValidValuesArePassed()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string bugId = fakeFactory.Database.Bugs.First().Id.ToString();
            string bugTitle = fakeFactory.Database.Bugs.First().Title;
            string memberName = fakeFactory.Database.Members.First().Name;
            IList<string> parameters = new List<string>() { bugId, memberName, "Test comment" };
            var command = new AddCommentToWorkItemCommand(fakeFactory);
            string expected = $"Message '{parameters[2]}' was added to workitem '{bugTitle}'";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }
    }
}
