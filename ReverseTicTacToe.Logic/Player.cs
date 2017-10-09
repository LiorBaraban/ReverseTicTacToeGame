using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseTicTacToe.Logic
{  
    public class Player
    {
        private string m_PlayerName;

        public string PlayerName
        {
            get { return m_PlayerName; }
        }

        private eGameTokenValue m_PlayerGameToken;

        public eGameTokenValue PlayerGameToken
        {
            get { return m_PlayerGameToken; }
        }

        private bool m_IsAI;

        public bool IsAI
        {
            get { return m_IsAI; }
        }

        private int m_PlayerScore;

        public int PlayerScore
        {
            get { return m_PlayerScore; }
            set { m_PlayerScore = value; }
        }

        public Player(string i_PlayerName, eGameTokenValue i_PlayerToken, bool i_IsAI)
        {
            m_PlayerName = i_PlayerName;
            m_PlayerGameToken = i_PlayerToken;
            m_IsAI = i_IsAI;
            m_PlayerScore = 0;
        }

        public void AddPoint()
        {
            PlayerScore++;
        }
    }
}
