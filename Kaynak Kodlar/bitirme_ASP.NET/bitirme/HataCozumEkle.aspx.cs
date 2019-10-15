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


public partial class hataCozumEkle : System.Web.UI.Page
{
    uint hata_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        //bu sayfaya sadece web sayfalarýndaki linklerden ulaþýlabilir
        if (Request.ServerVariables["HTTP_REFERER"] == null)
        {
            pnl.Visible = false;
            lblHata.Text = "Bu sayfaya eriþim izniniz yok";
            return;
        }

        hata_id = Convert.ToUInt32(Request.QueryString["id"]);

        if (hata_id <= 0)
        {
            lblHata.Text = "Geçersiz ID";
            return;
        }

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
            SayfayiDoldur();
        }
    }

    protected void SayfayiDoldur()
    {
        ph.Controls.Clear();

        hata h = new hata();
        DataSet ds = new DataSet();

        ds = h.Incele(hata_id);

        if (ds.Tables[0].DefaultView.Count > 0)
        {
            /*
             ilgili hatanýn ayrýntlarýný tabloda göster
             */
            for (int j = 0; j < ds.Tables[0].DefaultView.Table.Rows.Count; j++)
            {
                Table tablo = new Table();

                for (int i = 0; i < ds.Tables[0].DefaultView.Table.Columns.Count; i++)
                {
                    TableRow satir = new TableRow();
                    TableCell sutunAciklama = new TableCell();
                    TableCell sutun = new TableCell();

                    sutunAciklama.BackColor = System.Drawing.Color.Azure;
                    sutunAciklama.HorizontalAlign = HorizontalAlign.Left;
                    sutunAciklama.Text = ds.Tables[0].DefaultView.Table.Columns[i].Caption;

                    sutun.BackColor = System.Drawing.Color.BlanchedAlmond;
                    sutun.HorizontalAlign = HorizontalAlign.Left;


                    sutun.Text = ds.Tables[0].DefaultView.Table.Rows[j].ItemArray.GetValue(i).ToString();

                    if ((i == 0) || (i == 1) || (i == 2))
                    {
                        sutunAciklama.Height = 50;
                        sutun.Height = 50;
                    }
                    //true veya false çýktýlarý anlamlý hale getirildi: evet veya hayýr þekline
                    else if ((i == 3) || (i == 9))
                    {
                        if (ds.Tables[0].DefaultView.Table.Rows[j].ItemArray.GetValue(i).ToString() == "False")
                            sutun.Text = "Hayýr";
                        else if (ds.Tables[0].DefaultView.Table.Rows[j].ItemArray.GetValue(i).ToString() == "True")
                            sutun.Text = "Evet";
                    }
                    sutunAciklama.Width = 150;
                    sutun.Width = 400;

                    satir.Cells.Add(sutunAciklama);
                    satir.Cells.Add(sutun);

                    tablo.Rows.Add(satir);

                }

                //son satýra hata ile ilgili yapýlabilecek iþlem linkleri konulacak
                TableRow linkler = new TableRow();
                TableCell link = new TableCell();

                HyperLink hl2 = new HyperLink();
                hl2.NavigateUrl = "SorumluAta.aspx?id=" + hata_id;
                hl2.ID = "hl2";
                hl2.Text = "Sorumlu Ata";
                hl2.ForeColor = System.Drawing.Color.Black;
                hl2.Font.Bold = true;

                HyperLink hl = new HyperLink();
                hl.NavigateUrl = "Incele.aspx?id=" + hata_id;
                hl.ID = "hl";
                hl.Text = "Ýncele";
                hl.ForeColor = System.Drawing.Color.Black;
                hl.Font.Bold = true;

                Label lbl1 = new Label();
                lbl1.Text = " | ";

                link.ColumnSpan = 2;
                link.Controls.Add(hl);
                link.Controls.Add(lbl1);
                link.Controls.Add(hl2);

                linkler.Cells.Add(link);
                tablo.Rows.Add(linkler);

                tablo.Width = 550;
                ph.Controls.Add(tablo);

                Label l1 = new Label();
                l1.Text = "<br><br>";
                ph.Controls.Add(l1);
            }
        }
        else
            lblHata.Text = "Böyle bir hata yüklenmemiþ";

    }

    protected void ekle_Click(object sender, EventArgs e)
    {
        ArrayList parameterNameList = new ArrayList(1);
        parameterNameList.Add("@cozumS");
        ArrayList parameterList = new ArrayList(1);

        parameterList.Add(cozum.Text.Replace("\n", "<br>"));

        hata h = new hata();

        lblHata.Text = h.cozumEkle(hata_id, parameterNameList, parameterList);

        cozum.Text = "";

        SayfayiDoldur();      

    }

}
