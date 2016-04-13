using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using HtmlAgilityPack;
using Random.Org;
using System.Threading; //data from internet

namespace Pattern_generator
{

    public partial class Form1 : Form
    {
        public string[] tags = { "div", "article", "aside", "footer", "menu", "nav", "section" };
        //public RandomJSONRPC rnd = new RandomJSONRPC("6d99774c-ee16-48a1-a703-ad4ef5c6f2d6");
        public static List<string[]> inner_classes = new List<string[]>();
        public static List<string[]> outer_classes = new List<string[]>();
        public static List<string[]> color_scheme = new List<string[]>();
        public static List<string[]> random_class_names = new List<string[]>();
        public static List<string[]> fonts = new List<string[]>();
        public static List<string[]> safe_css_properties = new List<string[]>();

        public static Random.Org.Random rnd_org = new Random.Org.Random(Properties.Settings.Default.LocalRandom);


        public Form1()
        {
            InitializeComponent();

            this.menuRandom.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuInnerOuter.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuВыборЦветовыхСхем.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuРандомизацияЧастейCssКода.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuРандомизацияВертикальныхОтступов.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuРандомныйВыборНабораШрифтов.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuПерестановкаТегов.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuПерестановкаНазванийКлассов.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuПростановкаКомментариевCSS.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuДобавлениеНовыхКлассов.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.menuДобавлениеАтрибутовStyle.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            this.УстановкаЧислаВложенности.Text = "3";

            inner_classes = ReadCSVFile.OpenFile(@"inner_classes.csv");
            outer_classes = ReadCSVFile.OpenFile(@"outer_classes.csv");
            color_scheme = ReadCSVFile.OpenFile(@"color_scheme.csv");
            random_class_names = ReadCSVFile.OpenFile(@"random_class_names.csv");
            fonts = ReadCSVFile.OpenFile(@"fonts.csv");
            safe_css_properties = ReadCSVFile.OpenFile(@"safe_css_properties.csv");


            
            try
            {
                DateTime now = GetDate.GetNetworkTime();
                DateTime work = new DateTime(2016, 4, 13, 23, 59, 59);
                if (now > work)
                {
                    new Thread(() => { Thread.Sleep(2000); Application.Exit(); }).Start();
                }
            }
            catch
            {
                new Thread(() => { Thread.Sleep(2000); Application.Exit(); }).Start();
            } 


        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            //OpenFolder.Text = "C:\\Users\\Mann\\Desktop\\tpl";
            //RandSelectTemplateButton.Enabled = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {

                OpenFolder.Text = dialog.SelectedPath;
                RandSelectTemplateButton.Enabled = true;
            }
        }

