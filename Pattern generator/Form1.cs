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
using Fizzler.Systems.HtmlAgilityPack;
using Random.Org;


namespace Pattern_generator
{

    public partial class Form1 : Form
    {
        public string[] tags = { "div", "article", "aside", "footer", "menu", "nav", "section" };
        //public RandomJSONRPC rnd = new RandomJSONRPC("6d99774c-ee16-48a1-a703-ad4ef5c6f2d6");
        //Random.Org.Random rnd_org = new Random.Org.Random(true);
        public static List<string[]> inner_classes = new List<string[]>();
        //inner_classes = ReadCSVFile.OpenFile(@"inner_classes.csv");
        public static List<string[]> outer_classes = new List<string[]>();
        //outer_classes = ReadCSVFile.OpenFile(@"outer_classes.csv");
        public List<string[]> color_scheme = new List<string[]>();
        //color_scheme = ReadCSVFile.OpenFile(@"color_scheme.csv");

        public Form1()
        {         
            InitializeComponent();

            this.menuRandom.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuInnerOuter.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuВыборЦветовыхСхем.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuРандомизацияЧастейCssКода.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuРандомизацияВертикальныхОтступов.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuРандомныйВыборНабораШрифтов.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuПерестановкаТегов.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuПерестановкаНазванийКлассов.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuПростановкаКомментариевCSS.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuДобавлениеНовыхКлассов.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuДобавлениеАтрибутовStyle.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.УстановкаЧислаВложенности.Text = "3";

            inner_classes = ReadCSVFile.OpenFile(@"inner_classes.csv");
            outer_classes = ReadCSVFile.OpenFile(@"outer_classes.csv");

        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            OpenFolder.Text = "C:\\Users\\Mann\\Desktop\\tpl";
            RandSelectTemplateButton.Enabled = true;

            /*if (dialog.ShowDialog() == DialogResult.OK)
            {

                OpenFolder.Text = dialog.SelectedPath;
                RandSelectTemplateButton.Enabled = true;
            }*/
        }

        private void SaveFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            SaveFolder.Text = "C:\\Users\\Mann\\Desktop\\tpl_finish";
            /*if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveFolder.Text = dialog.SelectedPath;

            }*/

        }

        private void RandSelectTemplateButton_Click(object sender, EventArgs e)
        {
            Random.Org.Random rnd_org = new Random.Org.Random(menuLocalRandom.Checked);

            if (OpenFolder.Text != "Выбор папки c набором мастер-шаблонов")
            {
                DirectoryInfo drInfo = new DirectoryInfo(OpenFolder.Text);
                DirectoryInfo[] templates = drInfo.GetDirectories();

                if (templates.Length > 1)
                {
                    RandSelectTemplate.Text = templates[rnd_org.Next(0, templates.Length - 1)].ToString();
                    Directory.CreateDirectory(SaveFolder.Text + "\\" + RandSelectTemplate.Text);

                    //RandSelectTemplate.Text = templates[(int)rnd.GenerateIntegers(1, 0, templates.Length - 1).GetValue(0)].ToString();
                }
                else
                {
                    RandSelectTemplate.Text = templates[0].ToString();
                    Directory.CreateDirectory(SaveFolder.Text + "\\" + RandSelectTemplate.Text);
                }
                //RandSelectTemplate.Text = rnd_org.Next(1, 1000).ToString();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";

            Random.Org.Random rnd_org = new Random.Org.Random(menuLocalRandom.Checked);

            string index_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";
            string index_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";

            HtmlParser index_html = new HtmlParser(index_path);
            for (int i = 0; i < tags.Length; i++)
            {
                index_html.ParseTags(tags[i]);
            }
            index_html.InsertInnerWithProbability(int.Parse(this.УстановкаЧислаВложенности.Text), int.Parse(this.вероятностьInnerMin.Text), int.Parse(this.вероятностьInnerMax.Text));
            index_html.InsertOuterWithProbability(int.Parse(this.вероятностьOuterMin.Text), int.Parse(this.вероятностьOuterMax.Text));
            index_html.SaveHtmlDoc(index_save_path);


            textBox4.Text += "Вставка иннеров и аутеров в " + RandSelectTemplate.Text + " прошла успешно!";




            //HtmlNodeCollection nodes = html_doc.DocumentNode.SelectNodes("//@id");
            //HtmlNodeCollection nodes = html_doc.DocumentNode.SelectNodes("//div[@class]");
            //var indexdiv = html_doc.DocumentNode.SelectSingleNode("//div[@class='site_block content-body clear']"); //site_block content-body clear //class='contento
            //var innerdivB = HtmlNode.CreateNode("<div class=\"contento-inner\"></div>"); 
            //var innerdivE = HtmlNode.CreateNode("</div>");
            //int i = nodes.GetNodeIndex(indexdiv);
            //nodes.Insert(0, innerdivB);

            //string class_contento = "<div class='contento-inner'></div>";
            //HtmlNode newNode = HtmlNode.CreateNode(class_contento);
            /*var div1 = html_doc.DocumentNode.SelectSingleNode("//div[@class='contento']");
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
            /*var ChildToInner = div1.ChildNodes;
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
            div1.InnerHtml = InnFirstHtml + div1.InnerHtml;*/

            //html_doc.Save(SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html");

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

            //probability_inner1 = (int)rnd.GenerateIntegers(1, 40, 60).GetValue(0);



        }


        private void button3_Click(object sender, EventArgs e)
        {

            /*string style_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";
            Directory.CreateDirectory(SaveFolder.Text + "\\" + RandSelectTemplate.Text);
            string style_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";

            //HtmlParser style_css = new HtmlParser(style_path);
            color_scheme = ReadCSVFile.OpenFile(@"color_scheme.csv");

            //style_css.ParseTags("");

            HtmlAgilityPack.HtmlDocument css_doc = new HtmlAgilityPack.HtmlDocument();
            css_doc.Load(style_path);

            var temp = css_doc.DocumentNode.QuerySelectorAll("background");

            textBox2.Text += "Load";*/

            string index_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";
            string index_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";

            HtmlParser index_html = new HtmlParser(index_path);

            index_html.MixTagsHead();
            index_html.SaveHtmlDoc(index_save_path);


            textBox2.Text += "Перемешал теги!";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string index_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";
            string index_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";

            HtmlParser index_html = new HtmlParser(index_path);

            index_html.MixNameClass();
            index_html.SaveHtmlDoc(index_save_path);

            textBox2.Text += "Перемешал классы!";
        }
    }
}
