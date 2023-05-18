using proiectVolovici.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiectVolovici
{
    public partial class Form1 : Form
    {

        ChessBoard board = new ChessBoard();
        Piece piece = new Piece();
        Boolean isSelected = false;
  
        public Form1()
        { 
            InitializeComponent();
            
            boardPanel.Paint+=new PaintEventHandler(boardPanel_Paint);
            boardPanel.MouseDown += new MouseEventHandler(boardPanel_MouseDown);
           
        }

        private void boardPanel_Paint(object sender, PaintEventArgs e)
        {

            board.drawBoard(e.Graphics);

            board.drawPiece(e.Graphics);
            board.movePiece(e.Graphics);

        }

      

        private void boardPanel_MouseDown(object sender, MouseEventArgs e)
        {
            int squareSize = 40;
            int newx = e.X / squareSize;
            int newy = e.Y / squareSize;
           
            if (e.Button == MouseButtons.Left)
            {
                int newXPos = newx * squareSize;
                int newYPos = newy * squareSize;

                if (isSelected)
                {
                    board.setWidth(newXPos);
                    board.setHeight(newYPos);
                    isSelected = false;
                    boardPanel.Invalidate();
                }
                else
                {
                   
                    if (board.getWidth() == newXPos && board.getHeight() == newYPos)
                    {
                        isSelected = true;
                    }
                }

              
                

                
            }


            
          
        }



    }
}

