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
                //nodes = html_doc.DocumentNode.SelectNodes("/html//div[2][@class='both']");
                //nodes = html_doc.DocumentNode.SelectNodes("//ancestor::div[2][@class='both'] | //descendant::div[2][@class='both'] | //following::div[2][@class='both'] | //preceding::div[2][@class='both'] | //self::div[2][@class='both']");

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
                                tags_info.xpath_instruction = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i]));
                                /*tags_info.xpath_instruction = "//ancestor::" + n.XPath +
                                                           " | //descendant::" + n.XPath +
                                                           " | //following::" + n.XPath +
                                                           " | //preceding::" + n.XPath +
                                                           " | //self::" + n.XPath;*/
                                TagsList.Add(tags_info);
                            }
                            else
                            {
                                tags_info.tags_name_for_inner = "";
                                tags_info.tags_name_for_outer = "";
                                tags_info.xpath_instruction = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i]));
                                /*tags_info.xpath_instruction = "//ancestor::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) +
                                                           " | //descendant::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) +
                                                           " | //following::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) +
                                                           " | //preceding::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) +
                                                           " | //self::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i]));
                                TagsList.Add(tags_info);*/
                            }
                        }
                        if ((n.Attributes["id"] != null) && (n.Attributes["class"] == null))
                        {
                            tags_info.tags_name_for_inner = "<div class=\"" + n.Attributes["id"].Value + "-INNER\">";
                            tags_info.tags_name_for_outer = "<div class=\"" + n.Attributes["id"].Value + "-OUTER\">";
                            tags_info.xpath_instruction = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "']";
                            /*tags_info.xpath_instruction = "//ancestor::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "']" +
                                                       " | //descendant::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "']" +
                                                       " | //following::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "']" +
                                                       " | //preceding::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "']" +
                                                       " | //self::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "']";
                            */TagsList.Add(tags_info);
                        }
                        if ((n.Attributes["id"] != null) && (n.Attributes["class"] != null))
                        {
                            tags_info.tags_name_for_inner = "<div class=\"" + n.Attributes["id"].Value + "-INNER\">";
                            tags_info.tags_name_for_outer = "<div class=\"" + n.Attributes["id"].Value + "-OUTER\">";
                            tags_info.xpath_instruction = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "' and @" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']";
                            /*tags_info.xpath_instruction = "//ancestor::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "' and @" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']" +
                                                       " | //descendant::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "' and @" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']" +
                                                       " | //following::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "' and @" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']" +
                                                       " | //preceding::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "' and @" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']" +
                                                       " | //self::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["id"].Name + "='" + n.Attributes["id"].Value + "' and @" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']";
                            */TagsList.Add(tags_info);
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
                            tags_info.xpath_instruction = "//" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']";
                            /*tags_info.xpath_instruction = "//ancestor::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']" +
                                                       " | //descendant::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']" +
                                                       " | //following::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']" +
                                                       " | //preceding::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']" +
                                                       " | //self::" + n.XPath.Remove(0, n.XPath.LastIndexOf(tag[i])) + "[@" + n.Attributes["class"].Name + "='" + n.Attributes["class"].Value + "']";
                            */TagsList.Add(tags_info);
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

            
        }

        public void InsertInnerWithProbability(int nesting_level, int probability_min, int probability_max)
        {
            Random.Org.Random rnd_org = new Random.Org.Random(Properties.Settings.Default.LocalRandom);

            int probability;
            int probability_inner1;
            int probability_inner2;
            int probability_inner3;
            int j = 0;

            int rand_index_inner_classes = rnd_org.Next(0, Form1.inner_classes.Count - 1);

            switch (nesting_level)
            {
                case 3:
                    {
                        foreach (var t in TagsList)
                        {
                            probability_inner1 = rnd_org.Next(probability_min, probability_max);
                            probability_inner2 = probability_inner1 / 2;
                            probability_inner3 = probability_inner2 / 2;
                            probability = rnd_org.Next(1, 100);

                            if (probability < probability_inner3)
                            {
                                InsertInner(TagsList[j].tags_name_for_inner.Replace("INNER", Form1.inner_classes[rand_index_inner_classes][2]), TagsList[j].xpath_instruction);
                            }
                            if (probability < probability_inner2)
                            {
                                InsertInner(TagsList[j].tags_name_for_inner.Replace("INNER", Form1.inner_classes[rand_index_inner_classes][1]), TagsList[j].xpath_instruction);
                            }

                            if (probability < probability_inner1)
                            {
                                InsertInner(TagsList[j].tags_name_for_inner.Replace("INNER", Form1.inner_classes[rand_index_inner_classes][0]), TagsList[j].xpath_instruction);
                            }
                            j++;
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (var t in TagsList)
                        {
                            probability_inner1 = rnd_org.Next(probability_min, probability_max);
                            probability_inner2 = probability_inner1 / 2;
                            probability = rnd_org.Next(1, 100);

                            if (probability < probability_inner2)
                            {
                                InsertInner(TagsList[j].tags_name_for_inner.Replace("INNER", Form1.inner_classes[rand_index_inner_classes][1]), TagsList[j].xpath_instruction);
                            }

                            if (probability < probability_inner1)
                            {
                                InsertInner(TagsList[j].tags_name_for_inner.Replace("INNER", Form1.inner_classes[rand_index_inner_classes][0]), TagsList[j].xpath_instruction);
                            }
                            j++;
                        }
                        break;
                    }

                case 1:
                    {
                        foreach (var t in TagsList)
                        {

                            probability_inner1 = rnd_org.Next(probability_min, probability_max);
                            probability = rnd_org.Next(1, 100);

                            if (probability < probability_inner1)
                            {
                                InsertInner(TagsList[j].tags_name_for_inner.Replace("INNER", Form1.inner_classes[rand_index_inner_classes][0]), TagsList[j].xpath_instruction);
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

        public void InsertOuterWithProbability(int probability_min, int probability_max)
        {
            Random.Org.Random rnd_org = new Random.Org.Random(Properties.Settings.Default.LocalRandom);

            int probability;
            int probability_outer;
            int j = 0;

            int rand_index_outer_classes = rnd_org.Next(0, Form1.outer_classes.Count - 1);

            foreach (var t in TagsList)
            {
                probability_outer = rnd_org.Next(probability_min, probability_max);
                probability = rnd_org.Next(1, 100);

                if (probability < probability_outer)
                {
                    InsertOuter(TagsList[j].tags_name_for_outer.Replace("OUTER", Form1.outer_classes[rand_index_outer_classes][0]), TagsList[j].xpath_instruction);
                }
                j++;
            }
        }

        public void MixTagsHead()
        {
            Random.Org.Random rnd_org = new Random.Org.Random(Properties.Settings.Default.LocalRandom);

            var nodes_head = html_doc.DocumentNode.SelectNodes("//head");
            var head_child = nodes_head["head"].ChildNodes;
            var temp_head = HtmlNode.CreateNode("<>");
            temp_head.AppendChildren(head_child);
            int[] temp = rnd_org.Sequence(0, temp_head.ChildNodes.Where(x => x.Name != "#text").Count() - 1);
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
            Random.Org.Random rnd_org = new Random.Org.Random(Properties.Settings.Default.LocalRandom);

            var nodes_many_class = html_doc.DocumentNode.SelectNodes("//*[contains(@class, ' ') and not(contains(@class, '[FIXED]'))]");

            foreach (var m in nodes_many_class)
            {
                string [] class_name = m.Attributes["class"].Value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] temp = rnd_org.Sequence(0, class_name.Length - 1);
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
            //Random.Org.Random rnd_org = new Random.Org.Random(Properties.Settings.Default.LocalRandom);


            int count_class_names = Form1.rnd_org.Next(class_names_min, class_names_max);
            int[] rand_mix_class = Form1.rnd_org.Sequence(0, Form1.random_class_names.Count - 1);

            for (int i = 0; i < count_class_names; i++)
            {
                int count_css_properties = Form1.rnd_org.Next(css_properties_min, css_properties_max);
                int[] rand_mix_css = Form1.rnd_org.Sequence(0, Form1.safe_css_properties.Count - 1);
                for (int j = 0; j < count_css_properties; j++)
                {
                    //вставка в css
                    //Form1.safe_css_properties[rand_mix_css[j]]
                }
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

        public void AddAttributeStyle(string[] tags, int attr_style_min, int attr_style_max, int css_properties_min, int css_properties_max)
        {
            var nodes_without_style = html_doc.DocumentNode.SelectNodes("//*[not(@style) and not(contains(@class, '[FIXED]'))]");
            //var nodes_without_style = html_doc.DocumentNode.SelectNodes("//*[not(@style) and @*[not(contains(., '[FIXED]'))]]");

            int count_attr_style = Form1.rnd_org.Next(attr_style_min, attr_style_max);
            int count_css_properties = Form1.rnd_org.Next(css_properties_min, css_properties_max);
            int[] rand_css_properties = Form1.rnd_org.Sequence(0, Form1.safe_css_properties.Count - 1);
            string css_properties = "";
            for (int i = 0; i < count_css_properties; i++)
            {
                css_properties += Form1.safe_css_properties[rand_css_properties[i]][0] + "; ";
            }
            css_properties = css_properties.Remove(css_properties.Length - 1);

            int[] rand_nodes = Form1.rnd_org.Sequence(0, nodes_without_style.Count() - 1);
            for (int j = 0; j < count_css_properties; j++)
            {
                nodes_without_style[rand_nodes[j]].Attributes.Add("style", css_properties);
            }
        }

        public void SaveHtmlDoc(string html_path)
        {
            html_doc.Save(html_path);
        }
    }
}
