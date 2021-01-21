using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardUtilities
{
    public class CardValidator
    {
        public bool IsValid(string cardValue, out string errorMessage) 
        {
            char delimiter = ' ';
            string cardHolder = cardValue.ToUpper();
            string[] cards = cardHolder.Split(delimiter);
            if(cards.Length >= 5)
            {
                for(int i = 0; i < cards.Length; i++) 
                {
                    Console.WriteLine("cards: " + cards[i]);
                }
                errorMessage = string.Empty;
                return true;
            }
            else
            {
                errorMessage = NotEnoughCardsError();
            }
            return false;
        }
        private string NotEnoughCardsError()
        {
            return "The number of cards is not enough";
        }
    }
}
