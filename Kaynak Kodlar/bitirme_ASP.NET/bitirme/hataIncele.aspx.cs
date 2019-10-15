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

public partial class hataIncele : System.Web.UI.Page
{

    System.Data.DataSet ds = new System.Data.DataSet();

    protected void devam_Click(object sender, EventArgs e)
    {
        hata h = new hata();

        ds = h.projeyeAitHatalar(Convert.ToUInt32(projeler.SelectedItem.Value));


        //proje ile ilgili hata gönderilmiþse tabloda göster
        if (ds.Tables[0].DefaultView.Count > 0)
        {
            lblHata.Text = "";
            Label lbl = new Label();
            lbl.Text = "<h3>Bu proje ile ilgili daha çözülmemiþ hatalar</h3><br>";

            ph.Controls.Add(lbl);

            for (int t = 0; t < ds.Tables.Count; t++)
            {
                for (int j = 0; j < ds.Tables[t].DefaultView.Table.Rows.Count; j++)
                {
                    Table tablo = new Table();

                    for (int i = 0; i < ds.Tables[t].DefaultView.Table.Columns.Count; i++)
                    {
                        TableRow satir = new TableRow();
                        TableCell sutunAciklama = new TableCell();
                        TableCell sutun = new TableCell();

                        sutunAciklama.BackColor = System.Drawing.Color.Azure;
                        sutunAciklama.HorizontalAlign = HorizontalAlign.Left;
                        sutunAciklama.Text = ds.Tables[t].DefaultView.Table.Columns[i].Caption;

                        sutun.BackColor = System.Drawing.Color.BlanchedAlmond;
                        sutun.HorizontalAlign = HorizontalAlign.Left;

                        // ilk satýrda yapýlabilecek iþlemler bulunacak
                        if (i == 0)
                        {
                            HyperLink hl = new HyperLink();
                            hl.NavigateUrl = "Incele.aspx?id=" + ds.Tables[t].DefaultView.Table.Rows[j].ItemArray.GetValue(i).ToString();
                            hl.ID = "hl_" + j.ToString() + "_" + i.ToString();
                            hl.Text = "Ýncele";
                            hl.ForeColor = System.Drawing.Color.Black;
                            hl.Font.Bold = true;

                            HyperLink hl2 = new HyperLink();
                            hl2.NavigateUrl = "SorumluAta.aspx?id=" + ds.Tables[t].DefaultView.Table.Rows[j].ItemArray.GetValue(i).ToString();
                            hl2.ID = "hl2_" + j.ToString() + "_" + i.ToString();
                            hl2.Text = "Sorumlu Ata";
                            hl2.ForeColor = System.Drawing.Color.Black;
                            hl2.Font.Bold = true;

                            HyperLink hl3 = new HyperLink();
                            hl3.NavigateUrl = "HataCozumEkle.aspx?id=" + ds.Tables[t].DefaultView.Table.Rows[j].ItemArray.GetValue(i).ToString();
                            hl3.ID = "hl3_" + j.ToString() + "_" + i.ToString();
                            hl3.Text = "Çözüm Ekle";
                            hl3.ForeColor = System.Drawing.Color.Black;
                            hl3.Font.Bold = true;

                            Label lbl1 = new Label();
                            lbl1.Text = " | ";

                            Label lbl2 = new Label();
                            lbl2.Text = " | ";

                            sutun.Controls.Add(hl);
                            sutun.Controls.Add(lbl1);
                            sutun.Controls.Add(hl2);
                            sutun.Controls.Add(lbl2);
                            sutun.Controls.Add(hl3);
                        }
                        else
                            sutun.Text = ds.Tables[t].DefaultView.Table.Rows[j].ItemArray.GetValue(i).ToString();

                        //hata yüksekliði minimum 50px olacak
                        if (i == 2)
                        {
                            sutunAciklama.Height = 50;
                            sutun.Height = 50;
                        }

                        sutunAciklama.Width = 150;
                        sutun.Width = 350;
                        satir.Cells.Add(sutunAciklama);
                        satir.Cells.Add(sutun);

                        tablo.Rows.Add(satir);

                    }
                    tablo.Width = 500;
                    ph.Controls.Add(tablo);

                    Label l1 = new Label();
                    l1.Text = "<br><br>";
                    ph.Controls.Add(l1);
                }

            }

            Label l2 = new Label();
            l2.Text = "<br><br>";
            ph.Controls.Add(l2);
        }
        else
        {
            lblHata.Text = "Bu projeye ait çözülmemiþ bir hata mevcut deðil.";
        }
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
