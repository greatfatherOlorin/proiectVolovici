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
        Image pawn = Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\pawn.png");
        private int x = 40, y = 40;
        public void drawPieces(Graphics g)
        {
        Bitmap pawnBitmap = new Bitmap(pawn);
        pawnBitmap.MakeTransparent();
            for (int i = 0; i < 10; i++) {
               g.DrawImage(pawnBitmap, x*i, y, PIECE_WIDTH, PIECE_HEIGHT);
               g.DrawImage(pawnBitmap, x*i, y*8, PIECE_WIDTH, PIECE_HEIGHT);
            }
        
        }

        public void movePiece(MouseEventArgs e)
        {
          
        }

    }
}
