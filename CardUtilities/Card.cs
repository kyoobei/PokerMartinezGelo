using System;
using CardUtilities.Enums;
namespace CardUtilities
{
    public class Card
    {
        public Suits CardSuit => m_cardSuit;
        public int Value => m_value;
        private Suits m_cardSuit;
        private int m_value;
        public Card(Suits cardSuit, int value) 
        {
            m_cardSuit = cardSuit;
            m_value = value;
        }
    }
}
