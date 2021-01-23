using System.Collections.Generic;
using CardUtilities.Enums;
using CardUtilities.Rules;
namespace CardUtilities
{
    class CardCheckingFactory
    {
        private List<Rule> m_rulesList;
        public CardCheckingFactory() 
        {
            m_rulesList = new List<Rule>()
            {
                new RoyalFlushRule(),
                new StraightFlushRule(),
                new FourOfAKindRule(),
                new FullHouseRule(),
                new FlushRule(),
                new StraightRule(),
                new ThreeOfAKindRule(),
                new TwoPairRule(),
                new OnePairRule(),
                new HighCardRule()
            };
        }
        public CardHand GetCardHand(List<Card> cardCollection) 
        {
            CardHand currentHand = CardHand.HighCard;
            foreach(var rule in m_rulesList) 
            {
                if (rule.ContainsHand(cardCollection)) 
                {
                    currentHand = rule.GetHand();
                    break;
                }
            }
            return currentHand;
        }
    }
}
