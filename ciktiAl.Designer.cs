namespace WindowsFormsApplication1
{
    partial class ciktiAl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ciktiAl));
            this.label1 = new System.Windows.Forms.Label();
            this.belgeTuruComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.makinaKoduTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.yazdirButon = new System.Windows.Forms.Button();
            this.adTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grupTextBox = new System.Windows.Forms.TextBox();
            this.birmTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Belge Türü";
            // 
            // belgeTuruComboBox
            // 
            this.belgeTuruComboBox.FormattingEnabled = true;
            this.belgeTuruComboBox.Items.AddRange(new object[] {
            "Sicil Kartı",
            "Operatörler İçin Bakım Talimatı",
            "Çalıştırma Talimatı",
            "Bakımcı İçin Bakım Talimatı"});
            this.belgeTuruComboBox.Location = new System.Drawing.Point(92, 13);
            this.belgeTuruComboBox.Name = "belgeTuruComboBox";
            this.belgeTuruComboBox.Size = new System.Drawing.Size(130, 21);
            this.belgeTuruComboBox.TabIndex = 1;
            this.belgeTuruComboBox.Text = "Seçiniz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ekipman Kodu";
            // 
            // makinaKoduTextBox
            // 
            this.makinaKoduTextBox.Enabled = false;
            this.makinaKoduTextBox.Location = new System.Drawing.Point(92, 43);
            this.makinaKoduTextBox.Name = "makinaKoduTextBox";
            this.makinaKoduTextBox.Size = new System.Drawing.Size(130, 20);
            this.makinaKoduTextBox.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.yazdirButon);
            this.panel1.Controls.Add(this.adTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.grupTextBox);
            this.panel1.Controls.Add(this.birmTextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(16, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 128);
            this.panel1.TabIndex = 5;
            // 
            // yazdirButon
            // 
            this.yazdirButon.Location = new System.Drawing.Point(152, 99);
            this.yazdirButon.Name = "yazdirButon";
            this.yazdirButon.Size = new System.Drawing.Size(72, 23);
            this.yazdirButon.TabIndex = 6;
            this.yazdirButon.Text = "Yazdır...";
            this.yazdirButon.UseVisualStyleBackColor = true;
            this.yazdirButon.Click += new System.EventHandler(this.yazdırButon_Click);
            // 
            // adTextBox
            // 
            this.adTextBox.Enabled = false;
            this.adTextBox.Location = new System.Drawing.Point(3, 63);
            this.adTextBox.Name = "adTextBox";
            this.adTextBox.Size = new System.Drawing.Size(221, 20);
            this.adTextBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ekipman Adı";
            // 
            // grupTextBox
            // 
            this.grupTextBox.Enabled = false;
            this.grupTextBox.Location = new System.Drawing.Point(124, 16);
            this.grupTextBox.Name = "grupTextBox";
            this.grupTextBox.Size = new System.Drawing.Size(100, 20);
            this.grupTextBox.TabIndex = 2;
            // 
            // birmTextBox
            // 
            this.birmTextBox.Enabled = false;
            this.birmTextBox.Location = new System.Drawing.Point(3, 16);
            this.birmTextBox.Name = "birmTextBox";
            this.birmTextBox.Size = new System.Drawing.Size(101, 20);
            this.birmTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ekipman Grubu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bulunduğu Birim";
            // 
            // ciktiAl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 206);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.makinaKoduTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.belgeTuruComboBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ciktiAl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yazdırma Ekranı";
            this.Load += new System.EventHandler(this.ciktiAl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox belgeTuruComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox makinaKoduTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox birmTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox adTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox grupTextBox;
        private System.Windows.Forms.Button yazdirButon;
    }
}