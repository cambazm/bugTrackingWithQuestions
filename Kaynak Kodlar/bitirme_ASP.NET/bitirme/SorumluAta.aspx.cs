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
using _sorumlu;

public partial class SorumluAta : System.Web.UI.Page
{
    /*
     
     * sadece t�m sorumlular� listeliyor, 
     * proje id ile beraber o projeden sorumlu ki�ileri listelemeli
     
     * burada sorumlu atand���nda kendisine mail ile haber verilecek
     
     */
    uint hata_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        //bu sayfaya sadece hataInceleme.aspx sayfas�ndanki linklerden ula��labilir
        if (Request.ServerVariables["HTTP_REFERER"] == null)
        {
            pnl.Visible = false;
            lblHata.Text = "Bu sayfaya eri�im izniniz yok";
            return;
        }

        hata_id = Convert.ToUInt32(Request.QueryString["id"]);

        if (hata_id <= 0)
        {
            lblHata.Text = "Ge�ersiz ID";
            return;
        }

        if (Session["kullanici"] == null)
            Response.Redirect("gir.aspx");
        else
        {
            if (Session["tip"].ToString() != "sorumlu")
                Response.Redirect("yetkiYok.aspx");

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
        }
    }

    protected void tamam_Click(object sender, EventArgs e)
    {
        lblHata.Text = "";

        sorumlu s = new sorumlu();

        lblHata.Text = s.ata(hata_id, Convert.ToUInt32(sorumlular.SelectedItem.Value), sorumlular.SelectedItem.Text);

        //atama ba�ar�s�z olursa linki g�sterme
        if (lblHata.Text == "Atama i�lemi ba�ar�s�z")
            return;

        link.Visible = true;
        link.NavigateUrl = "Incele.aspx?id=" + hata_id;
        link.Text = "Hatay� incele";

        uint sonuc = s.atamaBildir(hata_id, Convert.ToUInt32(sorumlular.SelectedItem.Value));
        if (sonuc == 2)
            lblHata.Text = "Atama ba�ar�l� ama SMTP sunucusunda sorun var";

    }
}
