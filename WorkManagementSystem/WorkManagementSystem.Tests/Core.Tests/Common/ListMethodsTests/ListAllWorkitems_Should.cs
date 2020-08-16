using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.Common.ListMethodsTests
{
    [TestClass]
    public class ListAllWorkitems_Should
    {
        [TestMethod]
        public void ListAllWorkitemsCorrectly()
        {
            //Arrange
            IInstanceFactory factory = new FakeInstanceFactory();
            string expectedType = $"Type: {factory.Database.Bugs.First().GetWorkItemType()}";
            string expectedTitle = $"Title: {factory.Database.Bugs.First().Title}";

            string expectedType1 = $"Type: {factory.Database.Feedbacks.First().GetWorkItemType()}";
            string expectedTitle1 = $"Title: {factory.Database.Feedbacks.First().Title}";

            string expectedType2 = $"Type: {factory.Database.Stories.First().GetWorkItemType()}";
            string expectedTitle2 = $"Title: {factory.Database.Stories.First().Title}";

            Func<IWorkItem, string> criteria = x => "Type: " + x.GetWorkItemType() + " | Id: " + x.Id + " | Title: " + x.Title;

            //Act
            string actual = ListMethods.ListAllWorkItems(factory, criteria);

            //Assert
            Assert.IsTrue(actual.Contains(expectedType));
            Assert.IsTrue(actual.Contains(expectedType1));
            Assert.IsTrue(actual.Contains(expectedType2));

            Assert.IsTrue(actual.Contains(expectedTitle));
            Assert.IsTrue(actual.Contains(expectedTitle1));
            Assert.IsTrue(actual.Contains(expectedTitle2));
        }
    }
} 