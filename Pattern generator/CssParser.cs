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

        private string css_information;
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

        public void ParseSelectors()
        {
            //Regex regex = new Regex();
            Match element;
            MatchCollection elements, elements1;
            elements = Regex.Matches(css_information, @"\[FIXED_AREA\](.*)\[/FIXED_AREA\]", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
            elements1 = Regex.Matches(css_information, @"[^{}]*{[^{}]*}", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);

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
            css_information = temp_css_info;
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
                while (flag_fixed_area && (line.Contains("background:") || line.Contains("background-color:")) && !line.Contains("[FIXED]"))
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
            css_information = temp_css_info;
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
            css_information = temp_css_info;
            strReader.Close();
        }


        public void RandVerticalMarginPadding(int probability_min, int probability_max, int percent_changes)
        {
            StringReader strReader = new StringReader(css_information);
            string temp_css_info = "";
            bool flag_fixed_area = true;
            int ident;
            //Regex regex = new Regex();
            Match indent;

            int probability_change = Form1.rnd_org.Next(probability_min, probability_max);
            int probability = Form1.rnd_org.Next(1, 100);

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
                        int.TryParse(Regex.Match(line, @"-?\d+").Value, out ident);
                    }
                    string aaa = Regex.Match(line, @"[auto]?\d+").Value;


                    break;
                }
                temp_css_info += line + "\r\n";
                line = strReader.ReadLine();
            }
            css_information = temp_css_info;
            strReader.Close();
        }



        public void SaveCsslDoc(string css_path)
        {
            File.WriteAllText(css_path, css_information);
        }

    }
}
