using CardUtilities.Enums;
using System.Collections.Generic;

namespace CardUtilities.Rules
{
    public class FullHouseRule : Rule
    {
        OnePairRule onePair = new OnePairRule();
        ThreeOfAKindRule threeOfAKind = new ThreeOfAKindRule();
        public override bool ContainsHand(List<Card> cardsList)
        {
            if (threeOfAKind.ContainsHand(cardsList) && onePair.ContainsHand(cardsList))
            {
                return true;
            }
            return false;
        }

        public override CardHand GetHand()
        {
            return CardHand.FullHouse;
        }
    }
}
