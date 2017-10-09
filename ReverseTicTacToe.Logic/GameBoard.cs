using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseTicTacToe.Logic
{
    public class GameBoard
    {
        public static int s_OccupiedPlacesOnBoard;

        private GameToken[,] m_Board;

        public GameToken[,] Board
        {
            get { return m_Board; }
            set { m_Board = value; }
        }

        private PositionOnBoard m_GameBoardSize;

        public PositionOnBoard GameBoardSize
        {
            get { return m_GameBoardSize; }
        }

        public GameBoard(int i_SizeOfGameBoard)
        {
            m_Board = new GameToken[i_SizeOfGameBoard, i_SizeOfGameBoard];
            initializeGameBoard(i_SizeOfGameBoard);
            m_GameBoardSize = new PositionOnBoard(i_SizeOfGameBoard, i_SizeOfGameBoard);
            s_OccupiedPlacesOnBoard = 0;
        }

        private void initializeGameBoard(int i_SizeOfGameBoard)
        {
            for (int i = 0; i < i_SizeOfGameBoard; i++)
            {
                for (int j = 0; j < i_SizeOfGameBoard; j++)
                {
                    m_Board[i, j] = new GameToken(eGameTokenValue.NoToken);
                }
            }
        }

        public void ClearBoard()
        {
            for (int i = 0; i < m_GameBoardSize.Rows; i++)
            {
                for (int j = 0; j < m_GameBoardSize.Cols; j++)
                {
                    m_Board[i, j].GameTokenValue = eGameTokenValue.NoToken;
                }
            }

            s_OccupiedPlacesOnBoard = 0;
        }
    }
}
