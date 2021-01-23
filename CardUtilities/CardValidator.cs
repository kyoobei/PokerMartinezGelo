using System.Collections.Generic;
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
                    List<string> cardsNotUniqueList = new List<string>();
                    string notUniqueConcatenate = string.Empty;
                    for(int i = 0; i < validCardList.Count; i++) 
                    {
                        if (m_currentCardList.Contains(validCardList[i])) 
                        {
                            cardsNotUniqueList.Add(validCardList[i]);
                        }
                    }
                    if (cardsNotUniqueList.Count <= 0)
                    {
                        m_currentCardList.AddRange(validCardList);
                        errorMessage = string.Empty;
                        return true;
                    }
                    else 
                    {
                        for(int i = 0; i < cardsNotUniqueList.Count; i++) 
                        {
                            notUniqueConcatenate += string.Format(" {0}", cardsNotUniqueList[i]);
                        }
                        errorMessage = CardsAreNotUniqueError(notUniqueConcatenate);
                        return false;
                    }
                }
            }
            errorMessage = NotEnoughCardsError();
            return false;
        }
        private string CardsAreNotUniqueError(string cardNotUnique) 
        {
            return string.Format("The card/s{0} at hand are not unique.", cardNotUnique);
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
