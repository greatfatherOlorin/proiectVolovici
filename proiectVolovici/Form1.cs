﻿using proiectVolovici.Properties;
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
        
        private ChessBoard chessBoard;
        bool isSelected = false;
        public Form1()
        {
           
            InitializeComponent();
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseDown += pictureBox1_MouseDown;

            chessBoard = new ChessBoard(pictureBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chessBoard = new ChessBoard(pictureBox1);
            
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            chessBoard.drawBoard(e.Graphics);

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int squareSize = 40;
            int clickedRow = e.Y / squareSize;
            int clickedColumn = e.X / squareSize;


            if (e.Button == MouseButtons.Left)
            {

                if (!isSelected)
                {
                    isSelected = chessBoard.selectPiece(clickedRow, clickedColumn);
                }
                else
                {
                    chessBoard.moveSelectedPieceTo(clickedRow, clickedColumn);
                    isSelected = false;
                }
                pictureBox1.Invalidate();
            }


           
        }



        }

        
    }


