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
            this.SuspendLayout();
            // 
            // OpenFolderButton
            // 
            this.OpenFolderButton.BackgroundImage = global::Pattern_generator.Properties.Resources.folder;
            this.OpenFolderButton.Location = new System.Drawing.Point(12, 23);
            this.OpenFolderButton.Name = "OpenFolderButton";
            this.OpenFolderButton.Size = new System.Drawing.Size(23, 35);
            this.OpenFolderButton.TabIndex = 1;
            this.OpenFolderButton.UseVisualStyleBackColor = true;
            this.OpenFolderButton.Click += new System.EventHandler(this.OpenFolderButton_Click);
            // 
            // OpenFolder
            // 
            this.OpenFolder.Location = new System.Drawing.Point(41, 31);
            this.OpenFolder.Name = "OpenFolder";
            this.OpenFolder.Size = new System.Drawing.Size(398, 20);
            this.OpenFolder.TabIndex = 3;
            this.OpenFolder.Text = "Выбор папки tpl c набором мастер-шаблонов";
            // 
            // RandSelectTemplateButton
            // 
            this.RandSelectTemplateButton.Enabled = false;
            this.RandSelectTemplateButton.Location = new System.Drawing.Point(12, 112);
            this.RandSelectTemplateButton.Name = "RandSelectTemplateButton";
            this.RandSelectTemplateButton.Size = new System.Drawing.Size(159, 29);
            this.RandSelectTemplateButton.TabIndex = 4;
            this.RandSelectTemplateButton.Text = "Выбор мастер-шаблона:";
            this.RandSelectTemplateButton.UseVisualStyleBackColor = true;
            this.RandSelectTemplateButton.Click += new System.EventHandler(this.RandSelectTemplateButton_Click);
            // 
            // RandSelectTemplate
            // 
            this.RandSelectTemplate.Location = new System.Drawing.Point(177, 117);
            this.RandSelectTemplate.Name = "RandSelectTemplate";
            this.RandSelectTemplate.Size = new System.Drawing.Size(262, 20);
            this.RandSelectTemplate.TabIndex = 5;
            // 
            // SaveFolderButton
            // 
            this.SaveFolderButton.BackgroundImage = global::Pattern_generator.Properties.Resources.folder;
            this.SaveFolderButton.Location = new System.Drawing.Point(12, 64);
            this.SaveFolderButton.Name = "SaveFolderButton";
            this.SaveFolderButton.Size = new System.Drawing.Size(23, 35);
            this.SaveFolderButton.TabIndex = 6;
            this.SaveFolderButton.UseVisualStyleBackColor = true;
            this.SaveFolderButton.Click += new System.EventHandler(this.SaveFolderButton_Click);
            // 
            // SaveFolder
            // 
            this.SaveFolder.Location = new System.Drawing.Point(41, 72);
            this.SaveFolder.Name = "SaveFolder";
            this.SaveFolder.Size = new System.Drawing.Size(398, 20);
            this.SaveFolder.TabIndex = 7;
            this.SaveFolder.Text = "Папка для сохранения результирующих шаблонов";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 52);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(140, 171);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(386, 373);
            this.textBox4.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 431);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SaveFolder);
            this.Controls.Add(this.SaveFolderButton);
            this.Controls.Add(this.RandSelectTemplate);
            this.Controls.Add(this.RandSelectTemplateButton);
            this.Controls.Add(this.OpenFolder);
            this.Controls.Add(this.OpenFolderButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Pattern generator";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

