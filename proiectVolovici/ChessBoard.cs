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
        private string currentTag = "White";
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
                        InitializePawn(row, col, @"C:\Users\ganda\source\repos\proiectVolovici\proiectVolovici\Images\bluePawn.png", "Blue");
                    }
                    else if (row == 8)
                    {
                        InitializePawn(row, col, @"C:\Users\ganda\source\repos\proiectVolovici\proiectVolovici\Images\whitePawn.png", "White");
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
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\ganda\source\repos\proiectVolovici\proiectVolovici\Images\whiteRook.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Rook, pieceBitmap, row, col);
            }
            else if (col == 1 || col == 8)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\ganda\source\repos\proiectVolovici\proiectVolovici\Images\whiteKnight.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Knight, pieceBitmap, row, col);
            }
            else if (col == 2 || col == 7)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\ganda\source\repos\proiectVolovici\proiectVolovici\Images\whiteArrow.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Arrow, pieceBitmap, row, col);
            }
            else if (col == 3 || col == 6)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\ganda\source\repos\proiectVolovici\proiectVolovici\Images\whiteBishop.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Bishop, pieceBitmap, row, col);
            }
            else if (col == 4)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\ganda\source\repos\proiectVolovici\proiectVolovici\Images\whiteQueen.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Queen, pieceBitmap, row, col);
            }
            else if (col == 5)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\ganda\source\repos\proiectVolovici\proiectVolovici\Images\whiteKing.png"));
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
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\ganda\source\repos\proiectVolovici\proiectVolovici\Images\blueRook.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Rook, pieceBitmap, row, col);
            }
            else if (col == 1 || col == 8)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\ganda\source\repos\proiectVolovici\proiectVolovici\Images\blueKnight.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Knight, pieceBitmap, row, col);
            }
            else if (col == 2 || col == 7)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\ganda\source\repos\proiectVolovici\proiectVolovici\Images\blueArrow.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Arrow, pieceBitmap, row, col);
            }
            else if (col == 3 || col == 6)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\ganda\source\repos\proiectVolovici\proiectVolovici\Images\blueBishop.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Bishop, pieceBitmap, row, col);
            }
            else if (col == 4)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\ganda\source\repos\proiectVolovici\proiectVolovici\Images\blueQueen.png"));
                pieces[row, col] = CreatePiece(Piece.PieceType.Queen, pieceBitmap, row, col);
            }
            else if (col == 5)
            {
                pieceBitmap = new Bitmap(Image.FromFile(@"C:\Users\ganda\source\repos\proiectVolovici\proiectVolovici\Images\blueKing.png"));
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
            SolidBrush redDotBrush = new SolidBrush(Color.Red);

            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COLUMN; j++)
                {

                    if ((j % 2 == 0 && i % 2 == 0) || (j % 2 != 0 && i % 2 != 0))
                        g.FillRectangle(beigeBrush, i * WIDTH, j * HEIGHT, WIDTH, HEIGHT);
                    else if ((j % 2 == 0 && i % 2 != 0) || (j % 2 != 0 && i % 2 == 0))
                        g.FillRectangle(aquamarineBrush, i * WIDTH, j * HEIGHT, WIDTH, HEIGHT);

                    if (selectedPiece != null && IsValidMove(selectedPiece.Row, selectedPiece.Column, j, i))
                    {
                        g.FillEllipse(redDotBrush, i * WIDTH + WIDTH / 2 - 5, j * HEIGHT + HEIGHT / 2 - 5, 10, 10);
                       
                    }


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
                currentTag = currentTag == "White" ? "Blue" : "White";

            }
        }

        public bool selectPiece(int row, int column)
        {

            Piece piece = pieces[row, column];
            if (piece != null && piece.Bitmap.Tag.ToString() == currentTag)
            {
                selectedPiece = piece;
                return true;
            }
            return false;
        }

     

        public bool IsValidMove(int currentRow, int currentColumn, int newRow, int newColumn)
        {
            Piece currentPiece = pieces[currentRow, currentColumn];

            if (currentPiece == null)
                return false;

            if (currentPiece.Type == Piece.PieceType.Pawn)
                return IsValidPawnMove(currentPiece, currentRow, currentColumn, newRow, newColumn);
            else if (currentPiece.Type == Piece.PieceType.Bishop)
                return IsValidBishopMove(currentPiece, currentRow, currentColumn, newRow, newColumn);
            else if (currentPiece.Type == Piece.PieceType.Rook)
                return IsValidRookMove(currentPiece, currentRow, currentColumn, newRow, newColumn);
            else if (currentPiece.Type == Piece.PieceType.Knight)
                return IsValidKnightMove(currentPiece, currentRow, currentColumn, newRow, newColumn);
            else if (currentPiece.Type == Piece.PieceType.Queen)
                return IsValidQueenMove(currentPiece, currentRow, currentColumn, newRow, newColumn);
            else if (currentPiece.Type == Piece.PieceType.Arrow)
                return IsValidArcherMove(currentPiece, currentRow, currentColumn, newRow, newColumn);
            else if (currentPiece.Type == Piece.PieceType.King)
                return IsValidKingMove(currentPiece, currentRow, currentColumn, newRow, newColumn);



            return false;
        }

        public bool IsValidKingMove(Piece currentPiece, int currentRow, int currentColumn, int newRow, int newColumn)
        {
            int rowOffset = Math.Abs(newRow - currentRow);
            int columnOffset = Math.Abs(newColumn - currentColumn);

            // Check if the move is within one square in any direction
            if (rowOffset <= 1 && columnOffset <= 1)
            {
                // Check if the destination is empty or has an opponent's piece
                Piece destinationPiece = pieces[newRow, newColumn];
                if (destinationPiece == null || destinationPiece.Bitmap.Tag.ToString() != currentPiece.Bitmap.Tag.ToString())
                    return true;
            }

            return false;
        }
        public bool IsValidArcherMove(Piece archer, int currentRow, int currentColumn, int newRow, int newColumn)
        {
            int rowOffset = Math.Abs(newRow - currentRow);
            int columnOffset = Math.Abs(newColumn - currentColumn);

            // Check if the archer is moving diagonally
            if (rowOffset != columnOffset)
                return false;
            
            if (rowOffset != 2)
                return false;

            // Check for any pieces in the archer's path when moving diagonally
            int rowDirection = (newRow > currentRow) ? 1 : -1;
            int columnDirection = (newColumn > currentColumn) ? 1 : -1;

            int row = currentRow + rowDirection;
            int column = currentColumn + columnDirection;
            while (row != newRow && column != newColumn)
            {
                // Skip checking for obstacles when moving diagonally
                row += rowDirection;
                column += columnDirection;
            }

            // Check if the destination square is empty or has an opponent's piece
            Piece destinationPiece = pieces[newRow, newColumn];
            if (destinationPiece == null || destinationPiece.Bitmap.Tag.ToString() != archer.Bitmap.Tag.ToString())
                return true;

            return false;
        }

        public bool IsValidQueenMove(Piece currentPiece, int currentRow, int currentColumn, int newRow, int newColumn)
        {
            // Check if the move is a valid combination of rook and bishop moves
            if (IsValidRookMove(currentPiece, currentRow, currentColumn, newRow, newColumn) || IsValidBishopMove(currentPiece, currentRow, currentColumn, newRow, newColumn))
            {
                // Check if the destination is empty or has an opponent's piece
                Piece destinationPiece = pieces[newRow, newColumn];
                if (destinationPiece == null || destinationPiece.Bitmap.Tag.ToString() != currentPiece.Bitmap.Tag.ToString())
                    return true;
            }

            return false;
        }

        public bool IsValidKnightMove(Piece currentPiece, int currentRow, int currentColumn, int newRow, int newColumn)
        {
            int rowOffset = Math.Abs(newRow - currentRow);
            int columnOffset = Math.Abs(newColumn - currentColumn);

            // Check if the move follows the L-shape pattern of a knight
            if ((rowOffset == 2 && columnOffset == 1) || (rowOffset == 1 && columnOffset == 2))
            {
                // Check if the destination is empty or has an opponent's piece
                Piece destinationPiece = pieces[newRow, newColumn];
                if (destinationPiece == null || destinationPiece.Bitmap.Tag.ToString() != currentPiece.Bitmap.Tag.ToString())
                    return true;
            }

            return false;
        }
        public bool IsValidRookMove(Piece currentPiece, int currentRow, int currentColumn, int newRow, int newColumn)
        {
            // Rook can only move horizontally or vertically
            if (currentRow != newRow && currentColumn != newColumn)
                return false;

            // Check if the destination is empty or has an opponent's piece
            Piece destinationPiece = pieces[newRow, newColumn];
            if (destinationPiece != null && destinationPiece.Bitmap.Tag.ToString() == currentPiece.Bitmap.Tag.ToString())
                return false;

            // Check for any pieces blocking the path
            int rowDirection = (newRow - currentRow) / Math.Max(Math.Abs(newRow - currentRow), 1);
            int columnDirection = (newColumn - currentColumn) / Math.Max(Math.Abs(newColumn - currentColumn), 1);

            int row = currentRow + rowDirection;
            int column = currentColumn + columnDirection;
            while (row != newRow || column != newColumn)
            {
                if (pieces[row, column] != null)
                    return false;

                row += rowDirection;
                column += columnDirection;
            }

            return true;
        }

        public bool IsValidBishopMove(Piece bishop, int currentRow, int currentColumn, int newRow, int newColumn)
        {
            int rowOffset = Math.Abs(newRow - currentRow);
            int columnOffset = Math.Abs(newColumn - currentColumn);

            // Check if the bishop is moving diagonally
            if (rowOffset != columnOffset)
                return false;

            // Check for any pieces in the bishop's path
            int rowDirection = (newRow > currentRow) ? 1 : -1;
            int columnDirection = (newColumn > currentColumn) ? 1 : -1;

            for (int i = 1; i < rowOffset; i++)
            {
                int row = currentRow + i * rowDirection;
                int column = currentColumn + i * columnDirection;

                if (pieces[row, column] != null)
                    return false;
            }

            // Check if the destination square is empty or has an opponent's piece
            Piece destinationPiece = pieces[newRow, newColumn];
            if (destinationPiece == null || destinationPiece.Bitmap.Tag.ToString() != bishop.Bitmap.Tag.ToString())
                return true;

            return false;
        }

        public bool IsValidPawnMove(Piece pawn, int currentRow, int currentColumn, int newRow, int newColumn)
        {
            // Pawns can only move forward by one row (except for the initial 2-square move)
            int rowOffset = Math.Abs(newRow - currentRow);
            int columnOffset = Math.Abs(newColumn - currentColumn);

            // Check if the pawn is moving forward by one row
            if (pawn.Bitmap.Tag.ToString() == "Blue" && newRow == currentRow + 1 && columnOffset == 0)
            {
                // Check if the destination square is empty
                Piece destinationPiece = pieces[newRow, newColumn];
                if (destinationPiece == null)
                    return true;
            }
            else if (pawn.Bitmap.Tag.ToString() == "White" && newRow == currentRow - 1 && columnOffset == 0)
            {
                // Check if the destination square is empty
                Piece destinationPiece = pieces[newRow, newColumn];
                if (destinationPiece == null)
                    return true;
            }
            // Check if the pawn is capturing diagonally
            else if (pawn.Bitmap.Tag.ToString() == "Blue" && newRow == currentRow + 1 && columnOffset == 1)
            {
                // Check if the destination square contains an opponent's piece
                Piece destinationPiece = pieces[newRow, newColumn];
                if (destinationPiece != null && destinationPiece.Bitmap.Tag.ToString() == "White")
                    return true;
            }
            else if (pawn.Bitmap.Tag.ToString() == "White" && newRow == currentRow - 1 && columnOffset == 1)
            {
                // Check if the destination square contains an opponent's piece
                Piece destinationPiece = pieces[newRow, newColumn];
                if (destinationPiece != null && destinationPiece.Bitmap.Tag.ToString() == "Blue")
                    return true;
            }
            // Check if the pawn is making the initial 2-square move
            else if (pawn.Bitmap.Tag.ToString() == "Blue" && currentRow == 1 && newRow == 3 && columnOffset == 0)
            {
                // Check if the destination square is empty and the intermediate square is also empty
                Piece destinationPiece = pieces[newRow, newColumn];
                Piece intermediatePiece = pieces[currentRow + 1, newColumn];
                if (destinationPiece == null && intermediatePiece == null)
                {
                    // Mark the pawn as vulnerable to en passant capture
                    pawn.SetEnPassantVulnerability(true);
                    return true;
                }
            }
            else if (pawn.Bitmap.Tag.ToString() == "White" && currentRow == 8 && newRow == 6 && columnOffset == 0)
            {
                // Check if the destination square is empty and the intermediate square is also empty
                Piece destinationPiece = pieces[newRow, newColumn];
                Piece intermediatePiece = pieces[currentRow - 1, newColumn];
                if (destinationPiece == null && intermediatePiece == null)
                {
                    // Mark the pawn as vulnerable to en passant capture
                    pawn.SetEnPassantVulnerability(true);
                    return true;
                }
            }

            return false;
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
