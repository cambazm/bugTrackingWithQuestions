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
using System.IO;
using _soru;


public partial class SoruEkle : System.Web.UI.Page
{
    uint soruId;
    uint c;
    uint oncekiId;


    protected void Page_Load(object sender, EventArgs e)
    {
        soru s = new soru();

        //bu sayfaya sadece web sayfalar�ndaki linklerden ula��labilir
        if (Request.ServerVariables["HTTP_REFERER"] == null)
        {
            lblHata.Text = "Bu sayfaya eri�im izniniz yok";
            panel.Visible = false;
            Label1.Visible = false;
            ph.Visible = false;
         
            return;
        }

        if (Request.QueryString["id"] == null || Request.QueryString["c"] == null || Request.QueryString["o"] == null)
        {
            lblHata.Text = "Yanl�� �al��t�rma bi�imi";
            panel.Visible = false;

            return;
        }

        soruId = Convert.ToUInt32(Request.QueryString["id"]);
        c = Convert.ToUInt32(Request.QueryString["c"]);
        oncekiId = Convert.ToUInt32(Request.QueryString["o"]);


        if (soruId <= 0 || c < 0 || c > 1 || oncekiId <= 0)
        {
            lblHata.Text = "Ge�ersiz girdiler";
            panel.Visible = false;

            return;
        }

        if (Session["proje_ismi"] != null)
        {
            if (Session["tip"].ToString() != "sorumlu")
                Response.Redirect("yetkiYok.aspx");

            projeIsmi.Text = Session["proje_ismi"].ToString();

            DataSet ds = new DataSet();

            ds = s.sonraki(oncekiId);

            //�nceki soruyu g�ster
            if (ds.Tables[0].Rows.Count != 0)
            {
                ph.Controls.Clear();
                Label oncekiSoru = new Label();
                oncekiSoru.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                oncekiSoru.Text += "<br>Cevap: ";
                oncekiSoru.Text += c == 0 ? "Hay�r" : "Evet";
                ph.Controls.Add(oncekiSoru);
            }
        }
        else
        {
            lblHata.Text = "Ge�ersiz giri� y�ntemi";
            panel.Visible = false;
            return;
        }

        //soru yolland� ve daha sonraki sorular i�in yer ayr�ld�, linkleri g�ster
        if (IsPostBack && Session["yeni_pencere_se"] != null)
        {
            uint projeId = Convert.ToUInt32(Session["proje_id"]);
            bool basari = false;
            uint hayirId = 0;
            uint evetId = 0;

            if (Convert.ToUInt32(Session["yeni_pencere_se"]) == 2)
            {
                evetId = s.ekle(projeId, soruId);
                hayirId = s.ekle(projeId, soruId);

                basari = s.duzenle(soruId, evetId, hayirId);

                HyperLink evetLink = new HyperLink();
                HyperLink hayirLink = new HyperLink();
                Label soru = new Label();
                Label nl = new Label();
                Label bos = new Label();

                evetLink.NavigateUrl = "SoruEkle.aspx?id=" + evetId + "&c=1&o=" + soruId;
                evetLink.Visible = true;
                evetLink.Target = "_blank";
                evetLink.Text = "Evet";
                evetLink.Font.Bold = true;
                evetLink.ForeColor = System.Drawing.Color.Black;

                hayirLink.NavigateUrl = "SoruEkle.aspx?id=" + hayirId + "&c=0&o=" + soruId;
                hayirLink.Visible = true;
                hayirLink.Target = "_blank";
                hayirLink.Text = "Hay�r";
                hayirLink.Font.Bold = true;
                hayirLink.ForeColor = System.Drawing.Color.Black;

                soru.Text = Session["soru_se"].ToString();
                nl.Text = "\n";
                bos.Text = " ";

                ph2.Visible = true;
                ph2.Controls.Add(soru);
                ph2.Controls.Add(nl);
                ph2.Controls.Add(evetLink);
                ph2.Controls.Add(bos);
                ph2.Controls.Add(hayirLink);
            }
            else if (Convert.ToUInt32(Session["yeni_pencere_se"]) == 1)
            {
                //ayr�lacak soru hay�r i�in
                if (Convert.ToUInt32(Session["c_se"]) == 0)
                {
                    hayirId = s.ekle(projeId, soruId);

                    basari = s.duzenle(soruId, evetId, hayirId);

                    HyperLink hayirLink = new HyperLink();
                    Label soru = new Label();
                    Label nl = new Label();

                    hayirLink.NavigateUrl = "SoruEkle.aspx?id=" + hayirId + "&c=0&o=" + soruId;
                    hayirLink.Visible = true;
                    hayirLink.Target = "_blank";
                    hayirLink.Text = "Hay�r";
                    hayirLink.Font.Bold = true;
                    hayirLink.ForeColor = System.Drawing.Color.Black;

                    soru.Text = Session["soru_se"].ToString();
                    nl.Text = "\n";

                    ph2.Visible = true;
                    ph2.Controls.Add(soru);
                    ph2.Controls.Add(nl);
                    ph2.Controls.Add(hayirLink);
                }
                //evet i�in
                else
                {
                    evetId = s.ekle(projeId, soruId);

                    basari = s.duzenle(soruId, evetId, hayirId);

                    HyperLink evetLink = new HyperLink();
                    Label soru = new Label();
                    Label nl = new Label();

                    evetLink.NavigateUrl = "SoruEkle.aspx?id=" + evetId + "&c=1&o=" + soruId;
                    evetLink.Visible = true;
                    evetLink.Target = "_blank";
                    evetLink.Text = "Evet";
                    evetLink.Font.Bold = true;
                    evetLink.ForeColor = System.Drawing.Color.Black;

                    soru.Text = Session["soru_se"].ToString();
                    nl.Text = "\n";

                    ph2.Visible = true;
                    ph2.Controls.Add(soru);
                    ph2.Controls.Add(nl);
                    ph2.Controls.Add(evetLink);

                }
            }
            Session["yeni_pencere_se"] = null;
            Session["soru_se"] = null;
            Session["c_se"] = null;


            lblHata.Text = "Soru eklendi, di�er sorular� eklemek i�in linkleri takip ediniz. Te�ekk�rler.";
            panel.Visible = false;
            Label1.Visible = false;
            ph.Visible = false;
            //basarili ise sayfay� 5saniyede kapat
        }        
    }


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
        DataSet ds = new DataSet();

