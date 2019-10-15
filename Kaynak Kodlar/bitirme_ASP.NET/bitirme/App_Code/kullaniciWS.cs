using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using _kullanici;


/// <summary>
/// kullanýcý web servisi iþlemlerini saðlar
/// </summary>
[WebService(Namespace = "http://localhost/kullaniciWS/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class kullaniciWS : System.Web.Services.WebService 
{
    kullanici k;

    public kullaniciWS () 
    {
        k = new kullanici();
    }

    [WebMethod(Description = "Kullanýcý giriþi yapmayý saðlar")]
    public bool giris(string isim, string sifre)
    {
        return k.giris(isim, sifre);
    }

    [WebMethod(Description = "Verilen isimli kulanýcýnýn id'sini getirir")]
    public uint idGetir(string isim)
    {
        return k.idGetir(isim);
    }

    [WebMethod(Description = "Verilen isimli kulanýcýnýn tipini getirir")]
    public string tipGetir(string isim)
    {
        return k.tipGetir(isim);
    }
}

