using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseTicTacToe.Logic
{
    public struct PositionOnBoard
    {
        private int m_Rows;

        private int m_Cols;

        public int Rows
        {
            get { return m_Rows; }
        }
        
        public int Cols
        {
            get { return m_Cols; }
        }

        public PositionOnBoard(int i_Rows, int i_Cols)
        {
            m_Rows = i_Rows;
            m_Cols = i_Cols;
        }

        public static bool operator >=(PositionOnBoard i_Place1, PositionOnBoard i_Place2)
        {
            return i_Place1.m_Rows >= i_Place2.m_Rows && i_Place1.m_Cols >= i_Place2.m_Cols;
        }

        public static bool operator <=(PositionOnBoard i_Place1, PositionOnBoard i_Place2)
        {
            return i_Place1.m_Rows <= i_Place2.m_Rows && i_Place1.m_Cols <= i_Place2.m_Cols;
        }

        public static bool operator >(PositionOnBoard i_Place1, PositionOnBoard i_Place2)
        {
            return i_Place1.m_Rows > i_Place2.m_Rows && i_Place1.m_Cols > i_Place2.m_Cols;
        }

        public static bool operator <(PositionOnBoard i_Place1, PositionOnBoard i_Place2)
        {
            return i_Place1.m_Rows < i_Place2.m_Rows && i_Place1.m_Cols < i_Place2.m_Cols;
        }

        public static bool operator ==(PositionOnBoard i_Place1, PositionOnBoard i_Place2)
        {
            return i_Place1.m_Rows == i_Place2.m_Rows && i_Place1.m_Cols == i_Place2.m_Cols;
        }

        public static bool operator !=(PositionOnBoard i_Place1, PositionOnBoard i_Place2)
        {
            return i_Place1.m_Rows != i_Place2.m_Rows || i_Place1.m_Cols != i_Place2.m_Cols;
        }
    }
}
