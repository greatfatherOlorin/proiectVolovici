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
 
        public Form1()
        { 
            InitializeComponent();
            boardPanel.Paint += new PaintEventHandler(boardPanel_Paint);
               

        }

        private void boardPanel_Paint(object sender, PaintEventArgs e)
        {
            
            board.drawBoard(e.Graphics);
            piece.drawPieces(e.Graphics);

        }
    }
}

