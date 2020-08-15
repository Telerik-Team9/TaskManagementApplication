using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.UnitTests
{
    [TestClass]
    public class RemoveWorkitem_Should
    {
        [TestMethod]
        public void RemoveCorrectlyWorkitemToPerson()
        {
            //Arrange
            IMember member = new Member("TestMember");
            string title = new string('a', 11);
            string descr = new string('a', 11);
            IWorkItem feedback = new Feedback(title, descr, 5, default);
            member.AddWorkItem(feedback);

            //Act
            member.RemoveWorkItem(feedback);

            //Assert
            Assert.IsTrue(member.WorkItems.Count == 0);
        }

        [TestMethod]
        public void ThrowWhen_ItemDoesNotExist()
        {
            //Arrange
            IMember person = new Member("TestPerson");
            string title = new string('a', 11);
            string descr = new string('a', 11);
            IWorkItem feedback = new Feedback(title, descr, 5, default);

            //Act

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                person.RemoveWorkItem(feedback);
            });
        }

        [TestMethod]
        public void AddHistoryLogWhen_ItemAddedSuccessfully()
        {
            //Arrange
            IMember peroson = new Member("TestBoard");
            string title = new string('a', 11);
            string descr = new string('a', 11);
            IWorkItem feedback = new Feedback(title, descr, 5, default);
            peroson.AddWorkItem(feedback);

            //Act
            peroson.RemoveWorkItem(feedback);

            //Assert
            Assert.IsTrue(peroson.ActivityHistory.Count == 2);
        }
    }
}
