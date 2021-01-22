using System.Collections.Generic;

namespace CardUtilities
{
    public class PokerGame
    {
        public int NumberOfPlayers => m_pokerPlayers.Count;

        private List<PokerPlayer> m_pokerPlayers = new List<PokerPlayer>();
        private CardBuilder m_cardBuilder;
        private CardCheckingFactory m_cardCheckingFactory;
        public PokerGame() 
        {
            m_cardBuilder = new CardBuilder();
            m_cardCheckingFactory = new CardCheckingFactory();
        }
        public void AddPlayer(string name, string cardCollection) 
        {
            m_pokerPlayers.Add
                (new PokerPlayer(name, cardCollection, m_cardBuilder, m_cardCheckingFactory));
        }
        public void StartGame() 
        {
            if (m_pokerPlayers.Count <= 0)
                return;

            for(int i = 0; i < m_pokerPlayers.Count; i++) 
            {
                m_pokerPlayers[i].Start();
            }
        }
        public string GetPlayerName(int index) 
        {
            return m_pokerPlayers[index].Name;
        }
        public string GetCardCollection(int index) 
        {
            return m_pokerPlayers[index].CardCollection;
        }
        public string GetPlayerHand(int index) 
        {
            return m_pokerPlayers[index].Hand.ToString();
        }
        public List<string> GetWinners() 
        {
            List<PokerPlayer> temporaryWinners = new List<PokerPlayer>();
            List<string> finalWinners = new List<string>();
            for(int i = 0; i < m_pokerPlayers.Count; i++) 
            {
                if(temporaryWinners.Count <= 0)
                {
                    temporaryWinners.Add(m_pokerPlayers[i]);
                }
                else if(temporaryWinners.Count > 0)
                {
                    int tempWinner = (int)temporaryWinners[0].Hand;
                    int currentPlayer = (int)m_pokerPlayers[i].Hand;
                    if (currentPlayer > tempWinner)
                    {
                        temporaryWinners.Clear();
                        temporaryWinners.Add(m_pokerPlayers[i]);
                    }
                    else if (currentPlayer.Equals(tempWinner))
                    {
                        temporaryWinners.Add(m_pokerPlayers[i]);
                    }
                }
            }
            if(temporaryWinners.Count > 1) 
            {
                List<PokerPlayer> winners = new List<PokerPlayer>();
                for(int i = 0; i < temporaryWinners.Count; i++) 
                {
                    if (winners.Count <= 0)
                    {
                        winners.Add(temporaryWinners[i]);
                    }
                    else if (winners.Count > 0)
                    {
                        for (int j = 0; j < winners[0].PlayerCards.Count; j++)
                        {
                            int currentPlayerValue = temporaryWinners[i].PlayerCards[j].Value;
                            int compareValue = winners[0].PlayerCards[j].Value;
                            if (currentPlayerValue > compareValue) 
                            {
                                winners.Clear();
                                winners.Add(temporaryWinners[i]);
                                continue;
                            }
                            if(j == winners[0].PlayerCards.Count - 1) 
                            {
                                //if at the end of count its still equal then add
                                winners.Add(temporaryWinners[i]);   
                            }
                        }
                    }
                }
                for(int i = 0; i < winners.Count; i++) 
                {
                    finalWinners.Add(winners[i].Name);
                }
            }
            else if(temporaryWinners.Count <= 1) 
            {
                finalWinners.Add(temporaryWinners[0].Name);
            }
            return finalWinners;
        }
    }
}
