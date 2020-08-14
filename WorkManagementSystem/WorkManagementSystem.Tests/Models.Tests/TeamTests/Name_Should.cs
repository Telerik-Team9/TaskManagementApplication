using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.ModelsTests
{
    [TestClass]
    public class Name_Should
    {
        [TestMethod]
        public void ThrownWhen_PassedValueIsNull()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                ITeam team = new Team(null);
            });
        }

        [TestMethod]
        public void ThrowWhen_PassedValueIsEmpty()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                ITeam team = new Team("         ");
            });
        }

        [TestMethod]
        public void ThrowWhen_PassedValueIsShorter()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                ITeam team = new Team(new string('a', 2));
            });
        }

        [TestMethod]
        public void ThrowWhen_PassedValueIsLonger()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                ITeam team = new Team(new string('a', 16));
            });
        }
    }
}
