using System.Collections.Generic;
using CardUtilities.Enums;

namespace CardUtilities
{
    class PokerPlayer
    {
        public string Name => m_name;
        public string CardCollection => m_cardCollection;
        public List<Card> PlayerCards => m_playerCardsList;
        public CardHand Hand => m_cardHand;

        private CardBuilder m_cardBuilder;
        private CardCheckingFactory m_cardCheckingFactory;
        private List<Card> m_playerCardsList;
        private CardHand m_cardHand;
        private string m_name;
        private string m_cardCollection;
        public PokerPlayer(string name, string cardCollection, CardBuilder cardBuilder,
            CardCheckingFactory cardCheckingFactory) 
        {
            m_name = name;
            m_cardCollection = cardCollection;
            m_cardBuilder = cardBuilder;
            m_cardCheckingFactory = cardCheckingFactory;
        }
        public void Start() 
        {
            m_playerCardsList = new List<Card>(m_cardBuilder.Build(m_cardCollection));
            m_cardHand = m_cardCheckingFactory.GetCardHand(m_playerCardsList);
        }
    }
}
