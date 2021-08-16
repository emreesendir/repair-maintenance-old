namespace WindowsFormsApplication1
{
    partial class isGecmisiListeleme
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(isGecmisiListeleme));
            this.label1 = new System.Windows.Forms.Label();
            this.ilkDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.sonDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.listeleButon = new System.Windows.Forms.Button();
            this.tarihTümüCheckBox = new System.Windows.Forms.CheckBox();
            this.atölyeCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.atölyeTümüCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.atölyePanel = new System.Windows.Forms.Panel();
            this.islemTürüPanel = new System.Windows.Forms.Panel();
            this.islemTürüCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.islemTürüTümüCheckBox = new System.Windows.Forms.CheckBox();
            this.ekipmanPanel = new System.Windows.Forms.Panel();
            this.araButon = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ekipmanAdıTextBox = new System.Windows.Forms.TextBox();
            this.birimTextBox = new System.Windows.Forms.TextBox();
            this.grupTextBox = new System.Windows.Forms.TextBox();
            this.ekipmanKoduTextBox = new System.Windows.Forms.TextBox();
            this.ekipmanCheckBox = new System.Windows.Forms.CheckBox();
            this.atölyePanel.SuspendLayout();
            this.islemTürüPanel.SuspendLayout();
            this.ekipmanPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tarih";
            // 
            // ilkDateTimePicker
            // 
            this.ilkDateTimePicker.Location = new System.Drawing.Point(12, 347);
            this.ilkDateTimePicker.Name = "ilkDateTimePicker";
            this.ilkDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.ilkDateTimePicker.TabIndex = 1;
            // 
            // sonDateTimePicker
            // 
            this.sonDateTimePicker.Location = new System.Drawing.Point(234, 347);
            this.sonDateTimePicker.Name = "sonDateTimePicker";
            this.sonDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.sonDateTimePicker.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "-";
            // 
            // listeleButon
            // 
            this.listeleButon.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.listeleButon.Location = new System.Drawing.Point(359, 377);
            this.listeleButon.Name = "listeleButon";
            this.listeleButon.Size = new System.Drawing.Size(75, 23);
            this.listeleButon.TabIndex = 2;
            this.listeleButon.Text = "Listele";
            this.listeleButon.UseVisualStyleBackColor = true;
            this.listeleButon.Click += new System.EventHandler(this.listeleButon_Click);
            // 
            // tarihTümüCheckBox
            // 
            this.tarihTümüCheckBox.AutoSize = true;
            this.tarihTümüCheckBox.Location = new System.Drawing.Point(12, 324);
            this.tarihTümüCheckBox.Name = "tarihTümüCheckBox";
            this.tarihTümüCheckBox.Size = new System.Drawing.Size(53, 17);
            this.tarihTümüCheckBox.TabIndex = 3;
            this.tarihTümüCheckBox.Text = "Tümü";
            this.tarihTümüCheckBox.UseVisualStyleBackColor = true;
            this.tarihTümüCheckBox.CheckedChanged += new System.EventHandler(this.tarihTümüCheckBox_CheckedChanged);
            // 
            // atölyeCheckedListBox
            // 
            this.atölyeCheckedListBox.FormattingEnabled = true;
            this.atölyeCheckedListBox.Location = new System.Drawing.Point(3, 47);
            this.atölyeCheckedListBox.Name = "atölyeCheckedListBox";
            this.atölyeCheckedListBox.Size = new System.Drawing.Size(181, 124);
            this.atölyeCheckedListBox.TabIndex = 4;
            // 
            // atölyeTümüCheckBox
            // 
            this.atölyeTümüCheckBox.AutoSize = true;
            this.atölyeTümüCheckBox.Location = new System.Drawing.Point(6, 24);
            this.atölyeTümüCheckBox.Name = "atölyeTümüCheckBox";
            this.atölyeTümüCheckBox.Size = new System.Drawing.Size(53, 17);
            this.atölyeTümüCheckBox.TabIndex = 5;
            this.atölyeTümüCheckBox.Text = "Tümü";
            this.atölyeTümüCheckBox.UseVisualStyleBackColor = true;
            this.atölyeTümüCheckBox.CheckedChanged += new System.EventHandler(this.atölyeTümüCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Atölyeler";
            // 
            // atölyePanel
            // 
            this.atölyePanel.Controls.Add(this.atölyeCheckedListBox);
            this.atölyePanel.Controls.Add(this.label3);
            this.atölyePanel.Controls.Add(this.atölyeTümüCheckBox);
            this.atölyePanel.Location = new System.Drawing.Point(12, 0);
            this.atölyePanel.Name = "atölyePanel";
            this.atölyePanel.Size = new System.Drawing.Size(217, 176);
            this.atölyePanel.TabIndex = 7;
            // 
            // islemTürüPanel
            // 
            this.islemTürüPanel.Controls.Add(this.islemTürüCheckedListBox);
            this.islemTürüPanel.Controls.Add(this.label5);
            this.islemTürüPanel.Controls.Add(this.islemTürüTümüCheckBox);
            this.islemTürüPanel.Location = new System.Drawing.Point(235, 0);
            this.islemTürüPanel.Name = "islemTürüPanel";
            this.islemTürüPanel.Size = new System.Drawing.Size(199, 176);
            this.islemTürüPanel.TabIndex = 8;
            // 
            // islemTürüCheckedListBox
            // 
            this.islemTürüCheckedListBox.FormattingEnabled = true;
            this.islemTürüCheckedListBox.Location = new System.Drawing.Point(3, 47);
            this.islemTürüCheckedListBox.Name = "islemTürüCheckedListBox";
            this.islemTürüCheckedListBox.Size = new System.Drawing.Size(179, 124);
            this.islemTürüCheckedListBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "İşlem Türü";
            // 
            // islemTürüTümüCheckBox
            // 
            this.islemTürüTümüCheckBox.AutoSize = true;
            this.islemTürüTümüCheckBox.Location = new System.Drawing.Point(6, 24);
            this.islemTürüTümüCheckBox.Name = "islemTürüTümüCheckBox";
            this.islemTürüTümüCheckBox.Size = new System.Drawing.Size(53, 17);
            this.islemTürüTümüCheckBox.TabIndex = 5;
            this.islemTürüTümüCheckBox.Text = "Tümü";
            this.islemTürüTümüCheckBox.UseVisualStyleBackColor = true;
            this.islemTürüTümüCheckBox.CheckedChanged += new System.EventHandler(this.islemTürüTümüCheckBox_CheckedChanged);
            // 
            // ekipmanPanel
            // 
            this.ekipmanPanel.Controls.Add(this.araButon);
            this.ekipmanPanel.Controls.Add(this.label9);
            this.ekipmanPanel.Controls.Add(this.label6);
            this.ekipmanPanel.Controls.Add(this.label10);
            this.ekipmanPanel.Controls.Add(this.label4);
            this.ekipmanPanel.Controls.Add(this.ekipmanAdıTextBox);
            this.ekipmanPanel.Controls.Add(this.birimTextBox);
            this.ekipmanPanel.Controls.Add(this.grupTextBox);
            this.ekipmanPanel.Controls.Add(this.ekipmanKoduTextBox);
            this.ekipmanPanel.Location = new System.Drawing.Point(12, 214);
            this.ekipmanPanel.Name = "ekipmanPanel";
            this.ekipmanPanel.Size = new System.Drawing.Size(422, 91);
            this.ekipmanPanel.TabIndex = 9;
            // 
            // araButon
            // 
            this.araButon.BackColor = System.Drawing.Color.Transparent;
            this.araButon.Image = global::WindowsFormsApplication1.Properties.Resources.indir3;
            this.araButon.Location = new System.Drawing.Point(106, 15);
            this.araButon.Name = "araButon";
            this.araButon.Size = new System.Drawing.Size(21, 22);
            this.araButon.TabIndex = 12;
            this.araButon.UseVisualStyleBackColor = false;
            this.araButon.Click += new System.EventHandler(this.araButon_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(-3, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Ekipman Adı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Birim";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(289, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Grup";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-3, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ekipman Kodu";
            // 
            // ekipmanAdıTextBox
            // 
            this.ekipmanAdıTextBox.Enabled = false;
            this.ekipmanAdıTextBox.Location = new System.Drawing.Point(0, 59);
            this.ekipmanAdıTextBox.Name = "ekipmanAdıTextBox";
            this.ekipmanAdıTextBox.Size = new System.Drawing.Size(419, 20);
            this.ekipmanAdıTextBox.TabIndex = 6;
            // 
            // birimTextBox
            // 
            this.birimTextBox.Enabled = false;
            this.birimTextBox.Location = new System.Drawing.Point(159, 17);
            this.birimTextBox.Name = "birimTextBox";
            this.birimTextBox.Size = new System.Drawing.Size(127, 20);
            this.birimTextBox.TabIndex = 7;
            // 
            // grupTextBox
            // 
            this.grupTextBox.Enabled = false;
            this.grupTextBox.Location = new System.Drawing.Point(292, 17);
            this.grupTextBox.Name = "grupTextBox";
            this.grupTextBox.Size = new System.Drawing.Size(127, 20);
            this.grupTextBox.TabIndex = 7;
            // 
            // ekipmanKoduTextBox
            // 
            this.ekipmanKoduTextBox.Location = new System.Drawing.Point(0, 17);
            this.ekipmanKoduTextBox.Name = "ekipmanKoduTextBox";
            this.ekipmanKoduTextBox.Size = new System.Drawing.Size(100, 20);
            this.ekipmanKoduTextBox.TabIndex = 8;
            this.ekipmanKoduTextBox.TextChanged += new System.EventHandler(this.ekipmanKoduTextBox_TextChanged);
            // 
            // ekipmanCheckBox
            // 
            this.ekipmanCheckBox.AutoSize = true;
            this.ekipmanCheckBox.Location = new System.Drawing.Point(12, 191);
            this.ekipmanCheckBox.Name = "ekipmanCheckBox";
            this.ekipmanCheckBox.Size = new System.Drawing.Size(67, 17);
            this.ekipmanCheckBox.TabIndex = 10;
            this.ekipmanCheckBox.Text = "Ekipman";
            this.ekipmanCheckBox.UseVisualStyleBackColor = true;
            this.ekipmanCheckBox.CheckedChanged += new System.EventHandler(this.ekipmanCheckBox_CheckedChanged);
            // 
            // isGecmisiListeleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 412);
            this.Controls.Add(this.ekipmanCheckBox);
            this.Controls.Add(this.ekipmanPanel);
            this.Controls.Add(this.islemTürüPanel);
            this.Controls.Add(this.atölyePanel);
            this.Controls.Add(this.tarihTümüCheckBox);
            this.Controls.Add(this.listeleButon);
            this.Controls.Add(this.sonDateTimePicker);
            this.Controls.Add(this.ilkDateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "isGecmisiListeleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İş Gecmişi Listeleme Seçenekleri";
            this.Load += new System.EventHandler(this.isGecmisiListeleme_Load);
            this.atölyePanel.ResumeLayout(false);
            this.atölyePanel.PerformLayout();
            this.islemTürüPanel.ResumeLayout(false);
            this.islemTürüPanel.PerformLayout();
            this.ekipmanPanel.ResumeLayout(false);
            this.ekipmanPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ilkDateTimePicker;
        private System.Windows.Forms.DateTimePicker sonDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button listeleButon;
        private System.Windows.Forms.CheckBox tarihTümüCheckBox;
        private System.Windows.Forms.CheckedListBox atölyeCheckedListBox;
        private System.Windows.Forms.CheckBox atölyeTümüCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel atölyePanel;
        private System.Windows.Forms.Panel islemTürüPanel;
        private System.Windows.Forms.CheckedListBox islemTürüCheckedListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox islemTürüTümüCheckBox;
        private System.Windows.Forms.Panel ekipmanPanel;
        private System.Windows.Forms.CheckBox ekipmanCheckBox;
        private System.Windows.Forms.Button araButon;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ekipmanAdıTextBox;
        private System.Windows.Forms.TextBox birimTextBox;
        private System.Windows.Forms.TextBox grupTextBox;
        private System.Windows.Forms.TextBox ekipmanKoduTextBox;
    }
}