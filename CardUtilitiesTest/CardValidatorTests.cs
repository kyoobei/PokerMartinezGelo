using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardUtilities;
using System;

namespace CardUtilitiesTest
{
    [TestClass]
    public class CardValidatorTests
    { 
        [TestMethod]
        public void TestHasFiveValidCards()
        {
            CardValidator cardValidator = new CardValidator();
            string testCardCollection = "2h 6d as 4s 3h";
            string errorMessage = string.Empty;
            Assert.IsTrue(cardValidator.IsValid(testCardCollection, out errorMessage));
        }
        [TestMethod]
        public void TestHasMoreThanFiveValidCards() 
        {
            CardValidator cardValidator = new CardValidator();
            string testCardCollection = "2h 6d as 4s 3h ah 9d";
            string errorMessage = string.Empty;
            Assert.IsTrue(cardValidator.IsValid(testCardCollection, out errorMessage));
        }
        [TestMethod]
        public void TestHasInvalidFormatCards() 
        {
            CardValidator cardValidator = new CardValidator();
            string testCardCollection = "2h 6J as 4s 3jdka";
            string errorMessage = string.Empty;
            Assert.IsFalse(cardValidator.IsValid(testCardCollection, out errorMessage));
        }
        [TestMethod]
        public void TestHasFewerThanFiveCards() 
        {
            CardValidator cardValidator = new CardValidator();
            string testCardCollection = "2h 6d as 4s";
            string errorMessage = string.Empty;
            Assert.IsFalse(cardValidator.IsValid(testCardCollection, out errorMessage));
        }
        [TestMethod]
        public void TestNoCardInput() 
        {
            CardValidator cardValidator = new CardValidator();
            string testCardCollection = " ";
            string errorMessage = string.Empty;
            Assert.IsFalse(cardValidator.IsValid(testCardCollection, out errorMessage));
        }
        [TestMethod]
        public void TestCardCollectionHasNoSpace() 
        {
            CardValidator cardValidator = new CardValidator();
            string testCardCollection = "2h6das4s3h";
            string errorMessage = string.Empty;
            Assert.IsFalse(cardValidator.IsValid(testCardCollection, out errorMessage));
        }
        [TestMethod]
        public void TestCurrentCardFiveIsNotUnique() 
        {
            CardValidator cardValidator = new CardValidator();
            string testCardCollection = "2h 6d as 3h 3h";
            string errorMessage = string.Empty;
            Assert.IsFalse(cardValidator.IsValid(testCardCollection, out errorMessage));
        }
        [TestMethod]
        public void TestPlayersCardsAreUnique()
        {
            CardValidator cardValidator = new CardValidator();
            string testCardCollection1 = "2h 6d as 4s 3h";
            string testCardCollection2 = "2d 6c ac 4c 3c";

            string errorMessage = string.Empty;
            //build the first string first
            bool test1 = cardValidator.IsValid(testCardCollection1, out errorMessage);
            //build the second string second
            bool test2 = cardValidator.IsValid(testCardCollection2, out errorMessage);
            Assert.IsTrue(test2);
        }
        [TestMethod]
        public void TestPlayersCardsAreNotUnique() 
        {
            CardValidator cardValidator = new CardValidator();
            string testCardCollection1 = "2h 6d as 4s 3h";
            string testCardCollection2 = "2h 6c ac 4c 3c";

            string errorMessage = string.Empty;
            //build the first string first
            bool test1 = cardValidator.IsValid(testCardCollection1, out errorMessage);
            //build the second string second
            bool test2 = cardValidator.IsValid(testCardCollection2, out errorMessage);
            Assert.IsFalse(test2);
        }
    }
}
