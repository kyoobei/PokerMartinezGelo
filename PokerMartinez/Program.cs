﻿using System;
using System.Collections.Generic;
using CardUtilities;
namespace PokerMartinez
{
    class Program
    {
        
        static void Main(string[] args)
        {
            CardValidator cardValidator = new CardValidator();
            bool isTerminated = false;
            Dictionary<string, string> playerListDict = new Dictionary<string, string>();
            ShowIntroductions();   
            while (!isTerminated)
            {
                Console.Write("Enter the player name: ");
                string playerName = Console.ReadLine();
                string playerCard = string.Empty;
                DeclarePlayerCard(playerName, ref playerCard);
                while(cardValidator.IsValid(playerCard, out string errorMessage) != true) 
                {
                    Console.WriteLine("Error: " + errorMessage);
                    DeclarePlayerCard(playerName, ref playerCard);
                }
                //add to list for later should change this to some default class from library or
                //this area
                playerListDict.Add(playerName, playerCard);
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    isTerminated = true;
                }
            }
        }
        private static void DeclarePlayerCard(string playerName, ref string playerCard) 
        {
            Console.Write("Enter {0}'s card (ex: 2H 6D AS 4S 3H): ", playerName);
        }
        private static void ShowIntroductions()
        {
            string intro = string.Format
                ("Assumptions\n" +
                "1. Each player will only have 5 valid cards on their hands. \n" +
                "2. If there are more than 5 valid cards, then the system will only get the first 5 cards. \n" +
                "3. The cards or hand are evaluated by rank (2 is lowest while Ace is the highest). Suit doesn't matter in ranking.\n" +
                "4. There can be multiple winners if the highest hand has identical values with other player hands. \n" +
                "For Card Value Progression: \n" +
                "2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A \n" +
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
