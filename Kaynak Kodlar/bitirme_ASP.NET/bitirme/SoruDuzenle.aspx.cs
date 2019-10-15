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
using _soruBilgi;



public partial class SoruDuzenle : System.Web.UI.Page
{
    uint soruId;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //bu sayfaya sadece web sayfalar�ndaki linklerden ula��labilir
            if (Request.ServerVariables["HTTP_REFERER"] == null)
            {
                lblHata.Text = "Bu sayfaya eri�im izniniz yok";
                panel.Visible = false;
                Label1.Visible = false;
                ph.Visible = false;

                return;
            }

            soru s = new soru();

            if (Request.QueryString["id"] != null)
            {
                soruId = Convert.ToUInt32(Request.QueryString["id"]);


                if (soruId <= 0)
                {
                    lblHata.Text = "Ge�ersiz girdiler";
                    panel.Visible = false;

                    return;
                }
                else
                {
                    if (Session["tip"].ToString() != "sorumlu")
                        Response.Redirect("yetkiYok.aspx");

                    projeIsmi.Text = Session["proje_ismi"].ToString();

                    soruBilgi soruB = s.getir(soruId);

                    if (soruB.id != 0)
                    {
                        soru.Text = soruB.soru;
                        knot.Text = soruB.kNot;
                        gnot.Text = soruB.getgNot();

                        ph.Controls.Clear();

                        if (soruB.evetId == 0)
                            evetsorusor.Checked = false;
                        else
                        {
                            evetsorusor.Checked = true;
                            evetsorusor.Enabled = false;

                            HyperLink hl = new HyperLink();
                            hl.NavigateUrl = "SoruDuzenle.aspx?id=" + soruB.evetId;
                            hl.Target = "_blank";
                            hl.Text = "Evetse gidilecek soru";

                            Label nl = new Label();
                            nl.Text = "<br>";

                            ph.Controls.Add(hl);
                            ph.Controls.Add(nl);
                        }

                        if (soruB.hayirId == 0)
                            hayirsorusor.Checked = false;
                        else
                        {
                            hayirsorusor.Checked = true;
                            hayirsorusor.Enabled = false;

                            HyperLink hl = new HyperLink();
                            hl.NavigateUrl = "SoruDuzenle.aspx?id=" + soruB.hayirId;
                            hl.Target = "_blank";
                            hl.Text = "Hay�rsa gidilecek soru";

                            ph.Controls.Add(hl);
                        }
                    }
                    else
                    {
                        lblHata.Text = "Soru bulunamad�";
                        panel.Visible = false;

                        return;
                    }
                }
            }
        }
        else
        {   
            soruId = Convert.ToUInt32(Request.QueryString["id"]);
            
            soru s = new soru();

            if (evetsorusor.Checked == true && evetsorusor.Enabled == true)
            {
                soruBilgi soruB = s.getir(soruId);

                uint evetId = s.ekle(Convert.ToUInt32(Session["proje_id"]), soruId);

                bool basari = s.duzenleE(soruId, evetId);

                if (basari)
                {
                    ph2.Visible = true;

                    HyperLink evetLink = new HyperLink();
                    Label soru = new Label();
                    Label nl = new Label();
                    nl.Text = "<br>";

                    evetLink.NavigateUrl = "SoruEkle.aspx?id=" + evetId + "&c=1&o=" + soruId;
                    evetLink.Visible = true;
                    evetLink.Target = "_blank";
                    evetLink.Text = "Evet";
                    evetLink.Font.Bold = true;
                    evetLink.ForeColor = System.Drawing.Color.Black;

                    ph2.Controls.Add(evetLink);
                    ph2.Controls.Add(nl);
                }
                else
                    lblHata.Text = "Soru i�in yer ayr�lamad�";
            }
            if (hayirsorusor.Checked == true && hayirsorusor.Enabled == true)
            {
                soruBilgi soruB = s.getir(soruId);

                uint hayirId = s.ekle(Convert.ToUInt32(Session["proje_id"]), soruId);

                bool basari = s.duzenleH(soruId, hayirId);
                
                if (basari)
                {
                    ph2.Visible = true;

                    HyperLink hayirLink = new HyperLink();
                    Label nl = new Label();
                    nl.Text = "<br>";

                    hayirLink.NavigateUrl = "SoruEkle.aspx?id=" + hayirId + "&c=0&o=" + soruId;
                    hayirLink.Visible = true;
                    hayirLink.Target = "_blank";
                    hayirLink.Text = "Hay�r";
                    hayirLink.Font.Bold = true;
                    hayirLink.ForeColor = System.Drawing.Color.Black;

                    ph2.Controls.Add(hayirLink);
                    ph2.Controls.Add(nl);
                }
                else
                    lblHata.Text = "Soru i�in yer ayr�lamad�";
            }

        }
    }
    protected void devam_Click(object sender, EventArgs e)
    {
        soru s = new soru();

        ArrayList parameterNameList = new ArrayList(3);
        parameterNameList.Add("@sorup");
        parameterNameList.Add("@gnotp");
        parameterNameList.Add("@knotp");

        ArrayList parameterList = new ArrayList(3);
        parameterList.Add(soru.Text.Trim());
        parameterList.Add(gnot.Text.Trim());
        parameterList.Add(knot.Text.Trim());

        bool basari = s.duzenle(soruId, parameterNameList, parameterList);

        if (!basari)
            lblHata.Text = "��lem ba�ar�s�z";
        else
        {
            lblHata.Text = "Soru ba�ar�yla d�zeltildi";
            panel.Visible = false;
            ph.Visible = false;
            Label1.Visible = false;
        }    

    }
}
