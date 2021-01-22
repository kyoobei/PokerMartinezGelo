using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace CardUtilities
{
    public class CardValidator
    {
        private List<string> m_currentCardList = new List<string>();
        public bool IsValid(string cardValue, out string errorMessage) 
        {
            if (cardValue.Equals(string.Empty)) 
            {
                errorMessage = NoCardsError();
                return false;
            }
            else 
            {
                string cardHolder = cardValue.ToUpper();
                List<string> validCardList = new List<string>();
                var cardcheck = Regex.Matches(cardHolder, Constants.PATTERN_CARD);
                foreach (Match match in cardcheck)
                {
                    if (!validCardList.Contains(match.Value))
                    {
                        validCardList.Add(match.Value);
                    }
                }
                if(validCardList.Count >= Constants.MIN_CARD) 
                {
                    for(int i = 0; i < validCardList.Count; i++) 
                    {
                        if (m_currentCardList.Contains(validCardList[i])) 
                        {
                            errorMessage = CardsAreNotUniqueError();
                            return false;
                        }
                    }
                    m_currentCardList.AddRange(validCardList);
                    errorMessage = string.Empty;
                    return true;
                }
            }
            errorMessage = NotEnoughCardsError();
            return false;
        }
        private string CardsAreNotUniqueError() 
        {
            return "The cards at hand are not unique.";
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