        ds = s.sonraki(oncekiId);

        //�nceki soruyu g�ster
        if (ds.Tables[0].Rows.Count != 0)
        {
            ph.Controls.Clear();
            Label oncekiSoru = new Label();
            oncekiSoru.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            oncekiSoru.Text += "<br>Cevap: ";
            oncekiSoru.Text += c == 0 ? "Hay�r" : "Evet";
            ph.Controls.Add(oncekiSoru);
        }

        bool basari = s.duzenle(soruId, parameterNameList, parameterList);

        if (basari)
        {
            int cvp = -1;
            int sayac = 0;

            if (evetsorusor.Checked == true)
            {
                cvp = 1;
                sayac++;
            }
            if (hayirsorusor.Checked == true)
            {
                cvp = 0;
                sayac++;
            }

            Session["yeni_pencere_se"] = sayac;
            Session["c_se"] = cvp;
            Session["soru_se"] = soru.Text.Trim();

            //Server.Transfer("SoruEkle.aspx?id=" + soruId + "&c=" + c);
            
            soru.Text = "";
            gnot.Text = "";
            knot.Text = "";
            //yeni sorular i�in yer ay�r
            Page_Load(this, e);
        }
        else
        {
            lblHata.Text = "��lem ba�ar�s�z";
            panel.Visible = false;
        }
        //
    }
}
