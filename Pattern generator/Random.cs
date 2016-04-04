﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Random.Org
{
    public class Random
    {
        WebClient client = null;
        string format = "http://www.random.org/integers/?num={0}&min={1}&max={2}&col=1&base=10&format=plain&rnd=new";

        /// <summary>
        /// Gets or sets a value that, when false, prevents actually calling Random.org  and generates a local pseudo-random value -- useful for testing offline scenarios 
        /// </summary>
        public bool UseLocalMode { get; set; }
        private System.Random localRandom = new System.Random((int)DateTime.Now.Ticks);
        public int Next(int min, int max)
        {
            if (!UseLocalMode)
            {
                string url = string.Format(format, 1, min, max);
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
                return localRandom.Next(min, max);
            }
        }
    }
}