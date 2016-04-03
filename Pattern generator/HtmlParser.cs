using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Pattern_generator
{
    class HtmlParser
    {
        public HtmlAgilityPack.HtmlDocument html_doc;
        private HtmlNodeCollection nodes;
        public string[] tags_name_for_inner = new string[100];
        public string[] xpath_instr = new string[100];


        public HtmlParser(string html_path)
        {
            html_doc = new HtmlAgilityPack.HtmlDocument();
            html_doc.OptionWriteEmptyNodes = true;
            html_doc.Load(html_path);
        }
        
        public void ParseTags(string tag)
        {
            nodes = html_doc.DocumentNode.SelectNodes("//"+tag);
            int i = 0;
            foreach (var n in nodes)
            {
                
                if ((n.Attributes["id"] == null) && (n.Attributes["class"] == null) && (tag != "div"))
                {
                    tags_name_for_inner[i] = "<div class=\"" + tag + "-INNER\">";
                    //xpath_instr[i] = "//" + tag + "[@" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']";
                }
                if ((n.Attributes["id"] != null) && (n.Attributes["class"] == null)) 
                {
                    tags_name_for_inner[i] = "<div class=\"" + n.Attributes["id"].Value + "-INNER\">";
                    xpath_instr[i] = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag)) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "']";
                }
                if ((n.Attributes["id"] != null) && (n.Attributes["class"] != null))
                {
                    tags_name_for_inner[i] = "<div class=\"" + n.Attributes["id"].Value + "-INNER\">";
                    xpath_instr[i] = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag)) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "']";
                }
                if ((n.Attributes["id"] == null) && (n.Attributes["class"] != null))
                {
                    tags_name_for_inner[i] = "<div class=\"" + n.Attributes["class"].Value + "-INNER\">";
                    xpath_instr[i] = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag)) + "[@" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']";
                    //n.XPath.Remove(n.XPath.LastIndexOf(tag)
                }
                i++;
                /*foreach (var att in n.Attributes)   
                { 
            { tags_name_for_inner[i] = "//" + tag + "[@" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']"; }        
            tags_name_for_inner[i] = "//" + tag + "[@" + att.Name + "='" + att.Value + "']";
                    i++;
                }*/
            }
            //return tags_name_for_inner;

            //HtmlNodeCollection nodes = html_doc.DocumentNode.SelectNodes("//div[@class]");

        }

        public void InsertInner(string name_for_inner, int i, string tag)
        {
            string initital_tabulation;
            string final_tabulation;

            //for (int i = 0; i < 18; i++)
            //{


            //var parent_tag = html_doc.DocumentNode.SelectSingleNode("//div[1][@class='content_block']");
            var parent_tag = html_doc.DocumentNode.SelectSingleNode(xpath_instr[i]);
            //var parent_tag = html_doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]//[@id='page']");

            //var temp = html_doc.DocumentNode.SelectNodes("//div[@class='content_block']");
            //var parent_tag = nodes[i];
            //var parent_tag = html_doc.DocumentNode.SelectSingleNode(instr_parent_tag);
            if (parent_tag.FirstChild != null && (Regex.IsMatch(parent_tag.FirstChild.InnerText, @"[^\r\n\t]") == false)) { initital_tabulation = parent_tag.FirstChild.InnerText; }
                else { initital_tabulation = parent_tag.ParentNode.FirstChild.InnerText + "\t"; }
                if (parent_tag.LastChild != null && (Regex.IsMatch(parent_tag.FirstChild.InnerText, @"[^\r\n\t]") == false)) { final_tabulation = parent_tag.LastChild.InnerText; }
                else { final_tabulation = parent_tag.ParentNode.LastChild.InnerText + "\t"; }

                var inner_tag = HtmlNode.CreateNode(name_for_inner);
            //inner_tag.XPath = "2";

                var child_to_inner = parent_tag.ChildNodes;
                int j = 0;
                foreach (var ch in child_to_inner)
                {
                    int pos = child_to_inner[j].InnerHtml.IndexOf("\r\n");
                    while (pos >= 0)
                    {
                        child_to_inner[j].InnerHtml = child_to_inner[j].InnerHtml.Insert(pos + 2, "\t");
                        pos = child_to_inner[j].InnerHtml.IndexOf("\r\n", pos + 1);
                    }
                    j++;
                }
                inner_tag.AppendChildren(child_to_inner);
                parent_tag.RemoveAllChildren();
                parent_tag.InnerHtml = parent_tag.InnerHtml + final_tabulation;
                parent_tag.PrependChild(inner_tag);
                parent_tag.InnerHtml = initital_tabulation + parent_tag.InnerHtml;

            //}
        }

        public void SaveHtmlDoc(string html_path)
        {
            html_doc.Save(html_path);
        }
    }
}
