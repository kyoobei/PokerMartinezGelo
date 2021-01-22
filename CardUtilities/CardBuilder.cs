using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CardUtilities.Enums;
namespace CardUtilities
{
    public class CardBuilder
    {
        public List<Card> Build(string playerCardCollection) 
        {
            string cardCollection = playerCardCollection.ToUpper();
            List<Card> cardsList = new List<Card>();
            List<int> cardsValueList = new List<int>();
            List<Suits> cardsSuitList = new List<Suits>();
            var cardValueMatch = Regex.Matches(cardCollection, Constants.PATTERN_VALUE);
            var cardSuitMatch = Regex.Matches(cardCollection, Constants.PATTERN_SUIT);
            foreach (Match match in cardValueMatch)
            {
                int value = 0;
                bool isValueNumeric = int.TryParse(match.Value, out value);
                if (isValueNumeric)
                {
                    value = (int.Parse(match.Value) - 1);
                }
                else
                {
                    if (match.Value.Equals("J"))
                    {
                        value = 10;
                    }
                    if (match.Value.Equals("Q"))
                    {
                        value = 11;
                    }
                    if (match.Value.Equals("K"))
                    {
                        value = 12;
                    }
                    if (match.Value.Equals("A"))
                    {
                        value = 13;
                    }
                }
                cardsValueList.Add(value);
            }
            foreach (Match match in cardSuitMatch)
            {
                if (match.Value.Equals("C"))
                {
                    cardsSuitList.Add(Suits.Clover);
                }
                else if (match.Value.Equals("S"))
                {
                    cardsSuitList.Add(Suits.Spade);
                }
                else if (match.Value.Equals("H"))
                {
                    cardsSuitList.Add(Suits.Hearts);
                }
                else if (match.Value.Equals("D"))
                {
                    cardsSuitList.Add(Suits.Diamond);
                }
            }
            for (int i = 0; i < Constants.MIN_CARD; i++)
            {
                Card newCard = new Card(cardsSuitList[i], cardsValueList[i]);
                cardsList.Add(newCard);
            }
            return cardsList;
        }
    }
}
