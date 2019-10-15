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

public partial class kullaniciBilgiler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["kullanici"] == null)
                Response.Redirect("gir.aspx");
            else
            {
                Label isim1 = new Label();
                Label tip1 = new Label();
                Label lblGondericiMenu = new Label();
                Menu gondericiMenu = new Menu();
                Label lblSorumluMenu = new Label();
                Menu sorumluMenu = new Menu();
                Panel panel = new Panel();

                isim1 = (Label)Master.FindControl("kullaniciIsmi");
                isim1.Text = Session["kullanici"].ToString();
                tip1 = (Label)Master.FindControl("kullaniciTip");
                tip1.Text = Session["tip"].ToString();
                panel = (Panel)Master.FindControl("panel");
                panel.Visible = true;
                lblGondericiMenu = (Label)Master.FindControl("lblGondericiMenu");
                lblGondericiMenu.Visible = true;
                gondericiMenu = (Menu)Master.FindControl("gondericiMenu");
                gondericiMenu.Visible = true;

                if (Session["tip"].ToString() == "sorumlu")
                {
                    lblSorumluMenu = (Label)Master.FindControl("lblSorumluMenu");
                    lblSorumluMenu.Visible = true;
                    sorumluMenu = (Menu)Master.FindControl("sorumluMenu");
                    sorumluMenu.Visible = true;
                }


                bilgileriDoldur();
            }

        }
    }

    private void bilgileriDoldur()
    {
        isim.Text = Session["kullanici"].ToString();
        
        kullanici k = new kullanici();
        
        string[] bilgiler = k.bilgileriGetir(Session["kullanici"].ToString());

        if (bilgiler.Length == 1 && bilgiler[0] == "")
            lblHata.Text = "Ýþlem baþarýsýz";
        else
        {
            mail.Text = bilgiler[0];
            blg.Text = bilgiler[1];
        }
    }
    protected void guncelle_Click(object sender, EventArgs e)
    {
        mail.Text = mail.Text.Trim();
        blg.Text = blg.Text.Trim();

        kullanici k = new kullanici();

        bool basari = k.duzenle(Convert.ToUInt32(Session["yollayanid_session"]), mail.Text, blg.Text);
        if (basari)
            lblHata.Text = "Bilgileriniz baþarýyla güncellendi";
        else
            lblHata.Text = "Ýþlem baþarýsýz";
    }
    protected void sifredegistir_Click(object sender, EventArgs e)
    {
        kullanici k = new kullanici();

        uint sonuc = k.sifreDegistir(Convert.ToUInt32(Session["yollayanid_session"]), mevcutsifre.Text, sifre.Text);

        if (sonuc == 0)
            lblHata.Text = "Þifre baþarýyla deðiþtirildi";
        else if(sonuc == 1)
            lblHata.Text = "Mevcut þifre yanlýþ, iþlem baþarýsýz";
        else if (sonuc == 2)
            lblHata.Text = "Veritabanýna eriþilemedi, iþlem baþarýsýz";
    }
}
