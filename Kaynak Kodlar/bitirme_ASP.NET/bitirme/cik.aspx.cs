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

public partial class cik : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["tip"] = null;
        Session["kullanici"] = null;
        Session["yollayanid_session"] = null;
        Session.RemoveAll();

        lblHata.Text = "Oturumunuzu baþarýyla kapattýnýz.";
    }
}
