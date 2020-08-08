using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkManagementSystem.Models;

namespace WorkManagementSystem.Tests.ModelsTests
{
    [TestClass]
    public class BoardShould
    {
        [TestMethod]
        public void ConstructorShould()
        {
            //Arrange
            string expectedName = "Test name";

            //Act
            Board board = new Board(expectedName);
            string actualName = board.Name;

            //Assert
            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void ShouldThrowExceptionOnNullInput()
        {
            Assert.ThrowsException<ArgumentException>(() =>
           {
               Board board = new Board(null);
           });
        }

        [TestMethod]
        public void ShouldThrowExceptionOnShorterInputLength()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Board board = new Board(new string('a', 4));
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionOnLongerInputLength()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Board board = new Board(new string('a', 11));
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionOnInvalidNameSymbols()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Board board = new Board("12345!");
            });
        }

        //Add test for name uniqueness
    }
}
