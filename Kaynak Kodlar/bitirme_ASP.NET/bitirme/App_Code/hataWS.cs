using System;
using System.Web;
using System.Data;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using _hata;
using _proje;
using _soru;
using _hataBilgi;
using _soruBilgi;



/// <summary>
/// Summary description for hataWS
/// </summary>
[WebService(Namespace = "http://localhost/hataWS/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class hataWS : System.Web.Services.WebService 
{

    public hataWS () 
    {
    }

    [WebMethod(Description = "Girilen projeye ait mevcut çözülmemiþ hatalarý getirir.")]
    public hataBilgi[] getir(string projeIsmi) 
    {
        hataBilgi[] hatalarDizisi;
 
        uint id, projeId;
        string aciklama;
        string zaman;   //normalde DateTime ama W-I uyumlu olmasý için string gönderilecek
        DataSet ds;

        proje p = new proje();

        projeIsmi = projeIsmi.Trim().ToUpper();

        projeId = p.idGetir(projeIsmi);

        if (projeId == 0)
        {
            hatalarDizisi = new hataBilgi[1];
            hataBilgi hataB = new hataBilgi();
            hatalarDizisi[0] = hataB;

            return hatalarDizisi;
        }

        hata h = new hata();

        ds = h.projeyeAitHatalar(projeId);


        //proje ile ilgili çözümlenmemiþ hata varsa göster
        if (ds.Tables[0].DefaultView.Count > 0)
        {
            //dizi için yer ayýr
            hatalarDizisi = new hataBilgi[ds.Tables[0].DefaultView.Table.Rows.Count];

            for (int j = 0; j < ds.Tables[0].DefaultView.Table.Rows.Count; j++)
            {
                id = Convert.ToUInt32(ds.Tables[0].DefaultView.Table.Rows[j].ItemArray.GetValue(0));
                projeIsmi = ds.Tables[0].DefaultView.Table.Rows[j].ItemArray.GetValue(1).ToString();
                aciklama = ds.Tables[0].DefaultView.Table.Rows[j].ItemArray.GetValue(2).ToString();
                //DateTime ama WS-I uyumlu olmasý için string olarak gönderilmeli
                zaman = ds.Tables[0].DefaultView.Table.Rows[j].ItemArray.GetValue(3).ToString();

                hataBilgi hataB = new hataBilgi(id, projeIsmi, aciklama, zaman);
                hatalarDizisi[j] = hataB;
            }
        }
        else
        {
            hatalarDizisi = new hataBilgi[1];
            hataBilgi hataB = new hataBilgi();
            hatalarDizisi[0] = hataB;

        }

        return hatalarDizisi;
    }
    
    
    [WebMethod(Description = "Girilen projeye ait ilk soruyu getirir.")]
    public soruBilgi ilkSoru(string projeIsmi)
    {
        DataSet ds = new DataSet();
        soru s = new soru();
        soruBilgi soruB;
        proje p = new proje();

        projeIsmi = projeIsmi.Trim().ToUpper();

        uint projeId = p.idGetir(projeIsmi);

        if (projeId != 0)
            ds = s.ilkSoru(projeId);
        else
        {
            soruB = new soruBilgi();
            return soruB;
        }

        //soru varsa gösterilecek
        if (ds.Tables.Count != 0)
        {
            string soru1 = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            string kNot = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            uint id = Convert.ToUInt32(ds.Tables[0].Rows[0].ItemArray[2]);
            uint evetId, hayirId;

            if (ds.Tables[0].Rows[0].ItemArray[3] != System.DBNull.Value)
                evetId = Convert.ToUInt32(ds.Tables[0].Rows[0].ItemArray[3].ToString());
            else
                evetId = 0;

            if (ds.Tables[0].Rows[0].ItemArray[4] != System.DBNull.Value)
                hayirId = Convert.ToUInt32(ds.Tables[0].Rows[0].ItemArray[4].ToString());
            else
                hayirId = 0;

            soruB = new soruBilgi(id, soru1, kNot, evetId, hayirId);
        }
        else
            soruB = new soruBilgi();


        return soruB;
    }

    
    [WebMethod(Description = "Verilen id ye sahip soruyu getirir.")]
    public soruBilgi sonraki(uint id)
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


        /* evet denilince bir soru daha sor diye tanýmlanmýþsa yeni soruyu göster */
        if (ds.Tables[0].Rows.Count != 0)
        {
            //YAPILACAK ÝÞ VAR
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

    
    [WebMethod(Description = "Hata Gönderme aracý")]
    public string gonder(string projeIsmi, uint sonSoruId, int cevap, string hataAciklama, uint yollayanId)
    {
        string sonuc;
        uint projeId;


        if (cevap >= 1)
            cevap = 1;
        else
            cevap = 0;

        hata h = new hata();
        proje p = new proje();

        //proje mevcut olmalý kesin
        projeId = p.idGetir(projeIsmi);

        ArrayList parameterNameList = new ArrayList(2);
        parameterNameList.Add("@aciklama");
        parameterNameList.Add("@simdi");
        ArrayList parameterList = new ArrayList(2);
        parameterList.Add(hataAciklama.Replace("\n", "<br>").Trim());
        parameterList.Add(System.DateTime.Now);


        sonuc = h.gonder(projeId,
                         sonSoruId,
                         parameterNameList,
                         parameterList,
                         yollayanId,
                         cevap);

        return sonuc;
    }

}

