using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        bool saga = false;
        bool yukari = true;
        private int puan =  0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rdTop.Checked = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            if (sender == pnCubuk)
            {
                x = x + pnCubuk.Left;
            }
            int left = x - pnCubuk.Width / 2;

            if (left < 0)
                left = 0;
            else if (left > ClientSize.Width - pnCubuk.Width)
                left = ClientSize.Width - pnCubuk.Width;
            pnCubuk.Left = left;
        }
        bool Carptimi(Panel pn1)
        {

            if (!pn1.Visible) return false;
                    if (pn1.Bounds.Contains(rdTop.Right,rdTop.Top+rdTop.Height / 2))
            {
                saga = true;
                rdTop.Left += 5;
                if (yukari)
                    rdTop.Top -= 5;
                else rdTop.Top += 5;
                pn1.Visible = false;
                return true;

            }
                    else if (pn1.Bounds.Contains(rdTop.Left+rdTop.Width/2,rdTop.Bottom))
            {
                yukari = true;
                rdTop.Top -= 5;
                if (saga)
                    rdTop.Left += 5;
                else rdTop.Left -= 5;
                pn1.Visible = false;
       
            }
            return false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int x = rdTop.Left;
            int y = rdTop.Top;
            if (saga)
                x += 5;
            else
                x -= 5;
            if (yukari)
                y -= 5;
            else
                y += 5;
            if (Carptimi(panel1) ||
                Carptimi(panel2) ||
                Carptimi(panel3) ||
                Carptimi(panel4) ||
                Carptimi(panel5) ||
                Carptimi(panel6))
            {
                puan += 10;
                lblPuan.Text = puan.ToString();
                return;
            }
            if(x+rdTop.Width>ClientSize.Width) //Sağa Çarptın
            {
                x = ClientSize.Width - rdTop.Width;
                saga = false;
            }
             if (y<0)// yukarı çarptın
            {
                y = 0;
                yukari = false;
            }
             if(x<0) //Sola carptın
            {
                x = 0;
                saga = true;
            }
             if(y+rdTop.Height>ClientSize.Height) //Aşağı Çarptın
            {
                y = ClientSize.Height - rdTop.Height;
                yukari = true;
                timer1.Enabled = false;
                //Oyun bitti yazdır

            }
             if(y+rdTop.Height>pnCubuk.Top && x+rdTop.Width >=pnCubuk.Left && x<=pnCubuk.Right)//
            {
                y = pnCubuk.Top - rdTop.Height;
                yukari = true;
            }
            rdTop.Left = x;
            rdTop.Top = y;
                    
                    }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Enabled = true;
                puan = 0;
                lblPuan.Text = "0";
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Timer1_Tick(this, null);
        }

        private void pnCubuk_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
