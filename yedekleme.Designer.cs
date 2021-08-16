namespace WindowsFormsApplication1
{
    partial class yedekleme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(yedekleme));
            this.yedekleCheckBox = new System.Windows.Forms.CheckBox();
            this.aktarCheckBox = new System.Windows.Forms.CheckBox();
            this.yedekleButon = new System.Windows.Forms.Button();
            this.aktarTextBox = new System.Windows.Forms.TextBox();
            this.aktarBrowseButon = new System.Windows.Forms.Button();
            this.aktarButon = new System.Windows.Forms.Button();
            this.yedekBrowseButon = new System.Windows.Forms.Button();
            this.yedekleTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // yedekleCheckBox
            // 
            this.yedekleCheckBox.AutoSize = true;
            this.yedekleCheckBox.Checked = true;
            this.yedekleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.yedekleCheckBox.Location = new System.Drawing.Point(12, 12);
            this.yedekleCheckBox.Name = "yedekleCheckBox";
            this.yedekleCheckBox.Size = new System.Drawing.Size(65, 17);
            this.yedekleCheckBox.TabIndex = 0;
            this.yedekleCheckBox.Text = "Yedekle";
            this.yedekleCheckBox.UseVisualStyleBackColor = true;
            // 
            // aktarCheckBox
            // 
            this.aktarCheckBox.AutoSize = true;
            this.aktarCheckBox.Enabled = false;
            this.aktarCheckBox.Location = new System.Drawing.Point(12, 105);
            this.aktarCheckBox.Name = "aktarCheckBox";
            this.aktarCheckBox.Size = new System.Drawing.Size(69, 17);
            this.aktarCheckBox.TabIndex = 0;
            this.aktarCheckBox.Text = "İçe Aktar";
            this.aktarCheckBox.UseVisualStyleBackColor = true;
            // 
            // yedekleButon
            // 
            this.yedekleButon.Location = new System.Drawing.Point(197, 66);
            this.yedekleButon.Name = "yedekleButon";
            this.yedekleButon.Size = new System.Drawing.Size(75, 23);
            this.yedekleButon.TabIndex = 1;
            this.yedekleButon.Text = "Yedekle";
            this.yedekleButon.UseVisualStyleBackColor = true;
            this.yedekleButon.Click += new System.EventHandler(this.yedekleButon_Click);
            // 
            // aktarTextBox
            // 
            this.aktarTextBox.Enabled = false;
            this.aktarTextBox.Location = new System.Drawing.Point(12, 128);
            this.aktarTextBox.Name = "aktarTextBox";
            this.aktarTextBox.Size = new System.Drawing.Size(228, 20);
            this.aktarTextBox.TabIndex = 2;
            this.aktarTextBox.Text = "C:\\Program Files\\Basak BOS v1.0\\BackupFiles";
            // 
            // aktarBrowseButon
            // 
            this.aktarBrowseButon.Enabled = false;
            this.aktarBrowseButon.Location = new System.Drawing.Point(246, 127);
            this.aktarBrowseButon.Name = "aktarBrowseButon";
            this.aktarBrowseButon.Size = new System.Drawing.Size(26, 20);
            this.aktarBrowseButon.TabIndex = 1;
            this.aktarBrowseButon.Text = "...";
            this.aktarBrowseButon.UseVisualStyleBackColor = true;
            // 
            // aktarButon
            // 
            this.aktarButon.Enabled = false;
            this.aktarButon.Location = new System.Drawing.Point(197, 161);
            this.aktarButon.Name = "aktarButon";
            this.aktarButon.Size = new System.Drawing.Size(75, 23);
            this.aktarButon.TabIndex = 1;
            this.aktarButon.Text = "Aktar";
            this.aktarButon.UseVisualStyleBackColor = true;
            // 
            // yedekBrowseButon
            // 
            this.yedekBrowseButon.Location = new System.Drawing.Point(246, 34);
            this.yedekBrowseButon.Name = "yedekBrowseButon";
            this.yedekBrowseButon.Size = new System.Drawing.Size(26, 20);
            this.yedekBrowseButon.TabIndex = 1;
            this.yedekBrowseButon.Text = "...";
            this.yedekBrowseButon.UseVisualStyleBackColor = true;
            // 
            // yedekleTextBox
            // 
            this.yedekleTextBox.Enabled = false;
            this.yedekleTextBox.Location = new System.Drawing.Point(12, 35);
            this.yedekleTextBox.Name = "yedekleTextBox";
            this.yedekleTextBox.Size = new System.Drawing.Size(228, 20);
            this.yedekleTextBox.TabIndex = 2;
            this.yedekleTextBox.Text = "C:\\Program Files\\Basak BOS v1.0\\BackupFiles";
            // 
            // yedekleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 200);
            this.Controls.Add(this.yedekleTextBox);
            this.Controls.Add(this.aktarTextBox);
            this.Controls.Add(this.yedekBrowseButon);
            this.Controls.Add(this.aktarButon);
            this.Controls.Add(this.aktarBrowseButon);
            this.Controls.Add(this.yedekleButon);
            this.Controls.Add(this.aktarCheckBox);
            this.Controls.Add(this.yedekleCheckBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "yedekleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yedekleme";
            this.Load += new System.EventHandler(this.yedekleme_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox yedekleCheckBox;
        private System.Windows.Forms.CheckBox aktarCheckBox;
        private System.Windows.Forms.Button yedekleButon;
        private System.Windows.Forms.TextBox aktarTextBox;
        private System.Windows.Forms.Button aktarBrowseButon;
        private System.Windows.Forms.Button aktarButon;
        private System.Windows.Forms.Button yedekBrowseButon;
        private System.Windows.Forms.TextBox yedekleTextBox;
    }
}