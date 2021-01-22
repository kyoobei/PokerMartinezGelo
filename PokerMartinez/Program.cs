using System;
using System.Collections.Generic;
using CardUtilities;
namespace PokerMartinez
{
    class Program
    {
        static void Main(string[] args)
        {
            CardValidator cardValidator = new CardValidator();
            PokerGame pokerGame = new PokerGame();
            bool isTerminated = false;
            int currentNumberOfPlayers = 0;
            ShowIntroductions();   
            while (!isTerminated)
            {
                Console.Write("\nEnter the player name: ");
                string playerName = Console.ReadLine();
                string playerCard = string.Empty;
                DeclarePlayerCard(playerName, ref playerCard);
                while(cardValidator.IsValid(playerCard, out string errorMessage) != true) 
                {
                    Console.WriteLine("Error: {0}\n",errorMessage);
                    DeclarePlayerCard(playerName, ref playerCard);
                }
                pokerGame.AddPlayer(playerName, playerCard);
                currentNumberOfPlayers++;    
                if (currentNumberOfPlayers > 1)
                {
                    Console.WriteLine("\nPress ANY KEY to add more players or ESC to start\n");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        isTerminated = true;
                    }
                }
            }
            pokerGame.StartGame();
            for(int i = 0; i < pokerGame.NumberOfPlayers; i++) 
            {
                Console.WriteLine("Name: {0}", pokerGame.GetPlayerName(i));
                Console.WriteLine("Cards: {0}", pokerGame.GetCardCollection(i));
                Console.WriteLine("Hand: {0}\n", pokerGame.GetPlayerHand(i));
            }
            Console.WriteLine("-------Winner-------");
            for (int i = 0; i < pokerGame.GetWinners().Count; i++) 
            {
                Console.WriteLine(pokerGame.GetWinners()[i]);
            }
            Console.WriteLine("\nPress ANY KEY to exit");
            Console.ReadLine();
        }
        private static void DeclarePlayerCard(string playerName, ref string playerCard) 
        {
            Console.Write("Enter {0}'s card (ex: 2H 6D AS 4S 3H): ", playerName);
            playerCard = Console.ReadLine();
        }
        private static void ShowIntroductions()
        {
            string intro = string.Format
                ("Assumptions\n\n" +
                "1. Each player will only have 5 unique valid cards on their hands. \n" +
                "2. If there are more than 5 cards, then the system will only get the first 5 cards. \n" +
                "3. The cards or hand are evaluated by rank (2 is lowest while Ace is the highest). Suit doesn't matter in ranking.\n" +
                "4. There can be multiple winners if the highest hand is identical to other player hands regardless of the suit. \n\n" +
                "For Card Value Progression: \n" +
                "2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A \n\n" +
                "For Suits:\n" +
                "C = Clover, S = Spade, H = Hearts, D = Diamond\n" +
                "Example:\n" +
                "2H = Two of Hearts, AD = Ace of Diamonds and etc. \n\n" +
                "Press any key to continue..."
                );
            Console.WriteLine(intro);
            Console.ReadLine();
        }
    }
}
