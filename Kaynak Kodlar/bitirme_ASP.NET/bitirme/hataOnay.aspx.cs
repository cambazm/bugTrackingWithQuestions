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

public partial class hataOnay : System.Web.UI.Page
{
    uint hata_id;

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
            SayfayiDoldur();
        }
    }

    protected void SayfayiDoldur()
    {
        ph.Controls.Clear();

        //kullan�c�n�n g�nderdi�i ��Z�LMEM�� ve ��z�m eklenmi� hatalar listelenecek
        uint yollayan_id = Convert.ToUInt32(Session["yollayanid_session"]);

        hata h = new hata();
        DataSet ds = new DataSet();

        ds = h.onaylanabilirHatalar(yollayan_id);


        if (ds.Tables[0].DefaultView.Count > 0)
        {
            /*
             ilgili hatalar�n listesini ��kar
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
                    

                    sutun.BackColor = System.Drawing.Color.BlanchedAlmond;
                    sutun.HorizontalAlign = HorizontalAlign.Left;

                    

                    if (i != 0)
                    {
                        sutunAciklama.Text = ds.Tables[0].DefaultView.Table.Columns[i].Caption;
                        sutun.Text = ds.Tables[0].DefaultView.Table.Rows[j].ItemArray.GetValue(i).ToString();
                        sutunAciklama.Height = 50;
                        sutun.Height = 50;
                    }
                    else if (i == 0)
                    {
                        HyperLink hl = new HyperLink();
                        hl.NavigateUrl = "Incele.aspx?id=" + ds.Tables[0].DefaultView.Table.Rows[j].ItemArray.GetValue(i).ToString();
                        hl.ID = "hl_" + j.ToString() + "_" + i.ToString();
                        hl.Text = "�ncele";
                        hl.ForeColor = System.Drawing.Color.Black;
                        hl.Font.Bold = true;

                        sutunAciklama.Text = "��lem";
                        sutun.Text = "";
                        sutun.Controls.Add(hl);
                    }

                    sutunAciklama.Width = 150;
                    sutun.Width = 400;

                    satir.Cells.Add(sutunAciklama);
                    satir.Cells.Add(sutun);

                    tablo.Rows.Add(satir);
                }

                //son sat�ra hata ile ilgili yap�labilecek i�lem linkleri konulacak
                TableRow linkler = new TableRow();
                TableCell link = new TableCell();

                Button onayver = new Button();
                onayver.Text = "��z�m� onayla";

                //butonun ID si hata id si olacak b�ylece o kullan�larak hata onaylama i�lemi ger�eklenecek
                onayver.ID = ds.Tables[0].DefaultView.Table.Rows[j].ItemArray.GetValue(0).ToString();

                onayver.Click += new System.EventHandler(onayla_Click);

                link.ColumnSpan = 2;
                link.HorizontalAlign = HorizontalAlign.Right;
                link.Controls.Add(onayver);

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
            lblHata.Text = "��z�m eklenmi� bir hatan�z mevcut de�il";

    }


    protected void onayla_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;

        hata h = new hata();
        
        hata_id = Convert.ToUInt32(b.ID);

        
        lblHata.Text = h.onayla(hata_id);


        SayfayiDoldur();
    }

}
