using CardUtilities.Enums;
using System.Collections.Generic;

namespace CardUtilities.Rules
{
    public class StraightRule : Rule
    {
        public override bool ContainsHand(List<Card> cardsList)
        {
            for (int i = 0; i < cardsList.Count; i++)
            {
                if (i != cardsList.Count - 1)
                {
                    int nextCardValue = cardsList[i + 1].Value;
                    int expectedCardValue = cardsList[i].Value - 1;
                    if (expectedCardValue.Equals(nextCardValue))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override CardHand GetHand()
        {
            return CardHand.Straight;
        }
    }
}
