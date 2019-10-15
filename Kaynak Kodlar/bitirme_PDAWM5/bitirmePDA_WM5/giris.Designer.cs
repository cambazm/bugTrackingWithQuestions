namespace bitirmePDA_WM5
{
    partial class giris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.isim = new System.Windows.Forms.TextBox();
            this.sifre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblHata = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // isim
            // 
            this.isim.Location = new System.Drawing.Point(91, 50);
            this.isim.MaxLength = 20;
            this.isim.Name = "isim";
            this.isim.Size = new System.Drawing.Size(129, 21);
            this.isim.TabIndex = 0;
            // 
            // sifre
            // 
            this.sifre.Location = new System.Drawing.Point(91, 77);
            this.sifre.MaxLength = 10;
            this.sifre.Name = "sifre";
            this.sifre.PasswordChar = '*';
            this.sifre.Size = new System.Drawing.Size(129, 21);
            this.sifre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.Text = "Kullanýcý adý";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.Text = "Þifre";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.TabIndex = 5;
            this.button1.Text = "Gir";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblHata
            // 
            this.lblHata.ForeColor = System.Drawing.Color.Maroon;
            this.lblHata.Location = new System.Drawing.Point(15, 160);
            this.lblHata.Name = "lblHata";
            this.lblHata.Size = new System.Drawing.Size(202, 80);
            this.lblHata.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.lblHata);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sifre);
            this.Controls.Add(this.isim);
            this.MinimizeBox = false;
            this.Name = "giris";
            this.Text = "Sisteme Giriþ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox isim;
        private System.Windows.Forms.TextBox sifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblHata;
    }
}