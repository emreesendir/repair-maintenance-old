namespace WindowsFormsApplication1
{
    partial class isTalebiDüzenle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(isTalebiDüzenle));
            this.label1 = new System.Windows.Forms.Label();
            this.kaydetButon = new System.Windows.Forms.Button();
            this.islemTuruComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ekipmanAdıTextBox = new System.Windows.Forms.TextBox();
            this.isTanımıTextBox = new System.Windows.Forms.TextBox();
            this.sorumluTextBox = new System.Windows.Forms.TextBox();
            this.birimTextBox = new System.Windows.Forms.TextBox();
            this.ekipmanKoduTextBox = new System.Windows.Forms.TextBox();
            this.talepEdenTextBox = new System.Windows.Forms.TextBox();
            this.bitisTarihiDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.kayıtTarihiDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.araButon = new System.Windows.Forms.Button();
            this.silButon = new System.Windows.Forms.Button();
            this.arızaComboBox = new System.Windows.Forms.ComboBox();
            this.arızaLabel = new System.Windows.Forms.Label();
            this.durusLabel = new System.Windows.Forms.Label();
            this.durusTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "İş Talebi Formu";
            // 
            // kaydetButon
            // 
            this.kaydetButon.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.kaydetButon.Location = new System.Drawing.Point(382, 250);
            this.kaydetButon.Name = "kaydetButon";
            this.kaydetButon.Size = new System.Drawing.Size(75, 23);
            this.kaydetButon.TabIndex = 6;
            this.kaydetButon.Text = "Kaydet";
            this.kaydetButon.UseVisualStyleBackColor = true;
            this.kaydetButon.Click += new System.EventHandler(this.kaydetButon_Click);
            // 
            // islemTuruComboBox
            // 
            this.islemTuruComboBox.FormattingEnabled = true;
            this.islemTuruComboBox.Items.AddRange(new object[] {
            "Bakım",
            "Onarım",
            "Revizyon",
            "Öneri"});
            this.islemTuruComboBox.Location = new System.Drawing.Point(3, 73);
            this.islemTuruComboBox.Name = "islemTuruComboBox";
            this.islemTuruComboBox.Size = new System.Drawing.Size(121, 21);
            this.islemTuruComboBox.TabIndex = 4;
            this.islemTuruComboBox.SelectedIndexChanged += new System.EventHandler(this.islemTuruComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(150, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Ekipman Adı";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "İşlem Türü";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "İş Tanımı";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(131, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Sorumlu";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(0, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Birim";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ekipman Kodu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Talep Eden";
            // 
            // ekipmanAdıTextBox
            // 
            this.ekipmanAdıTextBox.Enabled = false;
            this.ekipmanAdıTextBox.Location = new System.Drawing.Point(153, 170);
            this.ekipmanAdıTextBox.Name = "ekipmanAdıTextBox";
            this.ekipmanAdıTextBox.Size = new System.Drawing.Size(304, 20);
            this.ekipmanAdıTextBox.TabIndex = 2;
            // 
            // isTanımıTextBox
            // 
            this.isTanımıTextBox.Location = new System.Drawing.Point(3, 224);
            this.isTanımıTextBox.Name = "isTanımıTextBox";
            this.isTanımıTextBox.Size = new System.Drawing.Size(454, 20);
            this.isTanımıTextBox.TabIndex = 2;
            // 
            // sorumluTextBox
            // 
            this.sorumluTextBox.Location = new System.Drawing.Point(134, 26);
            this.sorumluTextBox.Name = "sorumluTextBox";
            this.sorumluTextBox.Size = new System.Drawing.Size(117, 20);
            this.sorumluTextBox.TabIndex = 2;
            // 
            // birimTextBox
            // 
            this.birimTextBox.Enabled = false;
            this.birimTextBox.Location = new System.Drawing.Point(3, 170);
            this.birimTextBox.Name = "birimTextBox";
            this.birimTextBox.Size = new System.Drawing.Size(127, 20);
            this.birimTextBox.TabIndex = 2;
            // 
            // ekipmanKoduTextBox
            // 
            this.ekipmanKoduTextBox.Location = new System.Drawing.Point(3, 131);
            this.ekipmanKoduTextBox.Name = "ekipmanKoduTextBox";
            this.ekipmanKoduTextBox.Size = new System.Drawing.Size(100, 20);
            this.ekipmanKoduTextBox.TabIndex = 2;
            this.ekipmanKoduTextBox.TextChanged += new System.EventHandler(this.ekipmanKoduTextBox_TextChanged);
            // 
            // talepEdenTextBox
            // 
            this.talepEdenTextBox.Location = new System.Drawing.Point(3, 26);
            this.talepEdenTextBox.Name = "talepEdenTextBox";
            this.talepEdenTextBox.Size = new System.Drawing.Size(121, 20);
            this.talepEdenTextBox.TabIndex = 2;
            // 
            // bitisTarihiDateTimePicker
            // 
            this.bitisTarihiDateTimePicker.Location = new System.Drawing.Point(257, 74);
            this.bitisTarihiDateTimePicker.Name = "bitisTarihiDateTimePicker";
            this.bitisTarihiDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.bitisTarihiDateTimePicker.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Planlanan Bitiş Tarihi";
            // 
            // kayıtTarihiDateTimePicker
            // 
            this.kayıtTarihiDateTimePicker.Location = new System.Drawing.Point(257, 26);
            this.kayıtTarihiDateTimePicker.Name = "kayıtTarihiDateTimePicker";
            this.kayıtTarihiDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.kayıtTarihiDateTimePicker.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Kayıt Tarihi";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.arızaComboBox);
            this.panel1.Controls.Add(this.kaydetButon);
            this.panel1.Controls.Add(this.arızaLabel);
            this.panel1.Controls.Add(this.araButon);
            this.panel1.Controls.Add(this.durusLabel);
            this.panel1.Controls.Add(this.durusTextBox);
            this.panel1.Controls.Add(this.islemTuruComboBox);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ekipmanAdıTextBox);
            this.panel1.Controls.Add(this.isTanımıTextBox);
            this.panel1.Controls.Add(this.sorumluTextBox);
            this.panel1.Controls.Add(this.birimTextBox);
            this.panel1.Controls.Add(this.ekipmanKoduTextBox);
            this.panel1.Controls.Add(this.talepEdenTextBox);
            this.panel1.Controls.Add(this.bitisTarihiDateTimePicker);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.kayıtTarihiDateTimePicker);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(14, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 281);
            this.panel1.TabIndex = 2;
            // 
            // araButon
            // 
            this.araButon.BackColor = System.Drawing.Color.Transparent;
            this.araButon.Image = global::WindowsFormsApplication1.Properties.Resources.indir3;
            this.araButon.Location = new System.Drawing.Point(109, 129);
            this.araButon.Name = "araButon";
            this.araButon.Size = new System.Drawing.Size(21, 22);
            this.araButon.TabIndex = 5;
            this.araButon.UseVisualStyleBackColor = false;
            this.araButon.Click += new System.EventHandler(this.araButon_Click);
            // 
            // silButon
            // 
            this.silButon.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.silButon.Location = new System.Drawing.Point(448, 3);
            this.silButon.Name = "silButon";
            this.silButon.Size = new System.Drawing.Size(26, 20);
            this.silButon.TabIndex = 4;
            this.silButon.Text = "Sil";
            this.silButon.UseVisualStyleBackColor = true;
            this.silButon.Click += new System.EventHandler(this.silButon_Click);
            // 
            // arızaComboBox
            // 
            this.arızaComboBox.FormattingEnabled = true;
            this.arızaComboBox.Items.AddRange(new object[] {
            "Elektrik",
            "Mekanik"});
            this.arızaComboBox.Location = new System.Drawing.Point(199, 72);
            this.arızaComboBox.Name = "arızaComboBox";
            this.arızaComboBox.Size = new System.Drawing.Size(52, 21);
            this.arızaComboBox.TabIndex = 8;
            this.arızaComboBox.Text = "Seçiniz";
            this.arızaComboBox.Visible = false;
            // 
            // arızaLabel
            // 
            this.arızaLabel.AutoSize = true;
            this.arızaLabel.Location = new System.Drawing.Point(196, 57);
            this.arızaLabel.Name = "arızaLabel";
            this.arızaLabel.Size = new System.Drawing.Size(50, 13);
            this.arızaLabel.TabIndex = 6;
            this.arızaLabel.Text = "Arıza Tipi";
            this.arızaLabel.Visible = false;
            // 
            // durusLabel
            // 
            this.durusLabel.AutoSize = true;
            this.durusLabel.Location = new System.Drawing.Point(131, 58);
            this.durusLabel.Name = "durusLabel";
            this.durusLabel.Size = new System.Drawing.Size(62, 13);
            this.durusLabel.TabIndex = 7;
            this.durusLabel.Text = "Duruş Saati";
            this.durusLabel.Visible = false;
            // 
            // durusTextBox
            // 
            this.durusTextBox.Location = new System.Drawing.Point(134, 74);
            this.durusTextBox.Name = "durusTextBox";
            this.durusTextBox.Size = new System.Drawing.Size(59, 20);
            this.durusTextBox.TabIndex = 5;
            this.durusTextBox.Text = "00:00";
            this.durusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.durusTextBox.Visible = false;
            // 
            // isTalebiDüzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 316);
            this.Controls.Add(this.silButon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "isTalebiDüzenle";
            this.Text = "İş Talebi Düzenle";
            this.Load += new System.EventHandler(this.isTalebiDüzenle_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button kaydetButon;
        private System.Windows.Forms.Button araButon;
        private System.Windows.Forms.ComboBox islemTuruComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ekipmanAdıTextBox;
        private System.Windows.Forms.TextBox isTanımıTextBox;
        private System.Windows.Forms.TextBox sorumluTextBox;
        private System.Windows.Forms.TextBox birimTextBox;
        private System.Windows.Forms.TextBox ekipmanKoduTextBox;
        private System.Windows.Forms.TextBox talepEdenTextBox;
        private System.Windows.Forms.DateTimePicker bitisTarihiDateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker kayıtTarihiDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button silButon;
        private System.Windows.Forms.ComboBox arızaComboBox;
        private System.Windows.Forms.Label arızaLabel;
        private System.Windows.Forms.Label durusLabel;
        private System.Windows.Forms.TextBox durusTextBox;
    }
}