using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Factories;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.Common.ListMethodsTests
{
    [TestClass]
    public class ListAllFeedbacks_Should
    {
        [TestMethod]
        public void CorrectlyListAllFeedbacks()
        {
            //Arrange
            IInstanceFactory factory = new InstanceFactory();
            string expected = "Type: Feedback | Title: SeedDataFeedback";
            Func<IWorkItem, string> criteria = x => "Type: " + x.GetWorkItemType() + " | Title: " + x.Title;

            //Act
            string actual = ListMethods.ListAllWorkItems(factory, criteria, "Feedback");

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ThrowWhen_NoFeedbacksInDatabase()
        {
            //Arrange
            IInstanceFactory factory = new FakeInstanceFactory();
            Func<IWorkItem, string> criteria = x => "Type: " + x.GetWorkItemType() + " | Id: " + x.Id + " | Title: " + x.Title;

            //Act and assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                string actual = ListMethods.ListAllWorkItems(factory, criteria, "Feedback");
            });
        }
    }
}
