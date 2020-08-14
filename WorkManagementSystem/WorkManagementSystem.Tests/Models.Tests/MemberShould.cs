/*using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkManagementSystem.Models;

namespace WorkManagementSystem.Tests.ModelsTests
{
    [TestClass]
    public class MemberShould
    {
        [TestMethod]
        public void ConstructorShould()
        {
            //Arrange
            string expectedName = "Test name";

            //Act
            Member member = new Member(expectedName);
            string actualName = member.Name;

            //Assert
            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void ShouldThrowExceptionOnNullInput()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                {
                    Member member = new Member(null);
                });
        }

        [TestMethod]
        public void ShouldThrowExceptionOnShorterInputLength()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Member member = new Member(new string('a', 4));
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionOnLongerInputLength()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Member member = new Member(new string('a', 16));
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionOnInvalidNameSymbols()
        {
            Assert.ThrowsException<ArgumentException>(() =>
           {
               Member member = new Member("Ali Marekov99");
           });
        }

        //Add test for name uniqueness
    }
}
*/