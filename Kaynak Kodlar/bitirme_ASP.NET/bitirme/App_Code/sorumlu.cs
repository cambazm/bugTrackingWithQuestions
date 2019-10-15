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
using _proje;
using System.Net.Mail;

namespace _sorumlu
{
    /// <summary>
    /// sorumlular üzerindeki iþlemleri gerçekler
    /// </summary>
    public class sorumlu
    {
        vt db;

        public sorumlu()
        {
            db = new vt();
        }


        //tüm sorumlu kiþileri döndür
        public DataSet sorumluListesi()
        {
            string sql = "SELECT Kullanici.ISIM, Kullanici.ID FROM KTip INNER JOIN Kullanici ON KTip.ID = Kullanici.TIPID WHERE (KTip.TIP = 'sorumlu')";

            return db.fillDataset(sql);
        }



        //ilgili projeye ait sorumlu kiþi belirler
        public string belirle(uint projeId, uint sorumluId, string projeIsim, string sorumluIsim)
        {
            DataSet ds = new DataSet();
            string sql = "INSERT INTO ProjeSorumlusu (PROJEID, SORUMLUID) VALUES (" + projeId + "," + sorumluId + ")";
            string selectSql = "SELECT * FROM ProjeSorumlusu WHERE (PROJEID = " + projeId + " ) AND (SORUMLUID = " + sorumluId + " )";

            ds = db.fillDataset(selectSql);

            //kiþi daha önce sorumlu olarak belirlenmiþse belirt
            if (ds.Tables[0].DefaultView.Count > 0)
                return "Bu kiþi bu projeden daha önce sorumlu olarak belirlenmiþ";
            else
            {
                bool basarili = db.executeNonQuery(sql);

                if (!basarili)
                    return "Ekleme iþlemi baþarýsýz";
                else
                    return "<b>" + sorumluIsim + "</b>, \"" + projeIsim + "\" projesinden sorumlu olarak belirlendi";
            }
        }


        //verilen hata id li hatadan sorumlu kiþi atar
        public string ata(uint hataId, uint sorumluId, string sorumluIsim)
        {
            DataSet ds = new DataSet();
            string sql = "INSERT INTO HataSorumlusu (HATAID, SORUMLUID) VALUES (" + hataId + "," + sorumluId + ")";
            string selectSql = "SELECT * FROM HataSorumlusu WHERE (SORUMLUID = " + sorumluId + " ) AND (HATAID = " + hataId + " )";

            ds = db.fillDataset(selectSql);

            if (ds.Tables[0].DefaultView.Count > 0)
                return "Bu kiþi bu hatadan daha önce sorumlu olarak belirlenmiþ";
            else
            {
                bool basarili = db.executeNonQuery(sql);

                if (!basarili)
                    return "Atama iþlemi baþarýsýz";
                else
                    return "<b>" + sorumluIsim + "</b>, hatadan sorumlu olarak belirlendi";

            }
        }


