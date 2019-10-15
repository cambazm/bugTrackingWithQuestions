using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using _kullanici;


/// <summary>
/// kullan�c� web servisi i�lemlerini sa�lar
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

    [WebMethod(Description = "Kullan�c� giri�i yapmay� sa�lar")]
    public bool giris(string isim, string sifre)
    {
        return k.giris(isim, sifre);
    }

    [WebMethod(Description = "Verilen isimli kulan�c�n�n id'sini getirir")]
    public uint idGetir(string isim)
    {
        return k.idGetir(isim);
    }

    [WebMethod(Description = "Verilen isimli kulan�c�n�n tipini getirir")]
    public string tipGetir(string isim)
    {
        return k.tipGetir(isim);
    }
}

