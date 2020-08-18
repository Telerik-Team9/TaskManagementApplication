using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Factories;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.Common.ListMethodsTests
{
    [TestClass]
    public class ListAllBugs_Should
    {
        [TestMethod]
        public void CorrectlyListAllBugs()
        {
            //Arrange
            IInstanceFactory factory = new InstanceFactory();
            string expected = "Type: Bug | Title: SeedDataBug";
            Func<IWorkItem, string> criteria = x => "Type: " + x.GetWorkItemType() + " | Title: " + x.Title;

            //Act
            string actual = ListMethods.ListAllWorkItems(factory, criteria, "Bug");

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }
        [TestMethod]
        public void ThrowWhen_NoBugsInDatabase()
        {
            //Arrange
            IInstanceFactory factory = new FakeInstanceFactory();
            Func<IWorkItem, string> criteria = x => "Type: " + x.GetWorkItemType() + " | Id: " + x.Id + " | Title: " + x.Title;
            factory.Database.Bugs.Clear();

            //Act and assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                string actual = ListMethods.ListAllWorkItems(factory, criteria, "Bug");
            });
        }
    }
}
