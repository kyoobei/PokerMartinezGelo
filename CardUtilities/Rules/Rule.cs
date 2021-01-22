using System.Collections.Generic;
using CardUtilities.Enums;

namespace CardUtilities.Rules
{
    public abstract class Rule
    {
        public abstract CardHand GetHand();
        public abstract bool ContainsHand(List<Card> cardsList);
    }
}
