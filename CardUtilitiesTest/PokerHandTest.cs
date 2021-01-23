using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CardUtilities;
using CardUtilities.Enums;
namespace CardUtilitiesTest
{
    [TestClass]
    public class PokerHandTest
    {
        [TestMethod]
        public void TestRoyalFlushHand()
        {
            PokerGame pokerGame = new PokerGame();
            string playerName = "Test";
            string playerCard = "10h jh qh kh ah";
            pokerGame.AddPlayer(playerName, playerCard);
            pokerGame.StartGame();
            string targetValue = CardHand.RoyalFlush.ToString();
            Assert.IsTrue(pokerGame.GetPlayerHand(0).Equals(targetValue));
        }
        [TestMethod]
        public void TestStraightFlushHand() 
        {
            PokerGame pokerGame = new PokerGame();
            string playerName = "Test";
            string playerCard = "2d 3d 4d 5d 6d";
            pokerGame.AddPlayer(playerName, playerCard);
            pokerGame.StartGame();
            string targetValue = CardHand.StraightFlush.ToString();
            Assert.IsTrue(pokerGame.GetPlayerHand(0).Equals(targetValue));
        }
        [TestMethod]
        public void TestFourOfAKindHand() 
        {
            PokerGame pokerGame = new PokerGame();
            string playerName = "Test";
            string playerCard = "2h 2d 2s 2c 3h";
            pokerGame.AddPlayer(playerName, playerCard);
            pokerGame.StartGame();
            string targetValue = CardHand.FourOfAKind.ToString();
            Assert.IsTrue(pokerGame.GetPlayerHand(0).Equals(targetValue));
        }
        [TestMethod]
        public void TestFullHouseHand() 
        {
            PokerGame pokerGame = new PokerGame();
            string playerName = "Test";
            string playerCard = "2h 2d 2s 3s 3h";
            pokerGame.AddPlayer(playerName, playerCard);
            pokerGame.StartGame();
            string targetValue = CardHand.FullHouse.ToString();
            Assert.IsTrue(pokerGame.GetPlayerHand(0).Equals(targetValue));
        }
        [TestMethod]
        public void TestFlushHand() 
        {
            PokerGame pokerGame = new PokerGame();
            string playerName = "Test";
            string playerCard = "2h 6h ah 4h 3h";
            pokerGame.AddPlayer(playerName, playerCard);
            pokerGame.StartGame();
            string targetValue = CardHand.Flush.ToString();
            Assert.IsTrue(pokerGame.GetPlayerHand(0).Equals(targetValue));
        }
        [TestMethod]
        public void TestStraightHand() 
        {
            PokerGame pokerGame = new PokerGame();
            string playerName = "Test";
            string playerCard = "4h 3d 2s 6s 5h";
            pokerGame.AddPlayer(playerName, playerCard);
            pokerGame.StartGame();
            string targetValue = CardHand.Straight.ToString();
            Assert.IsTrue(pokerGame.GetPlayerHand(0).Equals(targetValue));
        }
        [TestMethod]
        public void TestThreeofAKindHand() 
        {
            PokerGame pokerGame = new PokerGame();
            string playerName = "Test";
            string playerCard = "2h 6d as 2s 2d";
            pokerGame.AddPlayer(playerName, playerCard);
            pokerGame.StartGame();
            string targetValue = CardHand.ThreeOfAKind.ToString();
            Assert.IsTrue(pokerGame.GetPlayerHand(0).Equals(targetValue));
        }
        [TestMethod]
        public void TestTwoPairHand() 
        {
            PokerGame pokerGame = new PokerGame();
            string playerName = "Test";
            string playerCard = "2h 2d as 4s 4h";
            pokerGame.AddPlayer(playerName, playerCard);
            pokerGame.StartGame();
            string targetValue = CardHand.TwoPair.ToString();
            Assert.IsTrue(pokerGame.GetPlayerHand(0).Equals(targetValue));
        }
        [TestMethod]
        public void TestOnePairHand() 
        {
            PokerGame pokerGame = new PokerGame();
            string playerName = "Test";
            string playerCard = "2h 4d as 4s 3h";
            pokerGame.AddPlayer(playerName, playerCard);
            pokerGame.StartGame();
            string targetValue = CardHand.OnePair.ToString();
            Assert.IsTrue(pokerGame.GetPlayerHand(0).Equals(targetValue));
        }
        [TestMethod]
        public void TestHighCardHand() 
        {
            PokerGame pokerGame = new PokerGame();
            string playerName = "Test";
            string playerCard = "2h 6d as 4s 3h";
            pokerGame.AddPlayer(playerName, playerCard);
            pokerGame.StartGame();
            string targetValue = CardHand.HighCard.ToString();
            Assert.IsTrue(pokerGame.GetPlayerHand(0).Equals(targetValue));
        }
    }
}
