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
using _sorumlu;
using System.Data.SqlClient;
using System.Net.Mail;

namespace _hata
{
    /// <summary>
    /// hatalar �zerindeki i�lemleri ger�ekler
    /// </summary>
    public class hata
    {
        vt db;       //veritaban� eri�im ve i�lem nesnesi

        public hata()
        {
            db = new vt();
        }


        //hata g�nderimi
        public string gonder(uint projeId, uint soruId, ArrayList parameterNameList, ArrayList parameterList, uint yollayanId, int cevap)
        {
            string spName = "hataEkle";

            ArrayList parameterNameList1 = new ArrayList(6);
            parameterNameList1.Add("@projeId");
            parameterNameList1.Add("@soruId");
            parameterNameList1.Add("@aciklama");
            parameterNameList1.Add("@simdi");
            parameterNameList1.Add("@yollayanId");
            parameterNameList1.Add("@cevap");
            
            ArrayList parameterList1 = new ArrayList(6);
            parameterList1.Add(projeId);
            parameterList1.Add(soruId);
            parameterList1.Add(parameterList[0]);
            parameterList1.Add(parameterList[1]);
            parameterList1.Add(yollayanId);
            parameterList1.Add(cevap);

            uint hataId = executeStoredProcedure(spName, parameterNameList1, parameterList1);

            sorumlu s = new sorumlu();
            uint sonuc = s.bildir(hataId, projeId);

            if (hataId == 0)
                return "Hata g�nderme i�lemi ba�ar�s�z";
            else if (sonuc == 0 || sonuc == 1)
                return "Hata ba�ar�yla g�nderildi, te�ekk�rler";
            else
                return "Hata eklendi ama SMTP sunucusunda sorun var";
        }


        //verilen proje id si ile ilgili t�m hatalar� �zet bilgilerle d�nd�r�r
        public DataSet projeyeAitHatalar(uint projeId)
        {
            string sql = "SELECT Hata.ID AS [��lem], Proje.ISIM AS Proje, Hata.ACIKLAMA AS HATA, Hata.ZAMAN AS [Yollanma zaman�] FROM Hata INNER JOIN Proje ON Hata.PROJEID = Proje.ID WHERE (Proje.ID = " + projeId + ") AND (Hata.COZUMONAY = 0)";

            return db.fillDataset(sql);
        }


        //verilen proje id si ile ilgili �imdiye kadar ��z�lm�� hatalar� �zet bilgilerle d�nd�r�r
        public DataSet projeyeAitCozulmusHatalar(uint projeId)
        {
            string sql = "SELECT Hata.ID AS [��lem], Proje.ISIM AS Proje, Hata.ACIKLAMA AS HATA, Hata.COZUM AS [��z�m], Hata.ZAMAN AS [Yollanma zaman�] FROM Hata INNER JOIN Proje ON Hata.PROJEID = Proje.ID WHERE (Proje.ID = " + projeId + ") AND (Hata.COZUMONAY = 1)";

            return db.fillDataset(sql);
        }
        

        //verilen hata id li hata hakk�nda ayr�nt�l� bilgileri d�nd�r�r
        public DataSet Incele(uint hataId)
        {
            string sql = "SELECT Proje.ISIM AS Proje, Hata.ACIKLAMA AS HATA, Hata.COZUM AS [��z�m], Kullanici.ISIM AS Yollayan, KTip.TIP AS [Kullan�c� Tipi], Hata.ZAMAN AS [Yollanma zaman�], Soru.GELISTIRICINOT AS [Geli�tiriciye Not], Soru.KULLANICINOT AS [Kullan�c�ya Not], Soru.SORU AS [Son soru], Hata.CEVAP AS Cevap, Kullanici.BILGOZELLIK AS [Hatan�n bulundu�u bilgisayar] FROM Hata CROSS JOIN KTip INNER JOIN Kullanici ON Hata.YOLLAYANID = Kullanici.ID AND KTip.ID = Kullanici.TIPID INNER JOIN Proje ON Hata.PROJEID = Proje.ID INNER JOIN Soru ON Hata.SONSORUID = Soru.ID WHERE Hata.ID = " + hataId;

            return db.fillDataset(sql);
        }


