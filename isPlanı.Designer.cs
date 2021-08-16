namespace WindowsFormsApplication1
{
    partial class isPlanı
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(isPlanı));
            this.isListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.talepEkleButon = new System.Windows.Forms.Button();
            this.talebiDüzenleButon = new System.Windows.Forms.Button();
            this.sonucButon = new System.Windows.Forms.Button();
            this.yazdırButon = new System.Windows.Forms.Button();
            this.listelemeButon = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.yenileButon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // isListView
            // 
            this.isListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.isListView.Location = new System.Drawing.Point(12, 21);
            this.isListView.Name = "isListView";
            this.isListView.Size = new System.Drawing.Size(510, 290);
            this.isListView.TabIndex = 0;
            this.isListView.UseCompatibleStateImageBehavior = false;
            this.isListView.SelectedIndexChanged += new System.EventHandler(this.isListView_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "İş Planı";
            // 
            // talepEkleButon
            // 
            this.talepEkleButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.talepEkleButon.Location = new System.Drawing.Point(537, 92);
            this.talepEkleButon.Name = "talepEkleButon";
            this.talepEkleButon.Size = new System.Drawing.Size(75, 34);
            this.talepEkleButon.TabIndex = 2;
            this.talepEkleButon.Text = "İş Talebi\r\nEkle";
            this.talepEkleButon.UseVisualStyleBackColor = true;
            this.talepEkleButon.Click += new System.EventHandler(this.talepEkleButon_Click);
            // 
            // talebiDüzenleButon
            // 
            this.talebiDüzenleButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.talebiDüzenleButon.Location = new System.Drawing.Point(537, 132);
            this.talebiDüzenleButon.Name = "talebiDüzenleButon";
            this.talebiDüzenleButon.Size = new System.Drawing.Size(75, 37);
            this.talebiDüzenleButon.TabIndex = 3;
            this.talebiDüzenleButon.Text = "İş Talebi Düzenle";
            this.talebiDüzenleButon.UseVisualStyleBackColor = true;
            this.talebiDüzenleButon.Click += new System.EventHandler(this.talebiDüzenleButon_Click);
            // 
            // sonucButon
            // 
            this.sonucButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sonucButon.Location = new System.Drawing.Point(537, 175);
            this.sonucButon.Name = "sonucButon";
            this.sonucButon.Size = new System.Drawing.Size(75, 35);
            this.sonucButon.TabIndex = 3;
            this.sonucButon.Text = "İşi\r\nSonlandır";
            this.sonucButon.UseVisualStyleBackColor = true;
            this.sonucButon.Click += new System.EventHandler(this.sonucButon_Click);
            // 
            // yazdırButon
            // 
            this.yazdırButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yazdırButon.Location = new System.Drawing.Point(537, 216);
            this.yazdırButon.Name = "yazdırButon";
            this.yazdırButon.Size = new System.Drawing.Size(75, 35);
            this.yazdırButon.TabIndex = 3;
            this.yazdırButon.Text = "Word\'e Aktar";
            this.yazdırButon.UseVisualStyleBackColor = true;
            this.yazdırButon.Click += new System.EventHandler(this.yazdırButon_Click);
            // 
            // listelemeButon
            // 
            this.listelemeButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listelemeButon.Location = new System.Drawing.Point(537, 51);
            this.listelemeButon.Name = "listelemeButon";
            this.listelemeButon.Size = new System.Drawing.Size(75, 35);
            this.listelemeButon.TabIndex = 3;
            this.listelemeButon.Text = "Listeleme Seçenekleri";
            this.listelemeButon.UseVisualStyleBackColor = true;
            this.listelemeButon.Click += new System.EventHandler(this.listelemeButon_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(537, 282);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 27);
            this.button6.TabIndex = 3;
            this.button6.Text = "Ana Menü";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // yenileButon
            // 
            this.yenileButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yenileButon.Location = new System.Drawing.Point(537, 21);
            this.yenileButon.Name = "yenileButon";
            this.yenileButon.Size = new System.Drawing.Size(75, 24);
            this.yenileButon.TabIndex = 3;
            this.yenileButon.Text = "Yenile";
            this.yenileButon.UseVisualStyleBackColor = true;
            this.yenileButon.Click += new System.EventHandler(this.yenileButon_Click);
            // 
            // isPlanı
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.listelemeButon);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.yenileButon);
            this.Controls.Add(this.yazdırButon);
            this.Controls.Add(this.sonucButon);
            this.Controls.Add(this.talebiDüzenleButon);
            this.Controls.Add(this.talepEkleButon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.isListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "isPlanı";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İş Planı";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.isPlanı_FormClosed);
            this.Load += new System.EventHandler(this.isPlanı_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView isListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button talepEkleButon;
        private System.Windows.Forms.Button talebiDüzenleButon;
        private System.Windows.Forms.Button sonucButon;
        private System.Windows.Forms.Button yazdırButon;
        private System.Windows.Forms.Button listelemeButon;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button yenileButon;
    }
}