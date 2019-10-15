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
using _soru;
using _soruBilgi;


public partial class soruBelirle : System.Web.UI.Page
{
    protected void devam_Click(object sender, EventArgs e)
    {
        ArrayList parameterNameList = new ArrayList(3);
        parameterNameList.Add("@sorup");
        parameterNameList.Add("@gnotp");
        parameterNameList.Add("@knotp");

        ArrayList parameterList = new ArrayList(3);
        parameterList.Add(soru.Text.Trim());
        parameterList.Add(gnot.Text.Trim());
        parameterList.Add(knot.Text.Trim());

        soru s = new soru();
        uint oncekiId = Convert.ToUInt32(Session["ilk_soru"]);
        uint projeId = Convert.ToUInt32(Session["proje_id"]);

        bool basari = s.duzenle(oncekiId, parameterNameList, parameterList);

        if (basari)
        {
            int c = -1;
            int sayac = 0;

            if (evetsorusor.Checked == true)
            {
                c = 1;
                sayac++;
            }
            if (hayirsorusor.Checked == true)
            {
                c = 0;
                sayac++;
            }

            Session["yeni_pencere"] = sayac;
            Session["c"] = c;
            Session["soru"] = soru.Text.Trim();
            Page_Load(this, e);
        }
        else
        {
            soru.Text = "";
            gnot.Text = "";
            knot.Text = "";
        }
    }
    

