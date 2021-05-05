using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crawler
{
    public partial class Form1 : Form
    {
        BindingSource result = new BindingSource();
        Crawler crawler = new Crawler();


        public Form1()
        {
            InitializeComponent();
            dgv.DataSource = result;
            crawler.pagedown += Crawler_PageDownloaded;
        }
        private void Crawler_PageDownloaded(Crawler crawler, string url)
        {
            var pageInfo = new { Index = result.Count + 1, URL = url};
            Action action = () => { result.Add(pageInfo); };
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            crawler.starturl = textBox1.Text;
            crawler.name = textBox2.Text;
            Match match = Regex.Match(crawler.starturl, Crawler.urlParseRegex);

            string host = match.Groups["host"].Value;
            crawler.HostFilter = "^" + host + "$";
            crawler.FileFilter = "((.html?|.aspx|.jsp|.php)$|^[^.]+$)";
            new Thread(crawler.start).Start();
           
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
