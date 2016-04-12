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
        private string[] css_information_array;
        private struct SelectorsInformation
        {
            public string name;
            public string tags_name_for_outer;
            public string xpath_instruction;
        }
        private SelectorsInformation selector_info;
        private List<SelectorsInformation> TagsList = new List<SelectorsInformation>();

        public CssParser(string css_path)
        {
            css_information = File.ReadAllText(css_path);
            css_information_array = File.ReadAllLines(css_path);
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

        public void ParseSelectors()
        {
            //Regex regex = new Regex();
            Match element;
            MatchCollection elements, elements1;
            elements = Regex.Matches(css_information, @"\[FIXED_AREA\](.*)\[/FIXED_AREA\]", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
            while (true)
            {
                elements1 = Regex.Matches(css_information, @"[^{}]*{
                                                                    ([^{}]*{[^{}]*})*?
                                                             [^{}]*}", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace); // RegexOptions.Singleline | RegexOptions.Multiline);
            }
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
                    string bg_color = line.Substring(line.IndexOf('#') + 1, line.IndexOf(';') - line.IndexOf('#'));
                    int bc1 = Convert.ToInt32(bg_color.Substring(0, 2), 16);
                    int bc2 = Convert.ToInt32(bg_color.Substring(2, 2), 16);
                    int bc3 = Convert.ToInt32(bg_color.Substring(4, 2), 16);
                    if ((bc1 + bc2 + bc3) / 3 > 127)
                    {
                        line += "\r\n" + tabulation + "color:#000000;";
                    }
                    else
                    {
                        line += "\r\n" + tabulation + "color:#ffffff;";
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
            int ident, top_indent, bottom_indent, count_indent, indent_changes;
            double indent_changes_level;
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
                    //string indent_property = line.Substring((line.IndexOf("margin") | line.IndexOf("padding")), line.IndexOf(":") - 1);
                    //string[] bg_color = line.Substring(line.IndexOf('#') + 1, line.IndexOf(';') - line.IndexOf('#'));
                    //string indent_numbers = line.Substring(line.IndexOf(":"), line.IndexOf(";") - 1);
                    //string[] indent_definition = indent_numbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (line.Contains("margin-bottom") || line.Contains("margin-top") || line.Contains("padding-bottom") || line.Contains("padding-top"))
                    {
                        if (int.TryParse(Regex.Match(line, @"-?\d+").Value, out ident) && ident > 0)
                        {
                            probability_change = Form1.rnd_org.Next(probability_min, probability_max);
                            probability = Form1.rnd_org.Next(1, 100);
                            if (probability < probability_change)
                            {
                                probability_more_less = Form1.rnd_org.Next(-100, 100);
                                if (probability_more_less >= 0)
                                {
                                    indent_changes_level = Math.Ceiling((100 + (double)percent_changes) * (double)ident / 100);
                                    indent_changes = Form1.rnd_org.Next(ident, (int)indent_changes_level);
                                    line = line.Replace(ident.ToString(), indent_changes.ToString());
                                }
                                else
                                {
                                    indent_changes_level = Math.Ceiling((100 - (double)percent_changes) * (double)ident / 100);
                                    if ((int)indent_changes_level < 0)
                                    {
                                        indent_changes = Form1.rnd_org.Next(0, ident);
                                    }
                                    else
                                    {
                                        indent_changes = Form1.rnd_org.Next((int)indent_changes_level, ident);
                                    }
                                    line = line.Replace(ident.ToString(), indent_changes.ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        match_indent = Regex.Matches(line, @"(auto)|(-?\d+)");
                        count_indent = match_indent.Count;
                        switch (count_indent)
                        {
                            case 1: case 2:
                                {
                                    if (int.TryParse(match_indent[0].Value, out ident) && (ident > 0))
                                    {
                                        probability_change = Form1.rnd_org.Next(probability_min, probability_max);
                                        probability = Form1.rnd_org.Next(1, 100);
                                        if (probability < probability_change)
                                        {
                                            probability_more_less = Form1.rnd_org.Next(-100, 100);
                                            if (probability_more_less >= 0)
                                            {
                                                indent_changes_level = Math.Ceiling((100 + (double)percent_changes) * (double)ident / 100);
                                                indent_changes = Form1.rnd_org.Next(ident, (int)indent_changes_level);
                                                line = line.Replace(ident.ToString(), indent_changes.ToString());
                                            }
                                            else
                                            {
                                                indent_changes_level = Math.Ceiling((100 - (double)percent_changes) * (double)ident / 100);
                                                if ((int)indent_changes_level < 0)
                                                {
                                                    indent_changes = Form1.rnd_org.Next(0, ident);
                                                }
                                                else
                                                {
                                                    indent_changes = Form1.rnd_org.Next((int)indent_changes_level, ident);
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
                                        if (int.TryParse(match_indent[0].Value, out top_indent) && (top_indent > 0))
                                        {
                                            if (probability_more_less >= 0)
                                            {
                                                indent_changes_level = Math.Ceiling((100 + (double)percent_changes) * (double)top_indent / 100);
                                                indent_changes = Form1.rnd_org.Next(top_indent, (int)indent_changes_level);
                                                line = line.Replace(top_indent.ToString(), indent_changes.ToString());
                                            }
                                            else
                                            {
                                                indent_changes_level = Math.Ceiling((100 - (double)percent_changes) * (double)top_indent / 100);
                                                if ((int)indent_changes_level < 0)
                                                {
                                                    indent_changes = Form1.rnd_org.Next(0, top_indent);
                                                }
                                                else
                                                {
                                                    indent_changes = Form1.rnd_org.Next((int)indent_changes_level, top_indent);
                                                }
                                                line = line.Replace(top_indent.ToString(), indent_changes.ToString());
                                            }
                                        }
                                        if (int.TryParse(match_indent[2].Value, out bottom_indent) && (bottom_indent > 0))
                                        {
                                            if (probability_more_less >= 0)
                                            {
                                                indent_changes_level = Math.Ceiling((100 + (double)percent_changes) * (double)bottom_indent / 100);
                                                indent_changes = Form1.rnd_org.Next(bottom_indent, (int)indent_changes_level);
                                                line = line.Replace(bottom_indent.ToString(), indent_changes.ToString());
                                            }
                                            else
                                            {
                                                indent_changes_level = Math.Ceiling((100 - (double)percent_changes) * (double)bottom_indent / 100);
                                                if ((int)indent_changes_level < 0)
                                                {
                                                    indent_changes = Form1.rnd_org.Next(0, bottom_indent);
                                                }
                                                else
                                                {
                                                    indent_changes = Form1.rnd_org.Next((int)indent_changes_level, bottom_indent);
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

    }
}
