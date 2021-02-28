using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework02
{
   
    public partial class Form1 : Form
    {
        int n1 = 0;
        int n2 = 0;
        double n = 0;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void webControl1_OpenExternalLink(object sender, Awesomium.Core.OpenExternalLinkEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Text = textBox1.Text;
            n1 = Int32.Parse(Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Text = textBox2.Text;
            n2 = Int32.Parse(Text);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            n = n1 + n2;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            n = n1 - n2;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {
            

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            n = n1 * n2 ;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            n = n1 / n2 ;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            final.Text = n+"";

        }
    }
}
