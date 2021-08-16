namespace WindowsFormsApplication1
{
    partial class sistemAyarları
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sistemAyarları));
            this.label1 = new System.Windows.Forms.Label();
            this.kullanıcıEkleButon = new System.Windows.Forms.Button();
            this.kullanıcıSilButon = new System.Windows.Forms.Button();
            this.kullanıcıDüzenleButon = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.birimEkleButon = new System.Windows.Forms.Button();
            this.birimSilButon = new System.Windows.Forms.Button();
            this.birimDüzenleButon = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.grupEkleButon = new System.Windows.Forms.Button();
            this.grupSilButon = new System.Windows.Forms.Button();
            this.grupDüzenleButon = new System.Windows.Forms.Button();
            this.yenileButon = new System.Windows.Forms.Button();
            this.anaMenuButon = new System.Windows.Forms.Button();
            this.kullanıcıListView = new System.Windows.Forms.ListView();
            this.sysLogButon = new System.Windows.Forms.Button();
            this.yedeklemeButon = new System.Windows.Forms.Button();
            this.birimListBox = new System.Windows.Forms.ListBox();
            this.grupListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Yönetimi";
            // 
            // kullanıcıEkleButon
            // 
            this.kullanıcıEkleButon.Location = new System.Drawing.Point(49, 259);
            this.kullanıcıEkleButon.Name = "kullanıcıEkleButon";
            this.kullanıcıEkleButon.Size = new System.Drawing.Size(52, 23);
            this.kullanıcıEkleButon.TabIndex = 2;
            this.kullanıcıEkleButon.TabStop = false;
            this.kullanıcıEkleButon.Text = "Ekle";
            this.kullanıcıEkleButon.UseVisualStyleBackColor = true;
            this.kullanıcıEkleButon.Click += new System.EventHandler(this.kullanıcıEkleButon_Click);
            // 
            // kullanıcıSilButon
            // 
            this.kullanıcıSilButon.Location = new System.Drawing.Point(107, 259);
            this.kullanıcıSilButon.Name = "kullanıcıSilButon";
            this.kullanıcıSilButon.Size = new System.Drawing.Size(53, 23);
            this.kullanıcıSilButon.TabIndex = 2;
            this.kullanıcıSilButon.TabStop = false;
            this.kullanıcıSilButon.Text = "Sil";
            this.kullanıcıSilButon.UseVisualStyleBackColor = true;
            this.kullanıcıSilButon.Click += new System.EventHandler(this.kullanıcıSilButon_Click);
            // 
            // kullanıcıDüzenleButon
            // 
            this.kullanıcıDüzenleButon.Location = new System.Drawing.Point(49, 288);
            this.kullanıcıDüzenleButon.Name = "kullanıcıDüzenleButon";
            this.kullanıcıDüzenleButon.Size = new System.Drawing.Size(111, 23);
            this.kullanıcıDüzenleButon.TabIndex = 2;
            this.kullanıcıDüzenleButon.TabStop = false;
            this.kullanıcıDüzenleButon.Text = "Düzenle";
            this.kullanıcıDüzenleButon.UseVisualStyleBackColor = true;
            this.kullanıcıDüzenleButon.Click += new System.EventHandler(this.kullanıcıDüzenleButon_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Birim Yönetimi";
            // 
            // birimEkleButon
            // 
            this.birimEkleButon.Location = new System.Drawing.Point(243, 259);
            this.birimEkleButon.Name = "birimEkleButon";
            this.birimEkleButon.Size = new System.Drawing.Size(52, 23);
            this.birimEkleButon.TabIndex = 2;
            this.birimEkleButon.TabStop = false;
            this.birimEkleButon.Text = "Ekle";
            this.birimEkleButon.UseVisualStyleBackColor = true;
            this.birimEkleButon.Click += new System.EventHandler(this.birimEkleButon_Click);
            // 
            // birimSilButon
            // 
            this.birimSilButon.Location = new System.Drawing.Point(301, 259);
            this.birimSilButon.Name = "birimSilButon";
            this.birimSilButon.Size = new System.Drawing.Size(53, 23);
            this.birimSilButon.TabIndex = 2;
            this.birimSilButon.TabStop = false;
            this.birimSilButon.Text = "Sil";
            this.birimSilButon.UseVisualStyleBackColor = true;
            this.birimSilButon.Click += new System.EventHandler(this.birimSilButon_Click);
            // 
            // birimDüzenleButon
            // 
            this.birimDüzenleButon.Location = new System.Drawing.Point(243, 288);
            this.birimDüzenleButon.Name = "birimDüzenleButon";
            this.birimDüzenleButon.Size = new System.Drawing.Size(111, 23);
            this.birimDüzenleButon.TabIndex = 2;
            this.birimDüzenleButon.TabStop = false;
            this.birimDüzenleButon.Text = "Düzenle";
            this.birimDüzenleButon.UseVisualStyleBackColor = true;
            this.birimDüzenleButon.Click += new System.EventHandler(this.birimDüzenleButon_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Makina Grubu Yönetimi";
            // 
            // grupEkleButon
            // 
            this.grupEkleButon.Location = new System.Drawing.Point(399, 259);
            this.grupEkleButon.Name = "grupEkleButon";
            this.grupEkleButon.Size = new System.Drawing.Size(52, 23);
            this.grupEkleButon.TabIndex = 2;
            this.grupEkleButon.TabStop = false;
            this.grupEkleButon.Text = "Ekle";
            this.grupEkleButon.UseVisualStyleBackColor = true;
            this.grupEkleButon.Click += new System.EventHandler(this.grupEkleButon_Click);
            // 
            // grupSilButon
            // 
            this.grupSilButon.Location = new System.Drawing.Point(457, 259);
            this.grupSilButon.Name = "grupSilButon";
            this.grupSilButon.Size = new System.Drawing.Size(53, 23);
            this.grupSilButon.TabIndex = 2;
            this.grupSilButon.TabStop = false;
            this.grupSilButon.Text = "Sil";
            this.grupSilButon.UseVisualStyleBackColor = true;
            this.grupSilButon.Click += new System.EventHandler(this.grupSilButon_Click);
            // 
            // grupDüzenleButon
            // 
            this.grupDüzenleButon.Location = new System.Drawing.Point(399, 288);
            this.grupDüzenleButon.Name = "grupDüzenleButon";
            this.grupDüzenleButon.Size = new System.Drawing.Size(111, 23);
            this.grupDüzenleButon.TabIndex = 2;
            this.grupDüzenleButon.TabStop = false;
            this.grupDüzenleButon.Text = "Düzenle";
            this.grupDüzenleButon.UseVisualStyleBackColor = true;
            this.grupDüzenleButon.Click += new System.EventHandler(this.grupDüzenleButon_Click);
            // 
            // yenileButon
            // 
            this.yenileButon.Location = new System.Drawing.Point(533, 33);
            this.yenileButon.Name = "yenileButon";
            this.yenileButon.Size = new System.Drawing.Size(81, 33);
            this.yenileButon.TabIndex = 2;
            this.yenileButon.TabStop = false;
            this.yenileButon.Text = "Yenile";
            this.yenileButon.UseVisualStyleBackColor = true;
            this.yenileButon.Click += new System.EventHandler(this.yenileButon_Click);
            // 
            // anaMenuButon
            // 
            this.anaMenuButon.Location = new System.Drawing.Point(533, 72);
            this.anaMenuButon.Name = "anaMenuButon";
            this.anaMenuButon.Size = new System.Drawing.Size(81, 33);
            this.anaMenuButon.TabIndex = 2;
            this.anaMenuButon.TabStop = false;
            this.anaMenuButon.Text = "Ana Menü";
            this.anaMenuButon.UseVisualStyleBackColor = true;
            this.anaMenuButon.Click += new System.EventHandler(this.anaMenuButon_Click);
            // 
            // kullanıcıListView
            // 
            this.kullanıcıListView.Location = new System.Drawing.Point(12, 29);
            this.kullanıcıListView.Name = "kullanıcıListView";
            this.kullanıcıListView.Size = new System.Drawing.Size(190, 225);
            this.kullanıcıListView.TabIndex = 3;
            this.kullanıcıListView.UseCompatibleStateImageBehavior = false;
            this.kullanıcıListView.SelectedIndexChanged += new System.EventHandler(this.kullanıcıListView_SelectedIndexChanged);
            // 
            // sysLogButon
            // 
            this.sysLogButon.Location = new System.Drawing.Point(533, 169);
            this.sysLogButon.Name = "sysLogButon";
            this.sysLogButon.Size = new System.Drawing.Size(81, 40);
            this.sysLogButon.TabIndex = 2;
            this.sysLogButon.TabStop = false;
            this.sysLogButon.Text = "Sistem Kayıtları";
            this.sysLogButon.UseVisualStyleBackColor = true;
            this.sysLogButon.Click += new System.EventHandler(this.sysLogButon_Click);
            // 
            // yedeklemeButon
            // 
            this.yedeklemeButon.Location = new System.Drawing.Point(533, 111);
            this.yedeklemeButon.Name = "yedeklemeButon";
            this.yedeklemeButon.Size = new System.Drawing.Size(81, 52);
            this.yedeklemeButon.TabIndex = 2;
            this.yedeklemeButon.TabStop = false;
            this.yedeklemeButon.Text = "Sistem Yedekleme/ İçe Aktarma";
            this.yedeklemeButon.UseVisualStyleBackColor = true;
            this.yedeklemeButon.Click += new System.EventHandler(this.yedeklemeButon_Click);
            // 
            // birimListBox
            // 
            this.birimListBox.FormattingEnabled = true;
            this.birimListBox.Location = new System.Drawing.Point(229, 29);
            this.birimListBox.Name = "birimListBox";
            this.birimListBox.Size = new System.Drawing.Size(130, 225);
            this.birimListBox.TabIndex = 4;
            this.birimListBox.SelectedIndexChanged += new System.EventHandler(this.birimListBox_SelectedIndexChanged);
            // 
            // grupListBox
            // 
            this.grupListBox.FormattingEnabled = true;
            this.grupListBox.Location = new System.Drawing.Point(384, 29);
            this.grupListBox.Name = "grupListBox";
            this.grupListBox.Size = new System.Drawing.Size(130, 225);
            this.grupListBox.TabIndex = 4;
            this.grupListBox.SelectedIndexChanged += new System.EventHandler(this.grupListBox_SelectedIndexChanged);
            // 
            // sistemAyarları
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.grupListBox);
            this.Controls.Add(this.birimListBox);
            this.Controls.Add(this.kullanıcıListView);
            this.Controls.Add(this.anaMenuButon);
            this.Controls.Add(this.sysLogButon);
            this.Controls.Add(this.yedeklemeButon);
            this.Controls.Add(this.yenileButon);
            this.Controls.Add(this.grupDüzenleButon);
            this.Controls.Add(this.birimDüzenleButon);
            this.Controls.Add(this.kullanıcıDüzenleButon);
            this.Controls.Add(this.grupSilButon);
            this.Controls.Add(this.birimSilButon);
            this.Controls.Add(this.kullanıcıSilButon);
            this.Controls.Add(this.grupEkleButon);
            this.Controls.Add(this.birimEkleButon);
            this.Controls.Add(this.kullanıcıEkleButon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "sistemAyarları";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistem Ayarları";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.sistemAyarları_FormClosed);
            this.Load += new System.EventHandler(this.sistemAyarları_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button kullanıcıEkleButon;
        private System.Windows.Forms.Button kullanıcıSilButon;
        private System.Windows.Forms.Button kullanıcıDüzenleButon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button birimEkleButon;
        private System.Windows.Forms.Button birimSilButon;
        private System.Windows.Forms.Button birimDüzenleButon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button grupEkleButon;
        private System.Windows.Forms.Button grupSilButon;
        private System.Windows.Forms.Button grupDüzenleButon;
        private System.Windows.Forms.Button anaMenuButon;
        private System.Windows.Forms.ListView kullanıcıListView;
        private System.Windows.Forms.Button sysLogButon;
        private System.Windows.Forms.Button yedeklemeButon;
        private System.Windows.Forms.ListBox birimListBox;
        private System.Windows.Forms.ListBox grupListBox;
        public System.Windows.Forms.Button yenileButon;
    }
}