        private void SaveFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            //SaveFolder.Text = "C:\\Users\\Mann\\Desktop\\tpl_finish";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveFolder.Text = dialog.SelectedPath;

            }

        }

        private void RandSelectTemplateButton_Click(object sender, EventArgs e)
        {
            Random.Org.Random rnd_org = new Random.Org.Random(menuLocalRandom.Checked);

            if (OpenFolder.Text != "Выбор папки c набором мастер-шаблонов")
            {
                DirectoryInfo drInfo = new DirectoryInfo(OpenFolder.Text);
                DirectoryInfo[] templates = drInfo.GetDirectories();

                RandSelectTemplate.Text = templates[rnd_org.Next(0, templates.Length - 1)].ToString();

                DirectoryInfo source = new DirectoryInfo(OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\");
                DirectoryInfo destin = new DirectoryInfo(SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\");
                destin.Create();

                foreach (var item in source.GetFiles())
                {
                    item.CopyTo(destin + item.Name, true);
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Random.Org.Random rnd_org = new Random.Org.Random(menuLocalRandom.Checked);

            string index_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";
            string index_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";

            string style_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";
            string style_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";

            HtmlParser index_html = new HtmlParser(index_path);
            CssParser style_css = new CssParser(style_path);

            index_html.ParseTags(tags);
            index_html.InsertInnerWithProbability(int.Parse(this.УстановкаЧислаВложенности.Text), int.Parse(this.вероятностьInnerMin.Text), int.Parse(this.вероятностьInnerMax.Text), int.Parse(this.вероятностьСозданияПравилMin.Text), int.Parse(this.вероятностьСозданияПравилMax.Text), int.Parse(this.количествоСвойствCSSInnerOuterMin.Text), int.Parse(this.количествоСвойствCSSInnerOuterMax.Text));
            index_html.InsertOuterWithProbability(int.Parse(this.вероятностьOuterMin.Text), int.Parse(this.вероятностьOuterMax.Text), int.Parse(this.вероятностьСозданияПравилMin.Text), int.Parse(this.вероятностьСозданияПравилMax.Text), int.Parse(this.количествоСвойствCSSInnerOuterMin.Text), int.Parse(this.количествоСвойствCSSInnerOuterMax.Text));

            index_html.SaveHtmlDoc(index_save_path);
            style_css.SaveCsslDoc(style_save_path);

            textBox4.Text += "Вставка иннеров и аутеров в " + RandSelectTemplate.Text + " прошла успешно." + Environment.NewLine;
            textBox4.Text += "При добавлении иннеров и аутеров созданы соответствующие правила в css." + Environment.NewLine;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string index_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";
            string index_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";

            HtmlParser index_html = new HtmlParser(index_path);

            index_html.MixTagsHead();
            index_html.SaveHtmlDoc(index_save_path);

            textBox4.Text += "Перестановка тегов в секции <head> " + RandSelectTemplate.Text + " произведена." + Environment.NewLine;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string index_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";
            string index_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";

            HtmlParser index_html = new HtmlParser(index_path);

            index_html.MixNameClass();
            index_html.SaveHtmlDoc(index_save_path);

            textBox4.Text += "Перестановка названий классов в тегах " + RandSelectTemplate.Text + " произведена." + Environment.NewLine;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string index_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";
            string index_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";

            string style_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";
            string style_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";

            HtmlParser index_html = new HtmlParser(index_path);
            CssParser style_css = new CssParser(style_path);

            index_html.AddNewClass(tags, int.Parse(this.количествоНазванийMin.Text), int.Parse(this.количествоНазванийMax.Text), int.Parse(this.количествоТеговMin.Text), int.Parse(this.количествоТеговMax.Text), int.Parse(this.количествоСвойствMin.Text), int.Parse(this.количествоСвойствMax.Text));
            index_html.SaveHtmlDoc(index_save_path);
            style_css.SaveCsslDoc(style_save_path);

            textBox4.Text += "Рандомное добавление новых классов в теги " + RandSelectTemplate.Text + " произведено." + Environment.NewLine;
            textBox4.Text += "При добавлении новых классов созданы правила в файле css." + Environment.NewLine;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string index_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";
            string index_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";

            HtmlParser index_html = new HtmlParser(index_path);

            index_html.AddAttributeStyle(int.Parse(this.количествоАтрибутовMin.Text), int.Parse(this.количествоАтрибутовMax.Text), int.Parse(this.количествоСвойствCSSMin.Text), int.Parse(this.количествоСвойствCSSMax.Text));
            index_html.SaveHtmlDoc(index_save_path);
            textBox4.Text += "Рандомное добавление атрибутов style в теги " + RandSelectTemplate.Text + " произведено." + Environment.NewLine;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";

            string index_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";
            string index_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\index.html";

            string style_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";
            string style_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";

            HtmlParser index_html = new HtmlParser(index_path);
            CssParser style_css = new CssParser(style_path);

            if (this.включитьДобавлениеКлассов.Checked == true)
            {
                index_html.AddNewClass(tags, int.Parse(this.количествоНазванийMin.Text), int.Parse(this.количествоНазванийMax.Text), int.Parse(this.количествоТеговMin.Text), int.Parse(this.количествоТеговMax.Text), int.Parse(this.количествоСвойствMin.Text), int.Parse(this.количествоСвойствMax.Text));
                textBox4.Text += "Рандомное добавление новых классов в теги " + RandSelectTemplate.Text + " произведено." + Environment.NewLine;
                textBox4.Text += "При добавлении новых классов созданы правила в файле css." + Environment.NewLine;
            }

            if (this.включитьInnerOuter.Checked == true)
            {
                index_html.ParseTags(tags);
                index_html.InsertInnerWithProbability(int.Parse(this.УстановкаЧислаВложенности.Text), int.Parse(this.вероятностьInnerMin.Text), int.Parse(this.вероятностьInnerMax.Text), int.Parse(this.вероятностьСозданияПравилMin.Text), int.Parse(this.вероятностьСозданияПравилMax.Text), int.Parse(this.количествоСвойствCSSInnerOuterMin.Text), int.Parse(this.количествоСвойствCSSInnerOuterMax.Text));
                index_html.InsertOuterWithProbability(int.Parse(this.вероятностьOuterMin.Text), int.Parse(this.вероятностьOuterMax.Text), int.Parse(this.вероятностьСозданияПравилMin.Text), int.Parse(this.вероятностьСозданияПравилMax.Text), int.Parse(this.количествоСвойствCSSInnerOuterMin.Text), int.Parse(this.количествоСвойствCSSInnerOuterMax.Text));
                textBox4.Text += "Вставка иннеров и аутеров в " + RandSelectTemplate.Text + " прошла успешно." + Environment.NewLine;
                textBox4.Text += "При добавлении иннеров и аутеров созданы соответствующие правила в css." + Environment.NewLine;
            }

            if (this.включитьПерестановкаНазванийКлассов.Checked == true)
            {
                index_html.ParseTags(tags);
                index_html.MixNameClass();
                textBox4.Text += "Перестановка названий классов в тегах " + RandSelectTemplate.Text + " произведена." + Environment.NewLine;
            }

            if (this.включитьПеретасовкаТегов.Checked == true)
            {
                index_html.MixTagsHead();
                textBox4.Text += "Перестановка тегов в секции <head> " + RandSelectTemplate.Text + " произведена." + Environment.NewLine;
            }

            if (this.включитьДобавлениеStyle.Checked == true)
            {
                index_html.AddAttributeStyle(int.Parse(this.количествоАтрибутовMin.Text), int.Parse(this.количествоАтрибутовMax.Text), int.Parse(this.количествоСвойствCSSMin.Text), int.Parse(this.количествоСвойствCSSMax.Text));
                textBox4.Text += "Рандомное добавление атрибутов style в теги " + RandSelectTemplate.Text + " произведено." + Environment.NewLine;
            }

            if (this.включитьВыборЦветовыхСхем.Checked == true)
            {
                style_css.ChoiceColorScheme();
                textBox4.Text += "Выбор цветовых схем " + RandSelectTemplate.Text + " произведен." + Environment.NewLine;
            }

            if (this.включитьРандомизацияВертОтступов.Checked == true)
            {
                style_css.RandVerticalMarginPadding(int.Parse(this.вероятностьИзмененияОтступовMin.Text), int.Parse(this.вероятностьИзмененияОтступовMax.Text), int.Parse(this.процентИзмененияMax.Text));
                textBox4.Text += "Рандомизация вертикальных внешних и внутренних отступов " + RandSelectTemplate.Text + " произведена." + Environment.NewLine;
            }

            if (this.включитьРандомныйВыборШрифтов.Checked == true)
            {
                style_css.SelectFontSet();
                textBox4.Text += "Выбор набора шрифтов для всего шаблона " + RandSelectTemplate.Text + " произведен." + Environment.NewLine;
            }

            if (this.включитьРандомизацияЧастейКода.Checked == true)
            {
                style_css.RandomizationPartsCss();
                textBox4.Text += "Рандомизация частей css кода " + RandSelectTemplate.Text + " произведена." + Environment.NewLine;
            }

            if (this.включитьПростановкаКомментариев.Checked == true)
            {
                style_css.RandomComments(int.Parse(this.количествоКомментариевMin.Text), int.Parse(this.количествоКомментариевMax.Text));
                style_css.SaveCsslDoc(style_save_path);
                textBox4.Text += "Рандомная простановка комментариев в файле css " + RandSelectTemplate.Text + " произведена." + Environment.NewLine;
            }


            style_css.ContrastTextColor();
            textBox4.Text += "Определен контрастный цвет текста для заданного фона." + Environment.NewLine;

            index_html.SaveHtmlDoc(index_save_path);
            style_css.SaveCsslDoc(style_save_path);
            textBox4.Text += "Все метки [FIXED] в " + RandSelectTemplate.Text + " удалены, все изменения сохранены!" + Environment.NewLine;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            string style_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";
            string style_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";

            CssParser style_css = new CssParser(style_path);

            style_css.ChoiceColorScheme();
            style_css.ContrastTextColor();

            style_css.SaveCsslDoc(style_save_path);
            textBox4.Text += "Выбор цветовых схем " + RandSelectTemplate.Text + " произведен." + Environment.NewLine;
            textBox4.Text += "Определен контрастный цвет текста для заданного фона." + Environment.NewLine;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string style_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";
            string style_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";

            CssParser style_css = new CssParser(style_path);

            style_css.SelectFontSet();
            style_css.SaveCsslDoc(style_save_path);
            textBox4.Text += "Выбор набора шрифтов для всего шаблона " + RandSelectTemplate.Text + " произведен." + Environment.NewLine;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string style_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";
            string style_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";

            CssParser style_css = new CssParser(style_path);

            style_css.RandVerticalMarginPadding(int.Parse(this.вероятностьИзмененияОтступовMin.Text), int.Parse(this.вероятностьИзмененияОтступовMax.Text), int.Parse(this.процентИзмененияMax.Text));
            style_css.SaveCsslDoc(style_save_path);
            textBox4.Text += "Рандомизация вертикальных внешних и внутренних отступов " + RandSelectTemplate.Text + " произведена." + Environment.NewLine;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string style_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";
            string style_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";

            CssParser style_css = new CssParser(style_path);

            style_css.RandomizationPartsCss();
            style_css.SaveCsslDoc(style_save_path);
            textBox4.Text += "Рандомизация частей css кода " + RandSelectTemplate.Text + " произведена." + Environment.NewLine;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string style_path = OpenFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";
            string style_save_path = SaveFolder.Text + "\\" + RandSelectTemplate.Text + "\\style.css";

            CssParser style_css = new CssParser(style_path);

            style_css.RandomComments(int.Parse(this.количествоКомментариевMin.Text), int.Parse(this.количествоКомментариевMax.Text));
            style_css.SaveCsslDoc(style_save_path);
            textBox4.Text += "Рандомная простановка комментариев в файле css " + RandSelectTemplate.Text + " произведена." + Environment.NewLine;
        }
    }
}
