using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace _soruBilgi
{
    /// <summary>
    /// web servislerde soru bilgilerini temsil edecek nesne
    /// </summary>
    public class soruBilgi
    {
        public uint id;
        public string soru;
        public string kNot;
        public uint evetId;
        public uint hayirId;
        protected string gNot;
        protected uint oncekiId;

        public soruBilgi()
        {
            id = 0;
            soru = "";
            kNot = "";
            gNot = "";
            evetId = 0;
            hayirId = 0;
        }

        public soruBilgi(uint id1, string soru1)
        {
            id = id1;
            soru = soru1;
            kNot = "";
            gNot = "";
            evetId = 0;
            hayirId = 0;
        }

        public soruBilgi(uint id1, string soru1, string kNot1, uint evetId1, uint hayirId1)
        {
            id = id1;
            soru = soru1;
            kNot = kNot1;
            gNot = "";
            evetId = evetId1;
            hayirId = hayirId1;
        }

        public soruBilgi(uint id1, string soru1, string kNot1, string gNot1, uint evetId1, uint hayirId1)
        {
            id = id1;
            soru = soru1;
            kNot = kNot1;
            gNot = gNot1;
            evetId = evetId1;
            hayirId = hayirId1;
        }

        public soruBilgi(uint id1, string soru1, string kNot1, string gNot1, uint evetId1, uint hayirId1, uint oncekiId1)
        {
            id = id1;
            soru = soru1;
            kNot = kNot1;
            gNot = gNot1;
            evetId = evetId1;
            hayirId = hayirId1;
            oncekiId = oncekiId1;
        }

        public string getgNot()
        {
            return gNot;
        }

        public uint getoncekiId()
        {
            return oncekiId;
        }

        public soruBilgi(soruBilgi right)
        {
            id = right.id;
            soru = right.soru;
            kNot = right.kNot;
            gNot = right.gNot;
            evetId = right.evetId;
            hayirId = right.hayirId;
            oncekiId = right.oncekiId;
        }
    }
}
