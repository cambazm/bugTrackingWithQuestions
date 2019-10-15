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

public partial class Incele : System.Web.UI.Page
{
    uint hata_id;

    protected void Page_Load(object sender, EventArgs e)
    {
/*        //bu sayfaya sadece HataInceleme.aspx sayfasýndanki linklerden ulaþýlabilir
        if (Request.ServerVariables["HTTP_REFERER"] == null)
        {
            pnl.Visible = false;
            lblHata.Text = "Bu sayfaya eriþim izniniz yok";
            return;
        }
*/
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
        DataSet ds = new DataSet();
        hata h = new hata();

        ph.Controls.Clear();

        /*
         * ilgili hatanýn ayrýntýlarýný göster
         */
        ds = h.Incele(hata_id);

        if (ds.Tables[0].DefaultView.Count > 0)
        {
            lblHata.Text = "";

            //for (int j = 0; j < ds.Tables[0].DefaultView.Table.Rows.Count; j++)
            //{
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


                    sutun.Text = ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(i).ToString();
                    //son soruya verilen cevap anlamlý bir þekilde çýktý olarak gözükmeli, deðiþtirilecek
                    if (i == 9)
                    {
                        if (ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(i).ToString() == "False")
                            sutun.Text = "Hayýr";
                        else if (ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(i).ToString() == "True")
                            sutun.Text = "Evet";
                    }

                    if ((i == 0) || (i == 1) || (i == 2))
                    {
                        sutunAciklama.Height = 50;
                        sutun.Height = 50;
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
                //hl2.ID = "hl2";
                hl2.Text = "Sorumlu Ata";
                hl2.ForeColor = System.Drawing.Color.Black;
                hl2.Font.Bold = true;
                hl2.Visible = false;

                HyperLink hl3 = new HyperLink();
                hl3.NavigateUrl = "HataCozumEkle.aspx?id=" + hata_id;
                //hl3.ID = "hl3";
                hl3.Text = "Çözüm Ekle";
                hl3.ForeColor = System.Drawing.Color.Black;
                hl3.Font.Bold = true;
                hl3.Visible = false;

                Label lbl1 = new Label();
                lbl1.Text = " | ";

                link.ColumnSpan = 2;
                link.Controls.Add(hl2);
                link.Controls.Add(lbl1);
                link.Controls.Add(hl3);

                linkler.Cells.Add(link);
                tablo.Rows.Add(linkler);

                tablo.Width = 550;
                ph.Controls.Add(tablo);

                Label l1 = new Label();
                l1.Text = "<br><br>";
                ph.Controls.Add(l1);

                if (Session["tip"].ToString() == "sorumlu")
                {
                    hl2.Visible = true;
                    hl3.Visible = true;
                }
            //}
        }
        else
        {
            lblHata.Text = "Böyle bir hata yüklenmemiþ";
        }


        /*
         * ilgili hata üzerine yapýlmýþ konuþmalarý göster
         */
        ds = h.konusmalariGetir(hata_id);
        
        //konuþma yapýlmýþsa
        if (ds.Tables[0].DefaultView.Count > 0)
        {
            lblHata.Text = "";

            /*
             ilgili hata hakkýnda konuþulanlarý listele
             */
            Table tablo = new Table();

            TableRow baslik = new TableRow();
            baslik.Width = 700;
            baslik.BackColor = System.Drawing.Color.Orange;
            baslik.Font.Bold = true;

            TableCell yollayan = new TableCell();
            yollayan.Width = 100;
            yollayan.Text = "Yollayan";
            yollayan.HorizontalAlign = HorizontalAlign.Center;

            TableCell msj = new TableCell();
            msj.Width = 600;
            msj.Text = "Mesaj";
            msj.HorizontalAlign = HorizontalAlign.Center;

            baslik.Cells.Add(yollayan);
            baslik.Cells.Add(msj);
            tablo.Rows.Add(baslik);

            for (int j = 0; j < ds.Tables[0].DefaultView.Table.Rows.Count; j++)
            {
                TableRow Mesaj = new TableRow();
                TableCell MesajY = new TableCell();
                TableCell MesajM = new TableCell();

                MesajY.BackColor = System.Drawing.Color.BlanchedAlmond;
                MesajY.HorizontalAlign = HorizontalAlign.Left;
                MesajY.VerticalAlign = VerticalAlign.Top;
                MesajY.Text = ds.Tables[0].DefaultView.Table.Rows[j].ItemArray.GetValue(1).ToString();
                MesajY.Text += " (";
                MesajY.Text += ds.Tables[0].DefaultView.Table.Rows[j].ItemArray.GetValue(2).ToString();
                MesajY.Text += ")<br>";
                MesajY.Text += ds.Tables[0].DefaultView.Table.Rows[j].ItemArray.GetValue(3).ToString();
                MesajY.Width = 100;
                MesajY.Height = 50;

                MesajM.BackColor = System.Drawing.Color.BlanchedAlmond;
                MesajM.Text = ds.Tables[0].DefaultView.Table.Rows[j].ItemArray.GetValue(0).ToString();
                MesajM.HorizontalAlign = HorizontalAlign.Left;
                MesajM.Width = 600;
                MesajM.Height = 50;

                Mesaj.Cells.Add(MesajY);
                Mesaj.Cells.Add(MesajM);
                Mesaj.Width = 700;

                tablo.Rows.Add(Mesaj);
                tablo.Width = 600;
                ph.Controls.Add(tablo);
            }
        }
        else
        {
            lblHata.Text = "Bu hata üzerinde daha konuþma yapýlmamýþ";
        }
    }


    /*
     yeni fikir eklenecek (yeni konuþma ekle)
     */
    protected void yolla_Click(object sender, EventArgs e)
    {
        hata h = new hata();
        bool basarili = false;

        uint yollayan_id = Convert.ToUInt32(Session["yollayanid_session"]);

        ArrayList parameterNameList = new ArrayList(2);
        parameterNameList.Add("@fikirS");
        parameterNameList.Add("@simdi");

        ArrayList parameterList = new ArrayList(2);
        parameterList.Add(fikir.Text.Replace("\n","<br>").Trim());
        parameterList.Add(System.DateTime.Now);

        basarili = h.konusmaEkle(hata_id, yollayan_id, parameterList, parameterNameList);

        if (basarili)
        {
            fikir.Text = "";

            lblHata.Text = "Fikir baþarýyla gönderildi, teþekkürler";
            SayfayiDoldur();
        }
        else
            lblHata.Text = "Konuþma ekleme baþarýsýz.";
        
    }
  
}
