using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ChessPiece
    {
        public PieceType Type { get; set; }
        public PieceColor Color { get; set; }
        public string Text { get; set; }
        public bool IsMoved { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }

    public enum PieceType
    {
        Pawn,
        Knight,
        Bishop,
        Rook,
        Queen,
        King
    }

    public enum PieceColor
    {
        White,
        Black,
    }

    public enum Colors
    {
        White,
        LightGray
    }
}
