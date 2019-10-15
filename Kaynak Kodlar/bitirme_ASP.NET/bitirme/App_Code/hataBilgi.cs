using System;

namespace _hataBilgi
{

    /// <summary>
    /// web servislerde hata bilgilerini temsil edecek nesne
    /// </summary>
    public class hataBilgi
    {
        protected uint id;
        public string projeIsmi;
        public string aciklama;
        public string zaman;

        public hataBilgi()
        {
            id = 0;
            projeIsmi = "";
            aciklama = "";
            zaman = DateTime.MinValue.ToString();
        }

        public hataBilgi(uint id1, string projeIsmi1, string aciklama1, string zaman1)
        {
            id = id1;
            projeIsmi = projeIsmi1;
            aciklama = aciklama1;
            zaman = zaman1;
        }
    }
}