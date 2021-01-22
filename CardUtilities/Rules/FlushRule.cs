using CardUtilities.Enums;
using System.Collections.Generic;
using System.Linq;

namespace CardUtilities.Rules
{
    public class FlushRule : Rule
    {
        public override bool ContainsHand(List<Card> cardsList)
        {
            if (cardsList.GroupBy(card => card.CardSuit).Count() == 1)
            {
                return true;
            }
            return false;
        }

        public override CardHand GetHand()
        {
            return CardHand.Flush;
        }
    }
}
