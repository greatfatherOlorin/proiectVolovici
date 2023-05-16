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
        private const int COLUMN = 10;
        private const int WIDTH = 40;
        private const int HEIGHT = 40;

    
        SolidBrush beigeBrush = new SolidBrush(Color.Beige);
        SolidBrush aquamarineBrush = new SolidBrush(Color.Aquamarine);


        
        public void drawBoard(Graphics g)
        {
            for(int i = 0; i < ROW; i++)
            {
                for(int j = 0; j < COLUMN; j++)
                {
                    if ((j % 2 == 0 && i % 2 == 0) || (j % 2 != 0 && i % 2 != 0))
                         g.FillRectangle(beigeBrush, i * WIDTH, j * HEIGHT, WIDTH, HEIGHT);
                    else if ((j % 2 == 0 && i % 2 != 0) || (j % 2 != 0 && i % 2 == 0))
                        g.FillRectangle(aquamarineBrush, i * WIDTH, j * HEIGHT, WIDTH, HEIGHT);
                }
            }
        }
    }
}
