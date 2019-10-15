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


    [WebMethod(Description = "T�m mevcut projelerin isimlerini getirir")]
    public string[] projeleriListele()
    {
        DataSet ds = new DataSet();
        proje p = new proje();
        string[] projeler;                       //sonu�lar�n i�ine at�laca�� dizi


        //veritaban�ndan mevcut projelerin id lerini ve isimlerini �ek
        ds = p.isimListesi();


        //proje varsa diziye alaca��z
        if (ds.Tables[0].Rows.Count != 0)
        {
            //dizi i�in yer ay�r
            projeler = new string[ds.Tables[0].DefaultView.Table.Rows.Count];

            for (int j = 0; j < ds.Tables[0].DefaultView.Table.Rows.Count; j++)
            {
                string isim = ds.Tables[0].DefaultView.Table.Rows[j].ItemArray.GetValue(0).ToString();

                //her isim, d�nd�r�lecek projeler dizisinin bir eleman�
                projeler[j] = isim;
            }
        }
        //hi� proje yoksa dizi bo� olacak
        else
            projeler = null;


        //proje id ve isim listesini dondur
        return projeler;
    }


    [WebMethod(Description = "Girilen projeye ait mevcut ��z�lmemi� hata say�s�n� verir.")]
    public uint projeyeAitCozulmemisHataSayisi(string projeIsmi)
    {
        proje p = new proje();

        projeIsmi = projeIsmi.ToUpper().Trim();

        return p.projeyeAitCozulmemisHataSayisi(projeIsmi);
    }
    
}

