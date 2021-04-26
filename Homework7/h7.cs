using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homeworrk00
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private Graphics graphics;
        int n0 = 10;
        double x0 = 200;
        double y0 = 300;
        double leng = 100;
        double th = -Math.PI / 2;
        double th1 = 30 * Math.PI / 180;
        double th2 = 30 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;


        void drawCayleyTree(int n, double x, double y, double leng, double th)
        {
            if (n == 0)
                return;
            double x1 = x + leng * Math.Cos(th);
            double y1 = y + leng * Math.Sin(th);

            drawline(x, y, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);

        }
        void drawline(double x, double y, double x1, double y1)
        {
            if (radioButton1.Checked)
            {
                graphics.DrawLine(Pens.Red, (int)x, (int)y, (int)x1, (int)y1);
            }
            else if (radioButton2.Checked)
            {
                graphics.DrawLine(Pens.Blue, (int)x, (int)y, (int)x1, (int)y1);
            }
            else if (radioButton3.Checked)
            {
                graphics.DrawLine(Pens.Black, (int)x, (int)y, (int)x1, (int)y1);
            }
            else if (radioButton4.Checked)
            {
                graphics.DrawLine(Pens.Pink, (int)x, (int)y, (int)x1, (int)y1);
            }
            else
            {
                graphics.DrawLine(Pens.Blue, (int)x, (int)y, (int)x1, (int)y1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = CreateGraphics();
            drawCayleyTree(n0, x0, y0, leng, th);

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            n0 = Int32.Parse(textBox1.Text);


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            leng = Int32.Parse(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            per1 = Double.Parse(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            per2 = Double.Parse(textBox4.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            th1 = Int32.Parse(textBox5.Text) * Math.PI / 180;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            th2 = Int32.Parse(textBox6.Text) * Math.PI / 180;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
