﻿using System;
using System.Windows.Forms;

namespace Pattern_generator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.OpenFolderButton = new System.Windows.Forms.Button();
            this.OpenFolder = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.RandSelectTemplateButton = new System.Windows.Forms.Button();
            this.RandSelectTemplate = new System.Windows.Forms.TextBox();
            this.SaveFolderButton = new System.Windows.Forms.Button();
            this.SaveFolder = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRandom = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLocalRandom = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRandomOrg = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInnerOuter = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьInnerOuter = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьInnerOuter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.вложенностьInner = new System.Windows.Forms.ToolStripMenuItem();
            this.УстановкаЧислаВложенности = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.вероятностьВставкиInner = new System.Windows.Forms.ToolStripMenuItem();
            this.вероятностьInnerMin = new System.Windows.Forms.ToolStripTextBox();
            this.вероятностьInnerMax = new System.Windows.Forms.ToolStripTextBox();
            this.вероятностьВставкиOuter = new System.Windows.Forms.ToolStripMenuItem();
            this.вероятностьOuterMin = new System.Windows.Forms.ToolStripTextBox();
            this.вероятностьOuterMax = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.вероятностьСозданияОтдельныхCssПравил = new System.Windows.Forms.ToolStripMenuItem();
            this.вероятностьСозданияПравилMin = new System.Windows.Forms.ToolStripTextBox();
            this.вероятностьСозданияПравилMax = new System.Windows.Forms.ToolStripTextBox();
            this.количествоБезопасныхСвойствCSSInnerOuter = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоСвойствCSSInnerOuterMin = new System.Windows.Forms.ToolStripTextBox();
            this.количествоСвойствCSSInnerOuterMax = new System.Windows.Forms.ToolStripTextBox();
            this.menuВыборЦветовыхСхем = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьВыборЦветовыхСхем = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьВыборЦветовыхСхем = new System.Windows.Forms.ToolStripMenuItem();
            this.menuРандомизацияЧастейCssКода = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьРандомизацияЧастейКода = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьРандомизацияЧастейКода = new System.Windows.Forms.ToolStripMenuItem();
            this.menuРандомизацияВертикальныхОтступов = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьРандомизацияВертОтступов = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьРандомизацияВертОтступов = new System.Windows.Forms.ToolStripMenuItem();
            this.вероятностьИзмененияОтступов = new System.Windows.Forms.ToolStripMenuItem();
            this.вероятностьИзмененияОтступовMin = new System.Windows.Forms.ToolStripTextBox();
            this.вероятностьИзмененияОтступовMax = new System.Windows.Forms.ToolStripTextBox();
            this.максимальныйПроцентИзменения = new System.Windows.Forms.ToolStripMenuItem();
            this.процентИзмененияMax = new System.Windows.Forms.ToolStripTextBox();
            this.menuРандомныйВыборНабораШрифтов = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьРандомныйВыборШрифтов = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьРандомныйВыборШрифтов = new System.Windows.Forms.ToolStripMenuItem();
            this.menuПерестановкаТегов = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьПеретасовкаТегов = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьПеретасовкаТегов = new System.Windows.Forms.ToolStripMenuItem();
            this.menuПерестановкаНазванийКлассов = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьПерестановкаНазванийКлассов = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьПерестановкаНазванийКлассов = new System.Windows.Forms.ToolStripMenuItem();
            this.menuПростановкаКомментариевCSS = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьПростановкаКомментариев = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьПростановкаКомментариев = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоКомментариевНаФайл = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоКомментариевMin = new System.Windows.Forms.ToolStripTextBox();
            this.количествоКомментариевMax = new System.Windows.Forms.ToolStripTextBox();
            this.menuДобавлениеНовыхКлассов = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьДобавлениеКлассов = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьДобавлениеКлассов = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоВзятыхНазванийКлассов = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоНазванийMin = new System.Windows.Forms.ToolStripTextBox();
            this.количествоНазванийMax = new System.Windows.Forms.ToolStripTextBox();
            this.количествоТеговДляНазванияКласса = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоТеговMin = new System.Windows.Forms.ToolStripTextBox();
            this.количествоТеговMax = new System.Windows.Forms.ToolStripTextBox();
            this.количествоБезопасныхСвойствCSS = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоСвойствMin = new System.Windows.Forms.ToolStripTextBox();
            this.количествоСвойствMax = new System.Windows.Forms.ToolStripTextBox();
            this.menuДобавлениеАтрибутовStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьДобавлениеStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьДобавлениеStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоАтрибутовНаШаблон = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоАтрибутовMin = new System.Windows.Forms.ToolStripTextBox();
            this.количествоАтрибутовMax = new System.Windows.Forms.ToolStripTextBox();
            this.количествоБезопасныхСвойствCSSStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоСвойствCSSMin = new System.Windows.Forms.ToolStripTextBox();
            this.количествоСвойствCSSMax = new System.Windows.Forms.ToolStripTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFolderButton
            // 
            this.OpenFolderButton.BackgroundImage = global::Pattern_generator.Properties.Resources.folder;
            this.OpenFolderButton.Location = new System.Drawing.Point(29, 30);
            this.OpenFolderButton.Name = "OpenFolderButton";
            this.OpenFolderButton.Size = new System.Drawing.Size(23, 35);
            this.OpenFolderButton.TabIndex = 1;
            this.OpenFolderButton.UseVisualStyleBackColor = true;
            this.OpenFolderButton.Click += new System.EventHandler(this.OpenFolderButton_Click);
            // 
            // OpenFolder
            // 
            this.OpenFolder.BackColor = System.Drawing.Color.Black;
            this.OpenFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenFolder.ForeColor = System.Drawing.Color.White;
            this.OpenFolder.Location = new System.Drawing.Point(58, 38);
            this.OpenFolder.Name = "OpenFolder";
            this.OpenFolder.Size = new System.Drawing.Size(332, 20);
            this.OpenFolder.TabIndex = 3;
            this.OpenFolder.Text = "Выбор папки tpl c набором мастер-шаблонов";
            // 
            // RandSelectTemplateButton
            // 
            this.RandSelectTemplateButton.BackColor = System.Drawing.Color.Khaki;
            this.RandSelectTemplateButton.Enabled = false;
            this.RandSelectTemplateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RandSelectTemplateButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.RandSelectTemplateButton.Location = new System.Drawing.Point(29, 110);
            this.RandSelectTemplateButton.Name = "RandSelectTemplateButton";
            this.RandSelectTemplateButton.Size = new System.Drawing.Size(159, 29);
            this.RandSelectTemplateButton.TabIndex = 4;
            this.RandSelectTemplateButton.Text = "Выбор мастер-шаблона:";
            this.RandSelectTemplateButton.UseVisualStyleBackColor = false;
            this.RandSelectTemplateButton.Click += new System.EventHandler(this.RandSelectTemplateButton_Click);
            // 
            // RandSelectTemplate
            // 
            this.RandSelectTemplate.BackColor = System.Drawing.Color.Black;
            this.RandSelectTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RandSelectTemplate.ForeColor = System.Drawing.Color.White;
            this.RandSelectTemplate.Location = new System.Drawing.Point(194, 114);
            this.RandSelectTemplate.Name = "RandSelectTemplate";
            this.RandSelectTemplate.Size = new System.Drawing.Size(196, 22);
            this.RandSelectTemplate.TabIndex = 5;
            // 
            // SaveFolderButton
            // 
            this.SaveFolderButton.BackgroundImage = global::Pattern_generator.Properties.Resources.folder;
            this.SaveFolderButton.Location = new System.Drawing.Point(29, 70);
            this.SaveFolderButton.Name = "SaveFolderButton";
            this.SaveFolderButton.Size = new System.Drawing.Size(23, 35);
            this.SaveFolderButton.TabIndex = 6;
            this.SaveFolderButton.UseVisualStyleBackColor = true;
            this.SaveFolderButton.Click += new System.EventHandler(this.SaveFolderButton_Click);
            // 
            // SaveFolder
            // 
            this.SaveFolder.BackColor = System.Drawing.Color.Black;
            this.SaveFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveFolder.ForeColor = System.Drawing.Color.White;
            this.SaveFolder.Location = new System.Drawing.Point(58, 78);
            this.SaveFolder.Name = "SaveFolder";
            this.SaveFolder.Size = new System.Drawing.Size(332, 20);
            this.SaveFolder.TabIndex = 7;
            this.SaveFolder.Text = "Папка для сохранения результирующих шаблонов";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(29, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 38);
            this.button1.TabIndex = 8;
            this.button1.Text = "Вставка inner/outer";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.LightCyan;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(406, 38);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(413, 544);
            this.textBox4.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Location = new System.Drawing.Point(29, 235);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 38);
            this.button3.TabIndex = 12;
            this.button3.Text = "Перестановка тегов в секции <head>";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(836, 26);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(58, 22);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRandom,
            this.menuInnerOuter,
            this.menuВыборЦветовыхСхем,
            this.menuРандомизацияЧастейCssКода,
            this.menuРандомизацияВертикальныхОтступов,
            this.menuРандомныйВыборНабораШрифтов,
            this.menuПерестановкаТегов,
            this.menuПерестановкаНазванийКлассов,
            this.menuПростановкаКомментариевCSS,
            this.menuДобавлениеНовыхКлассов,
            this.menuДобавлениеАтрибутовStyle});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // menuRandom
            // 
            this.menuRandom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLocalRandom,
            this.menuRandomOrg});
            this.menuRandom.Name = "menuRandom";
            this.menuRandom.Size = new System.Drawing.Size(364, 22);
            this.menuRandom.Text = "Режим Random";
            // 
            // menuLocalRandom
            // 
            this.menuLocalRandom.Checked = global::Pattern_generator.Properties.Settings.Default.LocalRandom;
            this.menuLocalRandom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuLocalRandom.Name = "menuLocalRandom";
            this.menuLocalRandom.Size = new System.Drawing.Size(173, 22);
            this.menuLocalRandom.Text = "Local Random";
            this.menuLocalRandom.Click += new System.EventHandler(this.menuLocalRandom_Click);
            // 
            // menuRandomOrg
            // 
            this.menuRandomOrg.Checked = global::Pattern_generator.Properties.Settings.Default.RandomOrg;
            this.menuRandomOrg.Name = "menuRandomOrg";
            this.menuRandomOrg.Size = new System.Drawing.Size(173, 22);
            this.menuRandomOrg.Text = "Random.Org";
            this.menuRandomOrg.Click += new System.EventHandler(this.menuRandomOrg_Click);
            // 
            // menuInnerOuter
            // 
            this.menuInnerOuter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.включитьInnerOuter,
            this.отключитьInnerOuter,
            this.toolStripSeparator1,
            this.вложенностьInner,
            this.toolStripSeparator2,
            this.вероятностьВставкиInner,
            this.вероятностьВставкиOuter,
            this.toolStripSeparator3,
            this.вероятностьСозданияОтдельныхCssПравил,
            this.количествоБезопасныхСвойствCSSInnerOuter});
            this.menuInnerOuter.Name = "menuInnerOuter";
            this.menuInnerOuter.Size = new System.Drawing.Size(364, 22);
            this.menuInnerOuter.Text = "Создание inners, outers";
            // 
            // включитьInnerOuter
            // 
            this.включитьInnerOuter.Checked = true;
            this.включитьInnerOuter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.включитьInnerOuter.Name = "включитьInnerOuter";
            this.включитьInnerOuter.Size = new System.Drawing.Size(418, 22);
            this.включитьInnerOuter.Text = "Включить";
            this.включитьInnerOuter.Click += new System.EventHandler(this.включитьInnerOuter_Click);
            // 
            // отключитьInnerOuter
            // 
            this.отключитьInnerOuter.Name = "отключитьInnerOuter";
            this.отключитьInnerOuter.Size = new System.Drawing.Size(418, 22);
            this.отключитьInnerOuter.Text = "Отключить";
            this.отключитьInnerOuter.Click += new System.EventHandler(this.отключитьInnerOuter_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(415, 6);
            // 
            // вложенностьInner
            // 
            this.вложенностьInner.AccessibleDescription = "";
            this.вложенностьInner.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.УстановкаЧислаВложенности});
            this.вложенностьInner.Name = "вложенностьInner";
            this.вложенностьInner.ShowShortcutKeys = false;
            this.вложенностьInner.Size = new System.Drawing.Size(418, 22);
            this.вложенностьInner.Text = "Вложенность inner";
            // 
            // УстановкаЧислаВложенности
            // 
            this.УстановкаЧислаВложенности.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.УстановкаЧислаВложенности.Items.AddRange(new object[] {
            "3",
            "2",
            "1"});
            this.УстановкаЧислаВложенности.Name = "УстановкаЧислаВложенности";
            this.УстановкаЧислаВложенности.Size = new System.Drawing.Size(121, 23);
            this.УстановкаЧислаВложенности.ToolTipText = "Максимальная вложенность  (от 1 до 3)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(415, 6);
            // 
            // вероятностьВставкиInner
            // 
            this.вероятностьВставкиInner.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вероятностьInnerMin,
            this.вероятностьInnerMax});
            this.вероятностьВставкиInner.Name = "вероятностьВставкиInner";
            this.вероятностьВставкиInner.Size = new System.Drawing.Size(418, 22);
            this.вероятностьВставкиInner.Text = "Вероятность вставки inner. %";
            // 
            // вероятностьInnerMin
            // 
            this.вероятностьInnerMin.Name = "вероятностьInnerMin";
            this.вероятностьInnerMin.Size = new System.Drawing.Size(100, 23);
            this.вероятностьInnerMin.Text = "40";
            this.вероятностьInnerMin.ToolTipText = "граница \"от\", вводить целое число от 1 до 99";
            // 
            // вероятностьInnerMax
            // 
            this.вероятностьInnerMax.Name = "вероятностьInnerMax";
            this.вероятностьInnerMax.Size = new System.Drawing.Size(100, 23);
            this.вероятностьInnerMax.Text = "60";
            this.вероятностьInnerMax.ToolTipText = "граница \"до\", вводить целое число от 2 до 100";
            // 
            // вероятностьВставкиOuter
            // 
            this.вероятностьВставкиOuter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вероятностьOuterMin,
            this.вероятностьOuterMax});
            this.вероятностьВставкиOuter.Name = "вероятностьВставкиOuter";
            this.вероятностьВставкиOuter.Size = new System.Drawing.Size(418, 22);
            this.вероятностьВставкиOuter.Text = "Вероятность вставки outer, %";
            // 
            // вероятностьOuterMin
            // 
            this.вероятностьOuterMin.Name = "вероятностьOuterMin";
            this.вероятностьOuterMin.Size = new System.Drawing.Size(100, 23);
            this.вероятностьOuterMin.Text = "40";
            this.вероятностьOuterMin.ToolTipText = "граница \"от\", вводить целое число от 1 до 99";
            // 
            // вероятностьOuterMax
            // 
            this.вероятностьOuterMax.Name = "вероятностьOuterMax";
            this.вероятностьOuterMax.Size = new System.Drawing.Size(100, 23);
            this.вероятностьOuterMax.Text = "60";
            this.вероятностьOuterMax.ToolTipText = "граница \"до\", вводить целое число от 2 до 100";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(415, 6);
            // 
            // вероятностьСозданияОтдельныхCssПравил
            // 
            this.вероятностьСозданияОтдельныхCssПравил.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вероятностьСозданияПравилMin,
            this.вероятностьСозданияПравилMax});
            this.вероятностьСозданияОтдельныхCssПравил.Name = "вероятностьСозданияОтдельныхCssПравил";
            this.вероятностьСозданияОтдельныхCssПравил.Size = new System.Drawing.Size(418, 22);
            this.вероятностьСозданияОтдельныхCssПравил.Text = "Вероятность создания отдельных css правил, %";
            this.вероятностьСозданияОтдельныхCssПравил.ToolTipText = "граница \"до\", вводить целое число от 2 до 100";
            // 
            // вероятностьСозданияПравилMin
            // 
            this.вероятностьСозданияПравилMin.Name = "вероятностьСозданияПравилMin";
            this.вероятностьСозданияПравилMin.Size = new System.Drawing.Size(100, 23);
            this.вероятностьСозданияПравилMin.Text = "40";
            this.вероятностьСозданияПравилMin.ToolTipText = "граница \"от\", вводить целое число от 1 до 99";
            // 
            // вероятностьСозданияПравилMax
            // 
            this.вероятностьСозданияПравилMax.Name = "вероятностьСозданияПравилMax";
            this.вероятностьСозданияПравилMax.Size = new System.Drawing.Size(100, 23);
            this.вероятностьСозданияПравилMax.Text = "60";
            this.вероятностьСозданияПравилMax.ToolTipText = "граница \"до\", вводить целое число от 2 до 100";
            // 
            // количествоБезопасныхСвойствCSSInnerOuter
            // 
            this.количествоБезопасныхСвойствCSSInnerOuter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.количествоСвойствCSSInnerOuterMin,
            this.количествоСвойствCSSInnerOuterMax});
            this.количествоБезопасныхСвойствCSSInnerOuter.Name = "количествоБезопасныхСвойствCSSInnerOuter";
            this.количествоБезопасныхСвойствCSSInnerOuter.Size = new System.Drawing.Size(418, 22);
            this.количествоБезопасныхСвойствCSSInnerOuter.Text = "Количество безопасных свойств css";
            // 
            // количествоСвойствCSSInnerOuterMin
            // 
            this.количествоСвойствCSSInnerOuterMin.Name = "количествоСвойствCSSInnerOuterMin";
            this.количествоСвойствCSSInnerOuterMin.Size = new System.Drawing.Size(100, 23);
            this.количествоСвойствCSSInnerOuterMin.Text = "1";
            this.количествоСвойствCSSInnerOuterMin.ToolTipText = "Минимальное количество безопасных свойств css в значении атрибута";
            // 
            // количествоСвойствCSSInnerOuterMax
            // 
            this.количествоСвойствCSSInnerOuterMax.Name = "количествоСвойствCSSInnerOuterMax";
            this.количествоСвойствCSSInnerOuterMax.Size = new System.Drawing.Size(100, 23);
            this.количествоСвойствCSSInnerOuterMax.Text = "5";
            this.количествоСвойствCSSInnerOuterMax.ToolTipText = "Максимальное количество безопасных свойств css в значении атрибута";
            // 
            // menuВыборЦветовыхСхем
            // 
            this.menuВыборЦветовыхСхем.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.включитьВыборЦветовыхСхем,
            this.отключитьВыборЦветовыхСхем});
            this.menuВыборЦветовыхСхем.Name = "menuВыборЦветовыхСхем";
            this.menuВыборЦветовыхСхем.Size = new System.Drawing.Size(364, 22);
            this.menuВыборЦветовыхСхем.Text = "Выбор цветовых схем шаблонов";
            // 
            // включитьВыборЦветовыхСхем
            // 
            this.включитьВыборЦветовыхСхем.Checked = true;
            this.включитьВыборЦветовыхСхем.CheckState = System.Windows.Forms.CheckState.Checked;
            this.включитьВыборЦветовыхСхем.Name = "включитьВыборЦветовыхСхем";
            this.включитьВыборЦветовыхСхем.Size = new System.Drawing.Size(154, 22);
            this.включитьВыборЦветовыхСхем.Text = "Включить";
            this.включитьВыборЦветовыхСхем.Click += new System.EventHandler(this.включитьВыборЦветовыхСхем_Click);
            // 
            // отключитьВыборЦветовыхСхем
            // 
            this.отключитьВыборЦветовыхСхем.Name = "отключитьВыборЦветовыхСхем";
            this.отключитьВыборЦветовыхСхем.Size = new System.Drawing.Size(154, 22);
            this.отключитьВыборЦветовыхСхем.Text = "Отключить";
            this.отключитьВыборЦветовыхСхем.Click += new System.EventHandler(this.отключитьВыборЦветовыхСхем_Click);
            // 
            // menuРандомизацияЧастейCssКода
            // 
            this.menuРандомизацияЧастейCssКода.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.включитьРандомизацияЧастейКода,
            this.отключитьРандомизацияЧастейКода});
            this.menuРандомизацияЧастейCssКода.Name = "menuРандомизацияЧастейCssКода";
            this.menuРандомизацияЧастейCssКода.Size = new System.Drawing.Size(364, 22);
            this.menuРандомизацияЧастейCssКода.Text = "Рандомизация частей css кода";
            // 
            // включитьРандомизацияЧастейКода
            // 
            this.включитьРандомизацияЧастейКода.Checked = true;
            this.включитьРандомизацияЧастейКода.CheckState = System.Windows.Forms.CheckState.Checked;
            this.включитьРандомизацияЧастейКода.Name = "включитьРандомизацияЧастейКода";
            this.включитьРандомизацияЧастейКода.Size = new System.Drawing.Size(154, 22);
            this.включитьРандомизацияЧастейКода.Text = "Включить";
            this.включитьРандомизацияЧастейКода.Click += new System.EventHandler(this.включитьРандомизацияЧастейКода_Click);
            // 
            // отключитьРандомизацияЧастейКода
            // 
            this.отключитьРандомизацияЧастейКода.Name = "отключитьРандомизацияЧастейКода";
            this.отключитьРандомизацияЧастейКода.Size = new System.Drawing.Size(154, 22);
            this.отключитьРандомизацияЧастейКода.Text = "Отключить";
            this.отключитьРандомизацияЧастейКода.Click += new System.EventHandler(this.отключитьРандомизацияЧастейКода_Click);
            // 
            // menuРандомизацияВертикальныхОтступов
            // 
            this.menuРандомизацияВертикальныхОтступов.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.включитьРандомизацияВертОтступов,
            this.отключитьРандомизацияВертОтступов,
            this.вероятностьИзмененияОтступов,
            this.максимальныйПроцентИзменения});
            this.menuРандомизацияВертикальныхОтступов.Name = "menuРандомизацияВертикальныхОтступов";
            this.menuРандомизацияВертикальныхОтступов.Size = new System.Drawing.Size(364, 22);
            this.menuРандомизацияВертикальныхОтступов.Text = "Рандомизация вертикальных отступов";
            // 
            // включитьРандомизацияВертОтступов
            // 
            this.включитьРандомизацияВертОтступов.Checked = true;
            this.включитьРандомизацияВертОтступов.CheckState = System.Windows.Forms.CheckState.Checked;
            this.включитьРандомизацияВертОтступов.Name = "включитьРандомизацияВертОтступов";
            this.включитьРандомизацияВертОтступов.Size = new System.Drawing.Size(333, 22);
            this.включитьРандомизацияВертОтступов.Text = "Включить";
            this.включитьРандомизацияВертОтступов.Click += new System.EventHandler(this.включитьРандомизацияВертОтступов_Click);
            // 
            // отключитьРандомизацияВертОтступов
            // 
            this.отключитьРандомизацияВертОтступов.Name = "отключитьРандомизацияВертОтступов";
            this.отключитьРандомизацияВертОтступов.Size = new System.Drawing.Size(333, 22);
            this.отключитьРандомизацияВертОтступов.Text = "Отключить";
            this.отключитьРандомизацияВертОтступов.Click += new System.EventHandler(this.отключитьРандомизацияВертОтступов_Click);
            // 
            // вероятностьИзмененияОтступов
            // 
            this.вероятностьИзмененияОтступов.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вероятностьИзмененияОтступовMin,
            this.вероятностьИзмененияОтступовMax});
            this.вероятностьИзмененияОтступов.Name = "вероятностьИзмененияОтступов";
            this.вероятностьИзмененияОтступов.Size = new System.Drawing.Size(333, 22);
            this.вероятностьИзмененияОтступов.Text = "Вероятность изменения отступов, %";
            // 
            // вероятностьИзмененияОтступовMin
            // 
            this.вероятностьИзмененияОтступовMin.Name = "вероятностьИзмененияОтступовMin";
            this.вероятностьИзмененияОтступовMin.Size = new System.Drawing.Size(100, 23);
            this.вероятностьИзмененияОтступовMin.Text = "40";
            this.вероятностьИзмененияОтступовMin.ToolTipText = "граница \"от\", вводить целое число от 1 до 99";
            // 
            // вероятностьИзмененияОтступовMax
            // 
            this.вероятностьИзмененияОтступовMax.Name = "вероятностьИзмененияОтступовMax";
            this.вероятностьИзмененияОтступовMax.Size = new System.Drawing.Size(100, 23);
            this.вероятностьИзмененияОтступовMax.Text = "60";
            this.вероятностьИзмененияОтступовMax.ToolTipText = "граница \"до\", вводить целое число от 2 до 100";
            // 
            // максимальныйПроцентИзменения
            // 
            this.максимальныйПроцентИзменения.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.процентИзмененияMax});
            this.максимальныйПроцентИзменения.Name = "максимальныйПроцентИзменения";
            this.максимальныйПроцентИзменения.Size = new System.Drawing.Size(333, 22);
            this.максимальныйПроцентИзменения.Text = "Максимальный % изменения";
            // 
            // процентИзмененияMax
            // 
            this.процентИзмененияMax.Name = "процентИзмененияMax";
            this.процентИзмененияMax.Size = new System.Drawing.Size(100, 23);
            this.процентИзмененияMax.Text = "30";
            this.процентИзмененияMax.ToolTipText = "целое число от 1 до 100";
            // 
            // menuРандомныйВыборНабораШрифтов
            // 
            this.menuРандомныйВыборНабораШрифтов.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.включитьРандомныйВыборШрифтов,
            this.отключитьРандомныйВыборШрифтов});
            this.menuРандомныйВыборНабораШрифтов.Name = "menuРандомныйВыборНабораШрифтов";
            this.menuРандомныйВыборНабораШрифтов.Size = new System.Drawing.Size(364, 22);
            this.menuРандомныйВыборНабораШрифтов.Text = "Рандомный выбор набора шрифтов";
            // 
            // включитьРандомныйВыборШрифтов
            // 
            this.включитьРандомныйВыборШрифтов.Checked = true;
            this.включитьРандомныйВыборШрифтов.CheckState = System.Windows.Forms.CheckState.Checked;
            this.включитьРандомныйВыборШрифтов.Name = "включитьРандомныйВыборШрифтов";
            this.включитьРандомныйВыборШрифтов.Size = new System.Drawing.Size(154, 22);
            this.включитьРандомныйВыборШрифтов.Text = "Включить";
            this.включитьРандомныйВыборШрифтов.Click += new System.EventHandler(this.включитьРандомныйВыборШрифтов_Click);
            // 
            // отключитьРандомныйВыборШрифтов
            // 
            this.отключитьРандомныйВыборШрифтов.Name = "отключитьРандомныйВыборШрифтов";
            this.отключитьРандомныйВыборШрифтов.Size = new System.Drawing.Size(154, 22);
            this.отключитьРандомныйВыборШрифтов.Text = "Отключить";
            this.отключитьРандомныйВыборШрифтов.Click += new System.EventHandler(this.отключитьРандомныйВыборШрифтов_Click);
            // 
            // menuПерестановкаТегов
            // 
            this.menuПерестановкаТегов.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.включитьПеретасовкаТегов,
            this.отключитьПеретасовкаТегов});
            this.menuПерестановкаТегов.Name = "menuПерестановкаТегов";
            this.menuПерестановкаТегов.Size = new System.Drawing.Size(364, 22);
            this.menuПерестановкаТегов.Text = "Перестановка тегов в секции <head>";
            // 
            // включитьПеретасовкаТегов
            // 
            this.включитьПеретасовкаТегов.Checked = true;
            this.включитьПеретасовкаТегов.CheckState = System.Windows.Forms.CheckState.Checked;
            this.включитьПеретасовкаТегов.Name = "включитьПеретасовкаТегов";
            this.включитьПеретасовкаТегов.Size = new System.Drawing.Size(154, 22);
            this.включитьПеретасовкаТегов.Text = "Включить";
            this.включитьПеретасовкаТегов.Click += new System.EventHandler(this.включитьПеретасовкаТегов_Click);
            // 
            // отключитьПеретасовкаТегов
            // 
            this.отключитьПеретасовкаТегов.Name = "отключитьПеретасовкаТегов";
            this.отключитьПеретасовкаТегов.Size = new System.Drawing.Size(154, 22);
            this.отключитьПеретасовкаТегов.Text = "Отключить";
            this.отключитьПеретасовкаТегов.Click += new System.EventHandler(this.отключитьПеретасовкаТегов_Click);
            // 
            // menuПерестановкаНазванийКлассов
            // 
            this.menuПерестановкаНазванийКлассов.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.включитьПерестановкаНазванийКлассов,
            this.отключитьПерестановкаНазванийКлассов});
            this.menuПерестановкаНазванийКлассов.Name = "menuПерестановкаНазванийКлассов";
            this.menuПерестановкаНазванийКлассов.Size = new System.Drawing.Size(364, 22);
            this.menuПерестановкаНазванийКлассов.Text = "Перестановка названий классов в тегах";
            // 
            // включитьПерестановкаНазванийКлассов
            // 
            this.включитьПерестановкаНазванийКлассов.Checked = true;
            this.включитьПерестановкаНазванийКлассов.CheckState = System.Windows.Forms.CheckState.Checked;
            this.включитьПерестановкаНазванийКлассов.Name = "включитьПерестановкаНазванийКлассов";
            this.включитьПерестановкаНазванийКлассов.Size = new System.Drawing.Size(154, 22);
            this.включитьПерестановкаНазванийКлассов.Text = "Включить";
            this.включитьПерестановкаНазванийКлассов.Click += new System.EventHandler(this.включитьПерестановкаНазванийКлассов_Click);
            // 
            // отключитьПерестановкаНазванийКлассов
            // 
            this.отключитьПерестановкаНазванийКлассов.Name = "отключитьПерестановкаНазванийКлассов";
            this.отключитьПерестановкаНазванийКлассов.Size = new System.Drawing.Size(154, 22);
            this.отключитьПерестановкаНазванийКлассов.Text = "Отключить";
            this.отключитьПерестановкаНазванийКлассов.Click += new System.EventHandler(this.отключитьПерестановкаНазванийКлассов_Click);
            // 
            // menuПростановкаКомментариевCSS
            // 
            this.menuПростановкаКомментариевCSS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.включитьПростановкаКомментариев,
            this.отключитьПростановкаКомментариев,
            this.количествоКомментариевНаФайл});
            this.menuПростановкаКомментариевCSS.Name = "menuПростановкаКомментариевCSS";
            this.menuПростановкаКомментариевCSS.Size = new System.Drawing.Size(364, 22);
            this.menuПростановкаКомментариевCSS.Text = "Простановка комментариев в файле css";
            // 
            // включитьПростановкаКомментариев
            // 
            this.включитьПростановкаКомментариев.Checked = true;
            this.включитьПростановкаКомментариев.CheckState = System.Windows.Forms.CheckState.Checked;
            this.включитьПростановкаКомментариев.Name = "включитьПростановкаКомментариев";
            this.включитьПростановкаКомментариев.Size = new System.Drawing.Size(328, 22);
            this.включитьПростановкаКомментариев.Text = "Включить";
            this.включитьПростановкаКомментариев.Click += new System.EventHandler(this.включитьПростановкаКомментариев_Click);
            // 
            // отключитьПростановкаКомментариев
            // 
            this.отключитьПростановкаКомментариев.Name = "отключитьПростановкаКомментариев";
            this.отключитьПростановкаКомментариев.Size = new System.Drawing.Size(328, 22);
            this.отключитьПростановкаКомментариев.Text = "Отключить";
            this.отключитьПростановкаКомментариев.Click += new System.EventHandler(this.отключитьПростановкаКомментариев_Click);
            // 
            // количествоКомментариевНаФайл
            // 
            this.количествоКомментариевНаФайл.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.количествоКомментариевMin,
            this.количествоКомментариевMax});
            this.количествоКомментариевНаФайл.Name = "количествоКомментариевНаФайл";
            this.количествоКомментариевНаФайл.Size = new System.Drawing.Size(328, 22);
            this.количествоКомментариевНаФайл.Text = "Количество комментариев на файл";
            // 
            // количествоКомментариевMin
            // 
            this.количествоКомментариевMin.Name = "количествоКомментариевMin";
            this.количествоКомментариевMin.Size = new System.Drawing.Size(100, 23);
            this.количествоКомментариевMin.Text = "1";
            this.количествоКомментариевMin.ToolTipText = "Минимальное количество комментариев на файл";
            // 
            // количествоКомментариевMax
            // 
            this.количествоКомментариевMax.Name = "количествоКомментариевMax";
            this.количествоКомментариевMax.Size = new System.Drawing.Size(100, 23);
            this.количествоКомментариевMax.Text = "5";
            this.количествоКомментариевMax.ToolTipText = "Максимальное количество комментариев на файл";
            // 
            // menuДобавлениеНовыхКлассов
            // 
            this.menuДобавлениеНовыхКлассов.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.включитьДобавлениеКлассов,
            this.отключитьДобавлениеКлассов,
            this.количествоВзятыхНазванийКлассов,
            this.количествоТеговДляНазванияКласса,
            this.количествоБезопасныхСвойствCSS});
            this.menuДобавлениеНовыхКлассов.Name = "menuДобавлениеНовыхКлассов";
            this.menuДобавлениеНовыхКлассов.Size = new System.Drawing.Size(364, 22);
            this.menuДобавлениеНовыхКлассов.Text = "Добавление новых классов в теги";
            // 
            // включитьДобавлениеКлассов
            // 
            this.включитьДобавлениеКлассов.Checked = true;
            this.включитьДобавлениеКлассов.CheckState = System.Windows.Forms.CheckState.Checked;
            this.включитьДобавлениеКлассов.Name = "включитьДобавлениеКлассов";
            this.включитьДобавлениеКлассов.Size = new System.Drawing.Size(407, 22);
            this.включитьДобавлениеКлассов.Text = "Включить";
            this.включитьДобавлениеКлассов.Click += new System.EventHandler(this.включитьДобавлениеКлассов_Click);
            // 
            // отключитьДобавлениеКлассов
            // 
            this.отключитьДобавлениеКлассов.Name = "отключитьДобавлениеКлассов";
            this.отключитьДобавлениеКлассов.Size = new System.Drawing.Size(407, 22);
            this.отключитьДобавлениеКлассов.Text = "Отключить";
            this.отключитьДобавлениеКлассов.Click += new System.EventHandler(this.отключитьДобавлениеКлассов_Click);
            // 
            // количествоВзятыхНазванийКлассов
            // 
            this.количествоВзятыхНазванийКлассов.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.количествоНазванийMin,
            this.количествоНазванийMax});
            this.количествоВзятыхНазванийКлассов.Name = "количествоВзятыхНазванийКлассов";
            this.количествоВзятыхНазванийКлассов.Size = new System.Drawing.Size(407, 22);
            this.количествоВзятыхНазванийКлассов.Text = "Количество взятых названий классов";
            // 
            // количествоНазванийMin
            // 
            this.количествоНазванийMin.Name = "количествоНазванийMin";
            this.количествоНазванийMin.Size = new System.Drawing.Size(100, 23);
            this.количествоНазванийMin.Text = "1";
            this.количествоНазванийMin.ToolTipText = "Минимальное количество взятых названий классов";
            // 
            // количествоНазванийMax
            // 
            this.количествоНазванийMax.Name = "количествоНазванийMax";
            this.количествоНазванийMax.Size = new System.Drawing.Size(100, 23);
            this.количествоНазванийMax.Text = "5";
            this.количествоНазванийMax.ToolTipText = "Максимальное количество взятых названий классов";
            // 
            // количествоТеговДляНазванияКласса
            // 
            this.количествоТеговДляНазванияКласса.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.количествоТеговMin,
            this.количествоТеговMax});
            this.количествоТеговДляНазванияКласса.Name = "количествоТеговДляНазванияКласса";
            this.количествоТеговДляНазванияКласса.Size = new System.Drawing.Size(407, 22);
            this.количествоТеговДляНазванияКласса.Text = "Количество тегов для одного названия класса";
            // 
            // количествоТеговMin
            // 
            this.количествоТеговMin.Name = "количествоТеговMin";
            this.количествоТеговMin.Size = new System.Drawing.Size(100, 23);
            this.количествоТеговMin.Text = "1";
            this.количествоТеговMin.ToolTipText = "Минимальное количество тегов для одного названия класса";
            // 
            // количествоТеговMax
            // 
            this.количествоТеговMax.Name = "количествоТеговMax";
            this.количествоТеговMax.Size = new System.Drawing.Size(100, 23);
            this.количествоТеговMax.Text = "5";
            this.количествоТеговMax.ToolTipText = "Максимальное количество тегов для одного названия класса";
            // 
            // количествоБезопасныхСвойствCSS
            // 
            this.количествоБезопасныхСвойствCSS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.количествоСвойствMin,
            this.количествоСвойствMax});
            this.количествоБезопасныхСвойствCSS.Name = "количествоБезопасныхСвойствCSS";
            this.количествоБезопасныхСвойствCSS.Size = new System.Drawing.Size(407, 22);
            this.количествоБезопасныхСвойствCSS.Text = "Количество безопасных свойств css";
            // 
            // количествоСвойствMin
            // 
            this.количествоСвойствMin.Name = "количествоСвойствMin";
            this.количествоСвойствMin.Size = new System.Drawing.Size(100, 23);
            this.количествоСвойствMin.Text = "1";
            this.количествоСвойствMin.ToolTipText = "Минимальное количество безопасных свойств css";
            // 
            // количествоСвойствMax
            // 
            this.количествоСвойствMax.Name = "количествоСвойствMax";
            this.количествоСвойствMax.Size = new System.Drawing.Size(100, 23);
            this.количествоСвойствMax.Text = "8";
            this.количествоСвойствMax.ToolTipText = "Максимальное количество безопасных свойств css";
            // 
            // menuДобавлениеАтрибутовStyle
            // 
            this.menuДобавлениеАтрибутовStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.включитьДобавлениеStyle,
            this.отключитьДобавлениеStyle,
            this.количествоАтрибутовНаШаблон,
            this.количествоБезопасныхСвойствCSSStyle});
            this.menuДобавлениеАтрибутовStyle.Name = "menuДобавлениеАтрибутовStyle";
            this.menuДобавлениеАтрибутовStyle.Size = new System.Drawing.Size(364, 22);
            this.menuДобавлениеАтрибутовStyle.Text = "Добавление атрибутов style в теги";
            // 
            // включитьДобавлениеStyle
            // 
            this.включитьДобавлениеStyle.Checked = true;
            this.включитьДобавлениеStyle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.включитьДобавлениеStyle.Name = "включитьДобавлениеStyle";
            this.включитьДобавлениеStyle.Size = new System.Drawing.Size(336, 22);
            this.включитьДобавлениеStyle.Text = "Включить";
            this.включитьДобавлениеStyle.Click += new System.EventHandler(this.включитьДобавлениеStyle_Click);
            // 
            // отключитьДобавлениеStyle
            // 
            this.отключитьДобавлениеStyle.Name = "отключитьДобавлениеStyle";
            this.отключитьДобавлениеStyle.Size = new System.Drawing.Size(336, 22);
            this.отключитьДобавлениеStyle.Text = "Отключить";
            this.отключитьДобавлениеStyle.Click += new System.EventHandler(this.отключитьДобавлениеStyle_Click);
            // 
            // количествоАтрибутовНаШаблон
            // 
            this.количествоАтрибутовНаШаблон.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.количествоАтрибутовMin,
            this.количествоАтрибутовMax});
            this.количествоАтрибутовНаШаблон.Name = "количествоАтрибутовНаШаблон";
            this.количествоАтрибутовНаШаблон.Size = new System.Drawing.Size(336, 22);
            this.количествоАтрибутовНаШаблон.Text = "Количество атрибутов на шаблон";
            // 
            // количествоАтрибутовMin
            // 
            this.количествоАтрибутовMin.Name = "количествоАтрибутовMin";
            this.количествоАтрибутовMin.Size = new System.Drawing.Size(100, 23);
            this.количествоАтрибутовMin.Text = "1";
            this.количествоАтрибутовMin.ToolTipText = "Минимальное количество атрибутов на шаблон";
            // 
            // количествоАтрибутовMax
            // 
            this.количествоАтрибутовMax.Name = "количествоАтрибутовMax";
            this.количествоАтрибутовMax.Size = new System.Drawing.Size(100, 23);
            this.количествоАтрибутовMax.Text = "5";
            this.количествоАтрибутовMax.ToolTipText = "Максимальное количество атрибутов на шаблон";
            // 
            // количествоБезопасныхСвойствCSSStyle
            // 
            this.количествоБезопасныхСвойствCSSStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.количествоСвойствCSSMin,
            this.количествоСвойствCSSMax});
            this.количествоБезопасныхСвойствCSSStyle.Name = "количествоБезопасныхСвойствCSSStyle";
            this.количествоБезопасныхСвойствCSSStyle.Size = new System.Drawing.Size(336, 22);
            this.количествоБезопасныхСвойствCSSStyle.Text = "Количество безопасных свойств css";
            // 
            // количествоСвойствCSSMin
            // 
            this.количествоСвойствCSSMin.Name = "количествоСвойствCSSMin";
            this.количествоСвойствCSSMin.Size = new System.Drawing.Size(100, 23);
            this.количествоСвойствCSSMin.Text = "1";
            this.количествоСвойствCSSMin.ToolTipText = "Минимальное количество безопасных свойств css в значении атрибута";
            // 
            // количествоСвойствCSSMax
            // 
            this.количествоСвойствCSSMax.Name = "количествоСвойствCSSMax";
            this.количествоСвойствCSSMax.Size = new System.Drawing.Size(100, 23);
            this.количествоСвойствCSSMax.Text = "5";
            this.количествоСвойствCSSMax.ToolTipText = "Максимальное количество безопасных свойств css в значении атрибута";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Location = new System.Drawing.Point(29, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 38);
            this.button2.TabIndex = 15;
            this.button2.Text = "Перестановка названий классов в тегах";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.Location = new System.Drawing.Point(29, 323);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(163, 38);
            this.button4.TabIndex = 16;
            this.button4.Text = "Рандомное добавление новых классов в теги";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button5.Location = new System.Drawing.Point(29, 367);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(163, 38);
            this.button5.TabIndex = 17;
            this.button5.Text = "Рандомное добавление атрибутов style в теги";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button6.Location = new System.Drawing.Point(29, 146);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(361, 38);
            this.button6.TabIndex = 18;
            this.button6.Text = "Основной функционал";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button8.Location = new System.Drawing.Point(227, 368);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(163, 38);
            this.button8.TabIndex = 24;
            this.button8.Text = "Рандомная простановка комментариев в файле css";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button9.Location = new System.Drawing.Point(227, 324);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(163, 38);
            this.button9.TabIndex = 23;
            this.button9.Text = "Рандомизация частей css кода";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button10.Location = new System.Drawing.Point(227, 280);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(163, 38);
            this.button10.TabIndex = 22;
            this.button10.Text = "Рандомизация вертикальных отступов";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button11.Location = new System.Drawing.Point(227, 236);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(163, 38);
            this.button11.TabIndex = 21;
            this.button11.Text = "Выбор набора шрифтов";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button12.Location = new System.Drawing.Point(227, 191);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(163, 38);
            this.button12.TabIndex = 20;
            this.button12.Text = "Выбор цветовых схем / Выбор контрастного цвета текста";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.SteelBlue;
            this.button7.Location = new System.Drawing.Point(29, 500);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(163, 38);
            this.button7.TabIndex = 25;
            this.button7.Text = "Обработка случаев background";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.SteelBlue;
            this.button13.Location = new System.Drawing.Point(227, 456);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(163, 38);
            this.button13.TabIndex = 26;
            this.button13.Text = "Удаление color без background";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.SteelBlue;
            this.button14.Location = new System.Drawing.Point(29, 456);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(163, 38);
            this.button14.TabIndex = 27;
            this.button14.Text = "Замена id и классов";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.SteelBlue;
            this.button15.Location = new System.Drawing.Point(227, 500);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(163, 38);
            this.button15.TabIndex = 28;
            this.button15.Text = "Удаление пустых правил";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.SteelBlue;
            this.button16.Location = new System.Drawing.Point(29, 544);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(163, 38);
            this.button16.TabIndex = 29;
            this.button16.Text = "Установка цвета для ссылок";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.SteelBlue;
            this.button17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button17.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button17.Location = new System.Drawing.Point(29, 412);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(361, 38);
            this.button17.TabIndex = 30;
            this.button17.Text = "Дополнительный функционал";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(836, 594);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SaveFolder);
            this.Controls.Add(this.SaveFolderButton);
            this.Controls.Add(this.RandSelectTemplate);
            this.Controls.Add(this.RandSelectTemplateButton);
            this.Controls.Add(this.OpenFolder);
            this.Controls.Add(this.OpenFolderButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pattern generator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void DropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
                ((ToolStripDropDownMenu)sender).Invalidate();
            }
        }


        private void menuLocalRandom_Click(object sender, EventArgs e)
        {
            menuLocalRandom.CheckState = CheckState.Checked;
            menuRandomOrg.CheckState = CheckState.Unchecked;
            Properties.Settings.Default.LocalRandom = true;
            Properties.Settings.Default.RandomOrg = false;
        }

        private void menuRandomOrg_Click(object sender, EventArgs e)
        {
            menuRandomOrg.CheckState = CheckState.Checked;
            menuLocalRandom.CheckState = CheckState.Unchecked;
            Properties.Settings.Default.LocalRandom = false;
            Properties.Settings.Default.RandomOrg = true;
        }

        private void включитьInnerOuter_Click(object sender, EventArgs e)
        {
            включитьInnerOuter.CheckState = CheckState.Checked;
            отключитьInnerOuter.CheckState = CheckState.Unchecked;

        }

        private void отключитьInnerOuter_Click(object sender, EventArgs e)
        {
            отключитьInnerOuter.CheckState = CheckState.Checked;
            включитьInnerOuter.CheckState = CheckState.Unchecked;
        }

        private void включитьВыборЦветовыхСхем_Click(object sender, EventArgs e)
        {
            включитьВыборЦветовыхСхем.CheckState = CheckState.Checked;
            отключитьВыборЦветовыхСхем.CheckState = CheckState.Unchecked;
        }

        private void отключитьВыборЦветовыхСхем_Click(object sender, EventArgs e)
        {
            отключитьВыборЦветовыхСхем.CheckState = CheckState.Checked;
            включитьВыборЦветовыхСхем.CheckState = CheckState.Unchecked;
        }

        private void включитьРандомизацияЧастейКода_Click(object sender, EventArgs e)
        {
            включитьРандомизацияЧастейКода.CheckState = CheckState.Checked;
            отключитьРандомизацияЧастейКода.CheckState = CheckState.Unchecked;
        }

        private void отключитьРандомизацияЧастейКода_Click(object sender, EventArgs e)
        {
            отключитьРандомизацияЧастейКода.CheckState = CheckState.Checked;
            включитьРандомизацияЧастейКода.CheckState = CheckState.Unchecked;
        }

        private void включитьРандомизацияВертОтступов_Click(object sender, EventArgs e)
        {
            включитьРандомизацияВертОтступов.CheckState = CheckState.Checked;
            отключитьРандомизацияВертОтступов.CheckState = CheckState.Unchecked;
        }

        private void отключитьРандомизацияВертОтступов_Click(object sender, EventArgs e)
        {
            отключитьРандомизацияВертОтступов.CheckState = CheckState.Checked;
            включитьРандомизацияВертОтступов.CheckState = CheckState.Unchecked;
        }

        private void включитьРандомныйВыборШрифтов_Click(object sender, EventArgs e)
        {
            включитьРандомныйВыборШрифтов.CheckState = CheckState.Checked;
            отключитьРандомныйВыборШрифтов.CheckState = CheckState.Unchecked;
        }

        private void отключитьРандомныйВыборШрифтов_Click(object sender, EventArgs e)
        {
            отключитьРандомныйВыборШрифтов.CheckState = CheckState.Checked;
            включитьРандомныйВыборШрифтов.CheckState = CheckState.Unchecked;
        }

        private void включитьПеретасовкаТегов_Click(object sender, EventArgs e)
        {
            включитьПеретасовкаТегов.CheckState = CheckState.Checked;
            отключитьПеретасовкаТегов.CheckState = CheckState.Unchecked;
        }

        private void отключитьПеретасовкаТегов_Click(object sender, EventArgs e)
        {
            отключитьПеретасовкаТегов.CheckState = CheckState.Checked;
            включитьПеретасовкаТегов.CheckState = CheckState.Unchecked;
        }

        private void включитьПерестановкаНазванийКлассов_Click(object sender, EventArgs e)
        {
            включитьПерестановкаНазванийКлассов.CheckState = CheckState.Checked;
            отключитьПерестановкаНазванийКлассов.CheckState = CheckState.Unchecked;
        }

        private void отключитьПерестановкаНазванийКлассов_Click(object sender, EventArgs e)
        {
            отключитьПерестановкаНазванийКлассов.CheckState = CheckState.Checked;
            включитьПерестановкаНазванийКлассов.CheckState = CheckState.Unchecked;
        }

        private void включитьПростановкаКомментариев_Click(object sender, EventArgs e)
        {
            включитьПростановкаКомментариев.CheckState = CheckState.Checked;
            отключитьПростановкаКомментариев.CheckState = CheckState.Unchecked;
        }

        private void отключитьПростановкаКомментариев_Click(object sender, EventArgs e)
        {
            отключитьПростановкаКомментариев.CheckState = CheckState.Checked;
            включитьПростановкаКомментариев.CheckState = CheckState.Unchecked;
        }

        private void включитьДобавлениеКлассов_Click(object sender, EventArgs e)
        {
            включитьДобавлениеКлассов.CheckState = CheckState.Checked;
            отключитьДобавлениеКлассов.CheckState = CheckState.Unchecked;
        }

        private void отключитьДобавлениеКлассов_Click(object sender, EventArgs e)
        {
            отключитьДобавлениеКлассов.CheckState = CheckState.Checked;
            включитьДобавлениеКлассов.CheckState = CheckState.Unchecked;
        }

        private void включитьДобавлениеStyle_Click(object sender, EventArgs e)
        {
            включитьДобавлениеStyle.CheckState = CheckState.Checked;
            отключитьДобавлениеStyle.CheckState = CheckState.Unchecked;
        }

        private void отключитьДобавлениеStyle_Click(object sender, EventArgs e)
        {
            отключитьДобавлениеStyle.CheckState = CheckState.Checked;
            включитьДобавлениеStyle.CheckState = CheckState.Unchecked;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons msb = MessageBoxButtons.YesNo;
            String message = "Вы действительно хотите выйти?";
            String caption = "Выход";
            if (MessageBox.Show(message, caption, msb) == DialogResult.Yes)
            {
                this.Close();
                Properties.Settings.Default.Save();
            }
        }

        #endregion
        private System.Windows.Forms.Button OpenFolderButton;
        private System.Windows.Forms.TextBox OpenFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button RandSelectTemplateButton;
        private System.Windows.Forms.TextBox RandSelectTemplate;
        private System.Windows.Forms.Button SaveFolderButton;
        private System.Windows.Forms.TextBox SaveFolder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuRandomOrg;
        private System.Windows.Forms.ToolStripMenuItem menuInnerOuter;
        private System.Windows.Forms.ToolStripMenuItem включитьInnerOuter;
        private System.Windows.Forms.ToolStripMenuItem отключитьInnerOuter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem вероятностьВставкиInner;
        private System.Windows.Forms.ToolStripMenuItem вероятностьВставкиOuter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripMenuItem вложенностьInner;
        public System.Windows.Forms.ToolStripComboBox УстановкаЧислаВложенности;
        public ToolStripMenuItem menuRandom;
        private ToolStripMenuItem menuВыборЦветовыхСхем;
        private ToolStripMenuItem включитьВыборЦветовыхСхем;
        private ToolStripMenuItem отключитьВыборЦветовыхСхем;
        private ToolStripMenuItem menuРандомизацияЧастейCssКода;
        private ToolStripMenuItem включитьРандомизацияЧастейКода;
        private ToolStripMenuItem отключитьРандомизацияЧастейКода;
        private ToolStripMenuItem menuРандомизацияВертикальныхОтступов;
        private ToolStripMenuItem включитьРандомизацияВертОтступов;
        private ToolStripMenuItem отключитьРандомизацияВертОтступов;
        private ToolStripTextBox вероятностьInnerMin;
        private ToolStripTextBox вероятностьOuterMin;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem вероятностьСозданияОтдельныхCssПравил;
        private ToolStripTextBox вероятностьСозданияПравилMin;
        private ToolStripTextBox вероятностьInnerMax;
        private ToolStripTextBox вероятностьOuterMax;
        private ToolStripTextBox вероятностьСозданияПравилMax;
        private ToolStripMenuItem вероятностьИзмененияОтступов;
        private ToolStripTextBox вероятностьИзмененияОтступовMin;
        private ToolStripTextBox вероятностьИзмененияОтступовMax;
        private ToolStripMenuItem menuРандомныйВыборНабораШрифтов;
        private ToolStripMenuItem включитьРандомныйВыборШрифтов;
        private ToolStripMenuItem отключитьРандомныйВыборШрифтов;
        private ToolStripMenuItem максимальныйПроцентИзменения;
        private ToolStripTextBox процентИзмененияMax;
        private ToolStripMenuItem menuПерестановкаТегов;
        private ToolStripMenuItem включитьПеретасовкаТегов;
        private ToolStripMenuItem отключитьПеретасовкаТегов;
        private ToolStripMenuItem menuПерестановкаНазванийКлассов;
        private ToolStripMenuItem включитьПерестановкаНазванийКлассов;
        private ToolStripMenuItem отключитьПерестановкаНазванийКлассов;
        private ToolStripMenuItem menuПростановкаКомментариевCSS;
        private ToolStripMenuItem включитьПростановкаКомментариев;
        private ToolStripMenuItem отключитьПростановкаКомментариев;
        private ToolStripMenuItem количествоКомментариевНаФайл;
        private ToolStripTextBox количествоКомментариевMin;
        private ToolStripTextBox количествоКомментариевMax;
        private ToolStripMenuItem menuДобавлениеНовыхКлассов;
        private ToolStripMenuItem включитьДобавлениеКлассов;
        private ToolStripMenuItem отключитьДобавлениеКлассов;
        private ToolStripMenuItem количествоВзятыхНазванийКлассов;
        private ToolStripTextBox количествоНазванийMin;
        private ToolStripTextBox количествоНазванийMax;
        private ToolStripMenuItem количествоТеговДляНазванияКласса;
        private ToolStripTextBox количествоТеговMin;
        private ToolStripTextBox количествоТеговMax;
        private ToolStripMenuItem количествоБезопасныхСвойствCSS;
        private ToolStripTextBox количествоСвойствMin;
        private ToolStripTextBox количествоСвойствMax;
        private ToolStripMenuItem menuДобавлениеАтрибутовStyle;
        private ToolStripMenuItem включитьДобавлениеStyle;
        private ToolStripMenuItem отключитьДобавлениеStyle;
        private ToolStripMenuItem количествоАтрибутовНаШаблон;
        private ToolStripTextBox количествоАтрибутовMin;
        private ToolStripTextBox количествоАтрибутовMax;
        private ToolStripMenuItem количествоБезопасныхСвойствCSSStyle;
        private ToolStripTextBox количествоСвойствCSSMin;
        private ToolStripTextBox количествоСвойствCSSMax;
        public ToolStripMenuItem menuLocalRandom;
        public ToolStripMenuItem настройкиToolStripMenuItem;
        public MenuStrip menuStrip1;
        private Button button2;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private ToolStripMenuItem количествоБезопасныхСвойствCSSInnerOuter;
        private ToolStripTextBox количествоСвойствCSSInnerOuterMin;
        private ToolStripTextBox количествоСвойствCSSInnerOuterMax;
        private Button button7;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
    }
}