    protected void tamam_Click(object sender, EventArgs e)
    {
        uint projeId = Convert.ToUInt32(projeler.SelectedItem.Value);

        Session["proje_id"] = projeId;
        Session["proje_ismi"] = projeler.SelectedItem.Text;

        soru s = new soru();
        DataSet ds = new DataSet();

        ds = s.ilkSoru(projeId);

        //soru varsa
        if (ds.Tables.Count != 0)
        {
            //lblHata.Text = "Bu projeye ait soru var";
            panel.Visible = false;
            ph.Visible = true;

            ds.Clear();
            //tüm sorularý göster
            ArrayList sorular = new ArrayList();

            sorular = s.listele(projeId);

            if (sorular.Count != 0)
            {
                ph.Controls.Clear();
                
                Table tablo = new Table();

                foreach (soruBilgi soru1 in sorular)
                {
                    TableRow trow = new TableRow();
                    TableCell tcell = new TableCell();
                    TableCell tcell2 = new TableCell();

                    Label satir = new Label();
                    //Label nl = new Label();
                    HyperLink hl = new HyperLink();
                    HyperLink hlsil = new HyperLink();

                    satir.Text = soru1.soru + " ";
                    //nl.Text = "<br>";
                    hl.Text = "Düzenle";
                    hl.Font.Bold = true;
                    hl.ForeColor = System.Drawing.Color.Black;
                    hl.NavigateUrl = "SoruDuzenle.aspx?id=" + soru1.id;
                    hl.Target = "_blank";

                    tcell.Controls.Add(satir);
                    tcell.HorizontalAlign = HorizontalAlign.Left;
                    tcell2.Controls.Add(hl);
                    if (soru1.evetId == 0 && soru1.hayirId == 0)
                    {
                        Label bos = new Label();
                        bos.Text = " - ";
                        hlsil.Text = "Sil";
                        hlsil.Font.Bold = true;
                        hlsil.ForeColor = System.Drawing.Color.Black;
                        hlsil.NavigateUrl = "SoruSil.aspx?id=" + soru1.id;
                        hlsil.Target = "_blank";
                        tcell2.Controls.Add(bos);
                        tcell2.Controls.Add(hlsil);
                    }
                    tcell2.HorizontalAlign = HorizontalAlign.Left;
                    trow.Cells.Add(tcell);
                    trow.Cells.Add(tcell2);

                    tablo.Rows.Add(trow);
                }
                ph.Controls.Add(tablo);  
            }
            else
                lblHata.Text = "Sorular bulunamadý";


        }
        else
        {
            panel.Visible = true;

            uint soruId = s.ekle(projeId, 0);

            if (soruId != 0)
                Session["ilk_soru"] = soruId;
            else
            {
                lblHata.Text = "Soru için yer ayrýlamadý";
                panel.Visible = false;
            }
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

        soru s = new soru();

        if (IsPostBack && Session["yeni_pencere"] != null)
        {
            ph.Controls.Clear();

            projeler.Enabled = false;
            panel.Visible = false;
            tamam.Visible = false;
            uint projeId = Convert.ToUInt32(Session["proje_id"]);
            uint oncekiId = Convert.ToUInt32(Session["ilk_soru"]);
            bool basari = false;
            uint hayirId = 0;
            uint evetId = 0;

            if (Convert.ToUInt32(Session["yeni_pencere"]) == 2)
            {
                evetId = s.ekle(projeId, oncekiId);
                hayirId = s.ekle(projeId, oncekiId);
/*
                string pencereler = "<script language='javascript'> window.open('SoruEkle.aspx?id=" + evetId + " &c=1', 'External') </script>";
                Page.RegisterStartupScript("PopupScript", pencereler);

                string hayirPenceresi = "<script language='javascript'> window.open('SoruEkle.aspx?id=" + hayirId + " &c=0', 'CustomPopUp' ) </script>";
                Page.RegisterStartupScript("PopupScript", hayirPenceresi);
*/
                basari = s.duzenle(oncekiId, evetId, hayirId);

                HyperLink evetLink = new HyperLink();
                HyperLink hayirLink = new HyperLink();
                Label soru = new Label();
                Label nl = new Label();
                Label bos = new Label();

                evetLink.NavigateUrl = "SoruEkle.aspx?id=" + evetId + "&c=1&o=" + oncekiId;
                evetLink.Visible = true;
                evetLink.Target = "_blank";
                evetLink.Text = "Evet";
                evetLink.Font.Bold = true;
                evetLink.ForeColor = System.Drawing.Color.Black;

                hayirLink.NavigateUrl = "SoruEkle.aspx?id=" + hayirId + "&c=0&o=" + oncekiId;
                hayirLink.Visible = true;
                hayirLink.Target = "_blank";
                hayirLink.Text = "Hayýr";
                hayirLink.Font.Bold = true;
                hayirLink.ForeColor = System.Drawing.Color.Black;

                soru.Text = Session["soru"].ToString();
                nl.Text = "\n";
                bos.Text = " ";

                ph.Visible = true;
                ph.Controls.Add(soru);
                ph.Controls.Add(nl);
                ph.Controls.Add(evetLink);
                ph.Controls.Add(bos);
                ph.Controls.Add(hayirLink);
            }
            else if (Convert.ToUInt32(Session["yeni_pencere"]) == 1)
            {
                //ayrýlacak soru hayýr için
                if (Convert.ToUInt32(Session["c"]) == 0)
                {
                    hayirId = s.ekle(projeId, oncekiId);

                    basari = s.duzenle(oncekiId, evetId, hayirId);

                    HyperLink hayirLink = new HyperLink();
                    Label soru = new Label();
                    Label nl = new Label();

                    hayirLink.NavigateUrl = "SoruEkle.aspx?id=" + hayirId + "&c=0&o=" + oncekiId;
                    hayirLink.Visible = true;
                    hayirLink.Target = "_blank";
                    hayirLink.Text = "Hayýr";
                    hayirLink.Font.Bold = true;
                    hayirLink.ForeColor = System.Drawing.Color.Black;

                    soru.Text = Session["soru"].ToString();
                    nl.Text = "\n";

                    ph.Visible = true;
                    ph.Controls.Add(soru);
                    ph.Controls.Add(nl);
                    ph.Controls.Add(hayirLink);
                }
                //evet için
                else
                {
                    evetId = s.ekle(projeId, oncekiId);

                    basari = s.duzenle(oncekiId, evetId, hayirId);

                    HyperLink evetLink = new HyperLink();
                    Label soru = new Label();
                    Label nl = new Label();

                    evetLink.NavigateUrl = "SoruEkle.aspx?id=" + evetId + "&c=1&o=" + oncekiId;
                    evetLink.Visible = true;
                    evetLink.Target = "_blank";
                    evetLink.Text = "Evet";
                    evetLink.Font.Bold = true;
                    evetLink.ForeColor = System.Drawing.Color.Black;
                    
                    soru.Text = Session["soru"].ToString();
                    nl.Text = "\n";
                    
                    ph.Visible = true;
                    ph.Controls.Add(soru);
                    ph.Controls.Add(nl);
                    ph.Controls.Add(evetLink);

                }
            }
            Session["yeni_pencere"] = null;

            lblHata.Text = "Soru eklendi, diðer sorularý eklemek için linkleri takip ediniz. Teþekkürler.";
            //basarili ise sayfayý 5saniyede kapat
        }

    }
}