        //verilen hata id li hata hakk�ndaki konu�malar� d�nd�r�r
        public DataSet konusmalariGetir(uint hataId)
        {
            string sql = "SELECT Konusma.MESAJ AS Mesaj, Kullanici.ISIM AS Yollayan, KTip.TIP AS [Kullan�c� Tipi], Konusma.ZAMAN AS [Yollama Zaman�] FROM Konusma INNER JOIN Kullanici ON Konusma.YOLLAYANID = Kullanici.ID INNER JOIN KTip ON Kullanici.TIPID = KTip.ID WHERE Konusma.HATAID = " + hataId;

            return db.fillDataset(sql);
        }


        //verilen hata id li hata hakk�nda konu�ma ekler
        public bool konusmaEkle(uint hataId, uint yollayanId, ArrayList parameterList, ArrayList parameterNameList)
        {
            //yollayan ki�i �imdilik varsay�lan ki�i
            string sql = "INSERT INTO Konusma (HATAID, YOLLAYANID, MESAJ, ZAMAN) VALUES (" + hataId + ", " + yollayanId;

            //parametre isimlerini sql c�mleci�ine ekle
            for (int i = 0; i < parameterNameList.Count; i++)
                sql += ", " + parameterNameList[i];

            sql += ")";

            return db.executeNonQuery(sql, parameterNameList, parameterList);

        }


        //verilen hata id li hataya bir ��z�m ekle
        public string cozumEkle(uint hataId, ArrayList parameterNameList, ArrayList parameterList)
        {
            string sql = "UPDATE Hata SET COZUM = ";
            
            for (int i = 0; i < parameterNameList.Count; i++)
                sql += parameterNameList[i].ToString(); 

            sql += " WHERE ID = " + hataId;


            bool basarili = db.executeNonQuery(sql, parameterNameList, parameterList);

            if (!basarili)
                return "��z�m ekleme ba�ar�s�z.";
            else
            {
                string sqls = "SELECT Kullanici.MAIL FROM Kullanici INNER JOIN Hata ON Hata.YOLLAYANID = Kullanici.ID WHERE Hata.ID = " + hataId;

                DataSet ds = new DataSet();
                ds = db.fillDataset(sqls);
                uint sonuc = 0;

                try
                {
                    string fromEmail = "haberci@hatatakip.com";
                    string fromName = "Hata Takip Yaz�l�m�";
                    string mail = "G�ndermi� oldu�unuz bir hataya ��z�m eklendi. L�tfen kontrol ediniz.<br><br><a href=\"http://localhost/1/Incele.aspx?id=" + hataId + "\" target=\"_blank\">Buradan</a> hatan�za eri�ebilirsiniz.";
                    mail += "<br><a href=\"http://localhost/1/hataOnay.aspx\" target=\"_blank\">Buradan</a> da hata ��z�m�ne onay verebilirsiniz.";
                    mail += "<br><br>Hata Takip Yaz�l�m� (2006)";

                    SmtpClient smtpClient = new SmtpClient();
                    MailMessage message = new MailMessage();
                    MailAddress fromAddress = new MailAddress(fromEmail, fromName);

                    smtpClient.Host = "160.75.96.32";
                    smtpClient.Port = 25;
                    message.From = fromAddress;

                    if (ds.Tables[0].DefaultView.Table.Rows.Count != 0)                        
                            message.To.Add(ds.Tables[0].DefaultView.Table.Rows[0].ItemArray.GetValue(0).ToString());
                    else
                        sonuc = 1;

                    message.Subject = "Hataya ��z�m eklendi";
                    message.IsBodyHtml = true;
                    message.Body = mail;
                    smtpClient.Send(message);

                    sonuc = 0;
                }
                catch (Exception ex)
                {
                    string hata = ex.ToString();
                    sonuc = 2;
                }

                return "��z�m ba�ar�yla eklendi";
            }
        }


