using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseTicTacToe.Logic
{
    public class GameManager
    {
        private GameBoard m_GameBoard;

        public GameBoard GameBoard
        {
            get { return m_GameBoard; }
        }

        private Player[] m_Players = new Player[2];
        private Player m_CurrentPlayer;
        private Player m_BenchedPlayer;

        public event EventHandler TurnEnd;

        public event EventHandler GameEnd;

        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
            set { m_CurrentPlayer = value; }
        }

        public Player BenchedPlayer
        {
            get { return m_BenchedPlayer; }
            set { m_BenchedPlayer = value; }
        }

        public GameManager(int i_SizeOfBoard, Player[] i_Players)
        {
            m_GameBoard = new GameBoard(i_SizeOfBoard);
            m_Players = i_Players;
            m_CurrentPlayer = m_Players[0];
            m_BenchedPlayer = m_Players[1];
        }

        public eActionStatus GameRound(int i_RowPosition, int i_ColPosition)
        {
            PositionOnBoard selectedPositionOnBoard = new PositionOnBoard(i_RowPosition, i_ColPosition);
            eActionStatus playerActionStatus = PreformActionOnBoard(selectedPositionOnBoard);
            return playerActionStatus;
        }

        public void ChangePlayer()
        {
            Player placeHolder = m_CurrentPlayer;
            m_CurrentPlayer = m_BenchedPlayer;
            m_BenchedPlayer = placeHolder;
            placeHolder = null;
        }

        public void RestartGame()
        {
            m_GameBoard.ClearBoard();
        }

        public eActionStatus PreformActionOnBoard(PositionOnBoard i_SelectedPositionOnBoard)
        {
            eActionStatus playerActionStatus;
            if (!isEmptyPositionOnBoard(i_SelectedPositionOnBoard))
            {
                playerActionStatus = eActionStatus.Invalid;
            }
            else
            {
                playerActionStatus = eActionStatus.Valid;
                placeTokenOnBoard(i_SelectedPositionOnBoard);

                if (isLosing(i_SelectedPositionOnBoard))
                {
                    playerActionStatus = eActionStatus.EndGameDefeat;
                }
                else if (isDraw())
                {
                    playerActionStatus = eActionStatus.EndGameDraw;
                }
            }

            return playerActionStatus;
        }

        private bool isDraw()
        {
            return GameBoard.s_OccupiedPlacesOnBoard == m_GameBoard.GameBoardSize.Rows * m_GameBoard.GameBoardSize.Cols;
        }

        private bool isEmptyPositionOnBoard(PositionOnBoard i_SelectedPositionOnBoard)
        {
            bool isEmptyPositionOnBoard = true;
            if (m_GameBoard.Board[i_SelectedPositionOnBoard.Rows, i_SelectedPositionOnBoard.Cols].GameTokenValue != eGameTokenValue.NoToken)
            {
                isEmptyPositionOnBoard = false;
            }

            return isEmptyPositionOnBoard;
        }

        private void placeTokenOnBoard(PositionOnBoard i_SelectedPositionOnBoard)
        {
            m_GameBoard.Board[i_SelectedPositionOnBoard.Rows, i_SelectedPositionOnBoard.Cols].GameTokenValue = m_CurrentPlayer.PlayerGameToken;
            m_GameBoard.Board[i_SelectedPositionOnBoard.Rows, i_SelectedPositionOnBoard.Cols].OnPlaceToken();
            GameBoard.s_OccupiedPlacesOnBoard++;
        }

        private bool isLosing(PositionOnBoard i_SelectedPositionOnBoard)
        {
            bool isLosingGame = false;
            if (isSerialRow(i_SelectedPositionOnBoard) || isSerialCol(i_SelectedPositionOnBoard) || isSerialSlant(i_SelectedPositionOnBoard) || isReverseSerialSlant(i_SelectedPositionOnBoard))
            {
                isLosingGame = true;
            }

            return isLosingGame;
        }

        public void AddScoresToPlayer()
        {
            BenchedPlayer.PlayerScore++;
        }

        private bool isSerialRow(PositionOnBoard i_SelectedPositionOnBoard)
        {
            bool isSerialRow = true;
            for (int j = 0; j < m_GameBoard.GameBoardSize.Cols && isSerialRow == true; j++)
            {
                if (m_GameBoard.Board[i_SelectedPositionOnBoard.Rows, j].GameTokenValue != m_GameBoard.Board[i_SelectedPositionOnBoard.Rows, i_SelectedPositionOnBoard.Cols].GameTokenValue)
                {
                    isSerialRow = false;
                }
            }

            return isSerialRow;
        }

        private bool isSerialCol(PositionOnBoard i_SelectedPositionOnBoard)
        {
            bool isSerialCol = true;
            for (int i = 0; i < m_GameBoard.GameBoardSize.Rows && isSerialCol == true; i++)
            {
                if (m_GameBoard.Board[i, i_SelectedPositionOnBoard.Cols].GameTokenValue != m_GameBoard.Board[i_SelectedPositionOnBoard.Rows, i_SelectedPositionOnBoard.Cols].GameTokenValue)
                {
                    isSerialCol = false;
                }
            }

            return isSerialCol;
        }

        private bool isSerialSlant(PositionOnBoard i_SelectedPositionOnBoard)
        {
            bool isSerialSlant = i_SelectedPositionOnBoard.Rows == i_SelectedPositionOnBoard.Cols;
            if (isSerialSlant)
            {
                for (int i = 0; i < m_GameBoard.GameBoardSize.Rows && isSerialSlant == true; i++)
                {
                    if (m_GameBoard.Board[i, i].GameTokenValue != m_GameBoard.Board[i_SelectedPositionOnBoard.Rows, i_SelectedPositionOnBoard.Cols].GameTokenValue)
                    {
                        isSerialSlant = false;
                    }
                }
            }

            return isSerialSlant;
        }

        private bool isReverseSerialSlant(PositionOnBoard i_SelectedPositionOnBoard)
        {
            bool isSerialReverseSlant = i_SelectedPositionOnBoard.Rows + i_SelectedPositionOnBoard.Cols == m_GameBoard.GameBoardSize.Cols - 1;

            if (isSerialReverseSlant)
            {
                for (int i = 0; i < m_GameBoard.GameBoardSize.Rows && isSerialReverseSlant == true; i++)
                {
                    if (m_GameBoard.Board[i, m_GameBoard.GameBoardSize.Cols - 1 - i].GameTokenValue != m_GameBoard.Board[i_SelectedPositionOnBoard.Rows, i_SelectedPositionOnBoard.Cols].GameTokenValue)
                    {
                        isSerialReverseSlant = false;
                    }
                }
            }

            return isSerialReverseSlant;
        }

        public void OnTurnEnd()
        {
            if (TurnEnd != null)
            {
                TurnEnd.Invoke(this, null);
            }
        }

        public void OnGameEnd()
        {
            if (GameEnd != null)
            {
                GameEnd.Invoke(this, null);
            }
        }
    }
}
