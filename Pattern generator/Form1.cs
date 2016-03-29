using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.random.JSONRPC;

namespace Pattern_generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd1 = new Random();
            textBox1.Text = rnd1.Next(0, 10000).ToString();

            RandomJSONRPC rnd2 = new RandomJSONRPC("6d99774c-ee16-48a1-a703-ad4ef5c6f2d6");
            int [] ar = new int[1];
            ar = rnd2.GenerateIntegers(1, 0, 10000);
            textBox2.Text = ar[0].ToString();
        }
    }
}
