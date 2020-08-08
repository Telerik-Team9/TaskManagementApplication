using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models;

namespace WorkManagementSystem.Tests.ModelsTests
{
    [TestClass]
    public class FeedbackShould
    {
        [TestMethod]
        public void ConstructorShould()
        {
            //Arrange
            string expectedTitle = "This is a test title.";
            string expectedDescription = "This is a test desctiption.";
            int expectedRating = 9;

            //Act
            Feedback feedback = new Feedback(expectedTitle, expectedDescription,expectedRating);
            string actualTitle = feedback.Title;
            string actualDescription = feedback.Description;
            int actualRating = feedback.Rating;

            //Assert
            Assert.AreEqual(expectedTitle, actualTitle);
            Assert.AreEqual(expectedDescription, actualDescription);
            Assert.AreEqual(expectedRating, actualRating);
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenTitleIsNull()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Feedback feedback = new Feedback(null, new string('a', 11), 1);
            });

        }

        [TestMethod]
        public void ShouldThrowExceptionWhenDescriptionIsNull()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Feedback feedback = new Feedback(new string('a', 11), null, 1);
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenTitlelengthIsShorter()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Feedback feedback = new Feedback(new string('a', 9), new string('b', 11), 1);
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenDescrtionlengthIsShorter()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Feedback feedback = new Feedback(new string('a', 11), new string('b', 9), 1);
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenTitlelengthIsLonger()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Feedback feedback = new Feedback(new string('a', 51), new string('b', 11), 1);
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenDescrtionlengthIsLonger()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Feedback feedback = new Feedback(new string('a', 11), new string('b', 501), 1);
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenRatingIsSmaller()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Feedback feedback = new Feedback(new string('a', 11), new string('b', 500), 0);
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenRatingIsBigger()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Feedback feedback = new Feedback(new string('a', 11), new string('b', 500), 11);
            });
        }
    }
}
