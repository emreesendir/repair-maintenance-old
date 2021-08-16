namespace WindowsFormsApplication1
{
    partial class isGecmisi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(isGecmisi));
            this.listelemeButon = new System.Windows.Forms.Button();
            this.anaMenuButon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gecmisListView = new System.Windows.Forms.ListView();
            this.yazdırButon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listelemeButon
            // 
            this.listelemeButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listelemeButon.Location = new System.Drawing.Point(539, 23);
            this.listelemeButon.Name = "listelemeButon";
            this.listelemeButon.Size = new System.Drawing.Size(75, 35);
            this.listelemeButon.TabIndex = 7;
            this.listelemeButon.Text = "Listeleme Seçenekleri";
            this.listelemeButon.UseVisualStyleBackColor = true;
            this.listelemeButon.Click += new System.EventHandler(this.listelemeButon_Click);
            // 
            // anaMenuButon
            // 
            this.anaMenuButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.anaMenuButon.Location = new System.Drawing.Point(539, 284);
            this.anaMenuButon.Name = "anaMenuButon";
            this.anaMenuButon.Size = new System.Drawing.Size(75, 27);
            this.anaMenuButon.TabIndex = 8;
            this.anaMenuButon.Text = "Ana Menü";
            this.anaMenuButon.UseVisualStyleBackColor = true;
            this.anaMenuButon.Click += new System.EventHandler(this.anaMenuButon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "İş Geçmişi";
            // 
            // gecmisListView
            // 
            this.gecmisListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gecmisListView.Location = new System.Drawing.Point(14, 23);
            this.gecmisListView.Name = "gecmisListView";
            this.gecmisListView.Size = new System.Drawing.Size(510, 290);
            this.gecmisListView.TabIndex = 4;
            this.gecmisListView.UseCompatibleStateImageBehavior = false;
            // 
            // yazdırButon
            // 
            this.yazdırButon.Location = new System.Drawing.Point(539, 64);
            this.yazdırButon.Name = "yazdırButon";
            this.yazdırButon.Size = new System.Drawing.Size(75, 35);
            this.yazdırButon.TabIndex = 9;
            this.yazdırButon.Text = "Word\'e Aktar";
            this.yazdırButon.UseVisualStyleBackColor = true;
            this.yazdırButon.Click += new System.EventHandler(this.yazdırButon_Click);
            // 
            // isGecmisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.yazdırButon);
            this.Controls.Add(this.listelemeButon);
            this.Controls.Add(this.anaMenuButon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gecmisListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "isGecmisi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İş Geçmişi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.isGecmisi_FormClosed);
            this.Load += new System.EventHandler(this.isGecmisi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button listelemeButon;
        private System.Windows.Forms.Button anaMenuButon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView gecmisListView;
        private System.Windows.Forms.Button yazdırButon;
    }
}