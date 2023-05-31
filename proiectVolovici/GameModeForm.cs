using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiectVolovici
{
    public class GameModeForm : Form
    {
        public bool IsAISelected { get; private set; }
        
        public GameModeForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Select Game Mode";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(300, 150);

            var button1v1 = new Button();
            button1v1.Text = "1v1";
            button1v1.Size = new Size(100, 30);
            button1v1.Location = new Point(30, 50);
            button1v1.Click += Button1v1_Click;

            var buttonAI = new Button();
            buttonAI.Text = "AI";
            buttonAI.Size = new Size(100, 30);
            buttonAI.Location = new Point(160, 50);
            buttonAI.Click += ButtonAI_Click;

            this.Controls.Add(button1v1);
            this.Controls.Add(buttonAI);
        }

        private void Button1v1_Click(object sender, EventArgs e)
        {
            IsAISelected = false;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonAI_Click(object sender, EventArgs e)
        {
            IsAISelected = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        
    }
}

