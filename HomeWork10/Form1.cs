using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Crawler
{
    public partial class Form1 : Form
    {
        BindingSource result = new BindingSource();
        Crawler crawler = new Crawler();
        Thread thread = null;
        public Form1()
        {
            InitializeComponent();
            dgv.DataSource = result;
            crawler.pagedown += Crawler_PageDownloaded;
            crawler.stopped += Crawler_PageStopped;
        }
        private void Crawler_PageStopped(Crawler crawler)
        {
            Action action =()=>label1.Text="已停止";
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
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

            if (thread != null)
            {
                thread.Abort();
            }
            thread = new Thread(crawler.start);
            thread.Start();
            label1.Text = "正在爬";
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
