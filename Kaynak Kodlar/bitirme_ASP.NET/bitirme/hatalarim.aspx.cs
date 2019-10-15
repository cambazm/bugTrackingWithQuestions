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
using _hata;


public partial class hatalarim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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
            lblHata.Text = "";
            SayfayiDoldur();
        }
    }

    private void SayfayiDoldur()
    {
        hata h = new hata();
        
        uint[] hatalar = h.hatalarim(Convert.ToUInt32(Session["yollayanid_session"]));

        if (hatalar[0] != 0)
        {
            for (int i = 0; i < hatalar.Length; i++)
            {
                Label l = new Label();
                l.Text = "<br>";
                HyperLink hl = new HyperLink();
                hl.NavigateUrl = "Incele.aspx?id=" + hatalar[i];
                hl.Text = "Hata " + i;
                hl.ForeColor = System.Drawing.Color.Black;
                hl.Font.Bold = true;

                ph.Controls.Add(hl);
                ph.Controls.Add(l);
            }
        }
        else
            lblHata.Text = "Hiç hata yollamamýþsýnýz";

        //adamýn yolladýðý hatalara linkler
    }
}
