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
using System.IO;

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
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.SelectedPath;
            }

            //int [] ar = new int[1];
            //ar = rnd2.GenerateIntegers(1, 0, 10000);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Выбор папки c набором мастер-шаблонов")
            {
                DirectoryInfo drInfo = new DirectoryInfo(textBox1.Text);
                DirectoryInfo[] templates = drInfo.GetDirectories();
                RandomJSONRPC rnd = new RandomJSONRPC("6d99774c-ee16-48a1-a703-ad4ef5c6f2d6");
                int [] n_a = rnd.GenerateIntegers(1, 0, templates.Length-1);
                int n = n_a[0];
                textBox2.Text = "Выбран мастер-шаблон: " + templates[n].ToString();

            }
        }

    }
}
