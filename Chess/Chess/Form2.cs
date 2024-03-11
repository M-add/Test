using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        private bool IsCheck(bool Turn)
        {
            ChessPiece king = FindKing(Turn);

            PieceColor opponentColor = Turn ? PieceColor.Black : PieceColor.White;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (pieces[col, row] != null && pieces[col, row].Color == opponentColor)
                    {
                        if (IsAttackingKing(pieces[col, row], king))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private ChessPiece FindKing(bool whiteTurn)
        {
            PieceColor kingColor = whiteTurn ? PieceColor.White : PieceColor.Black;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (pieces[col, row] != null && pieces[col, row].Type == PieceType.King && pieces[col, row].Color == kingColor)
                    {
                        return pieces[col, row];
                    }
                }
            }

            return null;
        }

        private bool IsAttackingKing(ChessPiece opponentPiece, ChessPiece king)
        {
            switch (opponentPiece.Type)
            {
                case PieceType.Pawn:
                    return IsPawnAttackingKing(opponentPiece, king);
                case PieceType.Rook:
                    return IsRookAttackingKing(opponentPiece, king);
                case PieceType.Knight:
                    return IsKnightAttackingKing(opponentPiece, king);
                case PieceType.Bishop:
                    return IsBishopAttackingKing(opponentPiece, king);
                case PieceType.Queen:
                    return IsRookAttackingKing(opponentPiece, king) || IsBishopAttackingKing(opponentPiece, king);
                default:
                    return false;
            }
        }

        private bool IsPawnAttackingKing(ChessPiece pawn, ChessPiece king)
        {
            int NextMove = pawn.Color == PieceColor.White ? 1 : -1;
            if ((pawn.Row - NextMove == king.Row && pawn.Col + NextMove == king.Col) ||
                    pawn.Row + NextMove == king.Row && pawn.Col + NextMove == king.Col)
            {
                return true;
            }
            return false;
        }

        private bool IsRookAttackingKing(ChessPiece rook, ChessPiece king)
        {
            if (rook.Row == king.Row || rook.Col == king.Col)
            {
                if (!IsPathBlocked(rook, king, pieces))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsKnightAttackingKing(ChessPiece knight, ChessPiece king)
        {
            int[] knightRows = { 2, 2, 1, 1, -1, -1, -2, -2 };
            int[] knightCols = { 1, -1, 2, -2, 2, -2, 1, -1 };

            for (int i = 0; i < 8; i++)
            {
                int nextRow = knight.Row + knightRows[i];
                int nextCol = knight.Col + knightCols[i];

                if (nextRow >= 0 && nextRow < 8 && nextCol >= 0 && nextCol < 8)
                {
                    if (nextRow == king.Row && nextCol == king.Col)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsBishopAttackingKing(ChessPiece bishop, ChessPiece king)
        {
            if (Math.Abs(bishop.Row - king.Row) == Math.Abs(bishop.Col - king.Col))
            {
                if (!IsPathBlockedDiagonally(bishop, king, pieces))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsPathBlocked(ChessPiece from, ChessPiece to, ChessPiece[,] board)
        {
            int rowDir = Math.Sign(to.Row - from.Row);
            int colDir = Math.Sign(to.Col - from.Col);

            if (rowDir == 0)
            {
                for (int col = from.Col + colDir; col != to.Col; col += colDir)
                {
                    if (board[from.Row, col] != null)
                    {
                        return true;
                    }
                }
            }
            else if (colDir == 0)
            {
                for (int row = from.Row + rowDir; row != to.Row; row += rowDir)
                {
                    if (board[row, from.Col] != null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsPathBlockedDiagonally(ChessPiece from, ChessPiece to, ChessPiece[,] board)
        {
            int rowDir = Math.Sign(to.Row - from.Row);
            int colDir = Math.Sign(to.Col - from.Col);

            for (int row = from.Row + rowDir, col = from.Col + colDir;
                 row != to.Row && col != to.Col;
                 row += rowDir, col += colDir)
            {
                if (board[row, col] != null)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
