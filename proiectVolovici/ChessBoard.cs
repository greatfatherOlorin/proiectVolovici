using System;
using System.Drawing;
using System.Windows.Forms;

namespace proiectVolovici
{

    class ChessBoard
    {
        private const int ROW = 10;
        private int COLUMN = 10;
        private int WIDTH = 40;
        private int HEIGHT = 40;

        private Piece[,] pieces;
        private Piece selectedPiece;
        public Piece SelectedPiece
        {
            get { return selectedPiece; }
            set { selectedPiece = value; }
        }

        public Piece GetPiece(int row, int column)
        {
            return pieces[row, column];
        }
        private PictureBox chessPictureBox;
        public ChessBoard(PictureBox pictureBox)
        {
            chessPictureBox = pictureBox;
            initializePieces();
        }


        private void initializePieces()
        {
            pieces = new Piece[ROW, COLUMN];

            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {

                    if (row == 1)
                    {
                        InitializePawn(row, col, @"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\bluePawn.png", "Black");
                    }
                    else if (row == 8)
                    {
                        InitializePawn(row, col, @"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whitePawn.png", "White");
                    }
                    else if (row == 9)
                    {
                        InitializeWhitePieces(row, col);
                    }
                    else if (row == 0)
                    {
                        InitializeBluePieces(row, col);
                    }
                }
            }
        }

        private void InitializePawn(int row, int col, string imagePath, string tag)
        {
            pieces[row, col] = new Piece
            {
                Type = Piece.PieceType.Pawn,
                Bitmap = new Bitmap(Image.FromFile(imagePath)),
                Row = row,
                Column = col
            };
            pieces[row, col].Bitmap.Tag = tag;
        }

