using System;
using System.Collections.Generic;

namespace CardUtilities
{
    class CardBuilder
    {
        public bool IsValid(string cardValue, out List<Card> builtCard) 
        {
            if(cardValue.Length == 5) 
            {
                builtCard = new List<Card>(Build(cardValue));
                return true;
            }
            builtCard = null;
            return false;
        }
        private List<Card> Build(string cardValue) 
        {
            List<Card> cardsList = new List<Card>();

            return cardsList;
        }
        
        
    }
}
