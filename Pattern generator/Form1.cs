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
using System.Text.RegularExpressions;
using HtmlAgilityPack;


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
            textBox1.Text = "C:\\Users\\Mann\\Desktop\\tpl";
            RandSelectTemplateButton.Enabled = true;

            /*if (dialog.ShowDialog() == DialogResult.OK)
            {
                
                textBox1.Text = dialog.SelectedPath;
                RandSelectTemplateButton.Enabled = true;
            }*/
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
            textBox3.Text = "C:\\Users\\Mann\\Desktop\\tpl_finish";
            /*if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = dialog.SelectedPath;
            }*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string html = textBox1.Text + "\\" + textBox2.Text + "\\index.html";
            //html = File.ReadAllText(html);
            Directory.CreateDirectory(textBox3.Text + "\\" + textBox2.Text);
            
            var html_doc = new HtmlAgilityPack.HtmlDocument();
            html_doc.OptionWriteEmptyNodes = true;
            html_doc.Load(html);

            //HtmlNodeCollection nodes = html_doc.DocumentNode.SelectNodes("//@id");
            HtmlNodeCollection nodes = html_doc.DocumentNode.SelectNodes("//div[@class]");
            string output1 = "";
            string output2 = "";
            foreach (var n in nodes)
                {
                //output1 += n.OuterHtml + "\n\n";
                output2 += n.Attributes["class"].Name + "\t" + n.Attributes["class"].Value + "\n";
            }
            File.WriteAllText(textBox3.Text + "\\" + textBox2.Text + "\\index1.html", output2);
            html_doc.CreateElement("inner");
            html_doc.Save(textBox3.Text + "\\" + textBox2.Text + "\\index.html");

            //HtmlNode node = html_doc.DocumentNode.SelectSingleNode("//div[@class]");


            //File.WriteAllText(textBox3.Text + "\\" + textBox2.Text + "\\index.html", document.DocumentElement.OuterHtml);


            textBox4.Text += "done!";

            /*string pattern = @"<div.*?>.*?<\/div.*?>";
            string pattern1 = @"<div([^>]*[^/])>";
            string pattern2 = @"<div.*?>(.*?)<\/div.*>?";
            Regex RegDiv = new Regex(pattern, RegexOptions.Multiline);
            MatchCollection matches = RegDiv.Matches(html);
            foreach (Match mat in RegDiv.Matches(html))
                textBox4.Text += mat.Value + Environment.NewLine;*/

        }
    }
}