        private void InitializeWhitePieces(int row, int col)
        {
            Bitmap pieceBitmap = null;
            string tag = "White";

            if (col == 0 || col == 9)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteRook.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Rook, pieceBitmap, row, col);
            }
            else if (col == 1 || col == 8)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteKnight.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Knight, pieceBitmap, row, col);
            }
            else if (col == 2 || col == 7)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteArrow.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Arrow, pieceBitmap, row, col);
            }
            else if (col == 3 || col == 6)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteBishop.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Bishop, pieceBitmap, row, col);
            }
            else if (col == 4)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteQueen.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Queen, pieceBitmap, row, col);
            }
            else if (col == 5)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteKing.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.King, pieceBitmap, row, col);
            }

            pieces[row, col].Bitmap.Tag = tag;
        }

        private void InitializeBluePieces(int row, int col)
        {
            Bitmap pieceBitmap = null;
            string tag = "Blue";

            if (col == 0 || col == 9)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\blueRook.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Rook, pieceBitmap, row, col);
            }
            else if (col == 1 || col == 8)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\blueKnight.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Knight, pieceBitmap, row, col);
            }
            else if (col == 2 || col == 7)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\blueArrow.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Arrow, pieceBitmap, row, col);
            }
            else if (col == 3 || col == 6)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\blueBishop.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Bishop, pieceBitmap, row, col);
            }
            else if (col == 4)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\blueQueen.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Queen, pieceBitmap, row, col);
            }
            else if (col == 5)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\blueKing.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.King, pieceBitmap, row, col);
            }

            pieces[row, col].Bitmap.Tag = tag;
        }

        private Piece CreatePiece(Piece.PieceType type, Bitmap bitmap, int row, int col)
        {
            return new Piece
            {
                Type = type,
                Bitmap = bitmap,
                Row = row,
                Column = col
            };
        }

        public void drawBoard(Graphics g)
        {
            SolidBrush beigeBrush = new SolidBrush(Color.Beige);
            SolidBrush aquamarineBrush = new SolidBrush(Color.Aquamarine);

            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COLUMN; j++)
                {
                    if ((j % 2 == 0 && i % 2 == 0) || (j % 2 != 0 && i % 2 != 0))
                        g.FillRectangle(beigeBrush, i * WIDTH, j * HEIGHT, WIDTH, HEIGHT);
                    else if ((j % 2 == 0 && i % 2 != 0) || (j % 2 != 0 && i % 2 == 0))
                        g.FillRectangle(aquamarineBrush, i * WIDTH, j * HEIGHT, WIDTH, HEIGHT);
                }
            }

            foreach (Piece piece in pieces)
            {
                if (piece != null)
                {
                    int x = piece.Column * WIDTH;
                    int y = piece.Row * HEIGHT;
                    g.DrawImage(piece.Bitmap, x, y, WIDTH, HEIGHT);
                }
            }
        }

        public void moveSelectedPiece(Piece selectedPiece, int newRow, int newColumn)
        {
            if (selectedPiece == null)
                return;
            if (IsValidMove(selectedPiece.Row, selectedPiece.Column, newRow, newColumn))
            {
                pieces[newRow, newColumn] = selectedPiece;
                pieces[selectedPiece.Row, selectedPiece.Column] = null; // Set the previous position to null
                selectedPiece.Row = newRow;
                selectedPiece.Column = newColumn;
            }
        }

        public bool selectPiece(int row, int column)
        {
            selectedPiece = pieces[row, column];
            return selectedPiece != null;
        }
        public bool IsValidMove(int currentRow, int currentColumn, int newRow, int newColumn)
        {
            Piece currentPiece = pieces[currentRow, currentColumn];

            if (currentPiece == null)
                return false;

            if (currentPiece.Type == Piece.PieceType.Pawn)
                return IsValidPawnMove(currentPiece, currentRow, currentColumn, newRow, newColumn);

            return IsValidPieceMove(currentPiece, currentRow, currentColumn, newRow, newColumn);
        }

        private bool IsValidPawnMove(Piece pawn, int currentRow, int currentColumn, int newRow, int newColumn)
        {
            int direction = (pawn.Bitmap.Tag.ToString() == "White") ? -1 : 1;

            if (!IsValidSquare(newRow, newColumn))
                return false;

            if (IsForwardMove(pawn, currentRow, currentColumn, newRow, newColumn, direction))
            {
                if (IsEmptySquare(newRow, newColumn))
                {
                    pawn.HasMoved = true;
                    return true;
                }
            }

            if (IsEnPassantCapture(pawn, currentRow, currentColumn, newRow, newColumn, direction))
            {
                pieces[currentRow, newColumn] = null;
                return true;
            }

            if (IsDoubleForwardMove(pawn, currentRow, currentColumn, newRow, newColumn, direction))
            {
                pawn.HasDoubleStepped = true;
                pawn.HasMoved = true;
                return true;
            }

            if (IsPawnCapture(pawn, currentRow, currentColumn, newRow, newColumn, direction))
                return true;

            return false;
        }

        private bool IsForwardMove(Piece pawn, int currentRow, int currentColumn, int newRow, int newColumn, int direction)
        {
            return newColumn == currentColumn && (newRow - currentRow == direction);
        }

        private bool IsEnPassantCapture(Piece pawn, int currentRow, int currentColumn, int newRow, int newColumn, int direction)
        {
            if (Math.Abs(newColumn - currentColumn) == 1 && newRow - currentRow == direction)
            {
                Piece destinationPiece = pieces[newRow, newColumn];

                if (destinationPiece == null)
                {
                    Piece leftPiece = GetPieceAt(currentRow, currentColumn - 1);
                    Piece rightPiece = GetPieceAt(currentRow, currentColumn + 1);

                    if ((leftPiece != null && IsOpponentPawn(leftPiece, pawn, currentRow, newColumn, direction) && IsEnPassantRow(currentRow, direction) && leftPiece.HasDoubleStepped) ||
                        (rightPiece != null && IsOpponentPawn(rightPiece, pawn, currentRow, newColumn, direction) && IsEnPassantRow(currentRow, direction) && rightPiece.HasDoubleStepped))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsEnPassantRow(int row, int direction)
        {
            return row == (direction == -1 ? 3 : 6);
        }

        private bool IsOpponentPawn(Piece pawn, Piece currentPawn, int currentRow, int newColumn, int direction)
        {
            return pawn.Type == Piece.PieceType.Pawn &&
                   pawn.Bitmap.Tag.ToString() != currentPawn.Bitmap.Tag.ToString() &&
                   pawn.Row == currentRow &&
                   pawn.Column == newColumn;
        }

        private bool IsDoubleForwardMove(Piece pawn, int currentRow, int currentColumn, int newRow, int newColumn, int direction)
        {
            if (currentRow == (direction == -1 ? ROW - 2 : 1) && currentColumn == newColumn)
            {
                if (newRow == currentRow + (1 * direction) && IsEmptySquare(newRow, newColumn))
                {
                    pawn.HasDoubleStepped = true;
                    pawn.HasMoved = true;
                    return true;
                }

                if (!pawn.HasDoubleStepped && !pawn.HasMoved && newRow == currentRow + (2 * direction) &&
                    IsEmptySquare(newRow, newColumn) && IsEmptySquare(currentRow + (1 * direction), newColumn))
                {
                    pawn.HasDoubleStepped = true;
                    pawn.HasMoved = true;
                    return true;
                }
            }

            return false;
        }

        private bool IsPawnCapture(Piece pawn, int currentRow, int currentColumn, int newRow, int newColumn, int direction)
        {
            if (Math.Abs(newColumn - currentColumn) == 1 && newRow - currentRow == direction)
            {
                Piece destinationPiece = GetPieceAt(newRow, newColumn);
                if (destinationPiece != null && destinationPiece.Bitmap.Tag.ToString() != pawn.Bitmap.Tag.ToString())
                    return true;
            }

            return false;
        }

        private bool IsValidPieceMove(Piece piece, int currentRow, int currentColumn, int newRow, int newColumn)
        {
            Piece destinationPiece = GetPieceAt(newRow, newColumn);
            if (destinationPiece == null || destinationPiece.Bitmap.Tag.ToString() != piece.Bitmap.Tag.ToString())
            {
                if (currentRow != newRow || currentColumn != newColumn)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsEmptySquare(int row, int column)
        {
            return GetPieceAt(row, column) == null;
        }

        private bool IsValidSquare(int row, int column)
        {
            return row >= 0 && row < 10 && column >= 0 && column < 10;
        }

        private Piece GetPieceAt(int row, int column)
        {
            if (IsValidSquare(row, column))
                return pieces[row, column];

            return null;
        }
    }
}
