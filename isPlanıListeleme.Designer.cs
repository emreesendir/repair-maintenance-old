namespace WindowsFormsApplication1
{
    partial class isPlanıListeleme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(isPlanıListeleme));
            this.dBakımCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ileriTarihDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.listeleButon = new System.Windows.Forms.Button();
            this.yapilmamisCheckBox = new System.Windows.Forms.CheckBox();
            this.pGosterCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dBakımCheckBox
            // 
            this.dBakımCheckBox.AutoSize = true;
            this.dBakımCheckBox.Location = new System.Drawing.Point(27, 87);
            this.dBakımCheckBox.Name = "dBakımCheckBox";
            this.dBakımCheckBox.Size = new System.Drawing.Size(130, 17);
            this.dBakımCheckBox.TabIndex = 1;
            this.dBakımCheckBox.Text = "Diğer Bakımları Göster";
            this.dBakımCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tarih";
            // 
            // ileriTarihDateTimePicker
            // 
            this.ileriTarihDateTimePicker.Location = new System.Drawing.Point(12, 128);
            this.ileriTarihDateTimePicker.Name = "ileriTarihDateTimePicker";
            this.ileriTarihDateTimePicker.Size = new System.Drawing.Size(175, 20);
            this.ileriTarihDateTimePicker.TabIndex = 3;
            // 
            // listeleButon
            // 
            this.listeleButon.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.listeleButon.Location = new System.Drawing.Point(222, 176);
            this.listeleButon.Name = "listeleButon";
            this.listeleButon.Size = new System.Drawing.Size(75, 23);
            this.listeleButon.TabIndex = 4;
            this.listeleButon.Text = "Listele";
            this.listeleButon.UseVisualStyleBackColor = true;
            this.listeleButon.Click += new System.EventHandler(this.listeleButon_Click);
            // 
            // yapilmamisCheckBox
            // 
            this.yapilmamisCheckBox.AutoSize = true;
            this.yapilmamisCheckBox.Location = new System.Drawing.Point(42, 57);
            this.yapilmamisCheckBox.Name = "yapilmamisCheckBox";
            this.yapilmamisCheckBox.Size = new System.Drawing.Size(196, 17);
            this.yapilmamisCheckBox.TabIndex = 2;
            this.yapilmamisCheckBox.Text = "Hiç bakım yapılmamış kayıtları göster";
            this.yapilmamisCheckBox.UseVisualStyleBackColor = true;
            // 
            // pGosterCheckBox
            // 
            this.pGosterCheckBox.AutoSize = true;
            this.pGosterCheckBox.Location = new System.Drawing.Point(27, 35);
            this.pGosterCheckBox.Name = "pGosterCheckBox";
            this.pGosterCheckBox.Size = new System.Drawing.Size(148, 17);
            this.pGosterCheckBox.TabIndex = 1;
            this.pGosterCheckBox.Text = "Periyodik Bakımları Göster";
            this.pGosterCheckBox.UseVisualStyleBackColor = true;
            this.pGosterCheckBox.CheckedChanged += new System.EventHandler(this.pGosterCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bakım Listeleme Seçenekleri";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "tarihine kadar yapılacak işleri göster.";
            // 
            // isPlanıListeleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 211);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yapilmamisCheckBox);
            this.Controls.Add(this.listeleButon);
            this.Controls.Add(this.ileriTarihDateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dBakımCheckBox);
            this.Controls.Add(this.pGosterCheckBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "isPlanıListeleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İş Planı Listeleme Seçenekleri";
            this.Load += new System.EventHandler(this.isPlanıListeleme_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox dBakımCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker ileriTarihDateTimePicker;
        private System.Windows.Forms.Button listeleButon;
        private System.Windows.Forms.CheckBox yapilmamisCheckBox;
        private System.Windows.Forms.CheckBox pGosterCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}