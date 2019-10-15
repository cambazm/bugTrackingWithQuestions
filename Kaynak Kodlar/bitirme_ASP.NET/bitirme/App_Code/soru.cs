using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using _vt;
using _soruBilgi;

/// <summary>
/// sorular üzerindeki iþlemleri gerçekler
/// </summary>
namespace _soru
{
    public class soru
    {
        vt db;


        public soru()
        {
            db = new vt();
        }


        /// <summary>
        /// verilen proje id sine sahip verilen parametre adlarý ve parametreler ile soru ekler
        /// </summary>
        /// <param name="projeId"></param>
        /// <param name="parameterNameList"></param>
        /// <param name="parameterList"></param>
        /// <returns></returns>

        public bool ekle(uint projeId, ArrayList parameterNameList, ArrayList parameterList)
        {
            bool basarili = false;

            string sql = "INSERT INTO Soru (PROJEID, SORU, KULLANICINOT, GELISTIRICINOT) VALUES (" + projeId;
            
            for (int i = 0; i < parameterNameList.Count; i++)
                sql += ", " + parameterNameList[i];
            
            sql += ")";

            basarili = db.executeNonQuery(sql, parameterNameList, parameterList);

            return basarili;
        }


        /// <summary>
        /// sorulacak soru için yer ayýrarak ayýrdýðý sorunun idsini döndürür
        /// </summary>
        /// <param name="projeId"></param>
        /// <param name="oncekiId"></param>
        /// <returns></returns>
        public uint ekle(uint projeId, uint oncekiId)
        {
            string spName = "soruIcinYerAyir";

            ArrayList parameterNameList = new ArrayList(2);
            parameterNameList.Add("@projeId");
            parameterNameList.Add("@oncekiId");           

            ArrayList parameterList = new ArrayList(2);
            parameterList.Add(projeId);
            parameterList.Add(oncekiId);

            uint id = db.executeStoredProcedure(spName, parameterNameList, parameterList);

            return id;
        }


        /// <summary>
        /// verilen id li soruyu günceller
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameterNameList"></param>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        public bool duzenle(uint id, ArrayList parameterNameList, ArrayList parameterList)
        {
            bool basarili = false;

            string sql = "UPDATE Soru SET SORU = ";
            sql += parameterNameList[0];
            sql += ", GELISTIRICINOT = " + parameterNameList[1];
            sql += ", KULLANICINOT = " + parameterNameList[2];
            sql += " WHERE ID = " + id;
            
            basarili = db.executeNonQuery(sql, parameterNameList, parameterList);

            return basarili;

        }


        /// <summary>
        /// verilen id li sorunun sonraki sorularýný düzenler
        /// </summary>
        /// <param name="id"></param>
        /// <param name="evetId"></param>
        /// <param name="hayirId"></param>
        /// <returns></returns>
        public bool duzenle(uint id, uint evetId, uint hayirId)
        {
            bool basarili = false;

            string sql = "UPDATE Soru SET EVETID = " + evetId;

            sql += ", HAYIRID = " + hayirId;

            sql += " WHERE ID = " + id;

            basarili = db.executeNonQuery(sql);

            return basarili;
        }


        /// <summary>
        /// verilen id li sorunun evet-sonraki sorusunu düzenler
        /// </summary>
        /// <param name="id"></param>
        /// <param name="evetId"></param>
        /// <returns></returns>
        public bool duzenleE(uint id, uint evetId)
        {
            bool basarili = false;

            string sql = "UPDATE Soru SET EVETID = " + evetId;

            sql += " WHERE ID = " + id;

            basarili = db.executeNonQuery(sql);

            return basarili;
        }


        /// <summary>
        /// verilen id li sorunun hayýr-sonraki sorusunu düzenler
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hayirId"></param>
        /// <returns></returns>
        public bool duzenleH(uint id, uint hayirId)
        {
            bool basarili = false;

            string sql = "UPDATE Soru SET HAYIRID = " + hayirId;

            sql += " WHERE ID = " + id;

            basarili = db.executeNonQuery(sql);

            return basarili;
        }


        //projeye hata gönderileceði zaman ilk soruyu getirir
        /// <summary>
        /// verilen proje id li projenin ilk sorusunu getirir
        /// </summary>
        /// <param name="projeId"></param>
        /// <returns></returns>
        public DataSet ilkSoru(uint projeId)
        {
            string selectSql = "SELECT Proje.ID, Proje.ISIM, Proje.TUR, Soru.PROJEID, Soru.SORU, Soru.GELISTIRICINOT, Soru.KULLANICINOT FROM Proje,Soru WHERE (Soru.PROJEID = " + projeId + " AND Proje.ID=Soru.PROJEID)";
            string sql = "SELECT SORU, KULLANICINOT, ID, EVETID, HAYIRID FROM Soru WHERE ONCEKIID=0 AND PROJEID=" + projeId;

            DataSet ds = new DataSet();

            //proje ile ilgili soru var mý?
            ds = db.fillDataset(selectSql);

            //proje ile ilgili soru var
            if (ds.Tables[0].DefaultView.Count != 0)
            {
                ds = db.fillDataset(sql);

                return ds;
            }
            //proje ile ilgili soru yok, boþ dataset döndür
            else
            {
                DataSet bosDs = new DataSet();

                return bosDs;
            }
        }


