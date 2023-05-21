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
                            pieces[row, col] = new Piece
                            {
                                Type = Piece.PieceType.Rook,
                                Bitmap = pieceBitmap,
                                Row = row,
                                Column = col
                            };
                        }
                        if (col == 1 || col == 8)
                        {
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteKnight.png"));
                            pieces[row, col] = new Piece
                            {
                                Type = Piece.PieceType.Knight,
                                Bitmap = pieceBitmap,
                                Row = row,
                                Column = col
                            };
                        }
                        if (col == 2 || col == 7)
                        {
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteArrow.png"));
                            pieces[row, col] = new Piece
                            {
                                Type = Piece.PieceType.Arrow,
                                Bitmap = pieceBitmap,
                                Row = row,
                                Column = col
                            };
                        }
                        if (col == 3 || col == 6)
                        {
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteBishop.png"));
                            pieces[row, col] = new Piece
                            {
                                Type = Piece.PieceType.Bishop,
                                Bitmap = pieceBitmap,
                                Row = row,
                                Column = col
                            };
                        }
                        if (col == 4)
                        {
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteQueen.png"));
                            pieces[row, col] = new Piece
                            {
                                Type = Piece.PieceType.Queen,
                                Bitmap = pieceBitmap,
                                Row = row,
                                Column = col
                            };
                        }
                        if (col == 5)
                        {
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whiteKing.png"));
                            pieces[row, col] = new Piece
                            {
                                Type = Piece.PieceType.King,
                                Bitmap = pieceBitmap,
                                Row = row,
                                Column = col
                            };
                        }
                        pieces[row, col].Bitmap.Tag = "White";
                    }
                    if (row == 0)
                    {
                        
                        if (col == 0 || col == 9)
                        {
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\blueRook.png"));
                            pieces[row, col] = new Piece
                            {
                                Type = Piece.PieceType.Rook,
                                Bitmap = pieceBitmap,
                                Row = row,
                                Column = col
                            };
                        }
                        if (col == 1 || col == 8)
                        {
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\blueKnight.png"));
                            pieces[row, col] = new Piece
                            {
                                Type = Piece.PieceType.Knight,
                                Bitmap = pieceBitmap,
                                Row = row,
                                Column = col
                            };
                        }
                        if (col == 2 || col == 7)
                        {
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\blueArrow.png"));
                            pieces[row, col] = new Piece
                            {
                                Type = Piece.PieceType.Arrow,
                                Bitmap = pieceBitmap,
                                Row = row,
                                Column = col
                            };
                        }
                        if (col == 3 || col == 6)
                        {
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\blueBishop.png"));
                            pieces[row, col] = new Piece
                            {
                                Type = Piece.PieceType.Bishop,
                                Bitmap = pieceBitmap,
                                Row = row,
                                Column = col
                            };
                        }
                        if (col == 4)
                        {
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\blueQueen.png"));
                            pieces[row, col] = new Piece
                            {
                                Type = Piece.PieceType.Queen,
                                Bitmap = pieceBitmap,
                                Row = row,
                                Column = col
                            };
                        }
                        if (col == 5)
                        {
                            pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\blueKing.png"));
                            pieces[row, col] = new Piece
                            {
                                Type = Piece.PieceType.King,
                                Bitmap = pieceBitmap,
                                Row = row,
                                Column = col
                            };
                        }
                        pieces[row, col].Bitmap.Tag = "Black";
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
                bool hasMoved = currentPiece.HasMoved;
                bool hasDoubleStepped = currentPiece.HasDoubleStepped;

                int direction = (currentPiece.Bitmap.Tag.ToString() == "White") ? -1 : 1;

                if (newRow < 0 || newRow >= 10 || newColumn < 0 || newColumn >= 10)
                    return false;

                // check if the pawn is moving forward or backward
                if (newColumn == currentColumn && (newRow - currentRow == direction))
                {
                    if (pieces[newRow, newColumn] == null)
                    {
                        
                        currentPiece.HasMoved = true;
                        return true;
                    }
                }



                // check for en passant capture
                if (Math.Abs(newColumn - currentColumn) == 1 && newRow - currentRow == direction)
                {
                    // Check if there is an opponent's piece at the destination
                    Piece destinationPiece = pieces[newRow, newColumn];

                    if (destinationPiece == null)
                    {
                        Piece leftPiece = (currentColumn > 0) ? pieces[currentRow, currentColumn - 1] : null;
                        Piece rightPiece = (currentColumn < (COLUMN - 1)) ? pieces[currentRow, currentColumn + 1] : null;

                        if ((leftPiece != null && leftPiece.Type == Piece.PieceType.Pawn && leftPiece.Bitmap.Tag.ToString() != currentPiece.Bitmap.Tag.ToString() && leftPiece.Row == currentRow && leftPiece.Column == newColumn && currentRow == (direction == -1 ? 3 : 6)) ||
                            (rightPiece != null && rightPiece.Type == Piece.PieceType.Pawn && rightPiece.Bitmap.Tag.ToString() != currentPiece.Bitmap.Tag.ToString() && rightPiece.Row == currentRow && rightPiece.Column == newColumn && currentRow == (direction == -1 ? 3 : 6)))
                        {
                            if ((rightPiece != null && rightPiece.HasDoubleStepped) || (leftPiece != null && leftPiece.HasDoubleStepped))
                            {
                                pieces[currentRow, newColumn] = null;
                                return true;
                            }
                        }
                    }
                }

                // pawns on their starting rank can move two squares forward on the same column
                if (currentRow == (direction == -1 ? ROW - 2 : 1) && currentColumn == newColumn)
                {

                    // check if the destination is empty
                    if (newRow == currentRow + (1 * direction) && pieces[newRow, newColumn] == null)
                    {
                        // update hasMoved flag
                        currentPiece.HasDoubleStepped = true;
                        currentPiece.HasMoved = true;
                        
                        return true;
                    }

                    // check if the destination is empty and two squares forward, and the pawn hasn't moved before
                    if (!hasDoubleStepped&&!hasMoved && newRow == currentRow + (2 * direction) && pieces[newRow, newColumn] == null && pieces[currentRow + (1 * direction), newColumn] == null)
                    {
                        // update hasMoved flag
                        currentPiece.HasDoubleStepped = true;
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
