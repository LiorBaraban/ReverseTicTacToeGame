using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReverseTicTacToe.UI
{
    public class GameButton : Button
    {
        private int m_RowValue;
        private int m_ColValue;

        public GameButton(int i_GameRowValue, int i_GameColValue, Size i_Size, int i_Margin, Point i_Location) : base()
        {
            m_RowValue = i_GameRowValue;
            m_ColValue = i_GameColValue;
            Size = i_Size;
            Margin = new Padding(i_Margin);
            Location = i_Location;
            Visible = true;
            Anchor = AnchorStyles.Top | AnchorStyles.Left;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        public int RowValue
        {
            get { return m_RowValue; }
        }

        public int ColValue
        {
            get { return m_ColValue; }
        }

        public void Board_DrawPlaceToken(object sender, EventArgs e)
        {
            ReverseTicTacToe.Logic.GameToken currentGameToken = sender as ReverseTicTacToe.Logic.GameToken;
            if (currentGameToken.GameTokenValue == ReverseTicTacToe.Logic.eGameTokenValue.Player1Token)
            {
                BackgroundImage = Properties.Resources.xMark;
            }
            else if (currentGameToken.GameTokenValue == ReverseTicTacToe.Logic.eGameTokenValue.Player2Token)
            {
                BackgroundImage = Properties.Resources.oMark;
            }
        }
    }
}
