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
using _soru;
using _hata;
using _soruBilgi;


public partial class hataGonderU : System.Web.UI.Page
{
    soru s = new soru();


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

    //hata için bir açýklama girildi
    protected void gonder_Click(object sender, EventArgs e)
    {
        hata h = new hata();

        ArrayList parameterNameList = new ArrayList(2);
        parameterNameList.Add("@aciklama");
        parameterNameList.Add("@simdi");
        ArrayList parameterList = new ArrayList(2);
        parameterList.Add(hata.Text.Replace("\n", "<br>").Trim());
        parameterList.Add(System.DateTime.Now);


        lbl.Text = h.gonder(Convert.ToUInt32(projeler.SelectedItem.Value),
                            Convert.ToUInt32(Session["soruid_session"].ToString()),
                            parameterNameList,
                            parameterList,
                            Convert.ToUInt32(Session["yollayanid_session"].ToString()),
                            Convert.ToInt32(Session["cevap"]));
        hata.Text = "";

        MultiView1.SetActiveView(View1);
        evet.Visible = false;
        hayir.Visible = false; 
        lblAciklama.Visible = false;
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

    //proje ile ilgili tüm sorularý getir    
    protected void devam_Click(object sender, EventArgs e)
    {
        ArrayList sorular;

        sorular = s.listele(Convert.ToUInt32(projeler.SelectedItem.Value), true);

        if (sorular.Count != 0)
        {
            soruListesi.Items.Clear();
            foreach (soruBilgi soruB in sorular)
            {
                ListItem li = new ListItem(soruB.soru, soruB.id.ToString());
                soruListesi.Items.Add(li);
            }

            MultiView1.Visible = true;
            MultiView1.SetActiveView(View1);
        }
        else
            lblHata.Text = "Bu projeye ait soru yok";
    }

    //evet denilince ilgili bir sonraki soruya geç
    protected void evet_Click(object sender, EventArgs e)
    {
        Session["cevap"] = 1;

        if (Session["normal_devam"] == null)
        {
            soruBilgi s1 = s.getir(Convert.ToUInt32(soruListesi.SelectedItem.Value));
            Session["evetid_session"] = s1.evetId;
            Session["soruid_session"] = s1.id;
            soruListesi.Visible = false;
            devam.Visible = false;
        }

        soruyuGoster(Convert.ToUInt32(Session["evetid_session"]));
    }


    //hayýr denilince bir sonraki soruya geç
    protected void hayir_Click(object sender, EventArgs e)
    {
        Session["cevap"] = 0;

        if (Session["normal_devam"] == null)
        {
            soruBilgi s1 = s.getir(Convert.ToUInt32(soruListesi.SelectedItem.Value));
            Session["hayirid_session"] = s1.hayirId;
            Session["soruid_session"] = s1.id;
            soruListesi.Visible = false;
            devam.Visible = false;
        }

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
        soruBilgi soruB;

        if(id != 0)
            soruB = sonrakiSoru(id);
        else
        {
            MultiView1.SetActiveView(View2);
            return;
        }

        /* bir soru daha sor diye tanýmlanmýþsa yeni soruyu göster */
        if (soruB.id != 0)
        {
            lblAciklama.Visible = true;
            lbl.Text = soruB.soru;
            lblNot.Text = soruB.kNot;
            Session["soruid_session"] = soruB.id;
            Session["evetid_session"] = soruB.evetId;
            Session["hayirid_session"] = soruB.hayirId;
            Session["normal_devam"] = 1;
        }
        //yeni soru tanýmlý deðil hatayý al
        else
        {
            MultiView1.SetActiveView(View2);
        }

    }
}
