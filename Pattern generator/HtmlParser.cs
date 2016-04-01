using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Pattern_generator
{
    class HtmlParser
    {
        private HtmlAgilityPack.HtmlDocument html_doc;
        public string[] tags_attr = new string[100];

        public HtmlParser(string html_path)
        {
            html_doc = new HtmlAgilityPack.HtmlDocument();
            html_doc.OptionWriteEmptyNodes = true;
            html_doc.Load(html_path);
        }
        
        public string[] ParseTags(string tag)
        {
            
            HtmlNodeCollection nodes = html_doc.DocumentNode.SelectNodes("//"+tag);
            int i = 0;
            foreach (var n in nodes)
            {
                //int j = 0;
                if ((n.Attributes["id"] == null) && (n.Attributes["class"] == null) && (tag == "div")) { }
                if ((n.Attributes["id"] != null) && (n.Attributes["class"] == null)) 
                    { tags_attr[i] = "//" + tag + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "']"; }
                if ((n.Attributes["id"] != null) && (n.Attributes["class"] != null))
                    { tags_attr[i] = "//" + tag + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "']"; }
                if ((n.Attributes["id"] == null) && (n.Attributes["class"] != null))
                    { tags_attr[i] = "//" + tag + "[@" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']"; }
                i++;
                /*foreach (var att in n.Attributes)   
                { 
                    tags_attr[i] = "//" + tag + "[@" + att.Name + "='" + att.Value + "']";
                    i++;
                }*/
            }
            return tags_attr;

            //HtmlNodeCollection nodes = html_doc.DocumentNode.SelectNodes("//div[@class]");

        }

        public void InsertInner(string[] instr_parent_tag)
        {
            string initital_tabulation;
            string final_tabulation;

            for (int i = 0; i < 18; i++)
            {


                //var parent_tag = html_doc.DocumentNode.SelectSingleNode("//div[@class='contento']");
                var parent_tag = html_doc.DocumentNode.SelectSingleNode(instr_parent_tag[i]);
                if (parent_tag.FirstChild != null) { initital_tabulation = parent_tag.FirstChild.InnerText; }
                else { initital_tabulation = ""; }
                if (parent_tag.LastChild != null) { final_tabulation = parent_tag.LastChild.InnerText; }
                else { final_tabulation = ""; }

                var inner_tag = HtmlNode.CreateNode("<div class=\"INNER\">");

                var child_to_inner = parent_tag.ChildNodes;
                int j = 0;
                foreach (var ch in child_to_inner)
                {
                    int pos = child_to_inner[j].InnerHtml.IndexOf("\r\n");
                    while (pos >= 0)
                    {
                        child_to_inner[j].InnerHtml = child_to_inner[j].InnerHtml.Insert(pos + 1, "\t");
                        pos = child_to_inner[j].InnerHtml.IndexOf("\r\n", pos + 1);
                    }
                    j++;
                }
                inner_tag.AppendChildren(child_to_inner);
                parent_tag.RemoveAllChildren();
                parent_tag.InnerHtml = parent_tag.InnerHtml + final_tabulation;
                parent_tag.PrependChild(inner_tag);
                parent_tag.InnerHtml = initital_tabulation + parent_tag.InnerHtml;

            }
        }

        public void SaveHtmlDoc(string html_path)
        {
            html_doc.Save(html_path);
        }
    }
}
