using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectVolovici
{

    class ChessBoard
    {
        private const int ROW = 10;
        private  int COLUMN = 10;
        private  int WIDTH = 40;
        private  int HEIGHT = 40;
        Graphics f;
        private int x=40, y=40;
        public int getWidth()
        {
            return x;
        }
        public int getHeight()
        {
            return y;
        }

        public void setWidth(int width)
        {
            x = width;
        }
        public void setHeight(int height)
        {
            y = height;
        }


        SolidBrush beigeBrush = new SolidBrush(Color.Beige);
        SolidBrush aquamarineBrush = new SolidBrush(Color.Aquamarine);
        Image bluePawnImg = Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\pawn.png");
        Image whitePawnImg = Image.FromFile(@"C:\Users\redfear\source\repos\proiectVolovici\proiectVolovici\Images\whitePawn.png");
        Image[] img = new Image[10];
        public void drawBoard(Graphics g)
        {
            
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
        }

        public void movePiece(Graphics g)
        {
            Bitmap bluePawn = new Bitmap(bluePawnImg);
            bluePawn.MakeTransparent();
            g.DrawImage(bluePawn, getWidth(), getHeight(), 40, 40);

          
        }
        public void drawPiece(Graphics g)
        {
            Bitmap bluePawn = new Bitmap(bluePawnImg);
            bluePawn.MakeTransparent();
            for (int i = 0; i < 10; i++)
            {
                img[i] = bluePawn;
                g.DrawImage(img[i], WIDTH*i, HEIGHT, 40, 40);

                

            }
        }
    }
}
