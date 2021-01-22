using CardUtilities.Enums;
using System.Collections.Generic;

namespace CardUtilities.Rules
{
    public class RoyalFlushRule : Rule
    {
        StraightFlushRule straightFlush = new StraightFlushRule();
        public override bool ContainsHand(List<Card> cardsList)
        {
            if (straightFlush.ContainsHand(cardsList))
            {
                if (cardsList[0].Value == (int)FaceCard.Ace)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public override CardHand GetHand()
        {
            return CardHand.RoyalFlush;
        }
    }
}
