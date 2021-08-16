namespace WindowsFormsApplication1
{
    partial class bakımYönetimi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bakımYönetimi));
            this.yeriLabel = new System.Windows.Forms.Label();
            this.yeriTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ekleDuzenleButon = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.yerNoTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.kriterTextBox = new System.Windows.Forms.TextBox();
            this.metodLabel = new System.Windows.Forms.Label();
            this.metodTextBox = new System.Windows.Forms.TextBox();
            this.aracLabel = new System.Windows.Forms.Label();
            this.aracTextBox = new System.Windows.Forms.TextBox();
            this.periyotComboBox = new System.Windows.Forms.ComboBox();
            this.turComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yeriLabel
            // 
            this.yeriLabel.AutoSize = true;
            this.yeriLabel.Location = new System.Drawing.Point(52, 60);
            this.yeriLabel.Name = "yeriLabel";
            this.yeriLabel.Size = new System.Drawing.Size(25, 13);
            this.yeriLabel.TabIndex = 0;
            this.yeriLabel.Text = "Yeri";
            // 
            // yeriTextBox
            // 
            this.yeriTextBox.Location = new System.Drawing.Point(55, 76);
            this.yeriTextBox.Name = "yeriTextBox";
            this.yeriTextBox.Size = new System.Drawing.Size(150, 20);
            this.yeriTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Periyot";
            // 
            // ekleDuzenleButon
            // 
            this.ekleDuzenleButon.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.ekleDuzenleButon.Location = new System.Drawing.Point(146, 227);
            this.ekleDuzenleButon.Name = "ekleDuzenleButon";
            this.ekleDuzenleButon.Size = new System.Drawing.Size(59, 22);
            this.ekleDuzenleButon.TabIndex = 8;
            this.ekleDuzenleButon.Text = "button1";
            this.ekleDuzenleButon.UseVisualStyleBackColor = true;
            this.ekleDuzenleButon.Click += new System.EventHandler(this.ekleDuzenleButon_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Yer No";
            // 
            // yerNoTextBox
            // 
            this.yerNoTextBox.Location = new System.Drawing.Point(12, 76);
            this.yerNoTextBox.Name = "yerNoTextBox";
            this.yerNoTextBox.Size = new System.Drawing.Size(37, 20);
            this.yerNoTextBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Kriter";
            // 
            // kriterTextBox
            // 
            this.kriterTextBox.Location = new System.Drawing.Point(12, 117);
            this.kriterTextBox.Name = "kriterTextBox";
            this.kriterTextBox.Size = new System.Drawing.Size(193, 20);
            this.kriterTextBox.TabIndex = 5;
            // 
            // metodLabel
            // 
            this.metodLabel.AutoSize = true;
            this.metodLabel.Location = new System.Drawing.Point(9, 141);
            this.metodLabel.Name = "metodLabel";
            this.metodLabel.Size = new System.Drawing.Size(37, 13);
            this.metodLabel.TabIndex = 0;
            this.metodLabel.Text = "Metod";
            // 
            // metodTextBox
            // 
            this.metodTextBox.Location = new System.Drawing.Point(12, 157);
            this.metodTextBox.Name = "metodTextBox";
            this.metodTextBox.Size = new System.Drawing.Size(193, 20);
            this.metodTextBox.TabIndex = 6;
            // 
            // aracLabel
            // 
            this.aracLabel.AutoSize = true;
            this.aracLabel.Location = new System.Drawing.Point(9, 182);
            this.aracLabel.Name = "aracLabel";
            this.aracLabel.Size = new System.Drawing.Size(87, 13);
            this.aracLabel.TabIndex = 0;
            this.aracLabel.Text = "Araç ve Gereçler";
            // 
            // aracTextBox
            // 
            this.aracTextBox.Location = new System.Drawing.Point(12, 198);
            this.aracTextBox.Name = "aracTextBox";
            this.aracTextBox.Size = new System.Drawing.Size(193, 20);
            this.aracTextBox.TabIndex = 7;
            // 
            // periyotComboBox
            // 
            this.periyotComboBox.FormattingEnabled = true;
            this.periyotComboBox.Items.AddRange(new object[] {
            "G",
            "H",
            "A",
            "3A",
            "6A",
            "Y"});
            this.periyotComboBox.Location = new System.Drawing.Point(12, 34);
            this.periyotComboBox.Name = "periyotComboBox";
            this.periyotComboBox.Size = new System.Drawing.Size(88, 21);
            this.periyotComboBox.TabIndex = 1;
            this.periyotComboBox.Text = "Seçiniz";
            // 
            // turComboBox
            // 
            this.turComboBox.FormattingEnabled = true;
            this.turComboBox.Items.AddRange(new object[] {
            "Temizlik",
            "Yağlama",
            "Kontrol"});
            this.turComboBox.Location = new System.Drawing.Point(106, 34);
            this.turComboBox.Name = "turComboBox";
            this.turComboBox.Size = new System.Drawing.Size(99, 21);
            this.turComboBox.TabIndex = 2;
            this.turComboBox.Text = "Seçiniz";
            this.turComboBox.SelectedIndexChanged += new System.EventHandler(this.turComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(103, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Tür";
            // 
            // bakımYönetimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 262);
            this.Controls.Add(this.turComboBox);
            this.Controls.Add(this.periyotComboBox);
            this.Controls.Add(this.ekleDuzenleButon);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.yerNoTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.aracTextBox);
            this.Controls.Add(this.aracLabel);
            this.Controls.Add(this.metodTextBox);
            this.Controls.Add(this.metodLabel);
            this.Controls.Add(this.kriterTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yeriTextBox);
            this.Controls.Add(this.yeriLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "bakımYönetimi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bakım Yönetimi";
            this.Load += new System.EventHandler(this.bakımYönetimi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label yeriLabel;
        private System.Windows.Forms.TextBox yeriTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ekleDuzenleButon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox yerNoTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox kriterTextBox;
        private System.Windows.Forms.Label metodLabel;
        private System.Windows.Forms.TextBox metodTextBox;
        private System.Windows.Forms.Label aracLabel;
        private System.Windows.Forms.TextBox aracTextBox;
        private System.Windows.Forms.ComboBox periyotComboBox;
        private System.Windows.Forms.ComboBox turComboBox;
        private System.Windows.Forms.Label label7;
    }
}