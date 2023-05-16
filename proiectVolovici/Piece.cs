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
    class Piece
    {
        private const int PIECE_WIDTH = 40;
        private const int PIECE_HEIGHT = 40;
        Image bluePawnImg = Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\pawn.png");
        Image whitePawnImg = Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whitePawn.png");

        private int x = 40, y = 40;
        public void drawPieces(Graphics g)
        {
        Bitmap bluePawn = new Bitmap(bluePawnImg);
            Bitmap whitePawn = new Bitmap(whitePawnImg);
            whitePawn.MakeTransparent();
            bluePawn.MakeTransparent();
            for (int i = 0; i < 10; i++) {
               g.DrawImage(bluePawn, x*i, y, PIECE_WIDTH, PIECE_HEIGHT);
               g.DrawImage(whitePawn, x*i, y*8, PIECE_WIDTH, PIECE_HEIGHT);
            }
        
        }

        public void movePiece(MouseEventArgs e)
        {
          
        }

    }
}
