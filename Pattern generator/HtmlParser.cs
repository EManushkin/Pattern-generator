using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;

namespace Pattern_generator
{
    class HtmlParser
    {
        private HtmlAgilityPack.HtmlDocument html_doc;
        private HtmlNodeCollection nodes;
        public struct TagsInformation
        {
            public string tags_name_for_inner;
            public string tags_name_for_outer;
            public string xpath_instruction;
            //public int probability_inner1;
            //public int probability_inner2;
            //public int probability_inner3;
        }
        public TagsInformation tags_info;
        public List<TagsInformation> TagsList = new List<TagsInformation>();

        public HtmlParser(string html_path)
        {
            html_doc = new HtmlAgilityPack.HtmlDocument();
            html_doc.OptionWriteEmptyNodes = true;
            html_doc.Load(html_path);
        }
        
        public void ParseTags(string tag)
        {
            nodes = html_doc.DocumentNode.SelectNodes("//"+tag);
            //tags_info.tags_name_for_inner = "";
            //tags_info.xpath_instruction = "";


            if (nodes != null)
            {
                foreach (var n in nodes)
                {

                    if ((n.Attributes["id"] == null) && (n.Attributes["class"] == null) && (tag != "div"))
                    {
                        tags_info.tags_name_for_inner = "<div class=\"" + tag + "-INNER\">";
                        tags_info.tags_name_for_outer = "<div class=\"" + tag + "-OUTER\">";
                        tags_info.xpath_instruction = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag));
                        TagsList.Add(tags_info);

                    }
                    if ((n.Attributes["id"] != null) && (n.Attributes["class"] == null))
                    {
                        tags_info.tags_name_for_inner = "<div class=\"" + n.Attributes["id"].Value + "-INNER\">";
                        tags_info.tags_name_for_outer = "<div class=\"" + n.Attributes["id"].Value + "-OUTER\">";
                        tags_info.xpath_instruction = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag)) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "']";
                        TagsList.Add(tags_info);
                    }
                    if ((n.Attributes["id"] != null) && (n.Attributes["class"] != null))
                    {
                        tags_info.tags_name_for_inner = "<div class=\"" + n.Attributes["id"].Value + "-INNER\">";
                        tags_info.tags_name_for_outer = "<div class=\"" + n.Attributes["id"].Value + "-OUTER\">";
                        tags_info.xpath_instruction = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag)) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "']";
                        TagsList.Add(tags_info);
                    }
                    if ((n.Attributes["id"] == null) && (n.Attributes["class"] != null))
                    {
                        if (n.Attributes["class"].Value.IndexOf(' ') > 0)
                        {
                            tags_info.tags_name_for_inner = "<div class=\"" + n.Attributes["class"].Value.Remove(n.Attributes["class"].Value.IndexOf(' ')) + "-INNER\">";
                            tags_info.tags_name_for_outer = "<div class=\"" + n.Attributes["class"].Value.Remove(n.Attributes["class"].Value.IndexOf(' ')) + "-OUTER\">";
                        }
                        else
                        {
                            tags_info.tags_name_for_inner = "<div class=\"" + n.Attributes["class"].Value + "-INNER\">";
                            tags_info.tags_name_for_outer = "<div class=\"" + n.Attributes["class"].Value + "-OUTER\">";
                        }
                        tags_info.xpath_instruction = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag)) + "[@" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']";
                        TagsList.Add(tags_info);
                    }
                }
            }
        }




        public void InsertInner(string name_for_inner, string xpath_instr)
        {
            string initital_tabulation;
            string final_tabulation;



            //var parent_tag = html_doc.DocumentNode.SelectSingleNode("//div[1][@class='content_block']");
            var parent_tag = html_doc.DocumentNode.SelectSingleNode(xpath_instr);
            //var parent_tag = html_doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]//[@id='page']");

            //var temp = html_doc.DocumentNode.SelectNodes("//div[@class='content_block']");
            //var parent_tag = nodes[i];
            //var parent_tag = html_doc.DocumentNode.SelectSingleNode(instr_parent_tag);
            if (parent_tag.FirstChild != null && (Regex.IsMatch(parent_tag.FirstChild.InnerText, @"[^\r\n\t]") == false))
            {
                initital_tabulation = parent_tag.FirstChild.InnerText;
            }
            else
            {
                initital_tabulation = parent_tag.ParentNode.FirstChild.InnerText + "\t";
            }
            if (parent_tag.LastChild != null && (Regex.IsMatch(parent_tag.FirstChild.InnerText, @"[^\r\n\t]") == false))
            {
                final_tabulation = parent_tag.LastChild.InnerText;
            }
            else
            {
                final_tabulation = parent_tag.ParentNode.LastChild.InnerText + "\t";
            }

            var inner_tag = HtmlNode.CreateNode(name_for_inner);
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
        }


        public void InsertOuter(string name_for_outer, string xpath_instr)
        {
            string initital_tabulation;
            string final_tabulation;

            var parent_tag = html_doc.DocumentNode.SelectSingleNode(xpath_instr);
            //var pt = html_doc.DocumentNode.SelectSingleNode("//div/ancestor::[@id='all'] | //div/descendant::[@id='all'] | //div/following::[@id='all']| //div/preceding::[@id='all'] | //div/self::[@id='all']"); 

            if (parent_tag.FirstChild != null && (Regex.IsMatch(parent_tag.FirstChild.InnerText, @"[^\r\n\t]") == false))
            {
                initital_tabulation = parent_tag.FirstChild.InnerText;
            }
            else
            {
                initital_tabulation = parent_tag.ParentNode.FirstChild.InnerText + "\t";
            }
            if (parent_tag.LastChild != null && (Regex.IsMatch(parent_tag.FirstChild.InnerText, @"[^\r\n\t]") == false))
            {
                final_tabulation = parent_tag.LastChild.InnerText;
            }
            else
            {
                final_tabulation = parent_tag.ParentNode.LastChild.InnerText + "\t";
            }

            var outer_tag = HtmlNode.CreateNode(name_for_outer);
            var child_to_outer = parent_tag.ChildNodes;

            int j = 0;
            foreach (var ch in child_to_outer)
            {
                int pos = child_to_outer[j].InnerHtml.IndexOf("\r\n");
                while (pos >= 0)
                {
                    child_to_outer[j].InnerHtml = child_to_outer[j].InnerHtml.Insert(pos + 2, "\t");
                    pos = child_to_outer[j].InnerHtml.IndexOf("\r\n", pos + 1);
                }
                j++;
            }
            string temp_name = outer_tag.Name;
            string temp_att_name = outer_tag.Attributes[0].Name;
            string temp_att_value = outer_tag.Attributes[0].Value;

            outer_tag.RemoveAll();
            outer_tag.AppendChildren(child_to_outer);
            foreach (var att in parent_tag.Attributes)
            {
                outer_tag.SetAttributeValue(att.Name, att.Value);
            }
            outer_tag.Name = parent_tag.Name;

            parent_tag.RemoveAll();
            parent_tag.SetAttributeValue(temp_att_name, temp_att_value);
            parent_tag.Name = temp_name;
            parent_tag.InnerHtml = parent_tag.InnerHtml + final_tabulation;
            parent_tag.PrependChild(outer_tag);
            parent_tag.InnerHtml = initital_tabulation + parent_tag.InnerHtml;
            //parent_tag.Name = "";

            /*outer_tag.AppendChild(parent_tag);
            outer_tag.InnerHtml = outer_tag.InnerHtml + final_tabulation;
            outer_tag.InnerHtml = initital_tabulation + outer_tag.InnerHtml;
            parent_tag.RemoveAll();
            parent_tag.SetAttributeValue(outer_tag.Attributes[0].Name, outer_tag.Attributes[0].Value);*/
        } 

        public void SaveHtmlDoc(string html_path)
        {
            html_doc.Save(html_path);
        }
    }
}
