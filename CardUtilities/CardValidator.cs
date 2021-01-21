using System;
using System.Linq;
namespace CardUtilities
{
    public class CardValidator
    {
        public bool IsValid(string cardValue, out string errorMessage) 
        {
            char delimiter = ' ';
            string cardHolder = cardValue.ToUpper();
            string[] cards = cardHolder.Split(delimiter);
            if(IsCardLengthEnough(cards))
            {
                if (!IsEachCardAtHandValid(cards))
                {
                    errorMessage = CardsAreNotValidError();
                    return false;
                }
                errorMessage = string.Empty;
                return true;
            }
            errorMessage = NotEnoughCardsError();
            return false;
        }
        private bool IsCardLengthEnough(string[] cards) 
        {
            return (cards.Length >= 5);
        }
        private bool IsEachCardAtHandValid(string[] cards) 
        {
            char[] suitsCharacter = new char[] {'C', 'S', 'H', 'D'};
            char[] faceCardsCharacter = new char[] {'J', 'Q', 'K', 'A'};
            foreach(var card in cards) 
            {
                if(card.Length != 2)
                {
                    return false;
                }
            }
            for(int i = 0; i < cards.Length; i++) 
            {
                string tempHolder = cards[i];
                if (Char.IsDigit(tempHolder, 0))
                {
                    int value = int.Parse(tempHolder[0].ToString());
                    if ((value < 2) || (value >= 11))
                    {
                        return false;
                    }
                    if (Array.IndexOf(suitsCharacter, tempHolder[1]) <= -1)
                    {
                        return false;
                    }
                }
                else 
                {
                    if(Array.IndexOf(faceCardsCharacter, tempHolder[0]) <= -1)
                    {
                        return false;
                    }
                    if (Array.IndexOf(suitsCharacter, tempHolder[1]) <= -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private string NotEnoughCardsError()
        {
            return "The number of cards is not enough";
        }
        private string CardsAreNotValidError() 
        {
            return "Some of the players cards are not valid";
        }
    }
}
