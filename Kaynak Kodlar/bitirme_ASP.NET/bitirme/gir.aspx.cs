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


public partial class gir : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        lblHata.Text = "";

        isim.Text = isim.Text.Replace("'", "").Trim();
        sifre.Text = sifre.Text.Replace("'", "").Trim();
        isim.Text = isim.Text.Replace('"', ' ');
        sifre.Text = sifre.Text.Replace('"', ' ');

        kullanici k = new kullanici();

        if (k.giris(isim.Text, sifre.Text) == false)
            lblHata.Text = "Giriþ baþarýsýz";
        else
        {
            lblHata.Text = "Hoþgeldin, sayýn " + isim.Text;
            Session["kullanici"] = isim.Text;
            Session["tip"] = k.tipGetir(isim.Text);

/*            Label isim1 = new Label();
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
*/            
            Session["yollayanid_session"] = k.idGetir(isim.Text);
            Response.Redirect("Default.aspx");
        }

        isim.Text = "";
        sifre.Text = "";
    }
}
