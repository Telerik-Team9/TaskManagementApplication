using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkManagementSystem.Models;

namespace WorkManagementSystem.Tests.ModelsTests
{
    [TestClass]
    public class BoardShould
    {
        [TestMethod]
        public void ShouldThrowExceptionOnNullInput()
        {
            Assert.ThrowsException<ArgumentException>(() => new Board(null));
        }

        [TestMethod]
        public void ShouldThrowExceptionOnShorterInputLength()
        {
            Assert.ThrowsException<ArgumentException>(() => new Board(new string('a', 4)));
        }

        [TestMethod]
        public void ShouldThrowExceptionOnLongerInputLength()
        {
            Assert.ThrowsException<ArgumentException>(() => new Board(new string('a', 11)));
        }

        [TestMethod]
        public void ShouldThrowExceptionOnInvalidNameSymbols()
        {
            Assert.ThrowsException<ArgumentException>(() => new Board("12345!"));
        }

        //Add test for name uniqueness
    }
}
