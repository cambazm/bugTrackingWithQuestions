using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using _proje;


/// <summary>
/// Summary description for projeWS
/// </summary>
[WebService(Namespace = "http://localhost/projeWS/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class projeWS : System.Web.Services.WebService 
{

    public projeWS () 
    {
    }


    [WebMethod(Description = "Tüm mevcut projelerin isimlerini getirir")]
    public string[] projeleriListele()
    {
        DataSet ds = new DataSet();
        proje p = new proje();
        string[] projeler;                       //sonuçlarýn içine atýlacaðý dizi


        //veritabanýndan mevcut projelerin id lerini ve isimlerini çek
        ds = p.isimListesi();


        //proje varsa diziye alacaðýz
        if (ds.Tables[0].Rows.Count != 0)
        {
            //dizi için yer ayýr
            projeler = new string[ds.Tables[0].DefaultView.Table.Rows.Count];

            for (int j = 0; j < ds.Tables[0].DefaultView.Table.Rows.Count; j++)
            {
                string isim = ds.Tables[0].DefaultView.Table.Rows[j].ItemArray.GetValue(0).ToString();

                //her isim, döndürülecek projeler dizisinin bir elemaný
                projeler[j] = isim;
            }
        }
        //hiç proje yoksa dizi boþ olacak
        else
            projeler = null;


        //proje id ve isim listesini dondur
        return projeler;
    }


    [WebMethod(Description = "Girilen projeye ait mevcut çözülmemiþ hata sayýsýný verir.")]
    public uint projeyeAitCozulmemisHataSayisi(string projeIsmi)
    {
        proje p = new proje();

        projeIsmi = projeIsmi.ToUpper().Trim();

        return p.projeyeAitCozulmemisHataSayisi(projeIsmi);
    }
    
}

