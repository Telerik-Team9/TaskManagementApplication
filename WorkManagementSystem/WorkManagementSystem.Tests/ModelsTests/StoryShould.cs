﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models;

namespace WorkManagementSystem.Tests.ModelsTests
{
    [TestClass]
    public class StoryShould
    {
        [TestMethod]
        public void ConstructorShould()
        {
            //Arrange
            string expectedTitle = "This is a test title.";
            string expectedDescription = "This is a test desctiption.";

            //Act
            Story story = new Story(expectedTitle, expectedDescription);
            string actualTitle = story.Title;
            string actualDescription = story.Description;

            //Assert
            Assert.AreEqual(expectedTitle, actualTitle);
            Assert.AreEqual(expectedDescription, actualDescription);
        }
        [TestMethod]
        public void ShouldThrowExceptionWhenTitleIsNull()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Story story = new Story(null, new string('a', 11));
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenDescriptionIsNull()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Story story = new Story(new string('a', 11), null);
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenTitlelengthIsShorter()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Story story = new Story(new string('a', 9), new string('b', 11));
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenDescrtionlengthIsShorter()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Story story = new Story(new string('a', 11), new string('b', 9));
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenTitlelengthIsLonger()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Story story = new Story(new string('a', 51), new string('b', 11));
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenDescrtionlengthIsLonger()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Story story = new Story(new string('a', 11), new string('b', 501));
            });
        }
    }
}