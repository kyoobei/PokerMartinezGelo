using CardUtilities.Enums;
using System.Collections.Generic;

namespace CardUtilities.Rules
{
    public class HighCardRule : Rule
    {
        public override bool ContainsHand(List<Card> cardsList)
        {
            //Since this is the default hand or lowest hand
            return true;
        }

        public override CardHand GetHand()
        {
            return CardHand.HighCard;
        }
    }
}
