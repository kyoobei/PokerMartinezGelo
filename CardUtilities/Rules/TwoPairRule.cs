using CardUtilities.Enums;
using System.Collections.Generic;
using System.Linq;

namespace CardUtilities.Rules
{
    public class TwoPairRule : Rule
    {
        public override bool ContainsHand(List<Card> cardsList)
        {
            List<Card> listOfOnePair = new List<Card>();
            foreach (var groupElement in cardsList.GroupBy(cards => cards.Value))
            {
                if (groupElement.Count() == 2)
                {
                    listOfOnePair.AddRange(groupElement.ToList());
                }
            }
            if (listOfOnePair.Count == 4)
            {
                return true;
            }
            return false;
        }

        public override CardHand GetHand()
        {
            return CardHand.TwoPair;
        }
    }
}
