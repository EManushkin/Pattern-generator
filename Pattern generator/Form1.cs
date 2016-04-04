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
using HtmlAgilityPack;
using Random.Org;


namespace Pattern_generator
{

    public partial class Form1 : Form
    {
        public string[] tags = { "div", "article", "aside", "footer", "menu", "nav", "section" };
        //public RandomJSONRPC rnd = new RandomJSONRPC("6d99774c-ee16-48a1-a703-ad4ef5c6f2d6");
        Random.Org.Random rnd_org = new Random.Org.Random();
        //rnd_org.UseLocalMode = true; // prevents external web call, useful for testing
        public List<string[]> inner_classes = new List<string[]>();
        //inner_classes = ReadCSVFile.OpenFile(@"inner_classes.csv");
        public List<string[]> outer_classes = new List<string[]>();
        //inner_classes = ReadCSVFile.OpenFile(@"outer_classes.csv");

        public Form1()
        {
            InitializeComponent();
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

        private void RandSelectTemplateButton_Click(object sender, EventArgs e)
        {
            if (OpenFolder.Text != "Выбор папки c набором мастер-шаблонов")
            {
                DirectoryInfo drInfo = new DirectoryInfo(OpenFolder.Text);
                DirectoryInfo[] templates = drInfo.GetDirectories();

                if (templates.Length > 1)
                {
                    RandSelectTemplate.Text = templates[rnd_org.Next(0, templates.Length - 1)].ToString();
                    //RandSelectTemplate.Text = templates[(int)rnd.GenerateIntegers(1, 0, templates.Length - 1).GetValue(0)].ToString();
                }
                else
                {
                    RandSelectTemplate.Text = templates[0].ToString();
                }
                //RandSelectTemplate.Text = rnd_org.Next(1, 1000).ToString();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            string index_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";
            Directory.CreateDirectory(SaveFolder.Text + "\\" + RandSelectTemplate.Text);
            string index_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";

            int probability;
            int probability_inner1;
            int probability_inner2;
            int probability_inner3;

            HtmlParser index_html = new HtmlParser(index_path);

            inner_classes = ReadCSVFile.OpenFile(@"inner_classes.csv");

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            rnd_org.UseLocalMode = true; // prevents external web call, useful for testing

            int rand_index_inner_classes = rnd_org.Next(0, inner_classes.Count - 1);

            for (int i = 0; i < tags.Length; i++)
            {
                index_html.ParseTags(tags[i]);
            }

            int j = 0;
            foreach (var t in index_html.TagsList)
            {
                //probability_inner1 = (int)rnd.GenerateIntegers(1, 40, 60).GetValue(0);

                probability_inner1 = rnd_org.Next(40, 60);
                probability_inner2 = probability_inner1 / 2;
                probability_inner3 = probability_inner2 / 2;

                probability = 1; //для вставки всех иннеров!!!!!!!!
                //probability = rnd_org.Next(1, 100);
                if (probability < probability_inner3)
                {
                    index_html.InsertInner(index_html.TagsList[j].tags_name_for_inner.Replace("INNER", inner_classes[rand_index_inner_classes][2]), index_html.TagsList[j].xpath_instruction);
                }
                if (probability < probability_inner2)
                {
                    index_html.InsertInner(index_html.TagsList[j].tags_name_for_inner.Replace("INNER", inner_classes[rand_index_inner_classes][1]), index_html.TagsList[j].xpath_instruction);
                }

                if (probability < probability_inner1)
                {
                    index_html.InsertInner(index_html.TagsList[j].tags_name_for_inner.Replace("INNER", inner_classes[rand_index_inner_classes][0]), index_html.TagsList[j].xpath_instruction);
                }
                j++;
            }

            index_html.SaveHtmlDoc(index_save_path);
            textBox4.Text += "Вставка иннеров с вероятностью 40-60% в " + RandSelectTemplate.Text + " прошла успешно!";
            //index_html.SaveHtmlDoc(index_save_path);



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



        }

        private void button2_Click(object sender, EventArgs e)
        {
            string index_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";
            Directory.CreateDirectory(SaveFolder.Text + "\\" + RandSelectTemplate.Text);
            string index_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";

            int probability;
            int probability_outer;

            HtmlParser index_html = new HtmlParser(index_path);

            outer_classes = ReadCSVFile.OpenFile(@"outer_classes.csv");

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            rnd_org.UseLocalMode = true; // prevents external web call, useful for testing

            int rand_index_outer_classes = rnd_org.Next(0, outer_classes.Count - 1);

            for (int i = 0; i < tags.Length; i++)
            {
                index_html.ParseTags(tags[i]);
            }

            int j = 0;
            foreach (var t in index_html.TagsList)
            {
                
                probability_outer = rnd_org.Next(40, 60);
                probability = 1; //для вставки всех outer!!!!!!!!
                //probability = rnd_org.Next(1, 100);

                if (probability < probability_outer)
                {
                    index_html.InsertOuter(index_html.TagsList[j].tags_name_for_outer.Replace("OUTER", "OUTER"), index_html.TagsList[j].xpath_instruction);
                }
                j++;
            }

            index_html.SaveHtmlDoc(index_save_path);
            textBox1.Text += "Вставка аутеров с вероятностью 40-60% в " + RandSelectTemplate.Text + " прошла успешно!";
        }
    }
}
