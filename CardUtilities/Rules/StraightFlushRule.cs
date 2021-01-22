using CardUtilities.Enums;
using System.Collections.Generic;

namespace CardUtilities.Rules
{
    public class StraightFlushRule : Rule
    {
        StraightRule straight = new StraightRule();
        FlushRule flush = new FlushRule();
        public override bool ContainsHand(List<Card> cardsList)
        {
            if (straight.ContainsHand(cardsList) && flush.ContainsHand(cardsList))
            {
                return true;
            }
            return false;
        }

        public override CardHand GetHand()
        {
            return CardHand.StraightFlush;
        }
    }
}
