using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Pattern_generator
{
    class CssParser
    {
        private static string css_information;

        public CssParser(string css_path)
        {
            css_information = File.ReadAllText(css_path);
        }



        public static void AddNewRule(string name_class, int css_properties_min, int css_properties_max)
        {
            string css_properties = "\r\n." + name_class + "{";
            int count_css_properties = Form1.rnd_org.Next(css_properties_min, css_properties_max);
            int[] rand_css_properties = Form1.rnd_org.Sequence(0, Form1.safe_css_properties.Count - 1);

            for (int i = 0; i < count_css_properties; i++)
            {
                css_properties += "\r\n\t" + Form1.safe_css_properties[rand_css_properties[i]][0] + ";";
            }
            css_properties += "\r\n}";
            css_information += css_properties;
        }



        public static void ReplaceIdClass(string name, string new_name)
        {
            Regex replace = new Regex("(" + name + @")(?=[^\w-]*)", RegexOptions.Singleline | RegexOptions.Multiline);
            css_information = replace.Replace(css_information, new_name);
        }



        public void RandomComments(int count_comment_min, int count_comment_max)
        {
            string temp_css_info = "";
            string comment_name = "";
            string temp_elements_all = "";
            int where_ins;

            MatchCollection all_elements = Regex.Matches(css_information,
                                                     @"(\[FIXED_AREA\].*?\[\/FIXED_AREA\])
                                                     |                                                     
                                                     ([^{}]*{
                                                                ([^{}]*{[^{}]*})*?
                                                     [^{}]*})",
                                                     RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Multiline);

            string[] elements = new string[all_elements.Count];
            for (int i = 0; i < all_elements.Count; i++)
            {
                elements[i] = all_elements[i].ToString();
            }

            int count_comment = Form1.rnd_org.Next(count_comment_min, count_comment_max);
            int check = elements.Length + 1000;

            while (count_comment > 0 && check > 0)
            {
                int rand_index = Form1.rnd_org.Next(0, elements.Length - 1);

                if (!elements[rand_index].ToString().Contains("[FIXED_AREA]"))
                {
                    int count_prop = Regex.Matches(elements[rand_index].ToString(), @"{").Count;
                    switch (count_prop)
                    {
                        case 1:
                            {
                                if (!elements[rand_index].ToString().Contains("/*") &&
                                    Regex.Match(elements[rand_index], @"(?<=^(\.|#))([a-z0-9_-]*)", RegexOptions.IgnoreCase).Value != "")
                                {
                                    comment_name = Regex.Match(elements[rand_index], @"(?<=^(\.|#))([a-z0-9_-]*)", RegexOptions.IgnoreCase).Value;
                                    comment_name = comment_name.Substring(0, 1).ToUpper() + comment_name.Remove(0, 1);
                                    elements[rand_index] = "/*" + comment_name + "*/" + "\r\n" + elements[rand_index];
                                    count_comment--;
                                }
                                else
                                {
                                    check--;
                                }
                                break;
                            }
                        case 2:
                            {
                                where_ins = Form1.rnd_org.Next(1, 100);
                                if (where_ins >= 70)
                                {
                                    if (!elements[rand_index].Remove(0, elements[rand_index].IndexOf('{')).Contains("/*") &&
                                        Regex.Match(elements[rand_index], @"(?<=^(\.|#))([a-z0-9_-]*)", RegexOptions.IgnoreCase).Value != "")
                                    {
                                        comment_name = Regex.Match(elements[rand_index], @"(?<=^(\.|#))([a-z0-9_-]*)", RegexOptions.IgnoreCase).Value;
                                        comment_name = comment_name.Substring(0, 1).ToUpper() + comment_name.Remove(0, 1);
                                        elements[rand_index] = "/*" + comment_name + "*/" + "\r\n" + elements[rand_index];
                                        count_comment--;
                                    }
                                    else
                                    {
                                        check--;
                                    }
                                }
                                else
                                {
                                    Match reg = Regex.Match(elements[rand_index], @"(?<={.*(\.|#))([a-z0-9_-]*)(?=.*}.*})", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);

                                    if (!elements[rand_index].Substring(elements[rand_index].IndexOf('{'), elements[rand_index].IndexOf('}') - elements[rand_index].IndexOf('{')).Contains("/*") &&
                                            Regex.Match(elements[rand_index], @"(?<={.*(\.|#))([a-z0-9_-]*)(?=.*}.*})", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline).Value != "")
                                    {
                                        comment_name = Regex.Match(elements[rand_index], @"(?<={.*(\.|#))([a-z0-9_-]*)(?=.*}.*})", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline).Value;
                                        comment_name = comment_name.Substring(0, 1).ToUpper() + comment_name.Remove(0, 1);
                                        elements[rand_index] = elements[rand_index].Substring(0, elements[rand_index].IndexOf('{') + 1) + "\r\n\t/*" + comment_name + "*/" + elements[rand_index].Substring(elements[rand_index].IndexOf('{') + 1, elements[rand_index].Length - 1 - elements[rand_index].IndexOf('{'));
                                        count_comment--;
                                    }
                                    else
                                    {
                                        check--;
                                    }
                                }
                                break;
                            }
                        default:
                            {
                                where_ins = Form1.rnd_org.Next(1, 100);
                                if (where_ins >= 70)
                                {
                                    if (!elements[rand_index].Remove(0, elements[rand_index].IndexOf('{')).Contains("/*") &&
                                        Regex.Match(elements[rand_index], @"(?<=^(\.|#))([a-z0-9_-]*)", RegexOptions.IgnoreCase).Value != "")
                                    {
                                        comment_name = Regex.Match(elements[rand_index], @"(?<=^(\.|#))([a-z0-9_-]*)", RegexOptions.IgnoreCase).Value;
                                        comment_name = comment_name.Substring(0, 1).ToUpper() + comment_name.Remove(0, 1);
                                        elements[rand_index] = "/*" + comment_name + "*/" + "\r\n" + elements[rand_index];
                                        count_comment--;
                                    }
                                    else
                                    {
                                        check--;
                                    }
                                }
                                else
                                {
                                    MatchCollection elements_level1 = Regex.Matches(elements[rand_index], @"^[^{}]*{[^{}]*}", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                                    int rand_elements_level1 = Form1.rnd_org.Next(0, elements_level1.Count - 1);
                                    temp_elements_all = "";
                                    for (int i = 0; i < elements_level1.Count; i++)
                                    {
                                        Match aaa = Regex.Match(elements_level1[i].Value.ToString(), @"(?<=(\.|#))([a-z0-9_-]*)", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                                        if (i == rand_elements_level1 &&
                                            !elements_level1[i].Value.Contains("/*") &&
                                            Regex.Match(elements_level1[i].Value, @"(?<=(\.|#))([a-z0-9_-]*)", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline).Value != "")
                                        {
                                            comment_name = Regex.Match(elements_level1[i].Value, @"(?<=(\.|#))([a-z0-9_-]*)", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline).Value;
                                            comment_name = comment_name.Substring(0, 1).ToUpper() + comment_name.Remove(0, 1);
                                            temp_elements_all += "\r\n\t/*" + comment_name + "*/" + "\r\n" + elements_level1[i].Value;
                                            count_comment--;
                                        }
                                        else
                                        {
                                            temp_elements_all += "\r\n" + elements_level1[i];
                                            check--;
                                        }
                                    }
                                    elements[rand_index] = elements[rand_index].Substring(0, elements[rand_index].IndexOf('{') + 1) + temp_elements_all + "\r\n}";
                                }
                                break;
                            }
                    }
                }
            }

            for (int i = 0; i < elements.Length; i++)
            {
                temp_css_info += elements[i] + "\r\n";
            }
            css_information = temp_css_info.Remove(temp_css_info.LastIndexOf("\r\n"), temp_css_info.Length - temp_css_info.LastIndexOf("\r\n"));
        }



        public void RandomizationPartsCss()
        {
            string temp_css_info, temp_css_info_l0, temp_css_info_l1, temp_properties;
            MatchCollection elements_level0 = Regex.Matches(css_information, 
                                                     @"(\[FIXED_AREA\].*?\[\/FIXED_AREA\])
                                                     |                                                     
                                                     (^[^{}]*{
                                                                ([^{}]*{[^{}]*})*?
                                                     [^{}]*})", 
                                                     RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Multiline);


            if (elements_level0[0].ToString().Contains("[FIXED_AREA]"))
            {
                temp_css_info = elements_level0[0].ToString() + "\r\n";
            }
            else
            {
                temp_css_info = "";
            }

            int[] rand_elements_level0 = Form1.rnd_org.Sequence(0, elements_level0.Count - 1);
            for (int i = 0; i < elements_level0.Count; i++)
            {
                temp_css_info_l0 = "";
                if (!elements_level0[rand_elements_level0[i]].ToString().Contains("[FIXED_AREA]"))
                {
                    switch (Regex.Matches(elements_level0[rand_elements_level0[i]].ToString(), @"{").Count)
                    {
                        case 1:
                            {
                                temp_css_info_l0 = "";
                                Match all_properties = Regex.Match(elements_level0[rand_elements_level0[i]].ToString(), @"(?<={)(.*;)(?=.*})", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                                string[] properties = all_properties.Value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                                int[] rand_properties = Form1.rnd_org.Sequence(0, properties.Length - 1);
                                temp_properties = "";
                                for (int p = 0; p < properties.Length; p++)
                                {
                                    temp_properties += properties[rand_properties[p]] + ";";
                                }
                                temp_css_info_l0 += Regex.Match(elements_level0[rand_elements_level0[i]].ToString(), @"^[^{]*{", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline) + temp_properties + "\r\n}";
                                break;
                            }
                        case 2:
                            {
                                temp_css_info_l0 = "";
                                Match all_properties = Regex.Match(elements_level0[rand_elements_level0[i]].ToString(), @"(?<={.*{)(.*;)(?=.*}.*})", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                                string[] properties = all_properties.Value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                                int[] rand_properties = Form1.rnd_org.Sequence(0, properties.Length - 1);
                                temp_properties = "";
                                for (int p = 0; p < properties.Length; p++)
                                {
                                    temp_properties += properties[rand_properties[p]] + ";";
                                }
                                temp_css_info_l0 += Regex.Match(elements_level0[rand_elements_level0[i]].ToString(), @"^[^{]*{([^{]*{)*", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline) + temp_properties + "\r\n\t}\r\n}";
                                break;
                            }
                        default:
                            {
                                temp_css_info_l1 = "";
                                MatchCollection elements_level1 = Regex.Matches(elements_level0[rand_elements_level0[i]].ToString(), @"^[^{}]*{[^{}]*}", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                                int[] rand_elements_level1 = Form1.rnd_org.Sequence(0, elements_level1.Count - 1);
                                for (int j = 0; j < elements_level1.Count; j++)
                                {
                                    temp_css_info_l0 = "";
                                    Match all_properties = Regex.Match(elements_level1[rand_elements_level1[j]].ToString(), @"(?<={)(.*;)(?=.*})", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                                    string[] properties = all_properties.Value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                                    int[] rand_properties = Form1.rnd_org.Sequence(0, properties.Length - 1);
                                    temp_properties = "";
                                    for (int p = 0; p < properties.Length; p++)
                                    {
                                        temp_properties += properties[rand_properties[p]] + ";";
                                    }
                                    temp_css_info_l1 += Regex.Match(elements_level1[rand_elements_level1[j]].ToString(), @"^[^{]*{", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline) + temp_properties + "\r\n\t}\r\n";
                                }
                                temp_css_info_l0 += Regex.Match(elements_level0[rand_elements_level0[i]].ToString(), @"^[^{]*{", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline) + "\r\n" + temp_css_info_l1 + "}";
                                break;
                            }
                    }
                }
                else
                {
                    if (rand_elements_level0[i] != 0)
                    {
                        temp_css_info_l0 = elements_level0[rand_elements_level0[i]].ToString();
                    }
                }
                temp_css_info += temp_css_info_l0 + "\r\n";
            }
            temp_css_info = temp_css_info.Remove(temp_css_info.LastIndexOf("\r\n"), temp_css_info.Length - temp_css_info.LastIndexOf("\r\n"));
            css_information = temp_css_info;
        }



        public void ChoiceColorScheme()
        {
            int rand_index_color_scheme = Form1.rnd_org.Next(0, Form1.color_scheme.Count - 1);
            StringReader strReader = new StringReader(css_information);
            string temp_css_info = "";
            bool flag_fixed_area = true;
            string line = strReader.ReadLine();
            while (line != null)
            {
                if (line == "[FIXED_AREA]" || line == "[/FIXED_AREA]")
                {
                    flag_fixed_area = !flag_fixed_area;
                }
                while (flag_fixed_area && line.Contains("background") && line.Contains("[bg-") && !line.Contains("[FIXED]"))
                {
                    for (int i = 0; i < Form1.color_scheme[rand_index_color_scheme].Length; i++)
                    {
                        line = line.Replace("[bg-" + i.ToString() + "]", Form1.color_scheme[rand_index_color_scheme][i]);
                    }
                    break;
                }
                temp_css_info += line + "\r\n";
                line = strReader.ReadLine();
            }
            css_information = temp_css_info.Remove(temp_css_info.LastIndexOf("\r\n"), temp_css_info.Length - temp_css_info.LastIndexOf("\r\n"));
            strReader.Close();
        }



        public void ContrastTextColor()
        {
            StringReader strReader = new StringReader(css_information);
            string temp_css_info = "";
            int bc1, bc2, bc3;
            bool flag_fixed_area = true;
            string line = strReader.ReadLine();
            while (line != null)
            {
                if (line == "[FIXED_AREA]" || line == "[/FIXED_AREA]")
                {
                    flag_fixed_area = !flag_fixed_area;
                }
                while (flag_fixed_area && (line.Contains("background:") || line.Contains("background-color:")) && !line.Contains("[FIXED]") && !line.Contains("[bg-"))
                {
                    string tabulation = line.Substring(0, line.IndexOf("back"));
                    string bg_color = line.Substring(line.IndexOf('#') + 1, line.IndexOf(';') - line.IndexOf('#') - 1);
                    if (bg_color.Length == 6)
                    {
                        bc1 = Convert.ToInt32(bg_color.Substring(0, 2), 16);
                        bc2 = Convert.ToInt32(bg_color.Substring(2, 2), 16);
                        bc3 = Convert.ToInt32(bg_color.Substring(4, 2), 16);
                        if ((bc1 + bc2 + bc3) / 3 > 127)
                        {
                            line += "\r\n" + tabulation + "color:#000000;";
                        }
                        else
                        {
                            line += "\r\n" + tabulation + "color:#ffffff;";
                        }
                    }
                    else
                    {
                        if (bg_color.Length == 3)
                        {
                            bc1 = Convert.ToInt32(bg_color.Substring(0, 2), 16);
                            bc2 = Convert.ToInt32(bg_color.Substring(2, 1) + bg_color.Substring(0, 1), 16);
                            bc3 = Convert.ToInt32(bg_color.Substring(1, 2), 16);
                            if ((bc1 + bc2 + bc3) / 3 > 127)
                            {
                                line += "\r\n" + tabulation + "color:#000000;";
                            }
                            else
                            {
                                line += "\r\n" + tabulation + "color:#ffffff;";
                            }
                        }
                        else
                        {
                            line += "\r\n" + tabulation + "color:#000000;";
                        }
                    } 
                    break;
                }
                temp_css_info += line + "\r\n";
                line = strReader.ReadLine();
            }
            css_information = temp_css_info.Remove(temp_css_info.LastIndexOf("\r\n"), temp_css_info.Length - temp_css_info.LastIndexOf("\r\n"));
            strReader.Close();
        }



        public void SelectFontSet()
        {
            int rand_index_fonts = Form1.rnd_org.Next(0, Form1.fonts.Count - 1);
            StringReader strReader = new StringReader(css_information);
            string temp_css_info = "";
            bool flag_fixed_area = true;
            string line = strReader.ReadLine();
            while (line != null)
            {
                if (line == "[FIXED_AREA]" || line == "[/FIXED_AREA]")
                {
                    flag_fixed_area = !flag_fixed_area;
                }
                while (flag_fixed_area && line.Contains("[font-") && !line.Contains("[FIXED]"))
                {
                    for (int i = 0; i < Form1.fonts[rand_index_fonts].Length; i++)
                    {
                        line = line.Replace("[font-" + i.ToString() + "]", Form1.fonts[rand_index_fonts][i]);
                    }
                    break;
                }
                temp_css_info += line + "\r\n";
                line = strReader.ReadLine();
            }
            css_information = temp_css_info.Remove(temp_css_info.LastIndexOf("\r\n"), temp_css_info.Length - temp_css_info.LastIndexOf("\r\n"));
            strReader.Close();
        }



        public void RandVerticalMarginPadding(int probability_min, int probability_max, int percent_changes)
        {
            StringReader strReader = new StringReader(css_information);
            string temp_css_info = "";
            bool flag_fixed_area = true;
            int count_indent, indent_changes;
            double ident, top_indent, bottom_indent, indent_changes_level;
            int probability_change, probability, probability_more_less;
            MatchCollection  match_indent;

            string line = strReader.ReadLine();
            while (line != null)
            {
                if (line == "[FIXED_AREA]" || line == "[/FIXED_AREA]")
                {
                    flag_fixed_area = !flag_fixed_area;
                }
                while (flag_fixed_area && (line.Contains("margin") || line.Contains("padding")) && !line.Contains("[FIXED]"))
                {
                    if (line.Contains("margin-bottom") || line.Contains("margin-top") || line.Contains("padding-bottom") || line.Contains("padding-top"))
                    {
                        if (double.TryParse(Regex.Match(line, @"-?[0-9]+\.?[0-9]+").Value, out ident) && ident > 0)
                        {
                            probability_change = Form1.rnd_org.Next(probability_min, probability_max);
                            probability = Form1.rnd_org.Next(1, 100);
                            if (probability < probability_change)
                            {
                                probability_more_less = Form1.rnd_org.Next(-100, 100);
                                if (probability_more_less >= 0)
                                {
                                    indent_changes_level = Math.Ceiling((100 + (double)percent_changes) * (double)ident / 100);
                                    indent_changes = Form1.rnd_org.Next((int)Math.Ceiling(ident), (int)indent_changes_level);
                                    line = line.Replace(ident.ToString(), indent_changes.ToString());
                                }
                                else
                                {
                                    indent_changes_level = Math.Ceiling((100 - (double)percent_changes) * (double)ident / 100);
                                    if ((int)indent_changes_level < 0)
                                    {
                                        indent_changes = Form1.rnd_org.Next(0, (int)Math.Ceiling(ident));
                                    }
                                    else
                                    {
                                        indent_changes = Form1.rnd_org.Next((int)indent_changes_level, (int)Math.Ceiling(ident));
                                    }
                                    line = line.Replace(ident.ToString(), indent_changes.ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        match_indent = Regex.Matches(line, @"(auto)|(-?[0-9]+\.?[0-9]+)");
                        count_indent = match_indent.Count;
                        switch (count_indent)
                        {
                            case 1: case 2:
                                {
                                    if (double.TryParse(match_indent[0].Value, out ident) && (ident > 0))
                                    {
                                        probability_change = Form1.rnd_org.Next(probability_min, probability_max);
                                        probability = Form1.rnd_org.Next(1, 100);
                                        if (probability < probability_change)
                                        {
                                            probability_more_less = Form1.rnd_org.Next(-100, 100);
                                            if (probability_more_less >= 0)
                                            {
                                                indent_changes_level = Math.Ceiling((100 + (double)percent_changes) * (double)ident / 100);
                                                indent_changes = Form1.rnd_org.Next((int)Math.Ceiling(ident), (int)indent_changes_level);
                                                line = line.Replace(ident.ToString(), indent_changes.ToString());
                                            }
                                            else
                                            {
                                                indent_changes_level = Math.Ceiling((100 - (double)percent_changes) * (double)ident / 100);
                                                if ((int)indent_changes_level < 0)
                                                {
                                                    indent_changes = Form1.rnd_org.Next(0, (int)Math.Ceiling(ident));
                                                }
                                                else
                                                {
                                                    indent_changes = Form1.rnd_org.Next((int)indent_changes_level, (int)Math.Ceiling(ident));
                                                }
                                                line = line.Replace(ident.ToString(), indent_changes.ToString());
                                            }
                                        }
                                    }
                                    break;
                                }
                            case 3: case 4:
                                {
                                    probability_change = Form1.rnd_org.Next(probability_min, probability_max);
                                    probability = Form1.rnd_org.Next(1, 100);
                                    probability_more_less = Form1.rnd_org.Next(-100, 100);
                                    if (probability < probability_change)
                                    {
                                        if (double.TryParse(match_indent[0].Value, out top_indent) && (top_indent > 0))
                                        {
                                            if (probability_more_less >= 0)
                                            {
                                                indent_changes_level = Math.Ceiling((100 + (double)percent_changes) * (double)top_indent / 100);
                                                indent_changes = Form1.rnd_org.Next((int)Math.Ceiling(top_indent), (int)indent_changes_level);
                                                line = line.Replace(top_indent.ToString(), indent_changes.ToString());
                                            }
                                            else
                                            {
                                                indent_changes_level = Math.Ceiling((100 - (double)percent_changes) * (double)top_indent / 100);
                                                if ((int)indent_changes_level < 0)
                                                {
                                                    indent_changes = Form1.rnd_org.Next(0, (int)Math.Ceiling(top_indent));
                                                }
                                                else
                                                {
                                                    indent_changes = Form1.rnd_org.Next((int)indent_changes_level, (int)Math.Ceiling(top_indent));
                                                }
                                                line = line.Replace(top_indent.ToString(), indent_changes.ToString());
                                            }
                                        }
                                        if (double.TryParse(match_indent[2].Value, out bottom_indent) && (bottom_indent > 0))
                                        {
                                            if (probability_more_less >= 0)
                                            {
                                                indent_changes_level = Math.Ceiling((100 + (double)percent_changes) * (double)bottom_indent / 100);
                                                indent_changes = Form1.rnd_org.Next((int)Math.Ceiling(bottom_indent), (int)indent_changes_level);
                                                line = line.Replace(bottom_indent.ToString(), indent_changes.ToString());
                                            }
                                            else
                                            {
                                                indent_changes_level = Math.Ceiling((100 - (double)percent_changes) * (double)bottom_indent / 100);
                                                if ((int)indent_changes_level < 0)
                                                {
                                                    indent_changes = Form1.rnd_org.Next(0, (int)Math.Ceiling(bottom_indent));
                                                }
                                                else
                                                {
                                                    indent_changes = Form1.rnd_org.Next((int)indent_changes_level, (int)Math.Ceiling(bottom_indent));
                                                }
                                                line = line.Replace(bottom_indent.ToString(), indent_changes.ToString());
                                            }
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                    break;
                }
                temp_css_info += line + "\r\n";
                line = strReader.ReadLine();
            }
            css_information = temp_css_info.Remove(temp_css_info.LastIndexOf("\r\n"), temp_css_info.Length - temp_css_info.LastIndexOf("\r\n"));
            strReader.Close();
        }



        public void SaveCsslDoc(string css_path)
        {
            Regex fixe_tag = new Regex(@"\r*\n*\s*\[/?FIXED_AREA\]");
            Regex fixe = new Regex(@"\s*\[FIXED\]\s*");
            css_information = fixe_tag.Replace(css_information, "");
            css_information = fixe.Replace(css_information, "");
            if (css_information.IndexOf("\r\n") == 0)
            {
                css_information = css_information.Remove(css_information.IndexOf("\r\n"), 2);
            }
            File.WriteAllText(css_path, css_information);
        }


        public void BackgroundProcessing()
        {
            StringReader strReader = new StringReader(css_information);
            string temp_css_info = "";
            string standard_color = "";
            byte bc1, bc2, bc3;
            bool flag_fixed_area = true;
            string line = strReader.ReadLine();
            while (line != null)
            {
                if (line == "[FIXED_AREA]" || line == "[/FIXED_AREA]")
                {
                    flag_fixed_area = !flag_fixed_area;
                }
                while (flag_fixed_area && (line.Contains("background:") || line.Contains("background-color:")) && line.Contains("(") && line.Contains(")") && !line.Contains("[FIXED]"))
                {
                    string [] bg_color = line.Substring(line.IndexOf('(') + 1, line.IndexOf(')') - line.IndexOf('(') - 1).Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    bc1 = Convert.ToByte(bg_color[0].Trim(), 10);
                    bc2 = Convert.ToByte(bg_color[1].Trim(), 10);
                    bc3 = Convert.ToByte(bg_color[2].Trim(), 10);
                    standard_color = "#" + bc1.ToString("x2") + bc2.ToString("x2") + bc3.ToString("x2");
                    line = line.Replace(line.Substring(line.IndexOf('('), line.IndexOf(')') - line.IndexOf('(') + 1), standard_color);
                    break;
                }
                temp_css_info += line + "\r\n";
                line = strReader.ReadLine();
            }
            css_information = temp_css_info.Remove(temp_css_info.LastIndexOf("\r\n"), temp_css_info.Length - temp_css_info.LastIndexOf("\r\n"));
            strReader.Close();
        }

        public void DeleteColor()
        {
            string temp_css_info, temp_css_info_l0, temp_css_info_l1;
            Regex color = new Regex(@"\s*[^\w-]color:.*?;", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
            MatchCollection all_elements = Regex.Matches(css_information,
                                                     @"(\[FIXED_AREA\].*?\[\/FIXED_AREA\])
                                                     |                                                     
                                                     ([^{}]*{
                                                                ([^{}]*{[^{}]*})*?
                                                     [^{}]*})",
                                                     RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Multiline);


            temp_css_info = "";
            for (int i = 0; i < all_elements.Count; i++)
            {
                temp_css_info_l0 = "";
                if (!all_elements[i].ToString().Contains("[FIXED_AREA]"))
                {
                    switch (Regex.Matches(all_elements[i].ToString(), @"{").Count)
                    {
                        case 1:
                            {
                                temp_css_info_l0 = all_elements[i].ToString();
                                Match all_properties = Regex.Match(all_elements[i].ToString(), @"(?<={)(.*;)(?=.*})", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                                if (color.IsMatch(all_properties.ToString()) && !all_properties.ToString().Contains("background:") && !all_properties.ToString().Contains("background-color:"))
                                {
                                    temp_css_info_l0 = color.Replace(temp_css_info_l0, "");
                                }
                                break;
                            }
                        case 2:
                            {
                                temp_css_info_l0 = all_elements[i].ToString();
                                Match all_properties = Regex.Match(all_elements[i].ToString(), @"(?<={.*{)(.*;)(?=.*}.*})", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                                if (color.IsMatch(all_properties.ToString()) && !all_properties.ToString().Contains("background:") && !all_properties.ToString().Contains("background-color:"))
                                {
                                    temp_css_info_l0 = color.Replace(temp_css_info_l0, "");
                                }
                                break;
                            }
                        default:
                            {
                                temp_css_info_l1 = "";
                                MatchCollection elements_level1 = Regex.Matches(all_elements[i].ToString(), @"[^{}]*{[^{}]*}", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                                for (int j = 0; j < elements_level1.Count; j++)
                                {
                                    temp_css_info_l1 = elements_level1[j].ToString();
                                    Match all_properties = Regex.Match(elements_level1[j].ToString(), @"(?<={)(.*;)(?=.*})", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                                    if (color.IsMatch(all_properties.ToString()) && !all_properties.ToString().Contains("background:") && !all_properties.ToString().Contains("background-color:"))
                                    {
                                        temp_css_info_l1 = color.Replace(temp_css_info_l1, "");
                                    }
                                    temp_css_info_l0 += temp_css_info_l1;
                                }
                                temp_css_info_l0 = Regex.Match(all_elements[i].ToString(), @"^[^{]*{", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline) + temp_css_info_l0 + Regex.Match(all_elements[i].ToString(), @"\s*}$", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                                break;
                            }
                    }
                }
                else
                {
                    temp_css_info_l0 = all_elements[i].ToString();
                }
                temp_css_info += temp_css_info_l0;
            }
            css_information = temp_css_info;
        }



        public void DeleteEmptyRule()
        {
            string temp_css_info, temp_css_info_l0, temp_css_info_l1;
            Regex rule = new Regex(@"\S*;", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
            MatchCollection all_elements = Regex.Matches(css_information,
                                                     @"(\[FIXED_AREA\].*?\[\/FIXED_AREA\])
                                                     |                                                     
                                                     ([^{}]*{
                                                                ([^{}]*{[^{}]*})*?
                                                     [^{}]*})",
                                                     RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Multiline);


            temp_css_info = "";
            for (int i = 0; i < all_elements.Count; i++)
            {
                temp_css_info_l0 = "";
                if (!all_elements[i].ToString().Contains("[FIXED_AREA]"))
                {
                    switch (Regex.Matches(all_elements[i].ToString(), @"{").Count)
                    {
                        case 1:
                            {
                                Match all_properties = Regex.Match(all_elements[i].ToString(), @"(?<={)(.*;)(?=.*})", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                                if (rule.IsMatch(all_properties.ToString()))
                                {
                                    temp_css_info_l0 = all_elements[i].ToString();
                                }
                                break;
                            }
                        case 2:
                            {
                                Match all_properties = Regex.Match(all_elements[i].ToString(), @"(?<={.*{)(.*;)(?=.*}.*})", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                                if (rule.IsMatch(all_properties.ToString()))
                                {
                                    temp_css_info_l0 = all_elements[i].ToString();
                                }
                                break;
                            }
                        default:
                            {
                                MatchCollection elements_level1 = Regex.Matches(all_elements[i].ToString(), @"[^{}]*{[^{}]*}", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                                for (int j = 0; j < elements_level1.Count; j++)
                                {
                                    temp_css_info_l1 = "";
                                    Match all_properties = Regex.Match(elements_level1[j].ToString(), @"(?<={)(.*;)(?=.*})", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                                    if (rule.IsMatch(all_properties.ToString()))
                                    {
                                        temp_css_info_l1 = elements_level1[j].ToString();
                                    }
                                    temp_css_info_l0 += temp_css_info_l1;
                                }
                                if (temp_css_info_l0 != "")
                                {
                                    temp_css_info_l0 = Regex.Match(all_elements[i].ToString(), @"^[^{]*{", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline) + temp_css_info_l0 + Regex.Match(all_elements[i].ToString(), @"\s*}$", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                                }
                                break;
                            }
                    }
                }
                else
                {
                    temp_css_info_l0 = all_elements[i].ToString();
                }
                temp_css_info += temp_css_info_l0;
            }
            css_information = temp_css_info;
        }


    }
}
