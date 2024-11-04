using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Button[] klawiaturaNumeryczna = new Button[10];

        public Form1()
        {
            InitializeComponent();
            klawiaturaNumeryczna[1] = new Button();
            klawiaturaNumeryczna[1].Location = new Point(12, 233);
            klawiaturaNumeryczna[1].Name = "button9";
            klawiaturaNumeryczna[1].Size = new Size(50, 50);
            klawiaturaNumeryczna[1].Text = "1";
            klawiaturaNumeryczna[1].Click += new EventHandler(this.button9_Click);
            Controls.Add(klawiaturaNumeryczna[1]);
        }

        int wynik = 0;
        string operatorArtmetyczny = "+";
        bool czyOPerator = false;
        private void button9_Click(object sender, EventArgs e)
        {
            if (czyOPerator)
            {
                czyOPerator = false;
                textBox1.Text = "";
            }
            textBox1.Text += (sender as Button).Text;
            

        }

        private void button13_Click(object sender, EventArgs e)
        {
            czyOPerator = true;
            switch (operatorArtmetyczny)
            {
                case "+":
                    wynik += int.Parse(textBox1.Text);
                    break;
                case "-":
                    wynik -= int.Parse(textBox1.Text);
                    break;

            }
            textBox1.Text = wynik.ToString();
            operatorArtmetyczny = (sender as Button).Text;
        }
    }
}
