using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Bitmap pieceBitmap = null;

                    if (row == 1)
                    {
                        pieces[row, col] = new Piece
                        {
                            Type = Piece.PieceType.Pawn,
                            Bitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\bluePawn.png")),
                            Row = row,
                            Column = col
                        };
                        pieces[row, col].Bitmap.Tag = "Black";
                    }
                    else if (row == 8)
                    {
                        pieces[row, col] = new Piece
                        {
                            Type = Piece.PieceType.Pawn,
                            Bitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whitePawn.png")),
                            Row = row,
                            Column = col
                        };
                       
                        pieces[row, col].Bitmap.Tag = "White";  
                    }
                    if (row == 9)
                    {
                        if (col == 0 || col == 9)
                        {   
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteRook.png"));
                        }
                        if (col == 1 || col == 8)
                        {
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteKnight.png"));
                        }
                        if (col == 2 || col == 7)
                        {
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteArrow.png"));
                        }
                        if (col == 3 || col == 6)
                        {
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteBishop.png"));
                        }
                        if (col == 4)
                        {
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteQueen.png"));
                        }
                        if (col == 5)
                        {
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteKing.png"));
                        }
                    }

                    if (pieceBitmap != null)
                    {
                            pieces[row, col] = new Piece
                            {
                                Type = Piece.PieceType.Bishop,
                                Bitmap = pieceBitmap,
                                Row = row,
                                Column = col
                            };
                        pieces[row, col].Bitmap.Tag = "White";
                    }

                }
            }
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
            {

                int direction = (currentPiece.Bitmap.Tag.ToString() == "White") ? -1 : 1;


                if (newRow < 0 || newRow >= 10 || newColumn < 0 || newColumn >= 10)
                    return false;

                // check if the pawn is moving forward or backward
                if (newColumn == currentColumn && (newRow - currentRow == direction || newRow - currentRow == -direction))
                {
                    // check if the destination is empty
                    if (pieces[newRow, newColumn] == null)
                    {
                        return true;
                    }
                }

                bool hasMoved = currentPiece.HasMoved;

                // pawns on their starting rank can move two squares forward on the same column
                if (currentRow == (direction == -1 ? ROW - 2 : 1) && currentColumn == newColumn)
                {
                    // check if the destination is empty
                    if (newRow == currentRow + (1 * direction) && pieces[newRow, newColumn] == null)
                    {
                        return true;
                    }
                    // check if the destination is empty and two squares forward, and the pawn hasn't moved before
                    if (!hasMoved && newRow == currentRow + (2 * direction) && pieces[newRow, newColumn] == null && pieces[currentRow + direction, currentColumn] == null)
                    {

                        currentPiece.HasMoved = true;
                        return true;
                    }
                }
                // check pawn captures
                if (Math.Abs(newColumn - currentColumn) == 1 && newRow - currentRow == direction)
                {
                    // check if there is an opponent's piece at the destination
                    Piece destinationPiece = pieces[newRow, newColumn];
                    if (destinationPiece != null && destinationPiece.Bitmap.Tag.ToString() != currentPiece.Bitmap.Tag.ToString())
                        return true;

                    // check for en passant captures
                    Piece leftPiece = (currentColumn > 0) ? pieces[currentRow, currentColumn - 1] : null;
                    Piece rightPiece = (currentColumn < 9) ? pieces[currentRow, currentColumn + 1] : null;

                    if ((leftPiece != null && leftPiece.Type == Piece.PieceType.Pawn && leftPiece.Bitmap.Tag.ToString() != currentPiece.Bitmap.Tag.ToString() && leftPiece.HasMoved && Math.Abs(leftPiece.Row - newRow) == 1 && leftPiece.Column == newColumn) ||
                        (rightPiece != null && rightPiece.Type == Piece.PieceType.Pawn && rightPiece.Bitmap.Tag.ToString() != currentPiece.Bitmap.Tag.ToString() && rightPiece.HasMoved && Math.Abs(rightPiece.Row - newRow) == 1 && rightPiece.Column == newColumn))
                    {
                        
                        pieces[currentRow, newColumn] = null; 
                        return true;
                    }
                }
            }
            else
            {
                Piece destinationPiece = pieces[newRow, newColumn];
                if (destinationPiece == null || destinationPiece.Bitmap.Tag.ToString() != currentPiece.Bitmap.Tag.ToString())
                    return true;
            }

            return false;
        }
    }
}
