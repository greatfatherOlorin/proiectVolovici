using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiectVolovici
{
    class Piece
    {
        public Bitmap Bitmap { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public PieceType Type { get; set; }
        public PieceColor Color { get; set; }
        public bool HasMoved { get; set; }
        public enum PieceType
        {
            Pawn,
            Rook,
            Knight,
            Bishop,
            Queen,
            King
        }
        public enum PieceColor
        {
            White,
            Black
        }
    }
}
