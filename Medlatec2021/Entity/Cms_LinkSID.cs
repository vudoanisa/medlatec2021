using System;
using System.Collections.Generic;
using System.Text;
namespace MEDLATEC.BusinessLayer
{
    [Serializable]
    public class Cms_LinkSID
    {
        #region Constructors  
        public Cms_LinkSID() { }
        #endregion
        #region Private Fields  
        private string sid;
        private string place;
        private string La;
        private string token;
        
        #endregion
        #region Public Properties  
        public string sid1 { get { return sid; } set { sid = value; } }
        public string place1 { get { return place; } set { place = value; } }
        public string La1 { get { return La; } set { La = value; } }
        public string token1 { get { return token; } set { token = value; } }
       


        #endregion


    }
}
