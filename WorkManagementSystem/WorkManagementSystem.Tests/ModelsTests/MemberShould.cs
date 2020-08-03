using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkManagementSystem.Models;

namespace WorkManagementSystem.Tests.ModelsTests
{
    [TestClass]
    public class MemberShould
    {
        [TestMethod]
        public void ShouldThrowExceptionOnNullInput()
        {
            Assert.ThrowsException<ArgumentException>(() => new Member(null));
        }

        [TestMethod]
        public void ShouldThrowExceptionOnShorterInputLength()
        {
            Assert.ThrowsException<ArgumentException>(() => new Member(new string('a', 4)));
        }

        [TestMethod]
        public void ShouldThrowExceptionOnLongerInputLength()
        {
            Assert.ThrowsException<ArgumentException>(() => new Member(new string('a', 16)));
        }

        [TestMethod]
        public void ShouldThrowExceptionOnInvalidNameSymbols()
        {
            Assert.ThrowsException<ArgumentException>(() => new Member("Ali Marekov99"));
        }

        //Add test for name uniqueness
    }
}
