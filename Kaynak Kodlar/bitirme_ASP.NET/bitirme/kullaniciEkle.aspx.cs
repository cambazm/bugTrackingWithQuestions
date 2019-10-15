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
                tip = 2;    //varsayýlan kullanýcý gönderici
            else
                tip = Convert.ToUInt32(kullanicilar.SelectedItem.Value);

            sonuc = k.ekle(isim.Text, sifre.Text, mail.Text, blg.Text, tip);
            switch (sonuc)
            { 
                case 1:
                    lblHata.Text = "Kullanýcý ismi daha önce alýnmýþ.";
                    break;
                case 2:
                    lblHata.Text = "Bu e-posta adresi kayýtlý.";
                    break;
                case 3:
                    lblHata.Text = "Veritabanýna eriþilemedi.";
                    break;
                case 0:
                    lblHata.Text = "Kullanýcý baþarýyla eklendi!";
                    break;
                default:
                    lblHata.Text = "Olmamasý gereken þeyler oldu...";
                    break;
            }
        }
        else
            lblHata.Text = "Þifreler farklý";

    }
}
