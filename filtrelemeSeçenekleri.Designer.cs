namespace WindowsFormsApplication1
{
    partial class filtrelemeSeçenekleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(filtrelemeSeçenekleri));
            this.birimlerCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gruplarCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.kolonlarCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.filtreleButon = new System.Windows.Forms.Button();
            this.birimlerTümüCheckBox = new System.Windows.Forms.CheckBox();
            this.gruplarTümüCheckBox = new System.Windows.Forms.CheckBox();
            this.kolonlarTümüCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // birimlerCheckedListBox
            // 
            this.birimlerCheckedListBox.FormattingEnabled = true;
            this.birimlerCheckedListBox.Location = new System.Drawing.Point(12, 45);
            this.birimlerCheckedListBox.Name = "birimlerCheckedListBox";
            this.birimlerCheckedListBox.Size = new System.Drawing.Size(113, 169);
            this.birimlerCheckedListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Birimler";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gruplar";
            // 
            // gruplarCheckedListBox
            // 
            this.gruplarCheckedListBox.FormattingEnabled = true;
            this.gruplarCheckedListBox.Location = new System.Drawing.Point(146, 45);
            this.gruplarCheckedListBox.Name = "gruplarCheckedListBox";
            this.gruplarCheckedListBox.Size = new System.Drawing.Size(113, 139);
            this.gruplarCheckedListBox.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Kolonlar";
            this.label3.Visible = false;
            // 
            // kolonlarCheckedListBox
            // 
            this.kolonlarCheckedListBox.FormattingEnabled = true;
            this.kolonlarCheckedListBox.Location = new System.Drawing.Point(99, 45);
            this.kolonlarCheckedListBox.Name = "kolonlarCheckedListBox";
            this.kolonlarCheckedListBox.Size = new System.Drawing.Size(113, 139);
            this.kolonlarCheckedListBox.TabIndex = 2;
            this.kolonlarCheckedListBox.Visible = false;
            // 
            // filtreleButon
            // 
            this.filtreleButon.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.filtreleButon.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.filtreleButon.Location = new System.Drawing.Point(146, 189);
            this.filtreleButon.Name = "filtreleButon";
            this.filtreleButon.Size = new System.Drawing.Size(113, 24);
            this.filtreleButon.TabIndex = 4;
            this.filtreleButon.Text = "Listele";
            this.filtreleButon.UseVisualStyleBackColor = true;
            this.filtreleButon.Click += new System.EventHandler(this.filtreleButon_Click);
            // 
            // birimlerTümüCheckBox
            // 
            this.birimlerTümüCheckBox.AutoSize = true;
            this.birimlerTümüCheckBox.Location = new System.Drawing.Point(15, 25);
            this.birimlerTümüCheckBox.Name = "birimlerTümüCheckBox";
            this.birimlerTümüCheckBox.Size = new System.Drawing.Size(53, 17);
            this.birimlerTümüCheckBox.TabIndex = 5;
            this.birimlerTümüCheckBox.Text = "Tümü";
            this.birimlerTümüCheckBox.UseVisualStyleBackColor = true;
            this.birimlerTümüCheckBox.CheckedChanged += new System.EventHandler(this.birimlerTümüCheckBox_CheckedChanged);
            // 
            // gruplarTümüCheckBox
            // 
            this.gruplarTümüCheckBox.AutoSize = true;
            this.gruplarTümüCheckBox.Location = new System.Drawing.Point(149, 25);
            this.gruplarTümüCheckBox.Name = "gruplarTümüCheckBox";
            this.gruplarTümüCheckBox.Size = new System.Drawing.Size(53, 17);
            this.gruplarTümüCheckBox.TabIndex = 5;
            this.gruplarTümüCheckBox.Text = "Tümü";
            this.gruplarTümüCheckBox.UseVisualStyleBackColor = true;
            this.gruplarTümüCheckBox.CheckedChanged += new System.EventHandler(this.gruplarTümüCheckBox_CheckedChanged);
            // 
            // kolonlarTümüCheckBox
            // 
            this.kolonlarTümüCheckBox.AutoSize = true;
            this.kolonlarTümüCheckBox.Location = new System.Drawing.Point(102, 25);
            this.kolonlarTümüCheckBox.Name = "kolonlarTümüCheckBox";
            this.kolonlarTümüCheckBox.Size = new System.Drawing.Size(53, 17);
            this.kolonlarTümüCheckBox.TabIndex = 5;
            this.kolonlarTümüCheckBox.Text = "Tümü";
            this.kolonlarTümüCheckBox.UseVisualStyleBackColor = true;
            this.kolonlarTümüCheckBox.Visible = false;
            this.kolonlarTümüCheckBox.CheckedChanged += new System.EventHandler(this.kolonlarTümüCheckBox_CheckedChanged);
            // 
            // filtrelemeSeçenekleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 225);
            this.Controls.Add(this.kolonlarTümüCheckBox);
            this.Controls.Add(this.gruplarTümüCheckBox);
            this.Controls.Add(this.birimlerTümüCheckBox);
            this.Controls.Add(this.filtreleButon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kolonlarCheckedListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gruplarCheckedListBox);
            this.Controls.Add(this.birimlerCheckedListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "filtrelemeSeçenekleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "filtrelemeSeçenekleri";
            this.Load += new System.EventHandler(this.filtrelemeSeçenekleri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox birimlerCheckedListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox gruplarCheckedListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox kolonlarCheckedListBox;
        private System.Windows.Forms.Button filtreleButon;
        private System.Windows.Forms.CheckBox birimlerTümüCheckBox;
        private System.Windows.Forms.CheckBox gruplarTümüCheckBox;
        private System.Windows.Forms.CheckBox kolonlarTümüCheckBox;

    }
}