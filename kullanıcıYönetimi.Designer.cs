namespace WindowsFormsApplication1
{
    partial class kullanıcıYönetimi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kullanıcıYönetimi));
            this.baslikLabel = new System.Windows.Forms.Label();
            this.sifreTextBox = new System.Windows.Forms.TextBox();
            this.kAdıTextBox = new System.Windows.Forms.TextBox();
            this.yetkiComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ekleDuzenleButon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // baslikLabel
            // 
            this.baslikLabel.AutoSize = true;
            this.baslikLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.baslikLabel.Location = new System.Drawing.Point(12, 9);
            this.baslikLabel.Name = "baslikLabel";
            this.baslikLabel.Size = new System.Drawing.Size(41, 13);
            this.baslikLabel.TabIndex = 0;
            this.baslikLabel.Text = "label1";
            // 
            // sifreTextBox
            // 
            this.sifreTextBox.Location = new System.Drawing.Point(150, 50);
            this.sifreTextBox.Name = "sifreTextBox";
            this.sifreTextBox.Size = new System.Drawing.Size(100, 20);
            this.sifreTextBox.TabIndex = 1;
            // 
            // kAdıTextBox
            // 
            this.kAdıTextBox.Location = new System.Drawing.Point(12, 50);
            this.kAdıTextBox.Name = "kAdıTextBox";
            this.kAdıTextBox.Size = new System.Drawing.Size(100, 20);
            this.kAdıTextBox.TabIndex = 1;
            // 
            // yetkiComboBox
            // 
            this.yetkiComboBox.FormattingEnabled = true;
            this.yetkiComboBox.Items.AddRange(new object[] {
            "Sistem Yöneticisi",
            "Yönetici",
            "Kullanıcı"});
            this.yetkiComboBox.Location = new System.Drawing.Point(12, 102);
            this.yetkiComboBox.Name = "yetkiComboBox";
            this.yetkiComboBox.Size = new System.Drawing.Size(121, 21);
            this.yetkiComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Yetki";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kullanıcı Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Şifre";
            // 
            // ekleDuzenleButon
            // 
            this.ekleDuzenleButon.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.ekleDuzenleButon.Location = new System.Drawing.Point(172, 100);
            this.ekleDuzenleButon.Name = "ekleDuzenleButon";
            this.ekleDuzenleButon.Size = new System.Drawing.Size(78, 23);
            this.ekleDuzenleButon.TabIndex = 4;
            this.ekleDuzenleButon.Text = "ekle/duzenle";
            this.ekleDuzenleButon.UseVisualStyleBackColor = true;
            this.ekleDuzenleButon.Click += new System.EventHandler(this.ekleDuzenleButon_Click);
            // 
            // kullanıcıYönetimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 149);
            this.Controls.Add(this.ekleDuzenleButon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yetkiComboBox);
            this.Controls.Add(this.kAdıTextBox);
            this.Controls.Add(this.sifreTextBox);
            this.Controls.Add(this.baslikLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "kullanıcıYönetimi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Yönetimi";
            this.Load += new System.EventHandler(this.kullanıcıYönetimi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label baslikLabel;
        private System.Windows.Forms.TextBox sifreTextBox;
        private System.Windows.Forms.TextBox kAdıTextBox;
        private System.Windows.Forms.ComboBox yetkiComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ekleDuzenleButon;
    }
}