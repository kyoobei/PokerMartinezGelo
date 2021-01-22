using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace CardUtilities
{
    public class CardValidator
    {
        private const int MIN_CARD = 5;
        private const string PATTERN_CARD = @"\b([2-9]|10|[JQKA])[CDHS]\b";

        public bool IsValid(string cardValue, out string errorMessage) 
        {
            if (cardValue.Equals(string.Empty)) 
            {
                errorMessage = NoCardsError();
                return false;
            }
            else 
            {
                List<string> validCardList = new List<string>();
                string cardHolder = cardValue.ToUpper();              
                var cardcheck = Regex.Matches(cardHolder, PATTERN_CARD);
                foreach (Match match in cardcheck)
                {
                    if (!validCardList.Contains(match.Value))
                    {
                        validCardList.Add(match.Value);
                    }
                }
                if(validCardList.Count >= MIN_CARD) 
                {
                    errorMessage = string.Empty;
                    return true;
                }
            }
            errorMessage = NotEnoughCardsError();
            return false;
        }
        private string NotEnoughCardsError()
        {
            return "The number of cards is not enough or cards are invalid.";
        }
        private string NoCardsError() 
        {
            return "There are no cards detected.";
        }
    }
}
