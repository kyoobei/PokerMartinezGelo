using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CardUtilities;

namespace CardUtilitiesTest
{
    [TestClass]
    public class PokerWinnerTest
    {
        [TestMethod]
        public void TestOnePlayerWinByHand()
        {
            PokerGame pokerGame = new PokerGame();
            string player1 = "Tester1";
            string player1Cards = "2h 6d as 4s 3h"; //this is high card only
            pokerGame.AddPlayer(player1, player1Cards);

            string player2 = "Tester2";
            string player2Cards = "2s 2d 5d 4c 3d"; //this should win because one pair
            pokerGame.AddPlayer(player2, player2Cards);

            pokerGame.StartGame();
            List<string> expectedWinner = new List<string>();
            expectedWinner.Add(player2);
            List<string> winnerListFromPokerClass = pokerGame.GetWinners();
            CollectionAssert.AreEqual(winnerListFromPokerClass, expectedWinner);
        }
        [TestMethod]
        public void TestOnePlayerWinSameHand() 
        {
            PokerGame pokerGame = new PokerGame();
            string player1 = "Tester1";
            string player1Cards = "2h 2c as 4s 3h"; //this is high card but should win
            pokerGame.AddPlayer(player1, player1Cards);

            string player2 = "Tester2";
            string player2Cards = "2d 2s kh 4h 3d"; //this is high card
            pokerGame.AddPlayer(player2, player2Cards);

            pokerGame.StartGame();
            List<string> expectedWinner = new List<string>();
            expectedWinner.Add(player1);
            List<string> winnerListFromPokerClass = pokerGame.GetWinners();
            CollectionAssert.AreEqual(winnerListFromPokerClass, expectedWinner);
        }
        [TestMethod]
        public void TestPlayersHasMoreCardsThanRequired()
        {
            PokerGame pokerGame = new PokerGame();
            string player1 = "Tester1";
            string player1Cards = "2h 2c as 4s 3h ah ad"; //this is high card but should win
            pokerGame.AddPlayer(player1, player1Cards);

            string player2 = "Tester2";
            string player2Cards = "2d 2s kh 4h 3d 5d 6d 7d"; //this is high card
            pokerGame.AddPlayer(player2, player2Cards);

            pokerGame.StartGame();
            List<string> expectedWinner = new List<string>();
            expectedWinner.Add(player1);
            List<string> winnerListFromPokerClass = pokerGame.GetWinners();
            CollectionAssert.AreEqual(winnerListFromPokerClass, expectedWinner);
        }
        [TestMethod]
        public void TestBothPlayerWinSameHand()
        {
            PokerGame pokerGame = new PokerGame();
            string player1 = "Tester1";
            string player1Cards = "2h 6d as 4s 3h"; //this is high card 
            pokerGame.AddPlayer(player1, player1Cards);

            string player2 = "Tester2";
            string player2Cards = "2d 6c ah 4h 3d"; //also high card but both should win
            pokerGame.AddPlayer(player2, player2Cards);

            pokerGame.StartGame();
            List<string> expectedWinner = new List<string>();
            expectedWinner.Add(player1);
            expectedWinner.Add(player2);
            List<string> winnerListFromPokerClass = pokerGame.GetWinners();
            CollectionAssert.AreEqual(winnerListFromPokerClass, expectedWinner);
        }
        [TestMethod]
        public void TestManyPlayersOneWinner() 
        {
            PokerGame pokerGame = new PokerGame();
            string player1 = "Tester1";
            string player1Cards = "2h 6d as 4s 3h"; //this is high card only
            pokerGame.AddPlayer(player1, player1Cards);

            string player2 = "Tester2";
            string player2Cards = "2s 2d 5d 4c 3d"; //this is one pair
            pokerGame.AddPlayer(player2, player2Cards);

            string player3 = "Tester3";
            string player3Cards = "2c 3c 5h 5c 3s"; //this should win because two pair
            pokerGame.AddPlayer(player3, player3Cards);

            pokerGame.StartGame();
            List<string> expectedWinner = new List<string>();
            expectedWinner.Add(player3);
            List<string> winnerListFromPokerClass = pokerGame.GetWinners();
            CollectionAssert.AreEqual(winnerListFromPokerClass, expectedWinner);
        }
        [TestMethod]
        public void TestManyPlayerWithManyWinners() 
        {
            PokerGame pokerGame = new PokerGame();
            string player1 = "Tester1";
            string player1Cards = "10h 6d as 4s 9h"; //this is high card
            pokerGame.AddPlayer(player1, player1Cards);

            string player2 = "Tester2";
            string player2Cards = "10s 6h ad 4c 9d"; //this is also high card but similar to 1
            pokerGame.AddPlayer(player2, player2Cards);

            string player3 = "Tester3";
            string player3Cards = "2c 4d 5h 3c 7s"; //this is also high card
            pokerGame.AddPlayer(player3, player3Cards);

            pokerGame.StartGame();
            List<string> expectedWinner = new List<string>();
            expectedWinner.Add(player1);
            expectedWinner.Add(player2);
            List<string> winnerListFromPokerClass = pokerGame.GetWinners();
            CollectionAssert.AreEqual(winnerListFromPokerClass, expectedWinner);
        }
    }
}