        /// <summary>
        /// projeden sorumlu kiþilere yeni bir ahat geldiðinde mail ile bildirim yapar
        /// </summary>
        /// <param name="hataId"></param>
        /// <param name="projeId"></param>
        /// <returns>0: baþarýlý
        /// 1: sorumlu kimse yok
        /// 2: exception</returns>
        public uint bildir(uint hataId, uint projeId)
        {
            string sql = "SELECT DISTINCT Kullanici.MAIL FROM KTip INNER JOIN Kullanici ON KTip.ID = Kullanici.TIPID INNER JOIN ProjeSorumlusu ON Kullanici.ID = ProjeSorumlusu.SORUMLUID INNER JOIN Proje ON Proje.ID = ProjeSorumlusu.PROJEID WHERE KTip.TIP = 'sorumlu' AND Proje.ID = "+projeId;
            
            proje p = new proje();
            string projeIsmi = p.isimGetir(projeId);
            
            DataSet ds = new DataSet();
            ds = db.fillDataset(sql);

            uint sonuc = 0;

            try
            {
                string fromEmail = "haberci@hatatakip.com";
                string fromName = "Hata Takip Yazýlýmý";
                string mail = projeIsmi+" projesine yeni bir hata eklendi.<br><br><a href=\"http://localhost/1/Incele.aspx?id="+hataId+"\" target=\"_blank\">Buradan</a> eriþebilirsiniz.";
                mail += "<br><br>Hata Takip Yazýlýmý (2006)";

                SmtpClient smtpClient = new SmtpClient();
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress(fromEmail, fromName);

                smtpClient.Host = "160.75.96.32";
                smtpClient.Port = 25;
                message.From = fromAddress;

                if (ds.Tables[0].DefaultView.Table.Rows.Count != 0)
                    for (int i = 0; i < ds.Tables[0].DefaultView.Table.Rows.Count; i++)
                        message.To.Add(ds.Tables[0].DefaultView.Table.Rows[i].ItemArray.GetValue(0).ToString());
                else
                {
                    sonuc = 1;
                    return sonuc;
                }
                message.Subject = "Yeni bir hata var ("+projeIsmi+")";
                message.IsBodyHtml = true;
                message.Body = mail;
                smtpClient.Send(message);

                sonuc = 0;
            }
            catch(Exception ex)
            {
                string hata = ex.ToString();
                sonuc = 2;
            }

            return sonuc;
        }


        /// <summary>
        /// hatadan sorumlu atanan kiþiye mail ile bildirim yapar
        /// </summary>
        /// <param name="hataId"></param>
        /// <param name="sorumluId"></param>
        /// <returns></returns>
        public uint atamaBildir(uint hataId, uint sorumluId)
        {
            string sql = "SELECT DISTINCT Kullanici.MAIL FROM KTip INNER JOIN Kullanici ON KTip.ID = Kullanici.TIPID INNER JOIN HataSorumlusu ON HataSorumlusu.SORUMLUID = Kullanici.ID WHERE KTip.TIP = 'sorumlu' AND Kullanici.ID = " + sorumluId;

            DataSet ds = new DataSet();
            ds = db.fillDataset(sql);

            uint sonuc = 0;

            try
            {
                string fromEmail = "haberci@hatatakip.com";
                string fromName = "Hata Takip Yazýlýmý";
                string mail = "Bir hatadan sorumlu olarak belirlendiniz.<br><br><a href=\"http://localhost/1/Incele.aspx?id=" + hataId + "\" target=\"_blank\">Buradan</a> eriþebilirsiniz.";
                mail += "<br><br>Hata Takip Yazýlýmý (2006)";

                SmtpClient smtpClient = new SmtpClient();
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress(fromEmail, fromName);

                smtpClient.Host = "160.75.96.32";
                smtpClient.Port = 25;
                message.From = fromAddress;

                if (ds.Tables[0].DefaultView.Table.Rows.Count != 0)
                    for (int i = 0; i < ds.Tables[0].DefaultView.Table.Rows.Count; i++)
                        message.To.Add(ds.Tables[0].DefaultView.Table.Rows[i].ItemArray.GetValue(0).ToString());
                else
                    sonuc = 1;

                message.Subject = "Bir hatadan sorumlu olarak atandýnýz";
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

            return sonuc;        
        }


        public DataSet projeSorumlulari()
        {
            string sql = "SELECT Kullanici.ISIM AS Sorumlu, Proje.ISIM AS Proje FROM Proje INNER JOIN ProjeSorumlusu ON Proje.ID = ProjeSorumlusu.PROJEID INNER JOIN Kullanici ON ProjeSorumlusu.SORUMLUID = Kullanici.ID";

            return db.fillDataset(sql);
        }


        public DataSet hataSorumlulari()
        {
            string sql = "SELECT Kullanici.ISIM AS Sorumlu, HataSorumlusu.HATAID AS Hata FROM Kullanici INNER JOIN HataSorumlusu ON Kullanici.ID = HataSorumlusu.SORUMLUID";

            return db.fillDataset(sql);
        }
    }
}
