using CardUtilities.Enums;
using System.Collections.Generic;
using System.Linq;

namespace CardUtilities.Rules
{
    public class ThreeOfAKindRule : Rule
    {
        public override bool ContainsHand(List<Card> cardsList)
        {
            foreach (var groupElement in cardsList.GroupBy(cards => cards.Value))
            {
                if (groupElement.Count() == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public override CardHand GetHand()
        {
            return CardHand.ThreeOfAKind;
        }
    }
}
