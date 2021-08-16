namespace WindowsFormsApplication1
{
    partial class makinaListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(makinaListesi));
            this.label1 = new System.Windows.Forms.Label();
            this.makinaListView = new System.Windows.Forms.ListView();
            this.filtereButon = new System.Windows.Forms.Button();
            this.detayButon = new System.Windows.Forms.Button();
            this.ekleButon = new System.Windows.Forms.Button();
            this.anaMenuButon = new System.Windows.Forms.Button();
            this.yenileButon = new System.Windows.Forms.Button();
            this.yazdırButon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ekipmanlar";
            // 
            // makinaListView
            // 
            this.makinaListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.makinaListView.Location = new System.Drawing.Point(21, 31);
            this.makinaListView.Name = "makinaListView";
            this.makinaListView.Size = new System.Drawing.Size(510, 278);
            this.makinaListView.TabIndex = 1;
            this.makinaListView.UseCompatibleStateImageBehavior = false;
            this.makinaListView.SelectedIndexChanged += new System.EventHandler(this.makinaListView_SelectedIndexChanged);
            // 
            // filtereButon
            // 
            this.filtereButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filtereButon.Location = new System.Drawing.Point(537, 60);
            this.filtereButon.Name = "filtereButon";
            this.filtereButon.Size = new System.Drawing.Size(75, 38);
            this.filtereButon.TabIndex = 2;
            this.filtereButon.Text = "Listeleme Seçenekleri";
            this.filtereButon.UseVisualStyleBackColor = true;
            this.filtereButon.Click += new System.EventHandler(this.filtereButon_Click);
            // 
            // detayButon
            // 
            this.detayButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.detayButon.Location = new System.Drawing.Point(537, 104);
            this.detayButon.Name = "detayButon";
            this.detayButon.Size = new System.Drawing.Size(75, 39);
            this.detayButon.TabIndex = 2;
            this.detayButon.Text = "Ekipman\r\nDetayları";
            this.detayButon.UseVisualStyleBackColor = true;
            this.detayButon.Click += new System.EventHandler(this.detayButon_Click);
            // 
            // ekleButon
            // 
            this.ekleButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ekleButon.Location = new System.Drawing.Point(537, 149);
            this.ekleButon.Name = "ekleButon";
            this.ekleButon.Size = new System.Drawing.Size(75, 36);
            this.ekleButon.TabIndex = 2;
            this.ekleButon.Text = "Ekipman\r\nEkle";
            this.ekleButon.UseVisualStyleBackColor = true;
            this.ekleButon.Click += new System.EventHandler(this.ekleButon_Click);
            // 
            // anaMenuButon
            // 
            this.anaMenuButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.anaMenuButon.Location = new System.Drawing.Point(537, 286);
            this.anaMenuButon.Name = "anaMenuButon";
            this.anaMenuButon.Size = new System.Drawing.Size(75, 23);
            this.anaMenuButon.TabIndex = 2;
            this.anaMenuButon.Text = "Ana Menü";
            this.anaMenuButon.UseVisualStyleBackColor = true;
            this.anaMenuButon.Click += new System.EventHandler(this.anaMenuButon_Click);
            // 
            // yenileButon
            // 
            this.yenileButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yenileButon.Location = new System.Drawing.Point(537, 31);
            this.yenileButon.Name = "yenileButon";
            this.yenileButon.Size = new System.Drawing.Size(75, 23);
            this.yenileButon.TabIndex = 2;
            this.yenileButon.Text = "Yenile";
            this.yenileButon.UseVisualStyleBackColor = true;
            this.yenileButon.Click += new System.EventHandler(this.yenileButon_Click);
            // 
            // yazdırButon
            // 
            this.yazdırButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yazdırButon.Location = new System.Drawing.Point(537, 191);
            this.yazdırButon.Name = "yazdırButon";
            this.yazdırButon.Size = new System.Drawing.Size(75, 35);
            this.yazdırButon.TabIndex = 3;
            this.yazdırButon.Text = "Word\'e Aktar";
            this.yazdırButon.UseVisualStyleBackColor = true;
            this.yazdırButon.Click += new System.EventHandler(this.yazdırButon_Click);
            // 
            // makinaListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.yazdırButon);
            this.Controls.Add(this.yenileButon);
            this.Controls.Add(this.anaMenuButon);
            this.Controls.Add(this.ekleButon);
            this.Controls.Add(this.detayButon);
            this.Controls.Add(this.filtereButon);
            this.Controls.Add(this.makinaListView);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "makinaListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ekipman Listesi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.makinaListesi_FormClosed);
            this.Load += new System.EventHandler(this.makinaListesi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView makinaListView;
        private System.Windows.Forms.Button filtereButon;
        private System.Windows.Forms.Button detayButon;
        private System.Windows.Forms.Button ekleButon;
        private System.Windows.Forms.Button anaMenuButon;
        private System.Windows.Forms.Button yenileButon;
        private System.Windows.Forms.Button yazdırButon;
    }
}