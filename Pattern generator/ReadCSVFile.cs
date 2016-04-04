using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pattern_generator
{
    public static class ReadCSVFile
    {
        private static string[] array_to_split;
        private static List<string[]> list_of_value = new List<string[]>();

        public static List<string[]> OpenFile(string csv_path)
        {
            array_to_split = File.ReadAllLines(csv_path);
            for (int i = 0; i < array_to_split.Length; i++)
            {
                if (!String.IsNullOrEmpty(array_to_split[i]))
                {
                    list_of_value.Add(array_to_split[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
                }
            }
            return list_of_value;
        }
    }
}
