using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Factories;

namespace WorkManagementSystem.Tests.Core.Tests.Common.ListMethodsTests
{
    [TestClass]
    public class ListAllUnits_Should
    {
        [TestMethod]
        public void ListCorrectlyAllMembers()
        {
            //Arrange
            IInstanceFactory factory = new InstanceFactory();
            string expected = "Maggie\r\nAliii";

            //Act
            string actual = ListMethods.ListAllUnits(factory, x => x.Name, "member");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListCorrectlyAllBoards()
        {
            //Arrange
            IInstanceFactory factory = new InstanceFactory();
            string expected = "FIRSTBRD\r\nSECONDBRD";

            //Act
            string actual = ListMethods.ListAllUnits(factory, x => x.Name, "board");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThrowWhen_NoMembersIsDatabase()
        {
            //Arrange
            InstanceFactory factory = new InstanceFactory();
            factory.Database.Members.Clear();

            //Act and assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                string actual = ListMethods.ListAllUnits(factory, x => x.Name,"member");
            });
        }

        [TestMethod]
        public void ThrowWhen_NoBoardsIsDatabase()
        {
            //Arrange
            InstanceFactory factory = new InstanceFactory();
            factory.Database.Boards.Clear();

            //Act and assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                string actual = ListMethods.ListAllUnits(factory, x => x.Name, "board");
            });
        }
    }
}
