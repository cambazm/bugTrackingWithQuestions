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
using _proje;

public partial class projeEkle : System.Web.UI.Page
{

    protected void ekle_Click(object sender, EventArgs e)
    {
        projeismi.Text = projeismi.Text.Replace("'", " ");
        projeturu.Text = projeturu.Text.Replace("'", " ");

        proje p = new proje();

        lblHata.Text = p.ekle(projeismi.Text.Trim().ToUpper(), projeturu.Text.Trim().ToUpper());

        projeler.DataBind();

        projeismi.Text = "";
        projeturu.Text = "";
    }

    protected void sil_Click(object sender, EventArgs e)
    {
        proje p = new proje();

        lblHata.Text = p.sil(Convert.ToUInt32(projeler.SelectedItem.Value), projeler.SelectedItem.Text);
        
        projeler.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
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
}
