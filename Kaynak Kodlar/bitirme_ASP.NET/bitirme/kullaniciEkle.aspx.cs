using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using _kullanici;


public partial class kullaniciEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["tip"] != null)
            if (Session["tip"].ToString() == "sorumlu")
                kullanicilar.Visible = true;
    }
    protected void ekle_Click(object sender, EventArgs e)
    {
        isim.Text = isim.Text.Replace("'", "").Replace('"', ' ').Trim();
        sifre.Text = sifre.Text.Replace("'", "").Replace('"', ' ').Trim();
        sifre2.Text = sifre2.Text.Replace("'", "").Replace('"', ' ').Trim();
        mail.Text = mail.Text.Replace("'", "").Replace('"', ' ').Trim();

        if (sifre.Text == sifre2.Text)
        {
            uint tip, sonuc;
            kullanici k = new kullanici();

            if (kullanicilar.Visible == false)
                tip = 2;    //varsay�lan kullan�c� g�nderici
            else
                tip = Convert.ToUInt32(kullanicilar.SelectedItem.Value);

            sonuc = k.ekle(isim.Text, sifre.Text, mail.Text, blg.Text, tip);
            switch (sonuc)
            { 
                case 1:
                    lblHata.Text = "Kullan�c� ismi daha �nce al�nm��.";
                    break;
                case 2:
                    lblHata.Text = "Bu e-posta adresi kay�tl�.";
                    break;
                case 3:
                    lblHata.Text = "Veritaban�na eri�ilemedi.";
                    break;
                case 0:
                    lblHata.Text = "Kullan�c� ba�ar�yla eklendi!";
                    break;
                default:
                    lblHata.Text = "Olmamas� gereken �eyler oldu...";
                    break;
            }
        }
        else
            lblHata.Text = "�ifreler farkl�";

    }
}
