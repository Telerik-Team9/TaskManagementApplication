using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.UnitTests
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
                IUnit member = new Member(null);
            });
        }

        [TestMethod]
        public void ThrowWhen_PassedValueIsEmpty()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IUnit board = new Board("           ");
            });
        }

        [TestMethod]
        public void ThrowWhen_PassedValueIsShorter()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IUnit board = new Board("AA");
            });
        }

        [TestMethod]
        public void ThrowWhen_PassedValueIsLonger()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IUnit member = new Member(new string('a', 16));
            });
        }

        [TestMethod]
        [DataRow("sdasd58")]
        [DataRow("s@@441")]
        [DataRow("!!!!!!!")]
        [DataRow("````````")]
        public void ThrowWhen_NonLetterArePassed(string name)
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IUnit member = new Member(name);
            });
        }
    }
}
