using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.ShowCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.ShowCommandsTests
{
    [TestClass]
    public class ShowPersonAcitvityCommand_Should
    {
        [TestMethod]
        public void PrintValidInfo()
        {
            //Arrange
            string personName = "TelerikMember";
            IInstanceFactory factory = new FakeInstanceFactory();
            IList<string> parameters = new List<string>() { personName };
            IMember member = factory.Database.Members.First(p => p.Name == personName);
            var command = new ShowPersonActivityCommand(factory);
            string expected = member.PrintActivityHistory();

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}