        //ki�inin yollad��� ve bir ��z�m eklenmi� onaylanabilir hatalar� d�nd�r�r
        public DataSet onaylanabilirHatalar(uint yollayanId)
        {
            string sql = "SELECT Hata.ID, Hata.ACIKLAMA AS HATA, Hata.COZUM AS [��z�m], Proje.ISIM AS [Proje] FROM Hata INNER JOIN Kullanici ON Hata.YOLLAYANID = Kullanici.ID INNER JOIN Proje ON Hata.PROJEID = Proje.ID WHERE (Kullanici.ID = " + yollayanId + ") AND (Hata.COZUMONAY = 0) AND (Hata.COZUM IS NOT NULL)";

            return db.fillDataset(sql);
        }


        //verilen hata id li hatan�n ��z�m�n� onaylar
        public string onayla(uint hataId)
        {
            string sql = "UPDATE Hata SET COZUMONAY = 1 WHERE ID = " + hataId;

            bool basarili = db.executeNonQuery(sql);

            if (!basarili)
                return "��lem ba�ar�s�z.";
            else
                return "Onayland�";
        }


        public uint[] hatalarim(uint id)
        {
            uint[] hatalar;
            string sql = "SELECT ID FROM Hata WHERE YOLLAYANID = " + id;

            DataSet ds = new DataSet();

            ds = db.fillDataset(sql);

            if (ds.Tables[0].DefaultView.Table.Rows.Count != 0)
            {
                hatalar = new uint[ds.Tables[0].DefaultView.Table.Rows.Count];
                
                for(int i=0; i<ds.Tables[0].DefaultView.Table.Rows.Count; i++)
                    hatalar[i] = Convert.ToUInt32(ds.Tables[0].DefaultView.Table.Rows[i].ItemArray.GetValue(0));

            }
            else
            {
                hatalar = new uint[1];
                hatalar[0] = 0;
            }
            
            return hatalar;
        }



        //verilen isme sahip stored procedure (sakl� yordam) y�r�t�r
        private uint executeStoredProcedure(string storedProcedureName, ArrayList parameterNameList, ArrayList parameterList)
        {
            uint returnValue;

            ConnectionStringSettings settings;
            settings = ConfigurationManager.ConnectionStrings["HataTakipConnectionString"];
            string cs = settings.ConnectionString;
            
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(storedProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter returnValueP = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            returnValueP.Direction = ParameterDirection.ReturnValue;


            SqlParameter p1 = new SqlParameter(parameterNameList[0].ToString(), SqlDbType.Int);
            p1.Value = parameterList[0];
            cmd.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter(parameterNameList[1].ToString(), SqlDbType.Int);
            p2.Value = parameterList[1];
            cmd.Parameters.Add(p2);

            SqlParameter p3 = new SqlParameter(parameterNameList[2].ToString(), SqlDbType.NVarChar);
            p3.Value = parameterList[2];
            cmd.Parameters.Add(p3);

            SqlParameter p4 = new SqlParameter(parameterNameList[3].ToString(), SqlDbType.DateTime);
            p4.Value = parameterList[3];
            cmd.Parameters.Add(p4);

            SqlParameter p5 = new SqlParameter(parameterNameList[4].ToString(), SqlDbType.Int);
            p5.Value = parameterList[4];
            cmd.Parameters.Add(p5);

            SqlParameter p6 = new SqlParameter(parameterNameList[5].ToString(), SqlDbType.Int);
            p6.Value = parameterList[5];
            cmd.Parameters.Add(p6);


            cmd.Parameters.Add(returnValueP);

            try
            {
                con.Open();

                //stored procedure � �al��t�r�r
                cmd.ExecuteNonQuery();

                //d�n�� de�erini okur
                returnValue = Convert.ToUInt32(returnValueP.Value);

                con.Close();
            }
            catch(Exception ex)
            {
                string hata = ex.ToString();
                returnValue = 0;
            }

            return returnValue;
        }
    }
}
