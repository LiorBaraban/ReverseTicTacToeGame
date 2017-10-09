using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseTicTacToe.Logic
{
    public class GameToken
    {
        private eGameTokenValue m_GameTokenValue;

        public event EventHandler PlaceToken;

        public eGameTokenValue GameTokenValue
        {
            get { return m_GameTokenValue; }
            set { m_GameTokenValue = value; }
        }

        public GameToken(eGameTokenValue entryValueToken)
        {
            m_GameTokenValue = entryValueToken;
        }

        public void OnPlaceToken()
        {
            if (PlaceToken != null)
            {
                PlaceToken.Invoke(this, null);
            }
        }
    }
}
