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
using _soru;
using _soruBilgi;


public partial class SoruSil : System.Web.UI.Page
{
    uint soruId;


    protected void Page_Load(object sender, EventArgs e)
    {
        evetsorusor.Enabled = false;
        hayirsorusor.Enabled = false;
        if (!IsPostBack)
        {
            //bu sayfaya sadece web sayfalarýndaki linklerden ulaþýlabilir
            if (Request.ServerVariables["HTTP_REFERER"] == null)
            {
                lblHata.Text = "Bu sayfaya eriþim izniniz yok";
                panel.Visible = false;
                ph2.Visible = false;

                return;
            }

            if (Request.QueryString["id"] != null)
            {
                soru s = new soru();

                soruId = Convert.ToUInt32(Request.QueryString["id"]);

                if (soruId > 0)
                {
                    if (Session["tip"].ToString() != "sorumlu")
                        Response.Redirect("yetkiYok.aspx");

                    projeIsmi.Text = Session["proje_ismi"].ToString();

                    soruBilgi soruB = s.getir(soruId);

                    if (soruB.id != 0)
                    {
                        soru.Text = soruB.soru;
                        knot.Text = soruB.kNot;
                        gnot.Text = soruB.getgNot();
                    }
                    else
                    {
                        lblHata.Text = "Soru bulunamadý";
                        panel.Visible = false;

                        return;
                    }
                }
                else
                {
                    lblHata.Text = "Geçersiz ID";
                    panel.Visible = false;

                    return;
                }
            }
            else
            {
                lblHata.Text = "Geçersiz çalýþtýrma þekli";
                panel.Visible = false;
                ph2.Visible = false;
            }
        }
        else
            soruId = Convert.ToUInt32(Request.QueryString["id"]);
    }


    protected void sil_Click(object sender, EventArgs e)
    {
        soru s = new soru();

        bool basari = s.sil(soruId);

        if (basari)
        {
            lblHata.Text = "Soru silindi";
            panel.Visible = false;
        }
        else
            lblHata.Text = "Soru silinemedi.";
    }
}
