namespace OzayAkcan.BiltekKlavyeTest.Controls
{
    partial class KullaniciKontrol
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKullaniciAdi.Location = new System.Drawing.Point(5, 5);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(520, 25);
            this.lblKullaniciAdi.TabIndex = 0;
            this.lblKullaniciAdi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.BackColor = System.Drawing.Color.DarkCyan;
            this.btnDuzenle.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDuzenle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDuzenle.ForeColor = System.Drawing.Color.White;
            this.btnDuzenle.Location = new System.Drawing.Point(525, 5);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(75, 25);
            this.btnDuzenle.TabIndex = 1;
            this.btnDuzenle.Text = "Duzenle";
            this.btnDuzenle.UseVisualStyleBackColor = false;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Red;
            this.btnSil.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(605, 5);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 25);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(600, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 25);
            this.panel1.TabIndex = 3;
            // 
            // KullaniciKontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblKullaniciAdi);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSil);
            this.Name = "KullaniciKontrol";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(685, 35);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Panel panel1;
    }
}
