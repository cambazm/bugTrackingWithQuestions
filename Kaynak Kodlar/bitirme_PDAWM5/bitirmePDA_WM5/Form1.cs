using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using bitirmePDA_WM5;
using bitirmePDA_WM5.projeWebServisi;
using bitirmePDA_WM5.hataWebServisi;
using bitirmePDA_WM5.kullaniciWebServisi;

namespace bitirmePDA_WM5
{
    public partial class Form1 : Form
    {
        protected projeWS pWS;
        protected hataWS hWS;
        protected kullaniciWS kWS;
        protected bool projeDegisemez;
        protected uint hayirSonrakiSoru;
        protected uint evetSonrakiSoru;
        protected uint sonSoruId;
        protected int cevap;

        private string kullanici;
        private uint yollayanId;
        private bool sorumlu;

        public Form1(string kullaniciIsmi, uint kullaniciId, bool sorumlu1)
        {
            InitializeComponent();

            kullanici = kullaniciIsmi;
            yollayanId = kullaniciId;
            sorumlu = sorumlu1;
            if (!sorumlu)
            {
                tabControl1.SelectedIndex = 1;
                tabPage1.Enabled = false;
                tabPage1.Text = "";
            }

            projeDegisemez = false;
            hayirSonrakiSoru = 0;
            evetSonrakiSoru = 0;
            sonSoruId = 0;
            cevap = -1;
        }


        private void cozulmemisHSGetir_Click(object sender, EventArgs e)
        {
            try
            {
                uint hataSayisi = pWS.projeyeAitCozulmemisHataSayisi(projeler.Text);

                lblSayi.Text = hataSayisi.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void hataGonder_Click(object sender, EventArgs e)
        {
            try
            {
                soruBilgi soru = hWS.ilkSoru(projeler.Text);

                if (soru.id != 0)
                {

                    lblSoru.Text = soru.soru;
                    evetSonrakiSoru = soru.evetId;
                    hayirSonrakiSoru = soru.hayirId;
                    sonSoruId = soru.id;

                    evet.Visible = true;
                    hayir.Visible = true;
                }
                else
                    lblSoru.Text = "Bu projeye daha soru eklenmemiþ, hata gönderemezsiniz";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }

        private void evet_Click(object sender, EventArgs e)
        {
            cevap = 1;

            lblSoru.Text = "";

            //bir kere cevaplanmaya baþladýktan sonra proje deðiþemez
            if (projeDegisemez == false)
                projeDegisemez = true;

            //bir sonra sorulacak soru tanýmlý deðilse hatayý al
            if (evetSonrakiSoru == 0)
            {
                hataGonder.Visible = false;
                aciklama.Visible = true;
                gonder.Visible = true;
                evet.Visible = false;
                hayir.Visible = false;
            }
            //deðilse yeni soruyu göster
            else
            {
                soruBilgi soru = hWS.sonraki(evetSonrakiSoru);

                lblSoru.Text = soru.soru;
                evetSonrakiSoru = soru.evetId;
                hayirSonrakiSoru = soru.hayirId;
                sonSoruId = soru.id;
            }

        }

        private void hayir_Click(object sender, EventArgs e)
        {
            cevap = 0;

            lblSoru.Text = "";

            //bir kere cevaplanmaya baþladýktan sonra proje deðiþemez
            if (projeDegisemez == false)
                projeDegisemez = true;

            //bir sonra sorulacak soru tanýmlý deðilse hatayý al
            if (hayirSonrakiSoru == 0)
            {
                hataGonder.Visible = false;
                aciklama.Visible = true;
                gonder.Visible = true;
                evet.Visible = false;
                hayir.Visible = false;
            }
            //deðilse yeni soruyu göster
            else
            {
                soruBilgi soru = hWS.sonraki(hayirSonrakiSoru);

                lblSoru.Text = soru.soru;
                evetSonrakiSoru = soru.evetId;
                hayirSonrakiSoru = soru.hayirId;
                sonSoruId = soru.id;
            }
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (!sorumlu)
                {
                    tabControl1.SelectedIndex = 1;
                    tabPage1.Enabled = false;
                    tabPage1.Text = "";
                }


                pWS = new projeWS();

                pWS.Url = "http://160.75.96.32/1/webServices/projeWS.asmx";

                hWS = new hataWS();

                hWS.Url = "http://160.75.96.32/1/webServices/hataWS.asmx";

                projeler.Items.Clear();

                string[] projeIsimler = pWS.projeleriListele();

                for(int i=0; i<projeIsimler.Length; i++)
                    projeler.Items.Add(projeIsimler[i]);
            }
            catch
            {
                MessageBox.Show("Baðlantý kurulamadý");
                Application.Exit();
            }
        }

        private void yenile_Click(object sender, EventArgs e)
        {
            try
            {
                pWS = new projeWS();

                pWS.Url = "http://160.75.96.32/1/webServices/projeWS.asmx";

                hWS = new hataWS();

                hWS.Url = "http://160.75.96.32/1/webServices/hataWS.asmx";

                projeler.Items.Clear();

                string[] projeIsimler = pWS.projeleriListele();

                foreach (string projeIsmi in projeIsimler)
                    projeler.Items.Add(projeIsmi);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSayi.Text = "";

            if (projeDegisemez == true && tabControl1.SelectedIndex == 0)
                projeler.Enabled = true;
            else if (projeDegisemez == true && tabControl1.SelectedIndex == 1)
                projeler.Enabled = false;

        }

        private void gonder_Click(object sender, EventArgs e)
        {
            if (aciklama.Text.Trim() == "")
                MessageBox.Show("Hata hakkýnda açýklama girmelisiniz");
            else
            {
                lblSoru.Text = hWS.gonder(projeler.Text, sonSoruId, cevap, aciklama.Text, yollayanId);

                projeDegisemez = false;
                hayirSonrakiSoru = 0;
                evetSonrakiSoru = 0;
                sonSoruId = 0;
                cevap = -1;

                hataGonder.Visible = true;
                aciklama.Text = "";
                aciklama.Visible = false;
                evet.Visible = false;
                hayir.Visible = false;
                gonder.Visible = false;
            }
        }
    }
}