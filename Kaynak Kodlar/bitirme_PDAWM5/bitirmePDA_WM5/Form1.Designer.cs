namespace bitirmePDA_WM5
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gonder = new System.Windows.Forms.Button();
            this.hayir = new System.Windows.Forms.Button();
            this.evet = new System.Windows.Forms.Button();
            this.lblSoru = new System.Windows.Forms.Label();
            this.aciklama = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hataGonder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.projeler = new System.Windows.Forms.ComboBox();
            this.yenile = new System.Windows.Forms.Button();
            this.cozulmemisHSGetir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSayi = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl1.Location = new System.Drawing.Point(0, 76);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 192);
            this.tabControl1.TabIndex = 12;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Azure;
            this.tabPage2.Controls.Add(this.gonder);
            this.tabPage2.Controls.Add(this.hayir);
            this.tabPage2.Controls.Add(this.evet);
            this.tabPage2.Controls.Add(this.lblSoru);
            this.tabPage2.Controls.Add(this.aciklama);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.hataGonder);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(232, 166);
            this.tabPage2.Text = "Hata Gönder         ";
            // 
            // gonder
            // 
            this.gonder.Location = new System.Drawing.Point(132, 146);
            this.gonder.Name = "gonder";
            this.gonder.Size = new System.Drawing.Size(72, 20);
            this.gonder.TabIndex = 16;
            this.gonder.Text = "Gönder";
            this.gonder.Visible = false;
            this.gonder.Click += new System.EventHandler(this.gonder_Click);
            // 
            // hayir
            // 
            this.hayir.Location = new System.Drawing.Point(115, 79);
            this.hayir.Name = "hayir";
            this.hayir.Size = new System.Drawing.Size(72, 20);
            this.hayir.TabIndex = 13;
            this.hayir.Text = "Hayýr";
            this.hayir.Visible = false;
            this.hayir.Click += new System.EventHandler(this.hayir_Click);
            // 
            // evet
            // 
            this.evet.Location = new System.Drawing.Point(37, 79);
            this.evet.Name = "evet";
            this.evet.Size = new System.Drawing.Size(72, 20);
            this.evet.TabIndex = 12;
            this.evet.Text = "Evet";
            this.evet.Visible = false;
            this.evet.Click += new System.EventHandler(this.evet_Click);
            // 
            // lblSoru
            // 
            this.lblSoru.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular);
            this.lblSoru.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSoru.Location = new System.Drawing.Point(1, 40);
            this.lblSoru.Name = "lblSoru";
            this.lblSoru.Size = new System.Drawing.Size(236, 36);
            this.lblSoru.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // aciklama
            // 
            this.aciklama.Location = new System.Drawing.Point(20, 105);
            this.aciklama.Multiline = true;
            this.aciklama.Name = "aciklama";
            this.aciklama.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.aciklama.Size = new System.Drawing.Size(184, 38);
            this.aciklama.TabIndex = 9;
            this.aciklama.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(21, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.Text = "Hata gönder";
            // 
            // hataGonder
            // 
            this.hataGonder.Location = new System.Drawing.Point(132, 17);
            this.hataGonder.Name = "hataGonder";
            this.hataGonder.Size = new System.Drawing.Size(72, 20);
            this.hataGonder.TabIndex = 8;
            this.hataGonder.Text = "Yolla";
            this.hataGonder.Click += new System.EventHandler(this.hataGonder_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Proje seçiniz";
            // 
            // projeler
            // 
            this.projeler.Location = new System.Drawing.Point(21, 37);
            this.projeler.Name = "projeler";
            this.projeler.Size = new System.Drawing.Size(183, 22);
            this.projeler.TabIndex = 11;
            // 
            // yenile
            // 
            this.yenile.Location = new System.Drawing.Point(132, 11);
            this.yenile.Name = "yenile";
            this.yenile.Size = new System.Drawing.Size(72, 20);
            this.yenile.TabIndex = 14;
            this.yenile.Text = "Yenile";
            this.yenile.Click += new System.EventHandler(this.yenile_Click);
            // 
            // cozulmemisHSGetir
            // 
            this.cozulmemisHSGetir.Location = new System.Drawing.Point(79, 47);
            this.cozulmemisHSGetir.Name = "cozulmemisHSGetir";
            this.cozulmemisHSGetir.Size = new System.Drawing.Size(72, 20);
            this.cozulmemisHSGetir.TabIndex = 1;
            this.cozulmemisHSGetir.Text = "Getir";
            this.cozulmemisHSGetir.Click += new System.EventHandler(this.cozulmemisHSGetir_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 16);
            this.label2.Text = "Projeye ait çözülmemiþ hata sayýsýný";
            // 
            // lblSayi
            // 
            this.lblSayi.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular);
            this.lblSayi.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSayi.Location = new System.Drawing.Point(21, 85);
            this.lblSayi.Name = "lblSayi";
            this.lblSayi.Size = new System.Drawing.Size(183, 20);
            this.lblSayi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Azure;
            this.tabPage1.Controls.Add(this.lblSayi);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cozulmemisHSGetir);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 169);
            this.tabPage1.Text = "Çözülmemiþ hata sayýsýný al";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.yenile);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.projeler);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Hata Takip PDA Yazýlýmý";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button hayir;
        private System.Windows.Forms.Button evet;
        private System.Windows.Forms.Label lblSoru;
        private System.Windows.Forms.TextBox aciklama;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button hataGonder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox projeler;
        private System.Windows.Forms.Button yenile;
        private System.Windows.Forms.Button gonder;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblSayi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cozulmemisHSGetir;
    }
}

