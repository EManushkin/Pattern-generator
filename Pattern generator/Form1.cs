using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using CsQuery;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace Pattern_generator
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.SelectedPath;
                RandSelectTemplateButton.Enabled = true;
            }
        }

        private void RandSelectTemplateButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Выбор папки c набором мастер-шаблонов")
            {
                DirectoryInfo drInfo = new DirectoryInfo(textBox1.Text);
                DirectoryInfo[] templates = drInfo.GetDirectories();
                RandomJSONRPC rnd = new RandomJSONRPC("6d99774c-ee16-48a1-a703-ad4ef5c6f2d6");
                textBox2.Text = templates[(int)rnd.GenerateIntegers(1, 0, templates.Length - 1).GetValue(0)].ToString();
            }
        }

        private void SaveFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = dialog.SelectedPath;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string html = textBox1.Text + "\\" + textBox2.Text + "\\index.html";
            html = File.ReadAllText(html);
            //CQ dom = CQ.Create(html);
            //CQ dom = CQ.CreateFromFile(html);
            //string new_html = dom.Render();
            //Directory.CreateDirectory(textBox3.Text + "\\" + textBox2.Text);
            //File.WriteAllText(textBox3.Text + "\\" + textBox2.Text + "\\index.html", new_html);
            //HtmlAgilityPack.HtmlDocument html_doc = new HtmlAgilityPack.HtmlDocument();
            //html_doc.Load(html);

            string pattern = @"(\<(/?[^\>]+)\>)";
            string pattern1 = @"<div([^>]*[^/])>";
            //RegexOptions option = RegexOptions.IgnoreCase;
            Regex RegDiv = new Regex(pattern1, RegexOptions.IgnoreCase);
            MatchCollection matches = RegDiv.Matches(html);
            foreach (Match mat in RegDiv.Matches(html))
                textBox4.Text += mat.Value + Environment.NewLine;

        }
    }
}