        /// <summary>
        /// verilen soru id li yeni soruyu getirir
        /// </summary>
        /// <param name="soruId"></param>
        /// <returns></returns>
        public DataSet sonraki(uint soruId)
        {
            DataSet ds = new DataSet();
            //string sql = "SELECT EVETID FROM Soru WHERE (ID = " + soruId + ")";
            string sql = "SELECT SORU, KULLANICINOT, ID, EVETID, HAYIRID FROM Soru WHERE (ID=" + soruId + ")";

            ds = db.fillDataset(sql);

            return ds;
        }


        /// <summary>
        /// verilen idli soruyu getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public soruBilgi getir(uint id)
        {
            soruBilgi soruB;
            DataSet ds = new DataSet();

            string sql = "SELECT SORU, KULLANICINOT, GELISTIRICINOT, ID, EVETID, HAYIRID, ONCEKIID FROM Soru WHERE (ID=" + id + ")";

            ds = db.fillDataset(sql);

            if (ds.Tables.Count != 0)
            {
                string soru1 = ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(0).ToString();
                string knot1 = ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(1).ToString();
                string gnot1 = ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(2).ToString();
                uint id1 = Convert.ToUInt32(ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(3));
                uint evetid1 = Convert.ToUInt32(ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(4));
                uint hayirid1 = Convert.ToUInt32(ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(5));
                uint oncekiId1 = Convert.ToUInt32(ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(6));

                soruB = new soruBilgi(id1, soru1, knot1, gnot1, evetid1, hayirid1, oncekiId1);
            }
            else
                soruB = new soruBilgi();

            return soruB;
        }


        /// <summary>
        /// verilen proje idli projenin mevcut tüm sorularýný listeler
        /// </summary>
        /// <param name="projeId"></param>
        /// <returns></returns>
        public ArrayList listele(uint projeId)
        {
            DataSet ds = new DataSet();
            ArrayList sorular;

            string sql = "SELECT SORU, KULLANICINOT, GELISTIRICINOT, ID, EVETID, HAYIRID, ONCEKIID FROM Soru WHERE (PROJEID=" + projeId + ")";

            ds = db.fillDataset(sql);

            if (ds.Tables.Count != 0)
            {
                sorular = new ArrayList(ds.Tables[0].DefaultView.Table.Rows.Count);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string soru1 = ds.Tables[0].DefaultView.Table.Rows[i].ItemArray.GetValue(0).ToString();
                    string knot1 = ds.Tables[0].DefaultView.Table.Rows[i].ItemArray.GetValue(1).ToString();
                    string gnot1 = ds.Tables[0].DefaultView.Table.Rows[i].ItemArray.GetValue(2).ToString();
                    uint id1 = Convert.ToUInt32(ds.Tables[0].DefaultView.Table.Rows[i].ItemArray.GetValue(3));
                    uint evetid1 = Convert.ToUInt32(ds.Tables[0].DefaultView.Table.Rows[i].ItemArray.GetValue(4));
                    uint hayirid1 = Convert.ToUInt32(ds.Tables[0].DefaultView.Table.Rows[i].ItemArray.GetValue(5));
                    uint oncekiid1 = Convert.ToUInt32(ds.Tables[0].DefaultView.Table.Rows[i].ItemArray.GetValue(6));

                    soruBilgi soruB = new soruBilgi(id1, soru1, knot1, gnot1, evetid1, hayirid1, oncekiid1);

                    sorular.Add(soruB);
                }
            }
            else
            {
                sorular = new ArrayList();
                //soruBilgi soru1 = new soruBilgi();
                //sorular.Add(soru1);
            }

            return sorular;
        }

        public ArrayList listele(uint projeId, bool sade)
        {
            DataSet ds = new DataSet();
            ArrayList sorular;

            string sql = "SELECT SORU, ID FROM Soru WHERE (PROJEID=" + projeId + ")";

            ds = db.fillDataset(sql);

            if (ds.Tables.Count != 0)
            {
                sorular = new ArrayList(ds.Tables[0].DefaultView.Table.Rows.Count);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string soru1 = ds.Tables[0].DefaultView.Table.Rows[i].ItemArray.GetValue(0).ToString();
                    uint id1 = Convert.ToUInt32(ds.Tables[0].DefaultView.Table.Rows[i].ItemArray.GetValue(1));

                    soruBilgi soruB = new soruBilgi(id1, soru1);

                    sorular.Add(soruB);
                }
            }
            else
            {
                sorular = new ArrayList();
                //soruBilgi soru1 = new soruBilgi();
                //sorular.Add(soru1);
            }

            return sorular;
        }



        /// <summary>
        /// verilen id li soruyu siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool sil(uint id)
        {
            soruBilgi soruB = getir(id);

            uint oncekiId = soruB.getoncekiId();

            string oncekiniDuzeltSql1 = "UPDATE Soru SET EVETID = 0 WHERE ID = " + oncekiId + " AND EVETID = " + id;
            string oncekiniDuzeltSql2 = "UPDATE Soru SET HAYIRID = 0 WHERE ID = " + oncekiId + " AND HAYIRID = " + id;

            db.executeNonQuery(oncekiniDuzeltSql1);
            db.executeNonQuery(oncekiniDuzeltSql2);

            string soruyuSilSql = "DELETE FROM Soru WHERE ID = "+id;

            return db.executeNonQuery(soruyuSilSql);
        }


    }
}