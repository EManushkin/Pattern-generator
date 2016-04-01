﻿using System;
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
            //var indexdiv = html_doc.DocumentNode.SelectSingleNode("//div[@class='site_block content-body clear']"); //site_block content-body clear //class='contento
            //var innerdivB = HtmlNode.CreateNode("<div class=\"contento-inner\"></div>"); 
            //var innerdivE = HtmlNode.CreateNode("</div>");
            //int i = nodes.GetNodeIndex(indexdiv);
            //nodes.Insert(0, innerdivB);

            string output1 = "";
            string output2 = "";
            //string class_contento = "<div class='contento-inner'></div>";
            //HtmlNode newNode = HtmlNode.CreateNode(class_contento);
            var div1 = html_doc.DocumentNode.SelectSingleNode("//div[@class='contento']");
            string InnFirstHtml = div1.FirstChild.InnerText;
            string InnLastHtml = div1.LastChild.InnerText;
            //string tab = div1.ChildNodes["#text"].InnerText + "";
            //var tabnode = html_doc.CreateTextNode(tab);
            //div1.InsertAfter(tabnode, div1.ParentNode);
            var innerBeg = HtmlNode.CreateNode("<div class=\"contento-inner\">");
            //innerBeg.InnerHtml += "\t"; 
            //innerBeg.InnerHtml = tab; // + innerBeg.OuterHtml;
            //innerBeg.InnerHtml = tab;
            //innerBeg.ParentNode.InsertBefore(tabnode, innerBeg);
            //innerBeg.ParentNode.InsertBefore(tabnode, innerBeg);
            var ChildToInner = div1.ChildNodes;
            int i = 0;
            foreach (var ch in ChildToInner)
            {
                int pos = ChildToInner[i].InnerHtml.IndexOf("\r\n\t");
                while (pos >= 0)
                {
                    ChildToInner[i].InnerHtml = ChildToInner[i].InnerHtml.Insert(pos + 6, "\t");
                    pos = ChildToInner[i].InnerHtml.IndexOf("\r\n\t", pos + 1);
                }
                i++;
            }
            innerBeg.AppendChildren(ChildToInner);
            div1.RemoveAllChildren();
            div1.InnerHtml = div1.InnerHtml + InnLastHtml;
            div1.PrependChild(innerBeg);
            div1.InnerHtml = InnFirstHtml + div1.InnerHtml;

            //var div2 = html_doc.DocumentNode.SelectSingleNode("//div[@class='contento']");
            //div2.AppendChild(innerBeg);
            //div.ParentNode.InsertAfter(innerEnd, div);
            //div.InsertAfter(innerdiv, html_doc.DocumentNode.SelectSingleNode("//body"));
            //div.InsertAfter(html_doc.DocumentNode.SelectSingleNode("//div[@class='contento']"), innerdiv);
            //div.AppendChild(innerdivE);

            //nodes.Insert(1, newNode);
            /*var messageElement = new HtmlNode(HtmlNodeType.Element, html_doc, 6);
            messageElement.Attributes.Add("class", "contento-inner");
            messageElement.Name = "div";
            div1.ChildNodes.Insert(0, messageElement);*/


            /*foreach (var n in nodes)
                {
                //output1 += n.OuterHtml + "\n\n";
                output2 += n.Attributes["class"].Name + "\t" + n.Attributes["class"].Value + "\n";
            }*/
            //File.WriteAllText(textBox3.Text + "\\" + textBox2.Text + "\\index1.html", output2);
            html_doc.Save(textBox3.Text + "\\" + textBox2.Text + "\\index.html");
            textBox4.Text += "done!";

        }
    }
}