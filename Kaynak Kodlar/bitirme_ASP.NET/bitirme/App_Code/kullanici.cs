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
using _vt;

namespace _kullanici
{
    /// <summary>
    /// kullanýcý iþlemlerinden sorumlu nesne
    /// </summary>
    public class kullanici
    {
        vt db;

        public kullanici()
        {
            db = new vt();
        }


        /// <summary>
        /// verilen isimli kullanýcýnýn idsini getirir
        /// </summary>
        /// <param name="isim"></param>
        /// <returns></returns>
        public uint idGetir(string isim)
        {
            string sql = "SELECT ID FROM Kullanici WHERE ISIM ='" + isim + "'";

            DataSet ds = new DataSet();
            ds = db.fillDataset(sql);

            if (ds.Tables[0].DefaultView.Table.Rows.Count == 0)
                return 0;
            else
                return Convert.ToUInt32(ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(0)); 


        }

        /// <summary>
        /// sýfýrdan bir kullanýcý ekler
        /// </summary>
        /// <param name="isim"></param>
        /// <param name="sifre"></param>
        /// <param name="mail"></param>
        /// <param name="bilgOzellik"></param>
        /// <param name="tip"></param>
        /// <returns>1: kullanýcý ismi var
        /// 2: mail var
        /// 3: veritabanýna ekleme hatasý
        /// 0: baþarýle ekleme</returns>
        public uint ekle(string isim, string sifre, string mail, string bilgOzellik, uint tip)
        {
            string bakSql = "SELECT COUNT(*) FROM Kullanici WHERE ISIM = '" + isim + "'";
            DataSet ds = new DataSet();
            ds = db.fillDataset(bakSql);

            if (Convert.ToUInt32(ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(0)) == 1)
                return 1;   //kullanici ismi var
            else
            {
                string bakSqlMail = "SELECT COUNT(*) FROM Kullanici WHERE MAIL = '" + mail + "'";
                DataSet dsMail = new DataSet();
                dsMail = db.fillDataset(bakSqlMail);

                if (Convert.ToUInt32(dsMail.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(0)) == 1)
                    return 2;   //mail var
                else
                {
                    ArrayList parameterNameList = new ArrayList(1);
                    parameterNameList.Add("@bilgOzellik");
                    ArrayList parameterList = new ArrayList(1);
                    parameterList.Add(bilgOzellik);

                    string sql = "INSERT INTO Kullanici (ISIM, SIFRE, MAIL, BILGOZELLIK, TIPID) VALUES ('" + isim + "' ,'" + sifre + "', '" + mail + "', @bilgOzellik, " + tip + ")";

                    if (db.executeNonQuery(sql, parameterNameList, parameterList) == true)
                        return 0;
                    else
                        return 3;   //ekleme iþlemi hatasý
                }
            }

        }

        /// <summary>
        /// verilen isimli kullanýcýnýn kullanýcý tipini döndürür
        /// </summary>
        /// <param name="isim"></param>
        /// <returns></returns>
        public string tipGetir(string isim)
        {
            string sql = "SELECT TIP FROM KTip INNER JOIN Kullanici ON KTip.ID = Kullanici.TIPID WHERE ISIM = '" + isim + "'";
            DataSet ds = new DataSet();

            ds = db.fillDataset(sql);
            if (ds.Tables[0].DefaultView.Table.Rows.Count != 0)
                return ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(0).ToString();
            else
                return "";
        }

        /*
        /// <summary>
        /// verilen isimli kullanýcýyý sil
        /// </summary>
        /// <param name="isim"></param>
        /// <returns></returns>
        public bool sil(string isim)
        { 
        
        }

*/
        /// <summary>
        /// kullanýcýnýn mail ve bilgisayar özelliklerini düzenle
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sifre"></param>
        /// <param name="bilgOzellik"></param>
        /// <returns></returns>
        public bool duzenle(uint id, string mail, string bilgOzellik)
        {
            string sql = "UPDATE Kullanici SET MAIL = '"+mail+"'";
            sql += ", BILGOZELLIK = @BLGOZELLIK WHERE ID="+id;

            ArrayList parameterList = new ArrayList(1);
            parameterList.Add(bilgOzellik);
            ArrayList parameterNameList = new ArrayList(1);
            parameterNameList.Add("@BLGOZELLIK");

            return db.executeNonQuery(sql, parameterNameList, parameterList);
        }
        

        /// <summary>
        /// kullanýcýnýn þifresini deðiþtirir
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eskiSifre"></param>
        /// <param name="yeniSifre"></param>
        /// <returns>1: eski þifre yanlýþ
        /// 2: veritabanýna eriþilemedi
        /// 0: baþarý</returns>
        public uint sifreDegistir(uint id, string eskiSifre, string yeniSifre)
        {
            string sql = "SELECT COUNT(*) FROM Kullanici WHERE SIFRE='"+eskiSifre+"' AND ID="+id;
            
            DataSet ds = new DataSet();
            ds = db.fillDataset(sql);

            if(Convert.ToUInt32(ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(0)) == 1)
            {
                string dsql = "UPDATE Kullanici SET SIFRE = '"+yeniSifre+"' WHERE ID = "+id;
                
                bool basari = db.executeNonQuery(dsql);
                
                if(basari)
                    return 0;
                else
                    return 2;            
            }
            else
                return 1;    

        }


        /// <summary>
        /// verilen isimli kiþinin mail ve bilgisayar özelliklerini döndürür
        /// </summary>
        /// <param name="isim"></param>
        /// <returns>[0] mail
        /// [1] bilgisayar özelliði
        /// [0] "" ise baþarýsýz iþlem</returns>
        public string[] bilgileriGetir(string isim)
        {
            string sql = "SELECT MAIL, BILGOZELLIK FROM Kullanici WHERE ISIM = '"+isim+"'";
            string[] bilgiler;

            DataSet ds = new DataSet();
            ds = db.fillDataset(sql);

            if (ds.Tables[0].DefaultView.Table.Rows.Count != 0)
            {
                bilgiler = new string[ds.Tables[0].DefaultView.Table.Columns.Count];
                for (int i = 0; i < ds.Tables[0].DefaultView.Table.Columns.Count; i++)
                {
                    if (ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(i) != DBNull.Value)
                        bilgiler[i] = ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(i).ToString();
                    else
                        bilgiler[i] = "";
                }
            }
            else
            {
                bilgiler = new string[1];
                bilgiler[0] = "";
            }

            return bilgiler;
        }


        /// <summary>
        /// verilen isim ve þifre ile yetkilendirme iþlemi yapar
        /// </summary>
        /// <param name="isim"></param>
        /// <param name="sifre"></param>
        /// <returns>giriþ baþarýlý mý</returns>
        public bool giris(string isim, string sifre)
        {
            string sql = "SELECT COUNT(*) FROM Kullanici WHERE (ISIM = '" + isim + "') AND (SIFRE = '" + sifre + "')";

            DataSet ds = new DataSet();

            ds = db.fillDataset(sql);

            if (Convert.ToUInt32(ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(0)) == 1) 
                return true;
            else 
                return false;

        }
    }
}
