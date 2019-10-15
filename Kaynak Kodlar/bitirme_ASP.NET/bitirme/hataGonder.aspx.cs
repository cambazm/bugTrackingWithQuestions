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
using _soru;
using _soruBilgi;

public partial class hataGonder : System.Web.UI.Page
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
        }
    }


    //proje ile ilgili ilk soruyu getir    
    protected void devam_Click(object sender, EventArgs e)
    {
        lbl.Text = "";

        soru s = new soru();
        DataSet ds = new DataSet();

        ds = s.ilkSoru(Convert.ToUInt32(projeler.SelectedItem.Value));

        //soru dönmüþse gösterilecek
        if (ds.Tables.Count != 0)
        {
            evet.Visible = true;
            hayir.Visible = true;
            lblCevapla.Visible = true;
            lblNot.Visible = true;
            lblAciklama.Visible = true;

            //Soruyu lbl a al
            lbl.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            //Kullanýcý için notu lblNot a al
            lblNot.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();

            //sorunun id sini oturum deðiþkenine al
            Session["soruid_session"] = Convert.ToUInt32(ds.Tables[0].Rows[0].ItemArray[2].ToString());
            
            //evet ve hayir idlerini oturum deðiþkenlerine al (boþ deðilse)
            if (ds.Tables[0].Rows[0].ItemArray[3] != System.DBNull.Value)
                Session["evetid_session"] = Convert.ToUInt32(ds.Tables[0].Rows[0].ItemArray[3].ToString());
            else
                Session["evetid_session"] = 0;

            if(ds.Tables[0].Rows[0].ItemArray[4] != System.DBNull.Value)
                Session["hayirid_session"] = Convert.ToUInt32(ds.Tables[0].Rows[0].ItemArray[4].ToString());
            else
                Session["hayirid_session"] = 0;
        }
        else
        {
            pnl.Visible = false;
            lblCevapla.Visible = false;
            lblNot.Visible = false;
            lblAciklama.Visible = false;
            evet.Visible = false;
            hayir.Visible = false;
            lbl.Text = "Bu projeye daha soru eklenmemiþ, bu nedenle hata gönderemezsiniz.";
            lblNot.Text = "";
        }
    }


    //evet denilince ilgili bir sonraki soruya geç
    protected void evet_Click(object sender, EventArgs e)
    {
        Session["cevap"] = 1;

        soruyuGoster(Convert.ToUInt32(Session["evetid_session"]));
    }


    //hayýr denilince bir sonraki soruya geç
    protected void hayir_Click(object sender, EventArgs e)
    {
        Session["cevap"] = 0;

        soruyuGoster(Convert.ToUInt32(Session["hayirid_session"]));
    }


    //verilen id li soruyu formda düzgün bir þekilde göstererek oturum deðiþkenlerini ayarlar
    private void soruyuGoster(uint id)
    {
        //bir kere evet veya hayýr denildiðinde artýk proje deðiþtirilemez
        if (projeler.Enabled != false)
        {
            projeler.Enabled = false;
            devam.Visible = false;
        }

        lblHata.Text = "";

        soruBilgi soruB = sonrakiSoru(id);
                
        /* bir soru daha sor diye tanýmlanmýþsa yeni soruyu göster */
        if (soruB.id != 0)
        {
            lbl.Text = soruB.soru;
            lblNot.Text = soruB.kNot;
            Session["soruid_session"] = soruB.id;
            Session["evetid_session"] = soruB.evetId;
            Session["hayirid_session"] = soruB.hayirId;
        }
        //yeni soru tanýmlý deðil hatayý al
        else
        {
            pnl.Visible = true;
            evet.Visible = false;
            hayir.Visible = false;
            lblCevapla.Visible = false;
            lblNot.Visible = false;
            lblAciklama.Visible = false;
        }
     
    }


    //hata için bir açýklama girildi
    protected void gonder_Click(object sender, EventArgs e)
    {
        hata h = new hata();

        ArrayList parameterNameList = new ArrayList(2);
        parameterNameList.Add("@aciklama");
        parameterNameList.Add("@simdi");
        ArrayList parameterList = new ArrayList(2);
        parameterList.Add(hata.Text.Replace("\n","<br>").Trim());
        parameterList.Add(System.DateTime.Now);


        lbl.Text = h.gonder(Convert.ToUInt32(projeler.SelectedItem.Value),
                            Convert.ToUInt32(Session["soruid_session"].ToString()),
                            parameterNameList,
                            parameterList,
                            Convert.ToUInt32(Session["yollayanid_session"].ToString()),
                            Convert.ToInt32(Session["cevap"]));
        hata.Text = "";

    }


    //veritabanýndan verilen id li soruyu bir soruBilgi nesnesi içinde getirir
    private soruBilgi sonrakiSoru(uint id)
    {
        soruBilgi soruB;

        if (id <= 0)
        {
            soruB = new soruBilgi();
            return soruB;
        }

        soru s = new soru();

        DataSet ds = new DataSet();

        ds = s.sonraki(id);


        /* evet denilince bir soru daha sor diye tanýmlanmýþsa EVETID için geri dönen bir satýr olacak
           yeni soruyu göster */
        if (ds.Tables[0].Rows.Count != 0)
        {
            string soru1 = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            string kNot = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            uint soruId = Convert.ToUInt32(ds.Tables[0].Rows[0].ItemArray[2].ToString());
            uint evetId, hayirId;

            if (ds.Tables[0].Rows[0].ItemArray[3] != System.DBNull.Value)
                evetId = Convert.ToUInt32(ds.Tables[0].Rows[0].ItemArray[3].ToString());
            else
                evetId = 0;

            if (ds.Tables[0].Rows[0].ItemArray[4] != System.DBNull.Value)
                hayirId = Convert.ToUInt32(ds.Tables[0].Rows[0].ItemArray[4].ToString());
            else
                hayirId = 0;

            soruB = new soruBilgi(soruId, soru1, kNot, evetId, hayirId);
        }
        //yeni soru tanýmlý deðil hatayý al
        else
            soruB = new soruBilgi();


        return soruB;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Server.Transfer("hataGonderU.aspx");
    }
}
