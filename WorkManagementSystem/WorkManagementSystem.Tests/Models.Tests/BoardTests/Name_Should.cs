﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.BugTests
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
                IUnit member = new Board(null);
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
                IUnit board = new Board("AAAA");
            });
        }

        [TestMethod]
        public void ThrowWhen_PassedValueIsLonger()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IUnit board = new Board(new string('a', 11));
            });
        }

        [TestMethod]
        [DataRow("sdasd58")]
        [DataRow("s@@441")]
        [DataRow("!!!!!!!")]
        [DataRow("`````")]
        public void ThrowWhen_NonLetterArePassed(string name)
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IUnit board = new Board(name);
            });
        }
    }
}
