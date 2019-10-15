using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using _vt;

/// <summary>
/// projeler üzerindeki iþlemleri gerçekler
/// </summary>
namespace _proje
{
    public class proje
    {
        vt db;       //veritabanýna eriþim nesnesi


        public proje()
        {
            db = new vt();
        }


        /// <summary>
        /// verilen id li projenin ismini getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string isimGetir(uint id)
        {
            string sql = "SELECT ISIM FROM Proje WHERE ID="+id;
            DataSet ds = new DataSet();
            ds = db.fillDataset(sql);

            if (ds.Tables[0].DefaultView.Table.Rows.Count != 0)
                return ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(0).ToString();
            else
                return "";
        }

        //projelerin listesini getirir
        public DataSet doldur()
        {
            string sql = "SELECT * FROM Proje";

            return db.fillDataset(sql);
        }


        //projelerin isimleri getirir
        public DataSet isimListesi()
        {
            string sql = "SELECT ISIM FROM Proje";

            return db.fillDataset(sql);       
        }


        //projelerin isimlerini ve id lerini getirir
        public DataSet isimIdListesi()
        {
            string sql = "SELECT ID, ISIM FROM Proje";

            return db.fillDataset(sql);
        }


        //verilen proje isminin id deðerini getirir
        public uint idGetir(string projeIsmi)
        {
            string sql = "SELECT ID FROM Proje WHERE ISIM ='" + projeIsmi + "'";

            DataSet ds = new DataSet();

            ds = db.fillDataset(sql);

            if (ds.Tables[0].DefaultView.Count == 0)
                return 0;
            else
                return Convert.ToUInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        }


        //projelerin isimleri getirir
        public uint projeyeAitCozulmemisHataSayisi(string projeIsmi)
        {
            uint id = idGetir(projeIsmi);

            //böyle bir proje varsa
            if (id != 0)
            {
                string sql = "SELECT COUNT(*) FROM Hata WHERE PROJEID =" + id + " AND COZUMONAY = 0";

                DataSet ds = new DataSet();

                ds = db.fillDataset(sql);

                //hiç çözülmemiþ hata yoksa
                if (ds.Tables[0].DefaultView.Count == 0)
                    return 0;
                else
                    return Convert.ToUInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            else
                return 0;
        }



        //verilen isim ve türde proje ekler
        public string ekle(string projeIsmi, string projeTuru)
        {
            bool basarili = false;
            string selectSql = "SELECT ISIM FROM Proje WHERE ISIM='" + projeIsmi + "'";
            string sql = "INSERT INTO Proje (ISIM, TUR) VALUES ('" + projeIsmi + "','" + projeTuru + "')";

            try
            {
                DataSet ds = db.fillDataset(selectSql);

                //proje daha önce eklenmemiþ ise ekle
                if (!(ds.Tables[0].DefaultView.Count > 0))
                {
                    basarili = db.executeNonQuery(sql);

                    if (!basarili)
                        return "Ekleme iþlemi baþarýsýz.";
                    else
                        return "Proje baþarýyla eklendi";
                }
                else
                    return "Bu proje daha önce eklenmiþ";

            }
            catch
            {
                return "Veritabanýna eriþilemedi.";
            }
        }


        //verilen id li projeyi silmeye çalýþýr, eðer projeye ait hatalar varsa silmeye izin vermez
        public string sil(uint projeId, string projeIsmi)
        {
            bool basarili = false;

            string sql = "DELETE FROM Proje WHERE ID = " + projeId;

            basarili = db.executeNonQuery(sql);

            if (!basarili)
                return "Silme iþlemi baþarýsýz, bu projeye ait hatalar var.";
            else
                return projeIsmi + " silindi.";
        
        }

    }
}
