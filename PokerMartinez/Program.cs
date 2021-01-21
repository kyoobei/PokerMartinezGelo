using System;
using System.Collections.Generic;
using CardUtilities;
namespace PokerMartinez
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool isTerminated = false;
            //Dictionary<string, string> playerListDict = new Dictionary<string, string>();
            ShowIntroductions();
            
            while (!isTerminated)
            {
                Console.WriteLine("Press Esc to end");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    isTerminated = true;
                }
            }
        }
        private static void ShowIntroductions()
        {
            string intro = string.Format
                ("Assumptions\n" +
                "1. Each player will only have 5 valid cards on their hands. \n" +
                "2. If there are more than 5 valid cards, then the system will only get the first 5 cards. \n" +
                "3. The cards or hand are evaluated by rank (2 is lowest while Ace is the highest). Suit doesn't matter in ranking.\n" +
                "4. There can be multiple winners if the highest hand has identical values with other player hands. \n" +
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
