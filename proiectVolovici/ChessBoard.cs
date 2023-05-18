﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiectVolovici
{

    class ChessBoard
    {
        private const int ROW = 10;
        private  int COLUMN = 10;
        private  int WIDTH = 40;
        private  int HEIGHT = 40;

        private Piece[,] pieces;
        private Piece selectedPiece;
        private PictureBox chessPictureBox;
        public ChessBoard(PictureBox pictureBox)
        {
            chessPictureBox = pictureBox;
            InitializePieces();
        }
        private void InitializePieces()
        {
            pieces = new Piece[ROW, COLUMN];

            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col <10; col++)
                {
                    if (row == 1)
                    {

                        Bitmap bluePawn = new Bitmap(new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\pawn.png")));
                        bluePawn.MakeTransparent();

                        pieces[row, col] = new Piece
                        {
                            Bitmap = bluePawn,
                            Row = row,
                            Column = col
                        };
                    }
                    else if(row == 8)
                    {
                        Bitmap whitePawn = new Bitmap(new Bitmap(Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whitePawn.png")));
                        whitePawn.MakeTransparent();

                        pieces[row, col] = new Piece
                        {
                            
                            Bitmap = whitePawn,
                            Row = row,
                            Column = col
                        };
                       
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

        public void moveSelectedPiece(int newRow, int newColumn)
        {
            if (selectedPiece == null)
                return;
            
            pieces[selectedPiece.Row, selectedPiece.Column] = null;
            selectedPiece.Row = newRow;
            selectedPiece.Column = newColumn;
            pieces[newRow, newColumn] = selectedPiece;
            selectedPiece = null;

            chessPictureBox.Invalidate();
        }

        public bool selectPiece(int row, int column)
        {
            selectedPiece = pieces[row, column];
            return selectedPiece!=null;
            
        }

    }
}
