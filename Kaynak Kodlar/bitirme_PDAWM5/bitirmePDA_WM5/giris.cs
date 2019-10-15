using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using bitirmePDA_WM5.kullaniciWebServisi;

namespace bitirmePDA_WM5
{
    public partial class giris : Form
    {
        protected kullaniciWS kWS;

        public giris()
        {
            InitializeComponent();
            kWS = new kullaniciWS();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isim.Text = isim.Text.Replace("'", "").Trim().Replace('"', ' ');
            sifre.Text = sifre.Text.Replace("'", "").Trim().Replace('"', ' ');

            try
            {
                bool sonuc = kWS.giris(isim.Text, sifre.Text);

                if (sonuc)
                {
                    string tip = kWS.tipGetir(isim.Text);
                    bool sorumlu = false;
                    if (tip == "sorumlu")
                        sorumlu = true;

                    Form1 frm = new Form1(isim.Text, kWS.idGetir(isim.Text), sorumlu);
                    frm.Show();
                    sifre.Text = "";
                }
                else
                {
                    lblHata.Text = "Giriþ baþarýsýz.";
                    isim.Text = "";
                    sifre.Text = "";
                }
            }
            catch 
            {
                MessageBox.Show("Baðlantý kurulamadý.");
            }

        }
    }
}