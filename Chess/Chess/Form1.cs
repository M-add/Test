using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        private Button[,] buttons = new Button[8, 8];
        private Colors[,] colors = new Colors[8, 8];
        private ChessPiece[,] pieces = new ChessPiece[8, 8];
        private ChessPiece selected;
        private int SelectedCol;
        private int SelectedRow;

        private bool turn = true;
        private bool MouseHovered = false;
        private Dictionary<Tuple<int, int>, Color> prevColor = new Dictionary<Tuple<int, int>, Color>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1Load(object sender, EventArgs e)
        {
            InitializeBoard();
            SetTroops();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button button = new Button
                    {
                        Dock = DockStyle.Fill,
                        Font = new Font("Microsoft Tai Le", 12, FontStyle.Regular),
                        BackColor = (i + j) % 2 == 0 ? Color.White : Color.LightGray
                    };
                    //button.MouseMove += OnMouseHover;
                    //button.MouseLeave += OnMouseLeave;
                    button.Click += OnButtonClick;

                    LayoutPanel.Controls.Add(button, j, i);
                    buttons[i, j] = button;
                    colors[i, j] = (i + j) % 2 == 0 ? Colors.White : Colors.LightGray;
                }
            }
        }

        private void SetTroops()
        {
            for (int i = 0; i < 8; i++)
            {
                ChessPiece piece = new ChessPiece
                {
                    Type = PieceType.Pawn,
                    Color = PieceColor.White,
                    Row = i,
                    Col = 1
                };
                piece.Text = piece.Color.ToString() + " " + piece.Type.ToString();
                buttons[1, i].Text = piece.Text;
                pieces[i, 1] = piece;
            }

            for (int i = 0; i < 8; i++)
            {
                ChessPiece piece = new ChessPiece
                {
                    Type = PieceType.Pawn,
                    Row = i,
                    Col = 6,
                    Color = PieceColor.Black
                };
                piece.Text = piece.Color.ToString() + " " + piece.Type.ToString();
                buttons[6, i].Text = piece.Text;
                pieces[i, 6] = piece;
            }

            for (int i = 0; i < 8; i++)
            {
                ChessPiece piece;
                if (i == 0 || i == 7)
                {
                    piece = new ChessPiece
                    {
                        Type = PieceType.Rook,
                        Row = i,
                        Col = 0,
                        Color = PieceColor.White
                    };
                    piece.Text = piece.Color.ToString() + " " + piece.Type.ToString();
                    buttons[0, i].Text = piece.Text;
                }
                else if (i == 1 || i == 6)
                {
                    piece = new ChessPiece
                    {
                        Type = PieceType.Knight,
                        Row = i,
                        Col = 0,
                        Color = PieceColor.White
                    };
                    piece.Text = piece.Color.ToString() + " " + piece.Type.ToString();
                    buttons[0, i].Text = piece.Text;
                }
                else if (i == 2 || i == 5)
                {
                    piece = new ChessPiece
                    {
                        Type = PieceType.Bishop,
                        Row = i,
                        Col = 0,
                        Color = PieceColor.White
                    };
                    piece.Text = piece.Color.ToString() + " " + piece.Type.ToString();
                    buttons[0, i].Text = piece.Text;
                }
                else if (i == 3)
                {
                    piece = new ChessPiece
                    {
                        Type = PieceType.King,
                        Row = i,
                        Col = 0,
                        Color = PieceColor.White
                    };
                    piece.Text = piece.Color.ToString() + " " + piece.Type.ToString();
                    buttons[0, i].Text = piece.Text;
                }
                else
                {
                    piece = new ChessPiece
                    {
                        Type = PieceType.Queen,
                        Row = i,
                        Col = 0,
                        Color = PieceColor.White
                    };
                    piece.Text = piece.Color.ToString() + " " + piece.Type.ToString();
                    buttons[0, i].Text = piece.Text;
                }
                pieces[i, 0] = piece;
            }

            for (int i = 0; i < 8; i++)
            {
                ChessPiece piece;
                if (i == 0 || i == 7)
                {
                    piece = new ChessPiece
                    {
                        Type = PieceType.Rook,
                        Row = i,
                        Col = 7,
                        Color = PieceColor.Black
                    };
                    piece.Text = piece.Color.ToString() + " " + piece.Type.ToString();
                    buttons[7, i].Text = piece.Text;
                }
                else if (i == 1 || i == 6)
                {
                    piece = new ChessPiece
                    {
                        Type = PieceType.Knight,
                        Row = i,
                        Col = 7,
                        Color = PieceColor.Black
                    };
                    piece.Text = piece.Color.ToString() + " " + piece.Type.ToString();
                    buttons[7, i].Text = piece.Text;
                }
                else if (i == 2 || i == 5)
                {
                    piece = new ChessPiece
                    {
                        Type = PieceType.Bishop,
                        Row = i,
                        Col = 7,
                        Color = PieceColor.Black
                    };
                    piece.Text = piece.Color.ToString() + " " + piece.Type.ToString();
                    buttons[7, i].Text = piece.Text;
                }
                else if (i == 3)
                {
                    piece = new ChessPiece
                    {
                        Type = PieceType.King,
                        Row = i,
                        Col = 7,
                        Color = PieceColor.Black
                    };
                    piece.Text = piece.Color.ToString() + " " + piece.Type.ToString();
                    buttons[7, i].Text = piece.Text;
                }
                else
                {
                    piece = new ChessPiece
                    {
                        Type = PieceType.Queen,
                        Row = i,
                        Col = 7,
                        Color = PieceColor.Black
                    };
                    piece.Text = piece.Color.ToString() + " " + piece.Type.ToString();
                    buttons[7, i].Text = piece.Text;
                }
                pieces[i, 7] = piece;
            }

        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int row = LayoutPanel.GetRow(button);
            int col = LayoutPanel.GetColumn(button);
            button.Focus();

            ChessPiece Attackable = null;

            if (pieces[col, row] != null && (selected == null ||
                pieces[col, row].Color == selected.Color))
            {
                selected = pieces[col, row];
                SelectedCol = col;
                SelectedRow = row;
            }

            if (prevColor.ContainsKey(new Tuple<int, int>(row, col)) && pieces[col, row] != null &&
                pieces[col, row].Color != selected.Color && button.Text != "")
            {
                Attackable = pieces[col, row];
            }

            MouseHovered = !MouseHovered;
            OnMouseHover(sender, EventArgs.Empty);
            OnMouseLeave(sender, EventArgs.Empty);

            try
            {
                if ((turn && selected.Color == PieceColor.White) || (!turn && selected.Color == PieceColor.Black))
                {
                    MakeMove(row, col, Attackable, button);
                }
                else
                {
                    selected = null;
                }
            }
            catch (Exception)
            {
            }
        }

        private void MakeMove(int row, int col, ChessPiece Attackable, Button button)
        {
            if (selected != null && pieces[SelectedCol, SelectedRow] != null &&
                prevColor.ContainsKey(new Tuple<int, int>(row, col)))
            {
                if (selected != null && Attackable != null)
                {
                    Attackable = null;
                    pieces[col, row] = selected;
                    selected.IsMoved = true;
                    buttons[row, col].Text = selected.Text;
                    buttons[SelectedRow, SelectedCol].Text = "";
                    pieces[SelectedCol, SelectedRow] = null;
                    selected = null;
                }
                else
                {
                    button.Text = selected.Text;
                    buttons[SelectedRow, SelectedCol].Text = "";
                    selected.IsMoved = true;
                    pieces[SelectedCol, SelectedRow] = null;
                    pieces[col, row] = selected;
                    pieces[col, row].Row = col;
                    pieces[col, row].Col = row;
                    selected = null;
                }
                UpdateTurn();
                if (IsCheck(turn))
                {
                    PieceColor Current = turn ? PieceColor.White : PieceColor.Black;
                    MessageBox.Show($"{Current} King is in Danger:", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
        private void UpdateTurn()
        {
            turn = !turn;
            TurnLabel.Text = (turn) ? "White's Turn" : "Black's Turn";
        }
        private void OnMouseHover(object sender, EventArgs e)
        {
            if (MouseHovered)
            {
                Button button = (Button)sender;
                int row = LayoutPanel.GetRow(button);
                int col = LayoutPanel.GetColumn(button);

                if (pieces[col, row] != null)
                {
                    HighlightMoves(col, row);
                }
            }
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            if (!MouseHovered)
            {
                if (prevColor.Count > 0)
                {
                    foreach (var val in prevColor)
                    {
                        int row = val.Key.Item1;
                        int col = val.Key.Item2;
                        buttons[row, col].BackColor = (row + col) % 2 == 0 ? Color.White : Color.LightGray;
                    }
                }
            }
        }

        private void HighlightMoves(int col, int row)
        {
            prevColor.Clear();

            ChessPiece troop = pieces[col, row];

            if (troop.Type == PieceType.Pawn)
            {
                if (troop.Color == PieceColor.Black && turn == false)
                {
                    MovePawn(row, col, troop);
                }
                else if (troop.Color == PieceColor.White && turn == true)
                {
                    MovePawn(row, col, troop);
                }
            }
            else if (troop.Type == PieceType.Knight)
            {
                if (troop.Color == PieceColor.Black && turn == false)
                {
                    MoveKnight(row, col, troop);
                }
                else if (troop.Color == PieceColor.White && turn == true)
                {
                    MoveKnight(row, col, troop);
                }
            }
            else if (troop.Type == PieceType.King)
            {
                if (troop.Color == PieceColor.Black && turn == false)
                {
                    MoveKing(row, col, troop);
                }
                else if (troop.Color == PieceColor.White && turn == true)
                {
                    MoveKing(row, col, troop);
                }
            }
            else if (troop.Type == PieceType.Queen)
            {
                if (troop.Color == PieceColor.Black && turn == false)
                {
                    MoveQueen(row, col, troop);
                }
                else if (troop.Color == PieceColor.White && turn == true)
                {
                    MoveQueen(row, col, troop);
                }
            }
            else if (troop.Type == PieceType.Bishop)
            {
                if (troop.Color == PieceColor.Black && turn == false)
                {
                    MoveBishop(row, col, troop);
                }
                else if (troop.Color == PieceColor.White && turn == true)
                {
                    MoveBishop(row, col, troop);
                }
            }
            else if (troop.Type == PieceType.Rook)
            {
                if (troop.Color == PieceColor.Black && turn == false)
                {
                    MoveRook(row, col, troop);
                }
                else if (troop.Color == PieceColor.White && turn == true)
                {
                    MoveRook(row, col, troop);
                }
            }

            foreach (var key in prevColor.Keys)
            {
                int r = key.Item1;
                int c = key.Item2;
                if (pieces[c, r] != null)
                {
                    buttons[r, c].BackColor = Color.Crimson;
                }
            }
        }

        private void MovePawn(int row, int col, ChessPiece troop)
        {
            int direction = (troop.Color == PieceColor.White) ? 1 : -1;
            int newRow = row + direction;
            int newCol = col;

            if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8 && pieces[newCol, newRow] == null)
            {
                prevColor.Add(new Tuple<int, int>(newRow, newCol), SystemColors.ActiveCaption);
                buttons[newRow, newCol].BackColor = SystemColors.ActiveCaption;
                if (!troop.IsMoved)
                {
                    newRow += direction;
                    if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8 && pieces[newCol, newRow] == null)
                    {
                        prevColor.Add(new Tuple<int, int>(newRow, newCol), SystemColors.ActiveCaption);
                        buttons[newRow, newCol].BackColor = SystemColors.ActiveCaption;
                    }
                }
            }

            int[] capture = { -1, 1 };
            foreach (int dx in capture)
            {
                newRow = row + direction;
                newCol = col + dx;
                if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8 &&
                    pieces[newCol, newRow] != null && pieces[newCol, newRow].Color != troop.Color)
                {
                    prevColor.Add(new Tuple<int, int>(newRow, newCol), SystemColors.ActiveCaption);
                    buttons[newRow, newCol].BackColor = SystemColors.ActiveCaption;
                }
            }
        }

        private void MoveKnight(int row, int col, ChessPiece troop)
        {
            int[] dx = { -2, -2, -1, -1, 1, 1, 2, 2 };
            int[] dy = { -1, 1, -2, 2, -2, 2, -1, 1 };

            for (int i = 0; i < dx.Length; i++)
            {
                int newRow = row - dx[i];
                int newCol = col - dy[i];

                if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
                {
                    if (pieces[newCol, newRow] == null || pieces[newCol, newRow].Color != troop.Color)
                    {
                        prevColor.Add(new Tuple<int, int>(newRow, newCol), SystemColors.ActiveCaption);
                        buttons[newRow, newCol].BackColor = SystemColors.ActiveCaption;
                    }
                }
            }
        }

        private void MoveKing(int row, int col, ChessPiece king)
        {
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            king.Row = row;
            king.Col = col;

            for (int i = 0; i < dx.Length; i++)
            {
                int newRow = row + dx[i];
                int newCol = col + dy[i];

                if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
                {
                    if (pieces[newCol, newRow] == null || pieces[newCol, newRow].Color != king.Color)
                    {
                        prevColor.Add(new Tuple<int, int>(newRow, newCol), SystemColors.ActiveCaption);
                        buttons[newRow, newCol].BackColor = SystemColors.ActiveCaption;
                    }
                }
            }
        }

        private void MoveQueen(int row, int col, ChessPiece troop)
        {
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < dx.Length; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    int newRow = row + j * dx[i];
                    int newCol = col + j * dy[i];

                    if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
                    {
                        if (pieces[newCol, newRow] == null || pieces[newCol, newRow].Color != troop.Color)
                        {
                            prevColor.Add(new Tuple<int, int>(newRow, newCol), SystemColors.ActiveCaption);
                            buttons[newRow, newCol].BackColor = SystemColors.ActiveCaption;
                        }
                        if (pieces[newCol, newRow] != null)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void MoveBishop(int row, int col, ChessPiece troop)
        {
            int[] dx = { -1, -1, 1, 1 };
            int[] dy = { -1, 1, -1, 1 };

            for (int i = 0; i < dx.Length; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    int newRow = row + j * dx[i];
                    int newCol = col + j * dy[i];

                    if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
                    {
                        if (pieces[newCol, newRow] == null || pieces[newCol, newRow].Color != troop.Color)
                        {
                            prevColor.Add(new Tuple<int, int>(newRow, newCol), SystemColors.ActiveCaption);
                            buttons[newRow, newCol].BackColor = SystemColors.ActiveCaption;
                        }
                        if (pieces[newCol, newRow] != null)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void MoveRook(int row, int col, ChessPiece troop)
        {
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            for (int i = 0; i < dx.Length; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    int newRow = row + j * dx[i];
                    int newCol = col + j * dy[i];

                    if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
                    {
                        if (pieces[newCol, newRow] == null || pieces[newCol, newRow].Color != troop.Color)
                        {
                            prevColor.Add(new Tuple<int, int>(newRow, newCol), SystemColors.ActiveCaption);
                            buttons[newRow, newCol].BackColor = SystemColors.ActiveCaption;
                        }
                        if (pieces[newCol, newRow] != null)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
