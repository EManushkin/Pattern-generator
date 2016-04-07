using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Random.Org
{
    public class Random
    {
        private System.Random localRandom = new System.Random((int)DateTime.Now.Ticks);
        private bool UseLocalMode;
        WebClient client = null;
        string Integer_Generator = "http://www.random.org/integers/?num={0}&min={1}&max={2}&col=1&base=10&format=plain&rnd=new";
        string Sequence_Generator = "http://www.random.org/sequences/?min={0}&max={1}&col=1&format=plain&rnd=new";

        /// <summary>
        /// Use Local Random or Random.Org. When "true" use Local Random, generates a local pseudo-random value -- useful for testing offline scenarios 
        /// </summary>
        public Random(bool UseLocalMode)
        {
            this.UseLocalMode = UseLocalMode;
        }

        public int Next(int min, int max)
        {
            if (!UseLocalMode)
            {
                string url = string.Format(Integer_Generator, 1, min, max);
                client = new WebClient();
                client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.110 Safari/537.36"); // !!! без этой строки не работает
                string txt = client.DownloadString(url);

                if (string.IsNullOrEmpty(txt))
                {
                    throw new Exception("No response from random.org");
                }

                int value = -1;
                if (int.TryParse(txt, out value))
                {
                    return value;
                }
                else
                {
                    throw new ArgumentException("The value returned from random.org was not properly formatted");
                }
            }
            else
            {
                return localRandom.Next(min, max + 1);
            }
        }

        public int[] Sequence(int min, int max)
        {
            int[] value = new int [max-min+1];
            if (!UseLocalMode)
            {
                string url = string.Format(Sequence_Generator, min, max);
                client = new WebClient();
                client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.110 Safari/537.36"); // !!! без этой строки не работает
                string txt = client.DownloadString(url);

                if (string.IsNullOrEmpty(txt))
                {
                    throw new Exception("No response from random.org");
                }

                value = Array.ConvertAll(txt.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);

                return value;
            }
            else
            {
                for (int i = min; i <= max; i++)
                {
                    value[i] = i;
                }
                return value = value.OrderBy(x => localRandom.Next()).ToArray();
            }
        }

    }
}