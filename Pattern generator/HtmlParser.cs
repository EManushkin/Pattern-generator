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
        private HtmlAgilityPack.HtmlDocument html_doc;
        private HtmlNodeCollection nodes;
        private struct TagsInformation
        {
            public string tags_name_for_inner;
            public string tags_name_for_outer;
            public string css_rule_name;
            public string xpath_instruction;
        }
        private TagsInformation tags_info;
        private List<TagsInformation> TagsList = new List<TagsInformation>();



        public HtmlParser(string html_path)
        {
            html_doc = new HtmlAgilityPack.HtmlDocument();
            html_doc.OptionWriteEmptyNodes = true;
            html_doc.Load(html_path);
        }
        


        public void ParseTags(string[] tag)
        {
            TagsList.Clear();
            for (int i = 0; i < tag.Length; i++)
            {
                nodes = html_doc.DocumentNode.SelectNodes("//" + tag[i] + "[not(contains(@class, '[FIXED]')) and not(contains(@id, '[FIXED]'))]");

                if (nodes != null)
                {
                    foreach (var n in nodes)
                    {

                        if ((n.Attributes["id"] == null) && (n.Attributes["class"] == null))
                        {
                            if (tag[i] != "div")
                            {
                                tags_info.tags_name_for_inner = "<div class=\"" + tag[i] + "-INNER\">";
                                tags_info.tags_name_for_outer = "<div class=\"" + tag[i] + "-OUTER\">";
                                tags_info.css_rule_name = tag[i] + "-ELEMENT";
                                tags_info.xpath_instruction = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i]));
                                TagsList.Add(tags_info);
                            }
                            else
                            {
                                tags_info.tags_name_for_inner = "";
                                tags_info.tags_name_for_outer = "";
                                tags_info.css_rule_name = "";
                                tags_info.xpath_instruction = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i]));
                            }
                        }
                        if ((n.Attributes["id"] != null) && (n.Attributes["class"] == null))
                        {
                            tags_info.tags_name_for_inner = "<div class=\"" + n.Attributes["id"].Value + "-INNER\">";
                            tags_info.tags_name_for_outer = "<div class=\"" + n.Attributes["id"].Value + "-OUTER\">";
                            tags_info.css_rule_name = n.Attributes["id"].Value + "-ELEMENT";
                            tags_info.xpath_instruction = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "']";
                            TagsList.Add(tags_info);
                        }
                        if ((n.Attributes["id"] != null) && (n.Attributes["class"] != null))
                        {
                            tags_info.tags_name_for_inner = "<div class=\"" + n.Attributes["id"].Value + "-INNER\">";
                            tags_info.tags_name_for_outer = "<div class=\"" + n.Attributes["id"].Value + "-OUTER\">";
                            tags_info.css_rule_name = n.Attributes["id"].Value + "-ELEMENT";
                            tags_info.xpath_instruction = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "' and @" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']";
                            TagsList.Add(tags_info);
                        }
                        if ((n.Attributes["id"] == null) && (n.Attributes["class"] != null))
                        {
                            if (n.Attributes["class"].Value.Trim().IndexOf(' ') > 0)
                            {
                                tags_info.tags_name_for_inner = "<div class=\"" + n.Attributes["class"].Value.Trim().Remove(n.Attributes["class"].Value.Trim().IndexOf(' ')) + "-INNER\">";
                                tags_info.tags_name_for_outer = "<div class=\"" + n.Attributes["class"].Value.Trim().Remove(n.Attributes["class"].Value.Trim().IndexOf(' ')) + "-OUTER\">";
                                tags_info.css_rule_name = n.Attributes["class"].Value.Trim().Remove(n.Attributes["class"].Value.Trim().IndexOf(' ')) + "-ELEMENT";
                            }
                            else
                            {
                                tags_info.tags_name_for_inner = "<div class=\"" + n.Attributes["class"].Value + "-INNER\">";
                                tags_info.tags_name_for_outer = "<div class=\"" + n.Attributes["class"].Value + "-OUTER\">";
                                tags_info.css_rule_name = n.Attributes["class"].Value + "-ELEMENT";
                            }
                            tags_info.xpath_instruction = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']";
                            TagsList.Add(tags_info);
                        }
                    }
                }
            }
        }



        public void InsertInner(string name_for_inner, string xpath_instr)
        {
            string initital_tabulation;
            string final_tabulation;

            if (name_for_inner != "")
            {
                var parent_tag = html_doc.DocumentNode.SelectSingleNode(xpath_instr);

                if (parent_tag.FirstChild != null)
                {
                    initital_tabulation = Regex.Match(parent_tag.FirstChild.InnerHtml, @"^\r\n\s*").ToString();
                }
                else
                {
                    initital_tabulation = Regex.Match(parent_tag.ParentNode.FirstChild.InnerHtml, @"^\r\n\s*").ToString() + "\t";
                }
                if (parent_tag.LastChild != null)
                {
                    final_tabulation = Regex.Match(parent_tag.LastChild.InnerHtml, @"^\r\n\s*").ToString();
                }
                else
                {
                    final_tabulation = Regex.Match(parent_tag.ParentNode.LastChild.InnerHtml, @"^\r\n\s*").ToString() + "\t";
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
        }



        public void InsertInnerWithProbability(int nesting_level, int probability_min, int probability_max, int probability_css_min, int probability_css_max, int count_css_min, int count_css_max)
        {
            int probability_html, probability_css, probability_css_rule, probability_inner1, probability_inner2, probability_inner3;
            int j = 0;

            int rand_index_inner_classes = Form1.rnd_org.Next(0, Form1.inner_classes.Count - 1);

            switch (nesting_level)
            {
                case 3:
                    {
                        foreach (var t in TagsList)
                        {
                            probability_inner1 = Form1.rnd_org.Next(probability_min, probability_max);
                            probability_inner2 = probability_inner1 / 2;
                            probability_inner3 = probability_inner2 / 2;
                            probability_html = Form1.rnd_org.Next(1, 100);

                            if (probability_html < probability_inner3)
                            {
                                InsertInner(TagsList[j].tags_name_for_inner.Replace("INNER", Form1.inner_classes[rand_index_inner_classes][2]), TagsList[j].xpath_instruction);
                                probability_css_rule = Form1.rnd_org.Next(probability_css_min, probability_css_max);
                                probability_css = Form1.rnd_org.Next(1, 100);
                                if (probability_css < probability_css_rule)
                                {
                                    CssParser.AddNewRule(TagsList[j].css_rule_name.Replace("ELEMENT", Form1.inner_classes[rand_index_inner_classes][2]), count_css_min, count_css_max);
                                }
                            }
                            if (probability_html < probability_inner2)
                            {
                                InsertInner(TagsList[j].tags_name_for_inner.Replace("INNER", Form1.inner_classes[rand_index_inner_classes][1]), TagsList[j].xpath_instruction);
                                probability_css_rule = Form1.rnd_org.Next(probability_css_min, probability_css_max);
                                probability_css = Form1.rnd_org.Next(1, 100);
                                if (probability_css < probability_css_rule)
                                {
                                    CssParser.AddNewRule(TagsList[j].css_rule_name.Replace("ELEMENT", Form1.inner_classes[rand_index_inner_classes][1]), count_css_min, count_css_max);
                                }
                            }

                            if (probability_html < probability_inner1)
                            {
                                InsertInner(TagsList[j].tags_name_for_inner.Replace("INNER", Form1.inner_classes[rand_index_inner_classes][0]), TagsList[j].xpath_instruction);
                                probability_css_rule = Form1.rnd_org.Next(probability_css_min, probability_css_max);
                                probability_css = Form1.rnd_org.Next(1, 100);
                                if (probability_css < probability_css_rule)
                                {
                                    CssParser.AddNewRule(TagsList[j].css_rule_name.Replace("ELEMENT", Form1.inner_classes[rand_index_inner_classes][0]), count_css_min, count_css_max);
                                }
                            }
                            j++;
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (var t in TagsList)
                        {
                            probability_inner1 = Form1.rnd_org.Next(probability_min, probability_max);
                            probability_inner2 = probability_inner1 / 2;
                            probability_html = Form1.rnd_org.Next(1, 100);

                            if (probability_html < probability_inner2)
                            {
                                InsertInner(TagsList[j].tags_name_for_inner.Replace("INNER", Form1.inner_classes[rand_index_inner_classes][1]), TagsList[j].xpath_instruction);
                                probability_css_rule = Form1.rnd_org.Next(probability_css_min, probability_css_max);
                                probability_css = Form1.rnd_org.Next(1, 100);
                                if (probability_css < probability_css_rule)
                                {
                                    CssParser.AddNewRule(TagsList[j].css_rule_name.Replace("ELEMENT", Form1.inner_classes[rand_index_inner_classes][1]), count_css_min, count_css_max);
                                }
                            }

                            if (probability_html < probability_inner1)
                            {
                                InsertInner(TagsList[j].tags_name_for_inner.Replace("INNER", Form1.inner_classes[rand_index_inner_classes][0]), TagsList[j].xpath_instruction);
                                probability_css_rule = Form1.rnd_org.Next(probability_css_min, probability_css_max);
                                probability_css = Form1.rnd_org.Next(1, 100);
                                if (probability_css < probability_css_rule)
                                {
                                    CssParser.AddNewRule(TagsList[j].css_rule_name.Replace("ELEMENT", Form1.inner_classes[rand_index_inner_classes][0]), count_css_min, count_css_max);
                                }
                            }
                            j++;
                        }
                        break;
                    }

                case 1:
                    {
                        foreach (var t in TagsList)
                        {

                            probability_inner1 = Form1.rnd_org.Next(probability_min, probability_max);
                            probability_html = Form1.rnd_org.Next(1, 100);

                            if (probability_html < probability_inner1)
                            {
                                InsertInner(TagsList[j].tags_name_for_inner.Replace("INNER", Form1.inner_classes[rand_index_inner_classes][0]), TagsList[j].xpath_instruction);
                                probability_css_rule = Form1.rnd_org.Next(probability_css_min, probability_css_max);
                                probability_css = Form1.rnd_org.Next(1, 100);
                                if (probability_css < probability_css_rule)
                                {
                                    CssParser.AddNewRule(TagsList[j].css_rule_name.Replace("ELEMENT", Form1.inner_classes[rand_index_inner_classes][0]), count_css_min, count_css_max);
                                }
                            }
                            j++;
                        }
                        break;
                    }
            }

        }



        public void InsertOuter(string name_for_outer, string xpath_instr)
        {
            string initital_tabulation;
            string final_tabulation;

            if (name_for_outer != "")
            {
                var parent_tag = html_doc.DocumentNode.SelectSingleNode(xpath_instr);

                if (parent_tag != null)
                {

                    if (parent_tag.FirstChild != null)
                    {
                        initital_tabulation = Regex.Match(parent_tag.FirstChild.InnerHtml, @"^\r\n\s*").ToString();
                    }
                    else
                    {
                        initital_tabulation = Regex.Match(parent_tag.ParentNode.FirstChild.InnerHtml, @"^\r\n\s*").ToString() + "\t";
                    }
                    if (parent_tag.LastChild != null)
                    {
                        final_tabulation = Regex.Match(parent_tag.LastChild.InnerHtml, @"^\r\n\s*").ToString();
                    }
                    else
                    {
                        final_tabulation = Regex.Match(parent_tag.ParentNode.LastChild.InnerHtml, @"^\r\n\s*").ToString() + "\t";
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
                }
            }
        }



        public void InsertOuterWithProbability(int probability_min, int probability_max, int probability_css_min, int probability_css_max, int count_css_min, int count_css_max)
        {
            int probability_html, probability_css, probability_css_rule, probability_outer;
            int j = 0;

            int rand_index_outer_classes = Form1.rnd_org.Next(0, Form1.outer_classes.Count - 1);

            foreach (var t in TagsList)
            {
                probability_outer = Form1.rnd_org.Next(probability_min, probability_max);
                probability_html = Form1.rnd_org.Next(1, 100);

                if (probability_html < probability_outer)
                {
                    InsertOuter(TagsList[j].tags_name_for_outer.Replace("OUTER", Form1.outer_classes[rand_index_outer_classes][0]), TagsList[j].xpath_instruction);
                    probability_css_rule = Form1.rnd_org.Next(probability_css_min, probability_css_max);
                    probability_css = Form1.rnd_org.Next(1, 100);
                    if (probability_css < probability_css_rule)
                    {
                        CssParser.AddNewRule(TagsList[j].css_rule_name.Replace("ELEMENT", Form1.outer_classes[rand_index_outer_classes][0]), count_css_min, count_css_max);
                    }
                }
                j++;
            }
        }



        public void MixTagsHead()
        {
            var nodes_head = html_doc.DocumentNode.SelectNodes("//head");
            var head_child = nodes_head["head"].ChildNodes;
            var temp_head = HtmlNode.CreateNode("<>");
            temp_head.AppendChildren(head_child);
            int[] temp = Form1.rnd_org.Sequence(0, temp_head.ChildNodes.Where(x => x.Name != "#text").Count() - 1);
            int j = 0;

            for (int i = 0; i < nodes_head["head"].ChildNodes.Count; i++)
            {
                if (nodes_head["head"].ChildNodes[i].Name != "#text")
                {
                    nodes_head["head"].ChildNodes[i] = temp_head.ChildNodes.Where(x => x.Name != "#text").ToArray()[temp[j]];
                    j++;
                }
            }

        }



        public void MixNameClass()
        {
            var nodes_many_class = html_doc.DocumentNode.SelectNodes("//*[contains(@class, ' ') and not(contains(@class, '[FIXED]'))]");

            foreach (var m in nodes_many_class)
            {
                string [] class_name = m.Attributes["class"].Value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] temp = Form1.rnd_org.Sequence(0, class_name.Length - 1);
                m.Attributes["class"].Value = "";
                for (int i = 0; i < temp.Length; i++)
                {
                    m.Attributes["class"].Value += class_name[temp[i]] + " ";
                }
                m.Attributes["class"].Value = m.Attributes["class"].Value.Remove(m.Attributes["class"].Value.Length - 1);
            }
        }



        public void AddNewClass(string[] tags, int class_names_min, int class_names_max, int tag_min, int tag_max, int css_properties_min, int css_properties_max)
        {
            int count_class_names = Form1.rnd_org.Next(class_names_min, class_names_max);
            int[] rand_mix_class = Form1.rnd_org.Sequence(0, Form1.random_class_names.Count - 1);

            for (int i = 0; i < count_class_names; i++)
            {
                CssParser.AddNewRule(Form1.random_class_names[rand_mix_class[i]][0], css_properties_min, css_properties_max);
                ParseTags(tags);
                int count_tag = Form1.rnd_org.Next(tag_min, tag_max);
                int[] rand_mix_all_tags = Form1.rnd_org.Sequence(0, TagsList.Count - 1);
                for (int k = 0; k < count_tag; k++)
                {
                    var tag_for_add_class = html_doc.DocumentNode.SelectSingleNode(TagsList[rand_mix_all_tags[k]].xpath_instruction);
                    if (tag_for_add_class.Attributes["class"] != null)
                    {
                        tag_for_add_class.Attributes["class"].Value += " " + Form1.random_class_names[rand_mix_class[i]][0];
                    }
                    else
                    {
                        tag_for_add_class.Attributes.Add("class", Form1.random_class_names[rand_mix_class[i]][0]);
                    }
                }
            }
        }

        public void AddAttributeStyle(int attr_style_min, int attr_style_max, int css_properties_min, int css_properties_max)
        {
            var nodes_without_style = html_doc.DocumentNode.SelectNodes("html/body//*[not(@style) and not(contains(@class, '[FIXED]')) and not(contains(@id, '[FIXED]'))]");

            int[] rand_nodes = Form1.rnd_org.Sequence(0, nodes_without_style.Count() - 1);
            int count_attr_style = Form1.rnd_org.Next(attr_style_min, attr_style_max);

            for (int j = 0; j < count_attr_style; j++)
            {
                string css_properties = "";
                int count_css_properties = Form1.rnd_org.Next(css_properties_min, css_properties_max);
                int[] rand_css_properties = Form1.rnd_org.Sequence(0, Form1.safe_css_properties.Count - 1);
                for (int i = 0; i < count_css_properties; i++)
                {
                    css_properties += Form1.safe_css_properties[rand_css_properties[i]][0] + "; ";
                }
                css_properties = css_properties.Remove(css_properties.Length - 1);
                nodes_without_style[rand_nodes[j]].Attributes.Add("style", css_properties);
            }
        }



        public void SaveHtmlDoc(string html_path)
        {
            Regex fixe = new Regex(@"\s*\[FIXED\]\s*");
            html_doc.DocumentNode.InnerHtml = fixe.Replace(html_doc.DocumentNode.InnerHtml, "");
            html_doc.Save(html_path);
        }



        public void ReplaceIdClass()
        {
            List<string> id_list = new List<string>();
            List<string> class_list = new List<string>();
            List<string> full_class_list = new List<string>();
            string[] temp_class_name;
            int[] rand_mix_names = Form1.rnd_org.Sequence(0, Form1.class_names.Count - 1);
            int j = 0;


            var nodes_id = html_doc.DocumentNode.SelectNodes("//*[(@id) and not(contains(@class, '[FIXED]'))]");
            foreach (var id_name in nodes_id)
            {
                if (!id_list.Contains(id_name.Attributes["id"].Value))
                {
                    id_list.Add(id_name.Attributes["id"].Value);
                }
            }
            var nodes_class = html_doc.DocumentNode.SelectNodes("//*[(@class) and not(contains(@class, '[FIXED]'))]");
            foreach (var class_name in nodes_class)
            {
                temp_class_name = class_name.Attributes["class"].Value.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                class_name.Attributes["class"].Value = " " + class_name.Attributes["class"].Value.Trim() + " ";
                for (int i = 0; i < temp_class_name.Length; i++)
                {
                    if (!class_list.Contains(temp_class_name[i]))
                    {
                        class_list.Add(temp_class_name[i]);
                    }
                } 
            }


            for (int i = 0; i < id_list.Count; i++)
            {
                var nodes = html_doc.DocumentNode.SelectNodes("//*[normalize-space(@id)='" + id_list[i] + "' and not(contains(@class, '[FIXED]'))]");
                while (j < Form1.class_names.Count)
                {
                    if (!id_list.Contains(Form1.class_names[rand_mix_names[j]][0]))
                    {
                        foreach (var n in nodes)
                        {
                            n.Attributes["id"].Value = Form1.class_names[rand_mix_names[j]][0];
                        }
                        CssParser.ReplaceIdClass("#" + id_list[i], "#" + Form1.class_names[rand_mix_names[j]][0]);
                        j++;
                        break;
                    }
                    j++;
                }
            }


            for (int i = 0; i < class_list.Count; i++)
            {
                var nodes = html_doc.DocumentNode.SelectNodes("//*[contains(@class, ' " + class_list[i] + " ') and not(contains(@class, '[FIXED]'))]");
                while (j < Form1.class_names.Count)
                {
                    if (!class_list.Contains(Form1.class_names[rand_mix_names[j]][0]))
                    {
                        foreach (var n in nodes)
                        {
                            n.Attributes["class"].Value = n.Attributes["class"].Value.Replace(" " + class_list[i] + " ", " " + Form1.class_names[rand_mix_names[j]][0] + " ");
                        }
                        CssParser.ReplaceIdClass(@"\." + class_list[i], "." + Form1.class_names[rand_mix_names[j]][0]);
                        j++;
                        break;
                    }
                    j++;
                }
            }
            foreach (var class_name in nodes_class)
            {
                class_name.Attributes["class"].Value = class_name.Attributes["class"].Value.Trim();
            }

        }


    }
}
