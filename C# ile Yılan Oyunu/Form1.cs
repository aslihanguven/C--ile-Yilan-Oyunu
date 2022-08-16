using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fare_Button
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string hedefYonu = "";
        int atla = 30;
        List<Point> konumListesi = new List<Point>();
        int btnSayisi = 8;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void yilanHareket_Tick(object sender, EventArgs e)
        {

            if (hedefYonu == "L")
            {
                konumListesi.Add(new Point(button1.Location.X - atla, button1.Location.Y));
            }
            else if (hedefYonu == "U")
            {
                konumListesi.Add(new Point(button1.Location.X, button1.Location.Y - atla));
            }
            else if (hedefYonu == "R")
            {
                konumListesi.Add(new Point(button1.Location.X + atla, button1.Location.Y));
            }
            else if (hedefYonu == "D")
            {
                konumListesi.Add(new Point(button1.Location.X, button1.Location.Y + atla));
            }

            yilaniKonumlandir();

        }

        private void yilaniKonumlandir()
        {

            //Yılanı konuma göre hareketlendir
            for (int i = 1; i <= btnSayisi; i++)
            {
                Button btn = this.Controls["button" + i] as Button;
                btn.Location = konumListesi[konumListesi.Count - i];
            }


            //Duvara çarptığında çık
            if (button1.Location.X < 0 || button1.Location.X > this.Width)
            {
                Environment.Exit(0);
            }
            else if (button1.Location.Y < 0 || button1.Location.Y > this.Height)
            {
                Environment.Exit(0);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hedefYonu = "L";
            for (int i = btnSayisi; i >= 1; i--)
            {
                Button btn = this.Controls["button" + i] as Button;
                konumListesi.Add(new Point(btn.Location.X, btn.Location.Y));
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Left)
            {
                hedefYonu = "L";
                konumListesi.Add(new Point(button1.Location.X - atla, button1.Location.Y));
            }
            else if (e.KeyData == Keys.Up)
            {
                hedefYonu = "U";
                konumListesi.Add(new Point(button1.Location.X, button1.Location.Y - atla));
            }
            else if (e.KeyData == Keys.Right)
            {
                hedefYonu = "R";
                konumListesi.Add(new Point(button1.Location.X + atla, button1.Location.Y));
            }
            else if (e.KeyData == Keys.Down)
            {
                hedefYonu = "D";
                konumListesi.Add(new Point(button1.Location.X, button1.Location.Y + atla));
            }

            yilaniKonumlandir();
        }

        private void timerEkle_Tick(object sender, EventArgs e)
        {

            Button btnSon = this.Controls["button" + btnSayisi] as Button;

            btnSayisi++;
            Button btn = new Button();
            btn.Name = "button" + btnSayisi;
            btn.Text = "";
            btn.Size = new Size(atla, atla);
            btn.BackColor = button8.BackColor;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = button8.FlatAppearance.BorderColor;
            btn.FlatAppearance.BorderSize = button8.FlatAppearance.BorderSize;
            btn.Enabled = false;

            if (hedefYonu == "L")
            {
                btn.Location = new Point(btnSon.Location.X + atla, btnSon.Location.Y);
            }
            else if (hedefYonu == "U")
            {
                btn.Location = new Point(btnSon.Location.X, btnSon.Location.Y + atla);
            }
            else if (hedefYonu == "R")
            {
                btn.Location = new Point(btnSon.Location.X + -atla, btnSon.Location.Y);
            }
            else if (hedefYonu == "D")
            {
                btn.Location = new Point(btnSon.Location.X, btnSon.Location.Y - atla);
            }

            this.Controls.Add(btn);
            label1.Text = btnSayisi.ToString();
        }
    }
}
