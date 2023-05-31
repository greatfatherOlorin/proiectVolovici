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
        public bool HasMoved { get; set; }
     
        public bool HasMovedTwoSquares { get; set; }
        public bool HasDoubleStepped { get; set; }
        public int Moves { get; set; }
        public bool IsEnPassantVulnerable { get; private set; }
        public string CurrentTag { get; set; }
        public Piece()
        {

            HasMoved = false;
            HasDoubleStepped = false;
            IsEnPassantVulnerable = false;
        }

        public void SetEnPassantVulnerability(bool isVulnerable)
        {
            if (Type == PieceType.Pawn)
                IsEnPassantVulnerable = isVulnerable;
            else
                IsEnPassantVulnerable = false;
        }
        public enum PieceType
        {
            Pawn,
            Rook,
            Knight,
            Bishop,
            Queen,
            King,
            Arrow
        }
    }
}
